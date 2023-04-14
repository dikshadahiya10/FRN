using NS.FRN.Data.Entities;
using NS.FRN.Models;

namespace NS.FRN.Repository
{
    public interface IAccountRepository
    {
        List<Role> GetRoles();
         User LoginPage(LoginModel login);
        
       void AddUser(UserModel UsrDetail);
              

       
    }
}