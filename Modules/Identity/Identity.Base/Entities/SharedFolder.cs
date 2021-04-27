using Iqt.Base.BaseTypes;

namespace Identity.Base.Entities
{
    public class SharedFolder : EntityBase
    {
        public string RootPath { get; set; }
        public string FolderName { get; set; }
        public string FolderPath { get; set; }

        public string SharerId { get; set; }
        public ApplicationUser Sharer { get; set; }

        public string SharedWithId { get; set; }
        public ApplicationUser SharedWith { get; set; }

        public string SharedWithAddress { get; set; }

        public bool IsFile { get; set; }
    }
}
