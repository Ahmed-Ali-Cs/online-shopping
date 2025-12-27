using online_shopping.Models.Data;
using online_shopping.Models.Repositories;

namespace online_shopping.Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingDbContext db;

        public IProductRepository Product { get; private set; }
        public UnitOfWork(ShoppingDbContext db)
        {
            this.db = db;
            Product=new ProductRepository(db);
        }
    }
}
