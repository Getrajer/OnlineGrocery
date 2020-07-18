using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class SQLSuppliersRepository : ISupplierRepository
    {
        private readonly AppDbContext _context;

        public SQLSuppliersRepository(AppDbContext context)
        {
            _context = context;
        }

        public SuppliersModel AddSupplier(SuppliersModel model)
        {
            _context.Suppliers.Add(model);
            _context.SaveChanges();
            return model;
        }

        public SuppliersModel DeleteSupplier(int Id)
        {
            SuppliersModel supplier = _context.Suppliers.Find(Id);

            if(supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }

            return supplier;
        }

        public SuppliersModel EditSupplier(SuppliersModel model)
        {
            var supplier = _context.Suppliers.Attach(model);
            supplier.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return model;
        }

        public SuppliersModel GetSupplier(int Id)
        {
            return _context.Suppliers.Find(Id);
        }

        public IEnumerable<SuppliersModel> ReturnSuppliers()
        {
            return _context.Suppliers;
        }
    }
}
