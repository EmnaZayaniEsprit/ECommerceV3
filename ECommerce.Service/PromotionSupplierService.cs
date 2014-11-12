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
    }




    public interface IPromotionSupplierService
    {


        List<promotion> getAllPromotion();
    }

}

