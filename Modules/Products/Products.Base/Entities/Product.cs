using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Feedback.Base.Entities;
using Filing.Base.Entities;
using Grouping.Base.Entities;
using Iqt.Base.Extensions;
using Iqt.Inventory.Entities;

namespace Products.Base.Entities
{
    /// <summary>
    /// A product that can be sold
    /// </summary>
    public class Product : ImageFileCollection<Product>
    {
        private string _shortDescription;

        #region Properties

        /// <summary>
        /// The barcode of the product
        /// </summary>
        [DisplayName(@"Bar-Code")]
        public string Barcode { get; set; }

        /// <summary>
        /// The Name of the Product
        /// </summary>
        [DisplayName(@"Name"), Required]
        public string Name { get; set; }

        /// <summary>
        /// Additional Information of the product
        /// </summary>
        [DisplayName(@"Short Description"), DataType(DataType.MultilineText)]
        public string ShortDescription
        {
            get => string.IsNullOrEmpty(_shortDescription)
                ? Description.HtmlToPlainText().TruncateLongString(150)
                : _shortDescription;
            set => _shortDescription = value;
        }

        /// <summary>
        /// A detailed description of the product
        /// </summary>
        [DisplayName(@"Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// Additional Information of the product
        /// </summary>
        [DisplayName(@"Additional Info"), DataType(DataType.MultilineText)]
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// The type of product (new or used)
        /// </summary>
        public ProductType ProductType { get; set; } = ProductType.New;

        /// <summary>
        /// The stock code of the product
        /// </summary>
        public string StockCode { get; set; }

        /// <summary>
        /// The model number
        /// </summary>
        public string ModelNr { get; set; }

        /// <summary>
        /// The webtags for this product
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// The rating for this product
        /// </summary>
        public double Rating { get; set; }

        #endregion

        #region Pricing

        /// <summary>
        /// The rate at which vat is calculated
        /// </summary>
        [DisplayName(@"Vat Rate")]
        public double VatRate { get; set; } = 15;

        /// <summary>
        /// The cost of the item
        /// </summary>
        public double CostExcl { get; set; }

        /// <summary>
        /// The Exclusive Price of the item
        /// </summary>
        public double PriceExcl => PriceIncl - Vat;

        /// <summary>
        /// The vat of a product
        /// </summary>
        public double Vat
        {
            get
            {
                if (Vatable)
                {
                    return (PriceIncl * VatRate) / 100;
                }

                return 0;
            }
        }

        /// <summary>
        /// The inclusive price of a product                                                                                                          
        /// </summary>
        public double PriceIncl { get; set; }

        /// <summary>
        /// Flag to see if item is vatable
        /// </summary>
        public bool Vatable
        {
            get
            {
                if (Math.Abs(VatRate) <= 0)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// The item wide discount given on the item
        /// </summary>
        public double DiscountPercentage { get; set; } = 0;

        /// <summary>
        /// The price after item wide discount is applied
        /// </summary>
        public double Discount
        {
            get
            {
                if (DiscountPercentage != 0)
                {
                    return ((PriceExcl * (1 + (DiscountPercentage / 100))) - PriceExcl);
                }

                return 0;
            }
        }

        /// <summary>
        /// The price after item wide discount is applied
        /// </summary>
        public double DiscountedPrice
        {
            get { return PriceExcl - Discount; }
        }

        /// <summary>
        /// The reward points allocated to the price
        /// </summary>
        public int RewardPoints { get; set; }

        /// <summary>
        /// The price after item wide discount is applied
        /// </summary>
        public double RewardPointsValue
        {
            get { return RewardPoints * 10; }
        }

        #endregion

        /// <summary>
        /// Flag to see if product is active 
        /// </summary>
        public bool Active { get; set; } = true;

        /// <summary>
        /// Flag to see if product is featured
        /// </summary>
        [DisplayName(@"Featured")]
        public bool Featured { get; set; }

        /// <summary>
        /// Flag to see if product must be listed
        /// </summary>
        [DisplayName(@"Featured")]
        public bool ListedItem { get; set; }

        /// <summary>
        /// The Amount of social shares received for this post
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        /// Flag to indicate whether it is a recent item or not
        /// </summary>
        public bool RecentItem
        {
            get
            {
                if (Created >= Created.AddDays(-30))
                {
                    return true;
                }

                return false;
            }
        }


        #region Quantities

        /// <summary>
        /// Qty of units in stock
        /// </summary>
        public int Sold { get; set; } = 0;

        /// <summary>
        /// Qty of units in stock
        /// </summary>
        public int QtyInStock { get; set; }

        /// <summary>
        /// Message Displayed when Item is out of Stock
        /// </summary>
        public string OutOfStockMessage
        {
            get
            {
                if (QtyInStock == 0)
                    return "Product out of Stock";
                else if (QtyInStock < 0)
                    return $"There are currently {QtyInStock} units on back order";
                return "";
            }
        }

        #endregion

        #region Relational Public Properties

        #region Packaging

        /// <summary>
        /// The identity of the packaged product
        /// </summary>
        [ForeignKey("Packaging")]
        public string PackagingId { get; set; }

        public Product Packaging { get; set; }

        #endregion

        #endregion

        #region Collections

        /// <summary>
        /// The categories this product belongs to
        /// </summary>
        public ICollection<EntityCategory<Product>> Categories { get; set; } = new List<EntityCategory<Product>>();

        /// <summary>
        /// The collection of categories that is sold with this product if the product is a combo
        /// </summary>
        public ICollection<ComboCategory<Product>> Combos { get; set; } = new List<ComboCategory<Product>>();

        public ICollection<ComboExclusions<Product>> Exclusions { get; set; } = new List<ComboExclusions<Product>>();

        /// <summary>
        /// The collection of products that is sold with this product if it is a combo
        /// </summary>
        public ICollection<IncludedProduct<Product>> IncludedProducts { get; set; } =
            new List<IncludedProduct<Product>>();

        /// <summary>
        /// The features of this product
        /// </summary>
        public virtual ICollection<OptionalProduct<Product>> OptionalProducts { get; set; } = new List<OptionalProduct<Product>>();

        /// <summary>
        /// The packsizes associated with this product
        /// </summary>
        public virtual ICollection<ProductBrand> Brands { get; set; } = new List<ProductBrand>();


        /// <summary>
        /// The collection of Items in a package if this is a package item
        /// </summary>
        public ICollection<Product> PackageItems { get; set; } = new List<Product>();

        /// <summary>
        /// Gets or sets the service reviews collection for this service
        /// has a one to many relationship with <see cref="NewsFeed"/>
        /// A Sevice can have many reviews
        /// </summary>
        public virtual ICollection<Comment<Product>> Reviews { get; set; } = new List<Comment<Product>>();

        #endregion
    }


    public enum ProductType
    {
        New,
        Used
    }
}
