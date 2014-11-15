using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Infrastructure
{
   public class PictureRepository : RepositoryBase <picture>,IPictureRepository
    {
                public PictureRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
                public picture getPictureByID(int idPicture)
                {

                    ecommerceContext context = new ecommerceContext ();
                   return context.pictures.Find(idPicture);

                     //   return this.DataContext.pictures.Find(idPicture);

                    
                    //picture exiting = this.DataContext.pictures.Find(idPicture);
                    //((IObjectContextAdapter)DataContext).ObjectContext.Detach(exiting);
                  //  return this.DataContext.pictures.Find(idPicture);
                }

    }
    public interface IPictureRepository : IRepository <picture>{

        picture getPictureByID(int idPicture);
    
    }
}
