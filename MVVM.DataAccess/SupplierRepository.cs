using MVVM.DataAccess.Base;
using MVVM.DataAccess.Entities.Models;

namespace MVVM.DataAccess
{
    public class SupplierRepository : RepositoryBase<Supplier>
    {
        public SupplierRepository(NorthwindContext context) : base(context) { }
        public SupplierRepository() : base() { }
    }
}