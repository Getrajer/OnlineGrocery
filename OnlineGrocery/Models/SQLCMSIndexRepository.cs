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

        public CMSIndexPageModel Update(CMSIndexPageModel pageModel)
        {
            var page = _context.IndexPageModel.Attach(pageModel);
            page.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return pageModel;
        }
    }
}
