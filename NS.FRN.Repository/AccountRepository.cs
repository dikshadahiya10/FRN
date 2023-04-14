using NS.FRN.Data.Entities;
using NS.FRN.Models;

namespace NS.FRN.Repository
{

    public class AccountRepository : IAccountRepository
    {
        private readonly FRNDBContext _context;
        public AccountRepository(FRNDBContext context)
        {
            _context = context;
        }

        public List<Role> GetRoles()
        {

            List<Role> userlist = new List<Role>();
           
                userlist = _context.Roles.ToList();
            
            return userlist;

        }
        public void AddUser(UserModel UsrDetail)
        {
          
                User FrnInfo = new User();
                FrnInfo.Id = UsrDetail.Id;
                FrnInfo.FirstName = UsrDetail.FirstName;
                FrnInfo.LastName = UsrDetail.LastName;
                FrnInfo.RoleId = Convert.ToInt64(Common.Roles.User);
                FrnInfo.Age = UsrDetail.Age;
                FrnInfo.Address = UsrDetail.Address;
                FrnInfo.City = UsrDetail.CityId;
                FrnInfo.State = UsrDetail.StateId;
                FrnInfo.Country = UsrDetail.CountryId;
                FrnInfo.Pincode = UsrDetail.Pincode;
                FrnInfo.Email = UsrDetail.Email;
                FrnInfo.Password = UsrDetail.Password;
                FrnInfo.PhoneNo = UsrDetail.MoboileNo;
                FrnInfo.ProfilePic = String.Empty;
                // FrnInfo.IsActive=true;
                //  FrnInfo.IsDeleted=false;
                FrnInfo.CreatedOn = DateTime.Now;
                FrnInfo.CreatedBy = 1;


                _context.Add(FrnInfo);
                _context.SaveChanges();
        

        }
        public User LoginPage(LoginModel login)
        {
            // using (var context = new FRNDBContext())
            // {
                return _context.Users.Where(x => x.Email == login.Email).FirstOrDefault();
         

        }


    }
}