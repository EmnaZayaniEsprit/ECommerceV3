using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service
{
    public class PictureService : IPictureService
    {
        static DatabaseFactory dbfactory = new DatabaseFactory();
        UnitOfWork utow = new UnitOfWork(dbfactory);

        public void addPicture(picture picture)
        {
            utow.PictureRepository.Add(picture);
            utow.Commit();

        }
       

    }
    public interface IPictureService
    {
        void addPicture(picture picture);

        
    }
}
