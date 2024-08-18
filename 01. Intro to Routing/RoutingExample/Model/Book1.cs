using Microsoft.AspNetCore.Mvc;

namespace RoutingExample.Model
{
    public class Book1
    {
        [FromQuery]
        public int? BookId { get; set; }
        [FromRoute]
        public bool? IsLogin { get; set; }

        public override string ToString()
        {
            return $"Book object - Book id: {BookId}, Author: {IsLogin}";
        }
    }
}
