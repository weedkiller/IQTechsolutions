using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Customers.Base.Entities;
using Customers.Core.Models;
using Filing.Base.Entities;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Filing.Core.Factories;
using Iqt.Base.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customers.Core.Context.Services
{
    public class CustomerContext
    {
        /// <summary>
        /// The Repository manger for this controller
        /// </summary>
        private readonly DbContext _context;

        /// <summary>
        /// The filefactory used to upload and download images
        /// </summary>
        private readonly IFileFactory _fileFactory;

        #region Constructors

        /// <summary>
        /// The default constructor  with injected parameters
        /// </summary>
        /// <param name="context">The injected database context</param>
        /// <param name="fileFactory">The injected file factory</param>
        public CustomerContext(DbContext context, IFileFactory fileFactory)
        {
            _context = context;
            _fileFactory = fileFactory;
        }

        #endregion

        #region GET

        /// <summary>
        /// Get an enumerated list of all the employees
        /// </summary>
        /// <returns>An enumerated list of all the employees</returns>
        public IQueryable<Customer> GetAll()
        {
            return _context.Set<Customer>().Include(c => c.Images).Include(c => c.Addresses).Include(c => c.ContactNumbers)
                .Include(c => c.EmailAddresses);
        }

        /// <summary>
        /// Get a specific employee
        /// </summary>
        /// <param name="id">the id of the employee to be fetched</param>
        /// <returns>a specific employee</returns>
        public Customer GetEntity(string id)
        {
            var employee = GetAll().FirstOrDefault(c => c.Id == id);
            return employee;
        }

        #endregion

        #region Add Employee

        /// <summary>
        /// Adds an employee to the database asynchronously
        /// </summary>
        /// <param name="model">The add edit model of the employee</param>
        /// <returns>The added employee</returns>
        public async Task<Customer> AddAsync(CustomerAddEditModel model)
        {
            
            _context.Set<Customer>().Add(model.Customer);

            var cover = await _fileFactory.UploadImageAndSaveToDbAsync<Customer>(model.CoverUpload, null, "images/uploads/customer/covers", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Customer.Id);


            await _context.SaveChangesAsync();

            return model.Customer;
        }

        #endregion

        #region Update Employee

        /// <summary>
        /// Update a specific employee
        /// </summary>
        /// <param name="model">The model to be updated from</param>
        /// <returns>The updated employee</returns>
        public async Task<Customer> UpdateAsync(CustomerAddEditModel model)
        {
            var employee = GetEntity(model.Customer.Id);

            _context.Entry(employee).CurrentValues.SetValues(model.Customer);

            var cover = await _fileFactory.UploadImageAndSaveToDbAsync<Customer>(model.CoverUpload, employee.GetImage()?.Id, "images/uploads/account/cover", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Customer.Id);

            // Add the product to the database
            _context.Set<Customer>().Update(employee);
            await _context.SaveChangesAsync();

            return employee;
        }
        public async Task<Customer> UpdateAsync(Customer model)
        {
            _context.Set<Customer>().Update(model);
            await _context.SaveChangesAsync();

            return model;
        }

        #endregion

        #region Delete Employee

        /// <summary>
        /// Removes the employee from the database
        /// </summary>
        /// <param name="id">The identity of the employee to be removed</param>
        /// <returns>The employee that was removed</returns>
        public async Task<Customer> DeleteAsync(string id)
        {
            // Gets the product to be deleted
            var employee = GetEntity(id);

            
            // Check to see if there any contact numbers that should be deleted
            if (employee.ContactNumbers != null && employee.ContactNumbers.Any())
            {
                // iterate through the contact numbers
                foreach (var skill in employee.ContactNumbers.ToList())
                {
                    employee.ContactNumbers.Remove(skill);
                    _context.Set<ContactNumber<Customer>>().Remove(skill);
                }
            }

            // Check to see if there any email addresses that should be deleted
            if (employee.EmailAddresses != null && employee.EmailAddresses.Any())
            {
                // iterate through the email addresses
                foreach (var skill in employee.EmailAddresses.ToList())
                {
                    employee.EmailAddresses.Remove(skill);
                    _context.Set<EmailAddress<Customer>>().Remove(skill);
                }
            }

            // Check to see if there any addresses that should be deleted
            if (employee.Addresses != null && employee.Addresses.Any())
            {
                // iterate through the addrsses
                foreach (var skill in employee.Addresses.ToList())
                {
                    employee.Addresses.Remove(skill);
                    _context.Set<Address<Customer>>().Remove(skill);
                }
            }

            // Check to see if there any images that should be deleted
            if (employee.Images != null && employee.Images.Any())
            {
                // iterate through the images
                foreach (var skill in employee.Images.ToList())
                {
                    employee.Images.Remove(skill);
                    _context.Set<ImageFile<Customer>>().Remove(skill);
                }
            }

            try
            {
                // deletes the product from the database
                _context.Set<Customer>().Remove(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return employee;
        }

        #endregion

        #region Contact Numbers Methods

        /// <summary>
        /// Gets a specific contact number
        /// </summary>
        /// <param name="id">The identity of the contact number that must be fetched</param>
        /// <returns>The contact number</returns>
        public async Task<ContactNumber<Customer>> GetContactNumber(string id)
        {
            var entity = await _context.Set<ContactNumber<Customer>>().FirstOrDefaultAsync(c => c.Id == id);
            return entity;
        }

        /// <summary>
        /// Removes a contact number from an event
        /// </summary>
        /// <param name="id">The identity of the contact number that must be removed</param>
        public async Task RemoveContactNumberAsync(string id)
        {
            var entity = await _context.Set<ContactNumber<Customer>>().FirstOrDefaultAsync(c => c.Id == id);

            _context.Set<ContactNumber<Customer>>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a new Contact number to the database
        /// </summary>
        /// <param name="model">The model used to add a contact number from a view</param>
        /// <returns>The added contact number</returns>
        public async Task<ContactNumber<Customer>> AddContactNrAsync(ContactNumber<Customer> model)
        {
            var contact = await GetParent(model.EntityId);

            var otherContacts = _context.Set<ContactNumber<Customer>>().Where(c => c.EntityId == model.EntityId);
            var newContactNumber = new ContactNumber<Customer>()
            {
                Name = model.Name,
                Number = model.Number,
                EntityId = model.EntityId
            };

            if (!otherContacts.Any())
            {
                newContactNumber.Default = true;
            }
            newContactNumber.EntityId = model.EntityId;

            _context.Set<ContactNumber<Customer>>().Add(newContactNumber);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (model.Default)
            {
                foreach (var item in otherContacts)
                {
                    item.Default = false;
                    _context.Set<ContactNumber<Customer>>().Update(item);
                }
            }
            await _context.SaveChangesAsync();

            return newContactNumber;
        }

        /// <summary>
        /// Updates an existing Contact number to the database
        /// </summary>
        /// <param name="model">The model used to update a contact number from a view</param>
        /// <returns>The updated contact number</returns>
        public async Task<ContactNumber<Customer>> EditContactNrAsync(ContactNumber<Customer> model)
        {
            var contactNumber = await _context.Set<ContactNumber<Customer>>().FirstOrDefaultAsync(c => c.Id == model.Id);
            var otherContacts = _context.Set<ContactNumber<Customer>>().Where(c => c.EntityId == model.EntityId).Where(c => c.Id != model.Id);

            contactNumber.Name = model.Name;
            contactNumber.InternationalCode = model.InternationalCode;
            contactNumber.AreaCode = model.AreaCode;
            contactNumber.Number = model.Number;
            contactNumber.Default = model.Default;

            if (!otherContacts.Any())
            {
                contactNumber.Default = true;
            }

            _context.Set<ContactNumber<Customer>>().Update(contactNumber);

            if (model.Default)
            {
                foreach (var item in otherContacts)
                {
                    item.Default = false;
                    _context.Set<ContactNumber<Customer>>().Update(item);
                }
            }


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return contactNumber;
        }

        #endregion

        #region Email Address Methods

        /// <summary>
        /// Gets a specific email address
        /// </summary>
        /// <param name="id">The identity of the email addresses that must be fetched</param>
        /// <returns>The specific email address</returns>
        public async Task<EmailAddress<Customer>> GetEmailAddressAsync(string id)
        {
            var entity = await _context.Set<EmailAddress<Customer>>().FirstOrDefaultAsync(c => c.Id == id);
            return entity;
        }

        /// <summary>
        /// Removes a email address from an entity
        /// </summary>
        /// <param name="id">The identity of the email address that must be removed</param>
        public async Task RemoveEmailAddressAsync(string id)
        {
            var entity = await _context.Set<EmailAddress<Customer>>().FirstOrDefaultAsync(c => c.Id == id);
            _context.Set<EmailAddress<Customer>>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a new Email Address to the database
        /// </summary>
        /// <param name="model">The model used to add a email address from a view</param>
        /// <returns>The added email address</returns>
        public async Task<EmailAddress<Customer>> AddEmailAddressAsync(EmailAddress<Customer> model)
        {
            var contact = await GetParent(model.EntityId);

            var otherEmailAddresses = _context.Set<EmailAddress<Customer>>().Where(c => c.EntityId == model.EntityId);
            var newEmailAddress = new EmailAddress<Customer>(model.Address);

            if (!otherEmailAddresses.Any())
            {
                newEmailAddress.Default = true;
            }
            newEmailAddress.EntityId = model.EntityId;

            _context.Set<EmailAddress<Customer>>().Add(newEmailAddress);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (model.Default)
            {
                foreach (var item in otherEmailAddresses)
                {
                    item.Default = false;
                    _context.Set<EmailAddress<Customer>>().Update(item);
                }
            }
            await _context.SaveChangesAsync();

            return newEmailAddress;
        }

        /// <summary>
        /// Updates an existing email address to the database
        /// </summary>
        /// /// <param name="model">The identity of the email address being updated</param>
        /// <returns>The updated email address</returns>
        public async Task<EmailAddress<Customer>> EditEmailAddressAsync(EmailAddress<Customer> model)
        {
            var emailAddress = await _context.Set<EmailAddress<Customer>>().FirstOrDefaultAsync(c => c.Id == model.Id);
            var otherEmailAddresses = _context.Set<EmailAddress<Customer>>().Where(c => c.EntityId != model.Id).Where(c => c.Id != model.Id); ;

            emailAddress.Address = model.Address;
            emailAddress.Default = model.Default;

            if (!otherEmailAddresses.Any())
            {
                emailAddress.Default = true;
            }

            _context.Set<EmailAddress<Customer>>().Update(emailAddress);

            if (model.Default)
            {
                foreach (var item in otherEmailAddresses)
                {
                    item.Default = false;
                    _context.Set<EmailAddress<Customer>>().Update(item);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return emailAddress;
        }

        #endregion

        #region Address Methods

        /// <summary>
        /// Gets a specific address
        /// </summary>
        /// <param name="id">The identity of the addresses that must be fetched</param>
        /// <returns>The specific address</returns>
        public async Task<Address<Customer>> GetAddressAsync(string id)
        {
            var entity = await _context.Set<Address<Customer>>().FirstOrDefaultAsync(c => c.Id == id);
            return entity;
        }

        /// <summary>
        /// Removes a address from an entity
        /// </summary>
        /// <param name="id">The identity of the address that must be removed</param>
        public async Task RemoveAddressAsync(string id)
        {
            var entity = await _context.Set<Address<Customer>>().FirstOrDefaultAsync(c => c.Id == id);
            _context.Set<Address<Customer>>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a new Address to the database
        /// </summary>
        /// <param name="model">The model used to add a address from a view</param>
        /// <returns>The added address</returns>
        public async Task<Address<Customer>> AddAddressAsync(Address<Customer> model)
        {
            var contact = await GetParent(model.EntityId);

            var otherAddresses = _context.Set<Address<Customer>>().Where(c => c.EntityId == model.EntityId);
            var newAddress = new Address<Customer>()
            {
                Name = model.Name,
                UnitNumber = model.UnitNumber,
                Complex = model.Complex,
                StreetNumber = model.StreetNumber,
                AddressLine1 = model.AddressLine1,
                Suburb = model.Suburb,
                PostalCode = model.PostalCode,
                City = model.City,
                Province = model.Province,
                Country = model.Country,
                Location = new Location
                {
                    Latitude = Convert.ToDouble(model.Location.Latitude),
                    Longitude = Convert.ToDouble(model.Location.Longitude)
                }
            };

            if (!otherAddresses.Any())
            {
                newAddress.Default = true;
            }
            newAddress.EntityId = model.EntityId;

            _context.Set<Address<Customer>>().Add(newAddress);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (model.Default)
            {
                foreach (var item in otherAddresses)
                {
                    item.Default = false;
                    _context.Set<Address<Customer>>().Update(item);
                }
            }
            await _context.SaveChangesAsync();

            return newAddress;
        }

        /// <summary>
        /// Updates an existing address to the database
        /// </summary>
        /// /// <param name="model">The identity of the address being updated</param>
        /// <returns>The updated address</returns>
        public async Task<Address<Customer>> EditAddressAsync(Address<Customer> model)
        {
            var address = await _context.Set<Address<Customer>>().FirstOrDefaultAsync(c => c.Id == model.Id);
            var otherAddresses = _context.Set<Address<Customer>>().Where(c => c.EntityId == model.EntityId).Where(c => c.Id != model.Id); ;

            address.Name = model.Name;
            address.UnitNumber = model.UnitNumber;
            address.Complex = model.Complex;
            address.StreetNumber = model.StreetNumber;
            address.AddressLine1 = model.AddressLine1;
            address.Suburb = model.Suburb;
            address.PostalCode = model.PostalCode;
            address.City = model.City;
            address.Province = model.Province;
            address.Country = model.Country;
            address.Location.Latitude = Convert.ToDouble(model.Location.Longitude);
            address.Location.Longitude = Convert.ToDouble(model.Location.Latitude);
            address.Default = model.Default;

            if (!otherAddresses.Any() || model.Default)
            {
                address.Default = true;
            }

            _context.Set<Address<Customer>>().Update(address);

            if (model.Default)
            {
                foreach (var item in otherAddresses)
                {
                    item.Default = false;
                    _context.Set<Address<Customer>>().Update(item);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return address;
        }

        public async Task<Customer> GetParent(string id)
        {
            return await _context.Set<Customer>().FirstOrDefaultAsync(c => c.Id == id);
        }

        #endregion
    }
}
