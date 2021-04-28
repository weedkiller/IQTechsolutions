using System.Collections.Generic;
using Identity.Base.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Syncfusion.EJ2.FileManager.Base;

namespace Olympia.Web.Site.Models
{
    public class ShareFileFolderModel
    {
        public string FolderPath { get; set; }

        public List<SharedFolder> SelectedFiles { get; set; } = new List<SharedFolder>();
        public SelectList Employees { get; set; }

        public string SelectedEmployee { get; set; }

        public string EmailAddress { get; set; }
            
    }

    public class SelectedFile
    {
        public FileManagerDirectoryContent[] data { get; set; }
    }
}
