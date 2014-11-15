using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Infrastructure
{
    public class PromotionRepository : RepositoryBase<promotion>,IPromotionRepository
    {
                public PromotionRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

        public void updatePromotion(promotion promotion)
                {

                    promotion exiting = this.DataContext.promotions.Find(promotion.idPromotion);
                    ((IObjectContextAdapter)DataContext).ObjectContext.Detach(exiting);
                    this.DataContext.Entry(promotion).State = EntityState.Modified;


                }
        public promotion getPromotionByID(int idPromotion)
        {
            promotion exiting = this.DataContext.promotions.Find(idPromotion);
           ((IObjectContextAdapter)DataContext).ObjectContext.Detach(exiting);


            return this.DataContext.promotions.Find(idPromotion);
        }

    }
        public interface IPromotionRepository :IRepository <promotion> {
            void updatePromotion(promotion promotion);
            promotion getPromotionByID(int idPromotion);
        
        }
}
