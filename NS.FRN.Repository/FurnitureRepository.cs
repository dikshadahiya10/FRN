using Microsoft.EntityFrameworkCore;
using NS.FRN.Data.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NS.FRN.Repository
{
    public class FurnitureRepository : IFurnitureRepository
    {
         private readonly FRNDBContext _context;
        public FurnitureRepository(FRNDBContext context)
        {
            _context = context;
        }
        private object item;

        public void AddFurnitureDetail(Product FrnDetail)
        {
            
                Product FrnInfo = new Product();
                FrnInfo.Category = FrnDetail.Category;
                FrnInfo.Name = FrnDetail.Name;
                FrnInfo.Price = FrnDetail.Price;
                FrnInfo.Description = FrnDetail.Description;
                // FrnInfo.IsEligibleForDiscount = FrnDetail.IsEligibleForDiscount;
                FrnInfo.Photo = FrnDetail.Photo;
                // FrnInfo.IsActive=true;
                //  FrnInfo.IsDeleted=false;
                FrnInfo.CreatedOn = DateTime.Now;
                FrnInfo.CreatedBy = 1;


                _context.Add(FrnInfo);
                _context.SaveChanges();
            

        }

        public List<Category> GetCategories()
        {
           
                var categoryList = _context.Categories.ToList();
                return categoryList;
            
        }

        public List<Product> GetProductList()
        {
          
                return _context.Products.ToList();
            
        }
        public bool ActivateDeactivateRecord(int Id)
        {
            var candidateRecord = _context.Products.FirstOrDefault(x => x.Id == Id);
            if (candidateRecord != null)
            {
                candidateRecord.IsActive = !candidateRecord.IsActive;
                _context.SaveChanges();
            }
            return true;
        }
        public bool AddToCart(CartViewModel cartViewModel)
        {
           
                Cart cart = new Cart();
                cart.ProductId = cartViewModel.ProductId;
                cart.UserId = cartViewModel.UserId;
                cart.Quantity = 1;
                cart.CreatedOn = DateTime.UtcNow;
                cart.CreatedBy = cartViewModel.Id;
               _context.Carts.Add(cart);
                _context.SaveChanges();
            
            return true;
        }
        public List<Product> GetProductByCategoryId(int categoryId)
        {
            List<Product> productList = new List<Product>();
         
                if (categoryId > 0)
                {
                    productList = _context.Products.Where(x => x.Category == categoryId).ToList();
                }
                else
                {
                    productList = _context.Products.ToList();
                }
                return productList;
            
        }
        public List<Cart> GetCartItems(long userId)
        {
            
                var cartItems = _context.Carts.Include("Product").Include("User").Where(x => x.UserId == userId && x.IsDeleted==false).ToList();
                return cartItems;
            
        }
        public bool BuyNow(List<Cart> cart, long userId)
        {
            long totalAmount = 0;
            foreach (var item in cart)
            {
                totalAmount += item.Quantity * (Convert.ToInt64(item.Product.Price));
            }

          
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.BillValue = totalAmount;
                orderDetail.PaymentModeId = 1;
                orderDetail.IsActive = true;
                orderDetail.IsDeleted = false;
                orderDetail.CreatedOn = DateTime.Now;
                orderDetail.CreatedBy = userId;
                // OrderReceived orderReceived= new OrderReceived();
                //  orderReceived.
                _context.Add(orderDetail);
                _context.SaveChanges();
                AddOrderReceived(cart, userId, orderDetail);

            
            return true;
        }


        private void AddOrderReceived(List<Cart> cart, long userId, OrderDetail orderDetail)
        {
            
             List<OrderReceived>orderReceiveds=new List<OrderReceived>();
                foreach (var item in cart)
                {


                    OrderReceived orderReceived = new OrderReceived();

                    orderReceived.OrderDetailId = orderDetail.Id;
                    orderReceived.ProductId = (int)item.Product.Id;
                    orderReceived.UserId = (int)userId;
                    orderReceived.Price = item.Product.Price;
                    orderReceived.Quantity = item.Quantity;
                    orderReceived.IsActive = true;
                    orderReceived.IsDeleted = false;
                    orderReceived.CreatedOn = DateTime.Now;
                    orderReceived.CreatedBy = userId;
                   orderReceiveds.Add(orderReceived);
                }
                //  context.OrderReceived.Add(orderReceiveds);
                  _context.OrderReceiveds.AddRange(orderReceiveds);
                    _context.SaveChanges();
                     DeleteCartItems(cart);
            
        }
          public void DeleteCartItems(List<Cart> cart)
          {
              
                 foreach (var cartItems in cart)
    {    var item = _context.Carts.Find(cartItems.Id);
       item.IsDeleted=true;
       _context.Carts.Update(item);
       _context.SaveChanges();
    }
   
               
          }
            public List<OrderReceived> GetMyOrders(long userId)
        {
           
                var MyOrderList = _context.OrderReceiveds.Include(x=> x.OrderDetail).Include(x=> x.Product).Where(x=>x.UserId==userId).ToList();
                return MyOrderList;
            
        }
      
    }
}


