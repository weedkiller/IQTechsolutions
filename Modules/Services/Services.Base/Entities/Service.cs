using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Calendar.Base.Entities;
using Feedback.Base.Entities;
using Filing.Base.Entities;
using Grouping.Base.Entities;
using Iqt.Base.Enums.Calendar;
using Iqt.Base.Enums.ECommerce;
using Iqt.Base.Extensions;

namespace Services.Base.Entities
{
    /// <summary>
    /// The service class of this application
    /// </summary>
    public class Service : ImageFileCollection<Service>
    {
        private string _shortDescription;

        #region Properties

        /// <summary>
        /// The Name of the Product
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// A short description of the product, if the member property of this field is empty
        /// a truncated detailed description of 150 characters is displayed
        /// </summary>
        [DisplayName(@"Short Description"), DataType(DataType.MultilineText)]
        public string ShortDescription
        {
            get => string.IsNullOrEmpty(_shortDescription) ? Description.HtmlToPlainText().TruncateLongString(150) : _shortDescription;
            set => _shortDescription = value;
        }
        
        /// <summary>
        /// A detailed description of the product
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// Additional Information added to this product
        /// </summary>
        [DisplayName(@"Additional Info"), DataType(DataType.MultilineText)]
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// The frequency this service is billed at
        /// </summary>
        [DisplayName(@"Billing Frequency")]
        public BillingFrequency BillingFrequency { get; set; } = BillingFrequency.Monthly;

        /// <summary>
        /// The recurrence rule of this service
        /// </summary>
        [DisplayName(@"Service Frequency")]
        public Recurrence ServiceFrequency { get; set; } = Recurrence.None;

        /// <summary>
        /// The rate this service is charged at
        /// </summary>
        [DisplayName(@"Price")]
        public double Price { get; set; }

        /// <summary>
        /// Flag to indicate if this item should be displayed as part of a price table
        /// </summary>
        [DisplayName(@"Price Table Item")]
        public bool PriceTableItem { get; set; }

        /// <summary>
        /// Gets or Sets the Flag to indicate if this is a popular service
        /// </summary>
        public bool Popular { get; set; }

        /// <summary>
        /// Gets or Sets the Flag to indicate if this is a featured service
        /// </summary>
        public bool Featured { get; set; }

        /// <summary>
        /// Gets or Sets the Flag to indicate if this is an active service
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or Sets the Flag to indicate if this is service Module
        /// </summary>
        public bool Module { get; set; }

        /// <summary>
        /// Gets or Sets the Web tags for this product
        /// </summary>
        public string Tags { get; set; }

        #endregion

        #region Collections

        /// <summary>
        /// Gets or Sets the project tasks
        /// </summary>
        public virtual ICollection<EntityTask<Service>> Tasks { get; set; } = new List<EntityTask<Service>>();

        /// <summary>
        /// Gets or Sets the Categories collection that this product is grouped into
        /// has a many to many relationship with <see cref="EntityCategory{T}"/>
        /// which in turn has a one to many relationship with <see cref="Service"/>
        /// and <see cref="Category{T}"/>
        /// A Category can have many services and a service can have many categories
        /// </summary>
        public virtual ICollection<EntityCategory<Service>> Categories { get; set; } = new List<EntityCategory<Service>>();

        /// <summary>
        /// Gets or Sets Combo Category collection that belongs to this service
        /// categories that are included in this service as combos
        /// has a many to many relationship with <see cref="ComboCategory{T}"/>
        /// which in turn has a one to many relationship with <see cref="Service"/>
        /// and <see cref="Category{T}"/>
        /// A Service can have many combo categories and a category combo can belong to many services
        /// </summary>
        public virtual ICollection<ComboCategory<Service>> Combos { get; set; } = new List<ComboCategory<Service>>();

        /// <summary>
        /// Gets or sets the services that are excluded from a specific combo category
        /// has a many to many relationship with <see cref="ComboExclusions{T}"/>
        /// which in turn has a one to many relationship with <see cref="Service"/>
        /// and <see cref="ComboCategory{T}"/>
        /// A ComboCategory can have many service exclusion and a service can be excluded in many Combo Caqtegories
        /// </summary>
        public ICollection<ComboExclusions<Service>> Exclusions { get; set; } = new List<ComboExclusions<Service>>();

        /// <summary>
        /// Gets or sets the services that are included with this service as a combo from a specific combo category
        /// has a many to many relationship with <see cref="IncludedService{T}"/>
        /// which in turn has a one to many relationship with <see cref="Service"/>
        /// and <see cref="Service"/>
        /// A Service can have many service included and a service can be included by many services
        /// </summary>
        public virtual ICollection<IncludedService<Service>> IncludedServices { get; set; } = new List<IncludedService<Service>>();

        /// <summary>
        /// Gets or sets the services that are optional with this service as a combo 
        /// has a many to many relationship with <see cref="OptionalService{T}"/>
        /// which in turn has a one to many relationship with <see cref="Service"/> as parent
        /// and <see cref="Service"/> as included optional service
        /// A Service can have many service included as optional and a service can be included by many services as optional
        /// </summary>
        public virtual ICollection<OptionalService<Service>> OptionalServices { get; set; } = new List<OptionalService<Service>>();

        /// <summary>
        /// Gets or sets the service reviews collection for this service
        /// has a one to many relationship with <see cref="NewsFeed"/>
        /// A Sevice can have many reviews
        /// </summary>
        public virtual ICollection<Comment<Service>> Reviews { get; set; } = new List<Comment<Service>>();

        #endregion
    }
}
