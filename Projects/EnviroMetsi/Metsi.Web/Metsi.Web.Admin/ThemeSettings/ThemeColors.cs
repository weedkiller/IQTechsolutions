using Calendar.Base.Enums;
using Iqt.Base.Enums;

namespace Metsi.Web.Admin.ThemeSettings
{
    public static class ThemeColors
    {
        public static string GetDragableTaskColor(Priority priority)
        {
            switch (priority)
            {
                case Priority.High:
                    return "bg-red";
                case Priority.Medium:
                    return "bg-orange";
                case Priority.Low:
                    return "bg-purple";
                case Priority.Optional:
                    return "bg-blue";
                default:
                    return "";
            }
        }
    }
}
