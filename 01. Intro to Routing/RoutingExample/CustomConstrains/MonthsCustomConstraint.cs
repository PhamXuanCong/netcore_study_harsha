using System.Text.RegularExpressions;

namespace RoutingExample.CustomConstrains
{
    public class MonthsCustomConstraint :IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
           //check whether the value exits
           if (!values.ContainsKey(routeKey))
           {
               return false;
           }

           Regex regex = new Regex("^(apr|jul|oct|jan|feb)$");
           string? monthValue = Convert.ToString(values[routeKey]);

           if (regex.IsMatch(monthValue))
           {
               return true;
           }

           return false;
        }
    }
}
