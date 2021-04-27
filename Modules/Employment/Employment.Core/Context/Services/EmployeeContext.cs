using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Employment.Base.Entities;
using Employment.Core.Models;
using Filing.Base.Entities;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Filing.Core.Factories;
using Iqt.Base.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employment.Core.Context.Services
{
    public class EmployeeContext
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
        /// <param name="manager">The injected application repository manager</param>
        /// <param name="fileFactory">The injected file factory</param>
        public EmployeeContext(DbContext context, IFileFactory fileFactory)
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
        public IEnumerable<Employee> GetAll()
        {
            return _context.Set<Employee>().Include(c => c.Names).Include(c => c.Skills)
                .Include(c => c.Images).Include(c => c.Addresses).Include(c => c.ContactNumbers)
                .Include(c => c.EmailAddresses);
        }

        /// <summary>
        /// Get a specific employee
        /// </summary>
        /// <param name="id">the id of the employee to be fetched</param>
        /// <returns>a specific employee</returns>
        public Employee GetEntity(string id)
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
        public async Task<Employee> AddAsync(EmployeeAddEditModel model)
        {
            
            _context.Set<Employee>().Add(model.Entity);

            var cover = await _fileFactory.UploadImageAndSaveToDbAsync<Employee>(model.CoverUpload, null, "images/uploads/account/profile", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);


            await _context.SaveChangesAsync();

            return model.Entity;
        }

        #endregion

        #region Update Employee

        /// <summary>
        /// Update a specific employee
        /// </summary>
        /// <param name="model">The model to be updated from</param>
        /// <returns>The updated employee</returns>
        public async Task<Employee> UpdateAsync(EmployeeAddEditModel model)
        {
            var employee = GetEntity(model.Entity.Id);

            _context.Entry(employee).CurrentValues.SetValues(model.Entity);

            var cover = await _fileFactory.UploadImageAndSaveToDbAsync<Employee>(model.CoverUpload, employee.GetImage()?.Id, "images/uploads/account/cover", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);

            // Add the product to the database
            _context.Set<Employee>().Update(employee);
            await _context.SaveChangesAsync();

            return employee;
        }
        public async Task<Employee> UpdateAsync(Employee model)
        {
            _context.Set<Employee>().Update(model);
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
        public async Task<Employee> DeleteAsync(string id)
        {
            // Gets the product to be deleted
            var employee = GetEntity(id);

            // Check to see if there any images that should be deleted
            if (employee.Skills != null && employee.Skills.Any())
            {
                // iterate through the images
                foreach (var skill in employee.Skills.ToList())
                {
                    employee.Skills.Remove(skill);
                    _context.Set<Skill>().Remove(skill);
                }
            }

            // Check to see if there any images that should be deleted
            if (employee.ContactNumbers != null && employee.ContactNumbers.Any())
            {
                // iterate through the images
                foreach (var skill in employee.ContactNumbers.ToList())
                {
                    employee.ContactNumbers.Remove(skill);
                    _context.Set<ContactNumber<Employee>>().Remove(skill);
                }
            }

            // Check to see if there any images that should be deleted
            if (employee.EmailAddresses != null && employee.EmailAddresses.Any())
            {
                // iterate through the images
                foreach (var skill in employee.EmailAddresses.ToList())
                {
                    employee.EmailAddresses.Remove(skill);
                    _context.Set<EmailAddress<Employee>>().Remove(skill);
                }
            }

            // Check to see if there any images that should be deleted
            if (employee.Addresses != null && employee.Addresses.Any())
            {
                // iterate through the images
                foreach (var skill in employee.Addresses.ToList())
                {
                    employee.Addresses.Remove(skill);
                    _context.Set<Address<Employee>>().Remove(skill);
                }
            }

            // Check to see if there any images that should be deleted
            if (employee.Images != null && employee.Images.Any())
            {
                // iterate through the images
                foreach (var skill in employee.Images.ToList())
                {
                    employee.Images.Remove(skill);
                    _context.Set<ImageFile<Employee>>().Remove(skill);
                }
            }

            try
            {
                // deletes the product from the database
                _context.Set<Employee>().Remove(employee);
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
        public async Task<ContactNumber<Employee>> GetContactNumber(string id)
        {
            var entity = await _context.Set<ContactNumber<Employee>>().FirstOrDefaultAsync(c => c.Id == id);
            return entity;
        }

        /// <summary>
        /// Removes a contact number from an event
        /// </summary>
        /// <param name="id">The identity of the contact number that must be removed</param>
        public async Task RemoveContactNumberAsync(string id)
        {
            var entity = await _context.Set<ContactNumber<Employee>>().FirstOrDefaultAsync(c => c.Id == id);

            _context.Set<ContactNumber<Employee>>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a new Contact number to the database
        /// </summary>
        /// <param name="model">The model used to add a contact number from a view</param>
        /// <returns>The added contact number</returns>
        public async Task<ContactNumber<Employee>> AddContactNrAsync(ContactNumber<Employee> model)
        {
            var contact = await GetParent(model.EntityId);

            var otherContacts = _context.Set<ContactNumber<Employee>>().Where(c => c.EntityId == model.EntityId);
            var newContactNumber = new ContactNumber<Employee>()
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

            _context.Set<ContactNumber<Employee>>().Add(newContactNumber);

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
                    _context.Set<ContactNumber<Employee>>().Update(item);
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
        public async Task<ContactNumber<Employee>> EditContactNrAsync(ContactNumber<Employee> model)
        {
            var contactNumber = await _context.Set<ContactNumber<Employee>>().FirstOrDefaultAsync(c => c.Id == model.Id);
            var otherContacts = _context.Set<ContactNumber<Employee>>().Where(c => c.EntityId == model.EntityId).Where(c => c.Id != model.Id);

            contactNumber.Name = model.Name;
            contactNumber.InternationalCode = model.InternationalCode;
            contactNumber.AreaCode = model.AreaCode;
            contactNumber.Number = model.Number;
            contactNumber.Default = model.Default;

            if (!otherContacts.Any())
            {
                contactNumber.Default = true;
            }

            _context.Set<ContactNumber<Employee>>().Update(contactNumber);

            if (model.Default)
            {
                foreach (var item in otherContacts)
                {
                    item.Default = false;
                    _context.Set<ContactNumber<Employee>>().Update(item);
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
        public async Task<EmailAddress<Employee>> GetEmailAddressAsync(string id)
        {
            var entity = await _context.Set<EmailAddress<Employee>>().FirstOrDefaultAsync(c => c.Id == id);
            return entity;
        }

        /// <summary>
        /// Removes a email address from an entity
        /// </summary>
        /// <param name="id">The identity of the email address that must be removed</param>
        public async Task RemoveEmailAddressAsync(string id)
        {
            var entity = await _context.Set<EmailAddress<Employee>>().FirstOrDefaultAsync(c => c.Id == id);
            _context.Set<EmailAddress<Employee>>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a new Email Address to the database
        /// </summary>
        /// <param name="model">The model used to add a email address from a view</param>
        /// <returns>The added email address</returns>
        public async Task<EmailAddress<Employee>> AddEmailAddressAsync(EmailAddress<Employee> model)
        {
            var contact = await GetParent(model.EntityId);

            var otherEmailAddresses = _context.Set<EmailAddress<Employee>>().Where(c => c.EntityId == model.EntityId);
            var newEmailAddress = new EmailAddress<Employee>(model.Address);

            if (!otherEmailAddresses.Any())
            {
                newEmailAddress.Default = true;
            }
            newEmailAddress.EntityId = model.EntityId;

            _context.Set<EmailAddress<Employee>>().Add(newEmailAddress);

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
                    _context.Set<EmailAddress<Employee>>().Update(item);
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
        public async Task<EmailAddress<Employee>> EditEmailAddressAsync(EmailAddress<Employee> model)
        {
            var emailAddress = await _context.Set<EmailAddress<Employee>>().FirstOrDefaultAsync(c => c.Id == model.Id);
            var otherEmailAddresses = _context.Set<EmailAddress<Employee>>().Where(c => c.EntityId != model.Id).Where(c => c.Id != model.Id); ;

            emailAddress.Address = model.Address;
            emailAddress.Default = model.Default;

            if (!otherEmailAddresses.Any())
            {
                emailAddress.Default = true;
            }

            _context.Set<EmailAddress<Employee>>().Update(emailAddress);

            if (model.Default)
            {
                foreach (var item in otherEmailAddresses)
                {
                    item.Default = false;
                    _context.Set<EmailAddress<Employee>>().Update(item);
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
        public async Task<Address<Employee>> GetAddressAsync(string id)
        {
            var entity = await _context.Set<Address<Employee>>().FirstOrDefaultAsync(c => c.Id == id);
            return entity;
        }

        /// <summary>
        /// Removes a address from an entity
        /// </summary>
        /// <param name="id">The identity of the address that must be removed</param>
        public async Task RemoveAddressAsync(string id)
        {
            var entity = await _context.Set<Address<Employee>>().FirstOrDefaultAsync(c => c.Id == id);
            _context.Set<Address<Employee>>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a new Address to the database
        /// </summary>
        /// <param name="model">The model used to add a address from a view</param>
        /// <returns>The added address</returns>
        public async Task<Address<Employee>> AddAddressAsync(Address<Employee> model)
        {
            var contact = await GetParent(model.EntityId);

            var otherAddresses = _context.Set<Address<Employee>>().Where(c => c.EntityId == model.EntityId);
            var newAddress = new Address<Employee>()
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
                Location = new Location()
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

            _context.Set<Address<Employee>>().Add(newAddress);

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
                    _context.Set<Address<Employee>>().Update(item);
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
        public async Task<Address<Employee>> EditAddressAsync(Address<Employee> model)
        {
            var address = await _context.Set<Address<Employee>>().FirstOrDefaultAsync(c => c.Id == model.Id);
            var otherAddresses = _context.Set<Address<Employee>>().Where(c => c.EntityId == model.EntityId).Where(c => c.Id != model.Id); ;

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
            address.Location.Latitude = Convert.ToDouble(model.Location.Latitude);
            address.Location.Longitude = Convert.ToDouble(model.Location.Longitude);
            address.Default = model.Default;

            if (!otherAddresses.Any() || model.Default)
            {
                address.Default = true;
            }

            _context.Set<Address<Employee>>().Update(address);

            if (model.Default)
            {
                foreach (var item in otherAddresses)
                {
                    item.Default = false;
                    _context.Set<Address<Employee>>().Update(item);
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

        public async Task<Employee> GetParent(string id)
        {
            return await _context.Set<Employee>().FirstOrDefaultAsync(c => c.Id == id);
        }

        #endregion
    }
}
