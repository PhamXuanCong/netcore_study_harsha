using Microsoft.AspNetCore.Mvc;
using RoutingExample.Model;
using System.Net;

namespace RoutingExample.Controllers
{
    public class HomeController : Controller
    {

        [Route("register")]
        public IActionResult RegisterResult(Person person)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).
                    Select(err => err.ErrorMessage));

                return BadRequest(errors);
            }
            return Content($"{person}");
        }

        [Route("bookstore/{isloggedin?}/{bookid?}")]
        //Url: /bookstore?bookid=10&isloggedin=true
        public IActionResult Book([FromQuery]int? bookid, [FromRoute]bool? isloggedin, Book book)
        {
            //Book id should be applied
            if (bookid.HasValue == false)
            {
                Response.StatusCode = 400;
                return BadRequest("book id is not suplied");
            }

            //Book id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                Response.StatusCode = 400;
                return BadRequest("Book id can't be null or empty");
            }

            //Book id should be between 1 to 1000
            if (bookid <= 0)
            {
                Response.StatusCode = 400;
                return BadRequest("Book id can't be less than or equal to zero");
            }

            if (bookid > 1000)
            {
                Response.StatusCode = 400;
                return NotFound("Book id can't be greater than 1000");
            }

            if (isloggedin == false)
            {
                Response.StatusCode = 401;
                return StatusCode(401);
            }

            //return File("testpdf.pdf", "application/pdf");
            //return new LocalRedirectResult($"/store/books/{bookId}", false);
            return Content($"Book id : {bookid} , Book: {book}", "text/plain");
        }

        [Route("bookstore1/{islogin?}/{bookid?}")]
        public IActionResult Book1(Book1 book)
        {
            return Content($"Book : {book}", "text/plain");
        }

        [Route("test")]
        public IActionResult Test()
        {
            return new LocalRedirectResult($"/about", false);
        }

        //isloggedin should be true


        [Route("home")]
        [Route("/")]
        public ContentResult Index()
        {
            return Content("<h1>Welcome</h1> <h2>Hello from Index</h2>", "text/html");
        }

        [Route("about")]
        public ContentResult About()
        {
            return Content("<h1>Welcome</h1> <h2>Hello from about</h2>", "text/html");
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "cong",
                LastName = "deptrai",
                Age = 25
            };

            return Json(person);
        }

        [Route("file-download")]
        public VirtualFileResult FileDowload()
        {
            return File("/test.jpg", "appliaction/jpg");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            return PhysicalFile(@"D:\Ebook\biquettruongtho.pdf", "application/pdf");
        }

        [Route("file-download3")]
        public FileContentResult FileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"D:\Ebook\biquettruongtho.pdf");

            return File(bytes, "appliaction/pdf");
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        public ContentResult Contact()
        {
            return Content("", "text/html");
        }
    }
}
