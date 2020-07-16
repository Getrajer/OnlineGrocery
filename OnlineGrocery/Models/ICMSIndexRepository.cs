using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public interface ICMSIndexRepository
    {
        CMSIndexPageModel Update(CMSIndexPageModel pageModel);

        CMSIndexPageModel Add(CMSIndexPageModel pageModel);

        CMSIndexPageModel Get(int Id);
    }
}
