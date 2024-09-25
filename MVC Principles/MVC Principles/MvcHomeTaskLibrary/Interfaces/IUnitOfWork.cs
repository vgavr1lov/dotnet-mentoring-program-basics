namespace MvcHomeTaskLibrary
{
    public interface IUnitOfWork
    {
        CategoryRepository CategoryRepository { get; }
        ProductRepository ProductRepository { get; }
        SupplierRepository SupplierRepository { get; }
        void Dispose();
        int Save();
    }
}