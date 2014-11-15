using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service
{
    public class PromotionSupplierService : IPromotionSupplierService
    {
        static DatabaseFactory dbfactory = new DatabaseFactory();
        UnitOfWork utow = new UnitOfWork(dbfactory);
        public List<promotion> getAllPromotion()
        {
            return utow.PromotionRepository.GetAll().ToList();
        }

        public void addPromotion(promotion promotion)
        {
            utow.PromotionRepository.Add(promotion);
            utow.Commit();
        }

        public void updatePromotion(promotion promotion)
        {
            utow.PromotionRepository.updatePromotion(promotion);
            //utow.PromotionRepository.Update(promotion);
            utow.Commit();
        }

        public void deletePromotion(promotion promotion)
        {
            utow.PromotionRepository.Delete(promotion);
            utow.Commit();

        }

        public promotion getPromotionRepository(int idPromotion)
        {
            return utow.PromotionRepository.getPromotionByID(idPromotion);
           
        }
         public promotion getPromotionById(int idPromotion)
        {
            return utow.PromotionRepository.GetById(idPromotion);
            
        }
         public List<promotion> getManyPromotion(int idUser)
         {
             return utow.PromotionRepository.GetMany(p => p.idUser == idUser).ToList();



         }
        
    }



     
    public interface IPromotionSupplierService
    {
        void addPromotion(promotion promotion);
        void updatePromotion(promotion promotion);
        void deletePromotion(promotion promotion);
        promotion getPromotionById(int idPromotion);

        promotion getPromotionRepository(int idPromotion);
        List<promotion> getAllPromotion();
        List<promotion> getManyPromotion(int idUser);
    }

}

