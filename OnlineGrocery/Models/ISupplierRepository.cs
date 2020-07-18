using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public interface ISupplierRepository
    {
        public SuppliersModel GetSupplier(int Id);

        public IEnumerable<SuppliersModel> ReturnSuppliers();

        public SuppliersModel AddSupplier(SuppliersModel model);

        public SuppliersModel EditSupplier(SuppliersModel model);

        public SuppliersModel DeleteSupplier(int Id);
    }
}
