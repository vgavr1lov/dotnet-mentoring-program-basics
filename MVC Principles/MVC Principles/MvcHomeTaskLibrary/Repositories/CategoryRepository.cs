using MvcHomeTaskLibrary.Models;

namespace MvcHomeTaskLibrary
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(NorthwindDbContext context) : base(context) { }
    }
}
