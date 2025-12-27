using online_shopping.Models.Repositories;

namespace online_shopping.Models.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IProductRepository Product { get;}
        void Save();
    }
}
