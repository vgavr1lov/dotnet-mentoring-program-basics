namespace MvcHomeTaskLibrary
{
    public class UnitOfWork : IUnitOfWork
    {
        private NorthwindDbContext DbContext { get; }
        public CategoryRepository CategoryRepository { get; }
        public ProductRepository ProductRepository { get; }
        public SupplierRepository SupplierRepository { get; }
        public UnitOfWork(
            NorthwindDbContext context,
            CategoryRepository categoryRepository,
            ProductRepository productRepository,
            SupplierRepository supplierRepository)
        {
            DbContext = context;
            CategoryRepository = categoryRepository;
            ProductRepository = productRepository;
            SupplierRepository = supplierRepository;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public int Save()
        {
            return DbContext.SaveChanges();
        }
    }
}
