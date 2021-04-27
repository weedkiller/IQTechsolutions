using System.Collections.Generic;
using Iqt.Calender.Entities;
using Iqt.Gallery.Entities;
using IQTechSolutions.Base.Models;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Gallery.Models
{
    public class KlsmPhotoAlbumIndexModel : IndexModelBase<PhotoAlbum>
    {
        public KlsmPhotoAlbumIndexModel(ICollection<PhotoAlbum> collection, int? size = null, int? page = null) : base(collection, size, page)
        {
        }

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
