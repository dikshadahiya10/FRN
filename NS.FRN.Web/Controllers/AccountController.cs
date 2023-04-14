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

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly IAccountBusiness _iAccountBusiness;
    

    public AccountController(ILogger<AccountController> logger,IAccountBusiness iAccountBusiness)
    {
        _logger = logger;
        _iAccountBusiness= iAccountBusiness;
    }

    public IActionResult Index()
    {
        return View();
    }
[Authorize(Roles="1")]
    public IActionResult Privacy()
    {
        return View();
    }
    [Authorize(Roles="1")]
     public IActionResult User()
    {
        return View();
    }
  
    public IActionResult Login()
    {
        return View();
    }
     public IActionResult LoginPage(LoginModel login){
            var userDetails=_iAccountBusiness.LoginPage(login);
            if(userDetails!=null )
            {
               
            
                if(BCrypt.Net.BCrypt.Verify(login.Password,userDetails.Password)) 
                {

                    var claims=new Claim[]{new Claim(ClaimTypes.Email,userDetails.Email),
                    new Claim(ClaimTypes.Role,userDetails.RoleId.ToString()),new Claim("UserId",userDetails.Id.ToString()),new Claim(ClaimTypes.Name,userDetails.FirstName)};
                    var identity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(identity));
                    if( userDetails.RoleId==1)
                    {
                        return RedirectToAction("ViewProductList","Home");
                    }
                    else{
                        return RedirectToAction("Index","Furniture");
                    }
               
                }
                else{
                ViewData["Errormsg"]="Incorrect Password";
                return View("Login");
                 }
             
             }
               
        return View();
    }
   
    public IActionResult LogOut()
    {
        HttpContext.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }
  [Authorize(Roles="1")]
    public IActionResult UserDetails(){
      using(var context=new FRNDBContext()){
        var userDetails=context.Users.ToList();
        return View(userDetails);
      }
    }

   public IActionResult AddUsers(UserModel UsrDetail)
    {     UsrDetail.Password=BCrypt.Net.BCrypt.HashPassword(UsrDetail.Password);
         _iAccountBusiness.AddUser(UsrDetail);
     return RedirectToAction(actionName: "login", controllerName: "Account");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
