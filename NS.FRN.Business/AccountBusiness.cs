using NS.FRN.Data.Entities;
using NS.FRN.Models;
using NS.FRN.Repository;
namespace NS.FRN.Business
{
    public class AccountBusiness:IAccountBusiness
    {
        public readonly IAccountRepository _iAccountRepository;
        public AccountBusiness(IAccountRepository iAccountRepository){
            _iAccountRepository=iAccountRepository;
        }
        public List<Role> GetRoles(){
           return  _iAccountRepository.GetRoles();
        }
         public User LoginPage(LoginModel login)
        {
            return _iAccountRepository.LoginPage(login);
        }
         public void AddUser(UserModel UsrDetail){
              _iAccountRepository.AddUser(UsrDetail);
        }
       
    }
}