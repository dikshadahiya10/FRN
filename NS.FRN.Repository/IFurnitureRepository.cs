using NS.FRN.Data.Entities;

namespace NS.FRN.Repository
{
    public interface IFurnitureRepository
    {
         void AddFurnitureDetail(Product FrnDetail);
            List<Category> GetCategories();
             List<Product> GetProductList();
              bool ActivateDeactivateRecord(int Id);

            bool AddToCart(CartViewModel cartViewModel);
             

List<Cart> GetCartItems(long userId);
  bool BuyNow(List<Cart> cart,long userId);
   List<OrderReceived> GetMyOrders(long userId);
    }
}
