using MvcHomeTaskLibrary.Models;

namespace MvcHomeTaskLibrary
{
    public class SupplierRepository : GenericRepository<Supplier>
    {
        public SupplierRepository(NorthwindDbContext context) : base(context) { }
    }
}
