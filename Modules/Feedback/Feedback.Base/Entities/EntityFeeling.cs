using Feedback.Base.Enums;
using Identity.Base.Entities;
using Iqt.Base.BaseTypes;

namespace Feedback.Base.Entities
{
    public class EntityFeeling : EntityBase
    {
        public string UserId { get; set; }
        public UserInfo User { get; set; }

        public Feeling Feeling { get; set; }

    }
}
