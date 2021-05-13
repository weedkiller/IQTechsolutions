using System.Collections.Generic;
using System.ComponentModel;
using Filing.Base.Entities;
using Iqt.Base.Entities;
using Iqt.Base.Enums.Personal;

namespace Identity.Base.Entities
{
    public class UserInfo : ImageFileCollection<UserInfo>
    {
        public Title Title { get; set; } = Title.Me;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string IdentityNr { get; set; }

        public Gender Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        
        [DisplayName("Mood Status")]
        public string MoodStatus { get; set; }

        [DisplayName("About Me")]
        public string Description { get; set; }

        public bool ReceiveNotifications { get; set; }
        public bool ReceiveNewsletters { get; set; }
        public bool ShowContactInfo { get; set; }
        
        public string StudentId { get; set; }

        public string EmployeeId { get; set; }
        
        public ICollection<ContactNumber<UserInfo>> ContactNumbers { get; set; } = new List<ContactNumber<UserInfo>>();
        public ICollection<EmailAddress<UserInfo>> EmailAddresses { get; set; } = new List<EmailAddress<UserInfo>>();
        public ICollection<Address<UserInfo>> Addresses { get; set; } = new List<Address<UserInfo>>();

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
