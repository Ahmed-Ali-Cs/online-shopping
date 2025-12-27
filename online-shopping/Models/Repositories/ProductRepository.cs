using online_shopping.Models.Data;

namespace online_shopping.Models.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ShoppingDbContext _db;
        public ProductRepository(ShoppingDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Product product)
        {
            _db.Update(product);
        }
    }
}
