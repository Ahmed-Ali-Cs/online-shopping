namespace online_shopping.Models.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
        void Save();
    }
}
