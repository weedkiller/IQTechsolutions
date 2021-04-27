using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Filing.Base.Entities;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Filing.Core.Factories;
using Grouping.Base.Entities;
using Iqt.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using Products.Base.Entities;
using Products.Core.Models;

namespace Products.Core.Context.Services
{
    public class ProductContext
    {
        #region Private Members

        private readonly IFileFactory _factory;
        private readonly DbContext _context;

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// The Default Constructor
        /// </summary>
        /// <param name="context">The injected database context</param>
        /// <param name="fileFactory">The injected file factory</param>
        public ProductContext(DbContext context, IFileFactory fileFactory)
        {
            _factory = fileFactory;
            _context = (DbContext) context;
        }

        #endregion

        #region Add Product

        public IQueryable<Product> GetAll()
        {
            var bb = _context.Set<Product>().Include(c => c.Images);
            return bb;
        }

        public async Task<Product> GetAsync(string id)
        {
            return await GetAll().FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Adds a specific product
        /// </summary>
        /// <param name="model">The model to be added from</param>
        /// <returns>The product that was added</returns>
        public async Task<Product> AddAsync(ProductAddEditModel model)
        {

            //await model.Entity.Images.AddImages(model.ImagesUpload, new Size(600,400));
            await _context.Set<Product>().AddAsync(model.Entity);

            var cover = await _factory.UploadImageAndSaveToDbAsync<Product>(model.CoverUpload, null, "images/uploads/products/covers", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);
            var banner = await _factory.UploadImageAndSaveToDbAsync<Product>(model.BannerUpload, null, "images/uploads/products/banners", ImageType.Banner, new Point(Convert.ToInt16(model.BannerCropSettings.X), Convert.ToInt16(model.BannerCropSettings.Y)), new Size(Convert.ToInt16(model.BannerCropSettings.Width), Convert.ToInt16(model.BannerCropSettings.Height)), model.Entity.Id, true);

            if (model.ImagesUpload != null && model.ImagesUpload.Any())
            {

                foreach (var item in model.ImagesUpload)
                {
                    var image = await _factory.UploadImageAndSaveToDbAsync<Product>(item, null, "images/uploads/products/images", ImageType.Image, new Point(0,0), new Size(870, 260), model.Entity.Id);
                }
            }

            if (model.SliderUpload != null)
            {
                var image = await _factory.UploadImageAndSaveToDbAsync<Product>(model.SliderUpload, null, "images/uploads/products/images", ImageType.Slider, new Point(0, 0), new Size(550, 370), model.Entity.Id, true);
            }

            foreach (var item in model.AvailableCategories)
            {
                if (item.IsSelected)
                {
                    _context.Set<EntityCategory<Product>>().Add(new EntityCategory<Product>(model.Entity.Id, item.Identity));
                }
                else
                {
                    var existingEntity = await _context.Set<EntityCategory<Product>>().Where(c => c.EntityId == model.Entity.Id).FirstOrDefaultAsync(c => c.CategoryId == item.Identity);
                    if (existingEntity != null)
                    {
                        _context.Set<EntityCategory<Product>>().Remove(existingEntity);
                    }
                }
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
            return model.Entity;
        }

        #endregion

        #region Update Product

        /// <summary>
        /// Update a specific product
        /// </summary>
        /// <param name="model">The model to be updated from</param>
        /// <returns>The product that was updated</returns>
        public async Task<Product> UpdateAsync(ProductAddEditModel model)
        {
            _context.Set<Product>().Update(model.Entity);

            var cover = await _factory.UploadImageAndSaveToDbAsync<Product>(model.CoverUpload, model.Entity.GetImage()?.Id, "images/uploads/products/covers", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);
            var banner = await _factory.UploadImageAndSaveToDbAsync<Product>(model.BannerUpload, model.Entity.GetImage(ImageType.Banner)?.Id, "images/uploads/products/banners", ImageType.Banner, new Point(Convert.ToInt16(model.BannerCropSettings.X), Convert.ToInt16(model.BannerCropSettings.Y)), new Size(Convert.ToInt16(model.BannerCropSettings.Width), Convert.ToInt16(model.BannerCropSettings.Height)), model.Entity.Id);

            if (model.ImagesUpload != null && model.ImagesUpload.Any())
            {
              
                foreach (var item in model.ImagesUpload)
                {
                    var image = await _factory.UploadImageAndSaveToDbAsync<Product>(item, null, "images/uploads/products/images", ImageType.Image, new Point( 0,0), new Size(870, 260), model.Entity.Id);
                }
            }

            if (model.SliderUpload != null)
            {
                var image = await _factory.UploadImageAndSaveToDbAsync<Product>(model.SliderUpload, null, "images/uploads/products/sliders", ImageType.Image, new Point(0, 0), new Size(870, 260), model.Entity.Id);
                
            }

            foreach (var item in model.AvailableCategories)
            {
                var existingEntity = _context.Set<EntityCategory<Product>>()
                    .Where(c => c.EntityId == model.Entity.Id).FirstOrDefault(c => c.CategoryId == item.Identity);
                if (item.IsSelected)
                {
                    if (existingEntity == null)
                    {
                        _context.Set<EntityCategory<Product>>().Add(new EntityCategory<Product>(model.Entity.Id, item.Identity));
                    }
                }
                else
                {
                    if (existingEntity != null)
                    {
                        _context.Set<EntityCategory<Product>>().Remove(existingEntity);
                    }
                }
                await _context.SaveChangesAsync();
            }

            return model.Entity;
        }

        #endregion

        #region Delete Product

        /// <summary>
        /// Update a specific product
        /// </summary>
        /// <param name="id">The identity of the entity to be deleted</param>
        /// <returns>The product that was deleted</returns>
        public async Task<Product> DeleteAsync(string id)
        {
            // Gets the product to be deleted
            var product = await GetAsync(id);

            foreach (var item in product.Images)
            {
                await _factory.DeleteImageAndRemoveFormDbAsync(item);
            }
            foreach (var item in product.Categories)
            {
                _context.Set<EntityCategory<Product>>().Remove(item);
            }
            foreach (var item in product.Combos)
            {
                _context.Set<ComboCategory<Product>>().Remove(item);
            }
            foreach (var item in product.Exclusions)
            {
                _context.Set<ComboExclusions<Product>>().Remove(item);
            }
            foreach (var item in product.IncludedProducts)
            {
                _context.Set<IncludedProduct<Product>>().Remove(item);
            }
            foreach (var item in product.OptionalProducts)
            {
                _context.Set<OptionalProduct<Product>>().Remove(item);
            }
            

            _context.Set<Product>().Remove(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            

            return product;
        }

        #endregion

        #region Brands

        public IQueryable<Brand> GetAllBrands()
        {
            return _context.Set<Brand>();
        }

        #endregion

        #region Categories

        public IQueryable<Category<Product>> GetAllCategories()
        {
            return _context.Set<Category<Product>>();
        }
        public IQueryable<Category<Product>> GetAllParentCategories()
        {
            return _context.Set<Category<Product>>().Where(c => c.ParentCategoryId == null);
        }

        #endregion

        public async Task RemoveImage(string id)
        {
            var addintional = _context.Set<ImageFile<Product>>().FirstOrDefault(c => c.Id == id);
            
            await _factory.DeleteImageAndRemoveFormDbAsync(addintional); 
        }
        
        /// <summary>
        /// Gets the previous entry
        /// </summary>
        /// <param name="current">The current entity</param>
        /// <returns>the previous entry if this is not the first entry otherwise it returns the first entry</returns>
        public async Task<Product> GetPreviousAsync(Product current)
        {
            var entityList = await GetAll().ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index > 0 ? entityList[index - 1] : null;
        }

        public async Task<Product> GetNextAsync(Product current)
        {
            var entityList = await GetAll().ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index < entityList.Count - 1 ? entityList[index + 1] : null;
        }

    }
}
