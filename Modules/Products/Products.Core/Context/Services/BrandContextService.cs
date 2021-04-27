using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Filing.Core.Factories;
using Microsoft.EntityFrameworkCore;
using Products.Base.Entities;
using Products.Core.Models;

namespace Products.Core.Context.Services
{
    /// <summary>
    /// The context service that manages blog details in the database
    /// </summary>
    public class BrandContext
    {
        private readonly IFileFactory _factory;
        private readonly DbContext _context;

        public BrandContext(DbContext context, IFileFactory factory) 
        {
            _factory = factory;
            _context = (DbContext) context;
        }

        #region GetAll

        public IQueryable<Brand> GetAll()
        {
            return _context.Set<Brand>();
        }

        public async Task<Brand> GetAsync(string id)
        {
            return await _context.Set<Brand>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Brand> GetPreviousAsync(Brand current)
        {
            var entityList = await GetAll().ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index > 0 ? entityList[index - 1] : null;
        }

        public async Task<Brand> GetNextAsync(Brand current)
        {
            var entityList = await GetAll().ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index < entityList.Count - 1 ? entityList[index + 1] : null;
        }

        #endregion

        #region Update Service

        /// <summary>
        /// Update a specific service
        /// </summary>
        /// <param name="model">The model to be updated from</param>
        /// <returns>The updated service</returns>
        public async Task<Brand> UpdateAsync(BrandAddEditModel model)
        {
            var entity = await _context.Set<Brand>().FirstOrDefaultAsync(c => c.Id == model.Entity.Id);
            entity.Update(model.Entity);

            await _factory.UploadImageAndSaveToDbAsync<Brand>(model.CoverUpload, entity.GetImage()?.Id, "images/uploads/brands/covers", ImageType.Cover, new Point(0,0), new Size(600, 400), model.Entity.Id);

            try
            {
                // Add the product to the database
                _context.Set<Brand>().Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return entity;
        }

        #endregion

        /// <summary>
        /// Adds an service to the database asyncronously
        /// </summary>
        /// <param name="model">The model the service should be added from</param>
        /// <returns> The employee that was added</returns>
        public async Task<Brand> AddAsync(BrandAddEditModel model)
        {
            _context.Set<Brand>().Add(model.Entity);
            await _factory.UploadImageAndSaveToDbAsync<Brand>(model.CoverUpload, null, "images/uploads/brands/covers", ImageType.Cover, new Point(0, 0), new Size(600, 400), model.Entity.Id);
            await _context.SaveChangesAsync();
            return model.Entity;
        }

        public async Task RemoveAsync(string id)
        {
            var brand = await GetAsync(id);
            _context.Remove(brand);
            await _context.SaveChangesAsync();
        }
    }
}