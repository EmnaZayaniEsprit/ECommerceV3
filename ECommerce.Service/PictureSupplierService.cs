using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service
{
   public class PictureSupplierService:IPictureSupplierService
    {
        static DatabaseFactory dbfactory = new DatabaseFactory();
        UnitOfWork utow = new UnitOfWork(dbfactory);
        public List<picture> getAllPicture()
        {
            return utow.PictureRepository.GetAll().ToList();
        }
        public picture getPictureRepositoryById(int idPicture)
        {
            return utow.PictureRepository.getPictureByID(idPicture);
        }
    }


    public interface IPictureSupplierService
    {

        picture getPictureRepositoryById(int idPicture);
        List<picture> getAllPicture();
    }

}

