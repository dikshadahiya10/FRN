using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NS.FRN.Business;
using NS.FRN.Data.Entities;
using NS.FRN.Models;
using NS.FRN.Web.Models;

namespace NS.FRN.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public readonly IFurnitureBusiness _iFurnitureBusiness;
    private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;

   
 public HomeController(ILogger<HomeController> logger,Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment,IFurnitureBusiness iFurnitureBusiness)
        {
            _logger = logger;
               Environment = _environment;
          _iFurnitureBusiness=iFurnitureBusiness;
        }
        [Authorize(Roles="1")]
[Authorize(Roles="2")]
    public IActionResult Index()
    {
        return View();
    }
    [Authorize(Roles="1")]
[Authorize(Roles="2")]
     public IActionResult ViewProductList()
    {
       using (var context=new FRNDBContext())
        {
            var productList= _iFurnitureBusiness.GetProductList();
            // var productList=context.Products.ToList();
             return View(productList);
        }
    }
[Authorize(Roles="1")]

    public IActionResult Privacy()
    {
        return View();
    }
    [Authorize(Roles="1")]
    public IActionResult AddFurniture()
    {     ViewBag.CategoryList= _iFurnitureBusiness.GetCategories();
        return View();
    }
    [Authorize(Roles="1")]

    [HttpPost]
    public IActionResult AddFurnitureDetail(Product FrnDetail,IFormFile furniturePhoto)
  {
        string wwwPath = this.Environment.WebRootPath;
        string contentPath = this.Environment.ContentRootPath;
        string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        List<string> uploadedFiles = new List<string>();
        string fileName = Path.GetFileName(furniturePhoto.FileName);
        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
        {
            furniturePhoto.CopyTo(stream);
            uploadedFiles.Add(fileName);
            ViewBag.Message += string.Format("<b>{0}</b> Profile pic uploaded.<br />", fileName);
        }
        // customer.Password=BCrypt.Net.BCrypt.HashPassword(customer.Password);
         FrnDetail.Photo=fileName;
          _iFurnitureBusiness.AddFurnitureDetail(FrnDetail);
     return RedirectToAction(actionName: "Index", controllerName: "Home");
        // return View();
    }
    [HttpGet]
        public IActionResult Editview(int id)
        {
            using (var context = new FRNDBContext())
            {
                var data = context.Products.FirstOrDefault(x => x.Id == id);
                if (data != null)
                {
                    var viewmodel = new Product()
                    {
                        Id = data.Id,
                        Category = data.Category,
                        Price = data.Price,
                        Description = data.Description,
                        Name = data. Name ,
                        // IsEligibleForDiscount  = data. IsEligibleForDiscount ,
                        Photo = data.Photo,
                        // IsActive = data.IsActive,
                        // IsDeleted = data.IsDeleted,
                        // CreatedOn = data.CreatedOn,
                        // CreatedBy = data.CreatedBy,
                        // ModifiedBy = data.ModifiedBy
                        // ModifiedOn = data.ModifiedOn
                        
                    };
                    return View(viewmodel);
                }
                return RedirectToAction(actionName: "ViewProductList", controllerName: "Home");
            }
        }
        [HttpPost]
        public IActionResult Editview(Product model)
        {
            using (var context = new FRNDBContext())
            {
                var data = context.Products.Find(model.Id);
                if (data != null)
                {
                    data.Id = model.Id;
                    data.Name = model.Name;
                    data.Category = model.Category;
                    data.Price = model.Price;
                    data.Photo = model.Photo;
                    data.Description = model.Description;
                    // data.IsEligibleForDiscount = model.IsEligibleForDiscount;
                    context.SaveChanges();
                    return RedirectToAction(actionName: "ViewProductList", controllerName: "Home");
                }
                return RedirectToAction(actionName: "ViewProductList", controllerName: "Home");
            }
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
