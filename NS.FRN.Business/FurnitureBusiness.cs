using NS.FRN.Data.Entities;
using NS.FRN.Repository;

namespace NS.FRN.Business
{
    public class FurnitureBusiness:IFurnitureBusiness
    {
        public readonly IFurnitureRepository _iFurnitureRepository;
        public FurnitureBusiness(IFurnitureRepository iFurnitureRepository){
           _iFurnitureRepository=iFurnitureRepository;
        }
        public void AddFurnitureDetail(Product FrnDetail){
              _iFurnitureRepository.AddFurnitureDetail(FrnDetail);
        }
          public List<Category> GetCategories()
        {
            return  _iFurnitureRepository.GetCategories();
        }
        public List<Product> GetProductList()
        {
            return _iFurnitureRepository.GetProductList();
        }
         public bool ActivateDeactivateRecord(int Id)
        {
            return _iFurnitureRepository.ActivateDeactivateRecord(Id);
        }
       public bool AddToCart(CartViewModel cartViewModel){
        return _iFurnitureRepository.AddToCart(cartViewModel);
       }
              public List<Cart> GetCartItems(long userId){
            return _iFurnitureRepository.GetCartItems((int)userId);
         }
        public bool BuyNow(List<Cart> cart,long userId)
        {
            return _iFurnitureRepository.BuyNow(cart, userId);
        }
    public List<OrderReceived> GetMyOrders(long userId)
        {
          
                return _iFurnitureRepository.GetMyOrders(userId);
            }
        
       
    }
    }
