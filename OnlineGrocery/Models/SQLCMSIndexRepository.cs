using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class SQLCMSIndexRepository : ICMSIndexRepository
    {
        private readonly AppDbContext _context;

        public SQLCMSIndexRepository(AppDbContext context)
        {
            _context = context;
        }

        public CMSIndexPageModel Add(CMSIndexPageModel pageModel)
        {
            _context.IndexPageModel.Add(pageModel);
            _context.SaveChanges();
            return pageModel;
        }

        public CMSIndexPageModel Get(int Id)
        {
            return _context.IndexPageModel.Find(Id);
        }

        public CMSIndexPageModel Update(CMSIndexPageModel pageModel)
        {
            var page = _context.IndexPageModel.Attach(pageModel);
            page.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return pageModel;
        }
    }
}
