using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Education.Base.Entities;
using Education.Core.Models;
using Filing.Base.Entities;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Filing.Core.Factories;
using Identity.Base.Entities;
using Iqt.Base.Entities;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.EntityFrameworkCore;

namespace Education.Core.Context.Services
{
    public class StudentContext
    {
        private readonly DbContext _context;
        private readonly IFileFactory _fileFactory;

        #region Constructors

        /// <summary>
        /// The default constructor  with injected parameters
        /// </summary>
        /// <param name="context">The injected database context</param>
        /// <param name="fileFactory">The injected file factory</param>
        public StudentContext(DbContext context, IFileFactory fileFactory)
        {
            _context = context;
            _fileFactory = fileFactory;
        }

        #endregion

        #region Get

        /// <summary>
        /// Gets a <see cref="IQueryable{T}"/> list of all the <see cref="Student"/>
        /// </summary>
        /// <returns>An <see cref="IQueryable{T}"/> list of all the <see cref="Student"/></returns>
        public IQueryable<Student> GetAll()
        {
            return _context.Set<Student>().Include(c => c.Names).Include(c => c.Courses)
                .Include(c => c.UserInfo).Include(c => c.Addresses).Include(c => c.ContactNumbers)
                .Include(c => c.EmailAddresses);
        }

        /// <summary>
        /// Get a specific <see cref="Student"/>
        /// </summary>
        /// <param name="id">the identity of the <see cref="Student"/> to be fetched</param>
        /// <returns>a specific <see cref="Student"/></returns>
        public async Task<Student> GetAsync(string id)
        {
            var employee = await GetAll().FirstOrDefaultAsync(c => c.Id == id);
            return employee;
        }

        /// <summary>
        /// Get a specific <see cref="Student"/>
        /// </summary>
        /// <param name="id">the identity of the <see cref="Student"/> to be fetched</param>
        /// <returns>a specific <see cref="Student"/></returns>
        public async Task<Student> GetByUserIdAsync(string id)
        {
            var employee = await GetAll().FirstOrDefaultAsync(c => c.UserInfo.Id == id);
            return employee;
        }

        /// <summary>
        /// Gets the previous database entry
        /// </summary>
        /// <param name="current">The current <see cref="Student"/></param>
        /// <returns>The previous <see cref="Student"/></returns>
        public async Task<Student> GetPreviousAsync(Student current)
        {
            var entityList = await GetAll().ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index > 0 ? entityList[index - 1] : null;
        }

        /// <summary>
        /// Gets the next database entry
        /// </summary>
        /// <param name="current">The current <see cref="Student"/></param>
        /// <returns>The previous <see cref="Student"/></returns>
        public async Task<Student> GetNextAsync(Student current)
        {
            var entityList = await GetAll().ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index < entityList.Count - 1 ? entityList[index + 1] : null;
        }

        #endregion

        #region Add Student

        /// <summary>
        /// Adds a <see cref="Student"/> to the database asynchronously
        /// </summary>
        /// <param name="model">The add edit model of the <see cref="Student"/></param>
        /// <returns>The added <see cref="Student"/></returns>
        public async Task<Student> AddAsync(StudentAddEditModel model)
        {
            
            _context.Set<Student>().Add(model.Entity);

            await _fileFactory.UploadImageAndSaveToDbAsync<UserInfo>(model.CoverUpload, null, "images/uploads/users/cover", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);


            await _context.SaveChangesAsync();

            return model.Entity;
        }

        #endregion

        #region Update Student

        /// <summary>
        /// Update a specific <see cref="Student"/>
        /// </summary>
        /// <param name="model">The <see cref="StudentAddEditModel"/> model to be updated from</param>
        /// <returns>The updated <see cref="Student"/></returns>
        public async Task<Student> UpdateAsync(StudentAddEditModel model)
        {
            var student = await GetAsync(model.Entity.Id);

            _context.Entry(student).CurrentValues.SetValues(model.Entity);

            await _fileFactory.UploadImageAndSaveToDbAsync<Student>(model.CoverUpload, student.UserInfo.GetImage()?.Id, "images/uploads/student/cover", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);

            _context.Set<Student>().Update(student);
            await _context.SaveChangesAsync();

            return student;
        }

        /// <summary>
        /// Update a specific <see cref="Student"/>
        /// </summary>
        /// <param name="student"></param>
        /// <returns>The updated <see cref="Student"/></returns>
        public async Task<Student> UpdateAsync(Student student)
        {
            _context.Set<Student>().Update(student);
            await _context.SaveChangesAsync();

            return student;
        }

        #endregion

        #region Delete Student

        /// <summary>
        /// Removes the <see cref="Student"/> from the database
        /// </summary>
        /// <param name="id">The identity of the <see cref="Student"/> to be removed</param>
        /// <returns>The <see cref="Student"/> that was removed</returns>
        public async Task DeleteAsync(string id)
        {
            // Gets the product to be deleted
            var employee = await GetAsync(id);

            // Check to see if there any images that should be deleted
            if (employee.ContactNumbers != null && employee.ContactNumbers.Any())
            {
                // iterate through the images
                foreach (var skill in employee.ContactNumbers.ToList())
                {
                    employee.ContactNumbers.Remove(skill);
                    _context.Set<ContactNumber<Student>>().Remove(skill);
                }
            }

            // Check to see if there any images that should be deleted
            if (employee.EmailAddresses != null && employee.EmailAddresses.Any())
            {
                // iterate through the images
                foreach (var skill in employee.EmailAddresses.ToList())
                {
                    employee.EmailAddresses.Remove(skill);
                    _context.Set<EmailAddress<Student>>().Remove(skill);
                }
            }

            // Check to see if there any images that should be deleted
            if (employee.Addresses != null && employee.Addresses.Any())
            {
                // iterate through the images
                foreach (var skill in employee.Addresses.ToList())
                {
                    employee.Addresses.Remove(skill);
                    _context.Set<Address<Student>>().Remove(skill);
                }
            }

            try
            {
                // deletes the product from the database
                _context.Set<Student>().Remove(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        #endregion

        #region StudentCourses

        public async Task<StudentCourse> GetStudentCourse(string studentId, string courseId)
        {
            return _context.Set<StudentCourse>().Include(c => c.Course).Where(c => c.CourseId == courseId)
                .FirstOrDefault(c => c.StudentId == studentId);
        }

        public async Task DeleteStudentCourse(string studentId, string courseId)
        {
            try
            {
                var studentCourse = _context.Set<StudentCourse>().Where(c => c.StudentId == studentId).FirstOrDefault(c => c.CourseId == courseId);
                _context.Remove(studentCourse);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        #endregion

        #region Contact Numbers Methods

        /// <summary>
        /// Gets a specific <see cref="ContactNumber{T}"/> for a <see cref="Student"/>
        /// </summary>
        /// <param name="id">The identity of the <see cref="ContactNumber{T}"/> that must be fetched</param>
        /// <returns>A Specific <see cref="ContactNumber{T}"/></returns>
        public async Task<ContactNumber<Student>> GetContactNumber(string id)
        {
            var entity = await _context.Set<ContactNumber<Student>>().FirstOrDefaultAsync(c => c.Id == id);
            return entity;
        }

        /// <summary>
        /// Removes a <see cref="ContactNumber{T}"/> from an <see cref="Student"/>
        /// </summary>
        /// <param name="id">The identity of the <see cref="ContactNumber{T}"/> that must be removed</param>
        public async Task RemoveContactNumberAsync(string id)
        {
            var entity = await _context.Set<ContactNumber<Student>>().FirstOrDefaultAsync(c => c.Id == id);

            _context.Set<ContactNumber<Student>>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a new <see cref="ContactNumber{T}"/> to the database
        /// </summary>
        /// <param name="model">The <see cref="AddEditContactNumberDetailModel"/> model used to add a <see cref="ContactNumber{T}"/> from a view</param>
        /// <returns>The added <see cref="ContactNumber{T}"/></returns>
        public async Task<ContactNumber<Student>> AddContactNrAsync(ContactNumber<Student> model)
        {
            var otherContacts = _context.Set<ContactNumber<Student>>().Where(c => c.EntityId == model.EntityId).Where(c => c.Id != model.Id);
            var newContactNumber = new ContactNumber<Student>()
            {
                Name = model.Name,
                Number = model.Number,
                EntityId = model.EntityId,
                Default = model.Default
            };

            if (!otherContacts.Any())
            {
                newContactNumber.Default = true;
            }
            newContactNumber.EntityId = model.EntityId;

            _context.Set<ContactNumber<Student>>().Add(newContactNumber);

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
                    _context.Set<ContactNumber<Student>>().Update(item);
                }
            }
            await _context.SaveChangesAsync();

            return newContactNumber;
        }

        /// <summary>
        /// Updates an existing <see cref="ContactNumber{T}"/> to the database
        /// </summary>
        /// <param name="model">The <see cref="AddEditContactNumberDetailModel"/> model used to update a <see cref="ContactNumber{T}"/> from a view</param>
        /// <returns>The updated <see cref="ContactNumber{T}"/></returns>
        public async Task<ContactNumber<Student>> EditContactNrAsync(ContactNumber<Student> model)
        {
            var contactNumber = await _context.Set<ContactNumber<Student>>().FirstOrDefaultAsync(c => c.Id == model.Id);
            var otherContacts = _context.Set<ContactNumber<Student>>().Where(c => c.EntityId == model.EntityId).Where(c => c.Id != model.Id);

            contactNumber.Name = model.Name;
            contactNumber.InternationalCode = model.InternationalCode;
            contactNumber.AreaCode = model.AreaCode;
            contactNumber.Number = model.Number;
            contactNumber.Default = model.Default;

            if (!otherContacts.Any())
            {
                contactNumber.Default = true;
            }

            _context.Set<ContactNumber<Student>>().Update(contactNumber);

            if (model.Default)
            {
                foreach (var item in otherContacts)
                {
                    item.Default = false;
                    _context.Set<ContactNumber<Student>>().Update(item);
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
        /// Gets a specific <see cref="EmailAddress{T}"/>
        /// </summary>
        /// <param name="id">The identity of the <see cref="EmailAddress{T}"/> that must be fetched</param>
        /// <returns>The specific <see cref="EmailAddress{T}"/></returns>
        public async Task<EmailAddress<Student>> GetEmailAddressAsync(string id)
        {
            var entity = await _context.Set<EmailAddress<Student>>().FirstOrDefaultAsync(c => c.Id == id);
            return entity;
        }

        /// <summary>
        /// Removes a <see cref="EmailAddress{T}"/> from an entity
        /// </summary>
        /// <param name="id">The identity of the email address that must be removed</param>
        public async Task RemoveEmailAddressAsync(string id)
        {
            var entity = await _context.Set<EmailAddress<Student>>().FirstOrDefaultAsync(c => c.Id == id);
            _context.Set<EmailAddress<Student>>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a new <see cref="EmailAddress{T}"/> to the database
        /// </summary>
        /// <param name="model">The <see cref="AddEditEmailAddressModel"/> model used to add a <see cref="EmailAddress{T}"/> from a view</param>
        /// <returns>The added <see cref="EmailAddress{T}"/></returns>
        public async Task<EmailAddress<Student>> AddEmailAddressAsync(EmailAddress<Student> model)
        {
            var otherEmailAddresses = _context.Set<EmailAddress<Student>>().Where(c => c.EntityId == model.EntityId);
            var newEmailAddress = new EmailAddress<Student>(model.Address);

            if (!otherEmailAddresses.Any())
            {
                newEmailAddress.Default = true;
            }
            newEmailAddress.EntityId = model.EntityId;

            _context.Set<EmailAddress<Student>>().Add(newEmailAddress);

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
                    _context.Set<EmailAddress<Student>>().Update(item);
                }
            }
            await _context.SaveChangesAsync();

            return newEmailAddress;
        }

        /// <summary>
        /// Updates an existing <see cref="EmailAddress{T}"/> to the database
        /// </summary>
        /// /// <param name="model">The identity of the <see cref="EmailAddress{T}"/> being updated</param>
        /// <returns>The updated <see cref="EmailAddress{T}"/></returns>
        public async Task<EmailAddress<Student>> EditEmailAddressAsync(EmailAddress<Student> model)
        {
            var emailAddress = await _context.Set<EmailAddress<Student>>().FirstOrDefaultAsync(c => c.Id == model.Id);
            var otherEmailAddresses = _context.Set<EmailAddress<Student>>().Where(c => c.EntityId != model.Id).Where(c => c.Id != model.Id); ;

            emailAddress.Address = model.Address;
            emailAddress.Default = model.Default;

            if (!otherEmailAddresses.Any())
            {
                emailAddress.Default = true;
            }

            _context.Set<EmailAddress<Student>>().Update(emailAddress);

            if (model.Default)
            {
                foreach (var item in otherEmailAddresses)
                {
                    item.Default = false;
                    _context.Set<EmailAddress<Student>>().Update(item);
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
        /// Gets a specific <see cref="Address{T}"/>
        /// </summary>
        /// <param name="id">The identity of the <see cref="Address{T}"/> that must be fetched</param>
        /// <returns>The specific address</returns>
        public async Task<Address<Student>> GetAddressAsync(string id)
        {
            var entity = await _context.Set<Address<Student>>().FirstOrDefaultAsync(c => c.Id == id);
            return entity;
        }

        /// <summary>
        /// Removes a <see cref="Address{T}"/> from an entity
        /// </summary>
        /// <param name="id">The identity of the <see cref="Address{T}"/> that must be removed</param>
        public async Task RemoveAddressAsync(string id)
        {
            var entity = await _context.Set<Address<Student>>().FirstOrDefaultAsync(c => c.Id == id);
            _context.Set<Address<Student>>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a new <see cref="Address{T}"/> to the database
        /// </summary>
        /// <param name="model">The <see cref="AddEditAddressDetailModel"/> model used to add a <see cref="Address{T}"/> from a view</param>
        /// <returns>The added <see cref="Address{T}"/></returns>
        public async Task<Address<Student>> AddAddressAsync(Address<Student> model)
        {
            var otherAddresses = _context.Set<Address<Student>>().Where(c => c.EntityId == model.EntityId);
            var newAddress = new Address<Student>()
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

            _context.Set<Address<Student>>().Add(newAddress);

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
                    _context.Set<Address<Student>>().Update(item);
                }
            }
            await _context.SaveChangesAsync();

            return newAddress;
        }

        /// <summary>
        /// Updates an existing <see cref="Address{T}"/> to the database
        /// </summary>
        /// <param name="model">The <see cref="AddEditAddressDetailModel"/> of the <see cref="Address{T}"/> being updated</param>
        /// <returns>The updated <see cref="Address{T}"/></returns>
        public async Task<Address<Student>> EditAddressAsync(Address<Student> model)
        {
            var address = await _context.Set<Address<Student>>().FirstOrDefaultAsync(c => c.Id == model.Id);
            var otherAddresses = _context.Set<Address<Student>>().Where(c => c.EntityId == model.EntityId).Where(c => c.Id != model.Id); ;

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
            address.Location = new Location()
            {
                Latitude = model.Location.Latitude,
                Longitude = model.Location.Longitude
            };

            if (!otherAddresses.Any() || model.Default)
            {
                address.Default = true;
            }

            _context.Set<Address<Student>>().Update(address);

            if (model.Default)
            {
                foreach (var item in otherAddresses)
                {
                    item.Default = false;
                    _context.Set<Address<Student>>().Update(item);
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

        /// <summary>
        /// Removes a single image
        /// </summary>
        /// <param name="id">The identity of the image that must be removed</param>
        public async Task RemoveImage(string id)
        {
            // Get the file to be deleted
            var file = _context.Set<ImageFile<Student>>().FirstOrDefault(c => c.Id == id);
            await _fileFactory.DeleteImageAndRemoveFormDbAsync<Student>(file);
            _context.SaveChanges();
        }

        #endregion
    }
}
