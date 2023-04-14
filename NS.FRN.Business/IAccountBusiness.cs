using NS.FRN.Data.Entities;
using NS.FRN.Models;

namespace NS.FRN.Business
{
    public interface IAccountBusiness
    {
        List<Role> GetRoles();
        User LoginPage(LoginModel login);
         void AddUser(UserModel UsrDetail);
       
    }

}