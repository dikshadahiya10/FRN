using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NS.FRN.Web.Models;
using NS.FRN.Business;
using NS.FRN.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using NS.FRN.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace NS.FRN.Web.Controllers;


public class FurnitureController : Controller
{
    private readonly ILogger<FurnitureController> _logger;
    private readonly IFurnitureBusiness _iFurnitureBusiness;


    public FurnitureController(ILogger<FurnitureController> logger, IFurnitureBusiness iFurnitureBusiness)
    {
        _logger = logger;
        _iFurnitureBusiness = iFurnitureBusiness;
    }

    // public IActionResult AddtoCart(int id){
    //    using(var context=new FRNDBContext()){
    //     var query=context.Products.Where(x=>x.ProductId==id).SingleOrDefault();
    //     return View(query);
    //    }
    // }

public IActionResult Index()
    {
        var productList = _iFurnitureBusiness.GetProductList();
        // var productList=context.Products.ToList();
        return View(productList);

    }
    public IActionResult ActivateDeactivateRecord(int Id)
    {
        _iFurnitureBusiness.ActivateDeactivateRecord(Id);
        return RedirectToAction(actionName: "ViewProductList", controllerName: "Home");
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
                    Name = data.Name,
                    // IsEligibleForDiscount = data.IsEligibleForDiscount,
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
            return RedirectToAction(actionName: "RoomDetail", controllerName: "Room");
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
                return RedirectToAction(actionName: "RoomDetail", controllerName: "Room");
            }
            return RedirectToAction(actionName: "RoomDetail", controllerName: "Room");
        }
    }
    [Authorize(Roles="2")]
       
    [HttpGet]
    public IActionResult AddToCart(int id)
    {
        var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        CartViewModel cartViewModel = new CartViewModel();
        cartViewModel.ProductId = id;
        cartViewModel.UserId = Convert.ToInt64(userId);
        _iFurnitureBusiness.AddToCart(cartViewModel);
        return RedirectToAction("ViewCart");
    }
    [Authorize(Roles="2")]
    public IActionResult ViewCart()
    {
        long userId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);
        var cartItems = _iFurnitureBusiness.GetCartItems(userId);
        return View(cartItems);
    }
    [Authorize(Roles="2")]
     public IActionResult MyOrders()
     
    { 
        long userId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);
          var myOrders = _iFurnitureBusiness.GetMyOrders(userId);
        return View(myOrders);

    }
   
    [HttpPost]
     public IActionResult BuyNow(List<Cart> cart)
    {
        long userId = Convert.ToInt64(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);
        _iFurnitureBusiness.BuyNow(cart, (int)userId);
       return RedirectToAction ("ViewCart");
    }
    
    // // private class FRNDBContext : IDisposable
    // {
    //     internal readonly IEnumerable<object> Products;
    // }
}