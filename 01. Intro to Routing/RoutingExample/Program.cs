
using RoutingExample.CustomModelBinders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//builder.Services.AddControllers(options =>
//{
//    options.ModelBinderProviders.Insert(0, new PersonBinderProvider());
//}); //adds all the controller classes as services
//builder.Services.AddControllers().AddXmlSerializerFormatters();

var app = builder.Build();

#region Code old

//var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
//{
//    WebRootPath = "myroot"
//});

////builder.Services.AddRouting(options =>
////{
////    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraint));
////});

//var app = builder.Build();

//app.UseStaticFiles();
//app.UseStaticFiles(new StaticFileOptions()
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "mywebroot"))
//});

////enable routing
//app.UseRouting();
//creating endpoints
//app.UseEndpoints(endpoints =>
//{
//    #region Code cu

//    //  //add your endpoints here
//    //  endpoints.MapGet("map1", async (context) =>
//    //  {
//    //      await context.Response.WriteAsync("In Map 1");
//    //  });

//    //  endpoints.MapGet("cong", async (context) =>
//    //  {
//    //      await context.Response.WriteAsync("cong dep trai");
//    //  });

//    //endpoints.MapPost("map2", async (context) =>
//    //  {
//    //      await context.Response.WriteAsync("In Map 2");
//    //  });

//    //Eg: files/sample.txt
//    //endpoints.Map("files/{filename}.{extension}",async (context) =>
//    //{
//    //    string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
//    //    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

//    //    await context.Response.WriteAsync($"In files - {filename} - {extension}");
//    //});

//    ////Eg: employee/profile/john
//    //endpoints.Map("employee/profile/{EmployeeName:length(4,7):alpha=cong}", async context =>
//    //{
//    //    string? employName = Convert.ToString(context.Request.RouteValues["EmployeeName"]);
//    //    await context.Response.WriteAsync($"In Employee profile - {employName}");
//    //});

//    ////Eg: products/details/1
//    //endpoints.Map("products/details/{id:int:range(1,100)?}", async context =>
//    //{
//    //    if (context.Request.RouteValues.ContainsKey("id"))
//    //    {
//    //        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
//    //        await context.Response.WriteAsync($"Products details - {id}");
//    //    }
//    //    else
//    //    {
//    //        await context.Response.WriteAsync($"Product details - id is not supplied");
//    //    }

//    //});

//    ////Eg: daily-digest-report/{reportdate}
//    //endpoints.Map("daily-digest-report/{reportdate:datetime}", async context =>
//    //{
//    //    DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
//    //    await context.Response.WriteAsync($"In daily-digest-report - {reportDate.ToShortDateString()}");
//    //});

//    ////Eg: cities/cityid
//    //endpoints.Map("cities/{city:guid}", async context =>
//    //{
//    //    Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"]));
//    //    await context.Response.WriteAsync($"City information - {cityId}");
//    //});

//    ////sales-report/2030/apr
//    //endpoints.Map("sales-report/{year:int:min(1900)}/{month:months}", async context =>
//    //{
//    //    int year = Convert.ToInt32(context.Request.RouteValues["year"]);
//    //    string? month = Convert.ToString(context.Request.RouteValues["month"]);

//    //    if (month == "apr" || month == "jul" || month == "oct" || month == "jan")
//    //    {
//    //        await context.Response.WriteAsync($"sales report - {year} - {month}");
//    //    }
//    //    else
//    //    {
//    //        await context.Response.WriteAsync($"{month} is not allowed for sales report");
//    //    }
//    //});

//    //endpoints.Map("sales-report/2024/jan", async context =>
//    //{
//    //    await context.Response.WriteAsync("Sales report exclusively for 2024 - jan");
//    //});

//    #endregion

//    endpoints.Map("/files/", async context =>
//    {
//        await context.Response.WriteAsync("Hello");
//    });
//});


//app.Run(async context =>
//{
//    await context.Response.WriteAsync($"No route matched at {context.Request.Path}");
//});

#endregion

#region Controller

app.UseRouting();
#endregion

app.UseStaticFiles();
app.MapControllers();
app.Run();
