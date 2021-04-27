using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Metsi.Web.Site.Helpers
{
    public static class HtmlHelpers
    {
        public static string IsActive(this IHtmlHelper htmlHelper, string areas, string controllers, string actions, string cssClass = "active")
        {
            string currentAction = htmlHelper.ViewContext.RouteData.Values["action"] as string;
            string currentController = htmlHelper.ViewContext.RouteData.Values["controller"] as string;
            string currentArea = htmlHelper.ViewContext.RouteData.Values["area"] as string;

            IEnumerable<string> acceptedActions = (actions ?? currentAction).Split(',');
            IEnumerable<string> acceptedControllers = (controllers ?? currentController).Split(',');
            IEnumerable<string> acceptedAreas = (areas ?? currentArea).Split(',');

            var ooo = String.Empty;

            if (string.IsNullOrEmpty(currentArea))
            {
                ooo = acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController) && acceptedAreas.Contains("") ? cssClass : String.Empty; ;
            }
            else
            {
                ooo = acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController) && acceptedAreas.Contains(currentArea) ?
                    cssClass : String.Empty;
            }

            return ooo;
        }
    }
}
