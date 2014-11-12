using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service
{
    public class CategorySupplierService: ICategorySupplierService
    {
 static DatabaseFactory dbfactory = new DatabaseFactory();
        UnitOfWork utow = new UnitOfWork(dbfactory);
 public List<category> getAllCategory()
        {
            return utow.CategoryRepository.GetAll().ToList();
        }
    }



   
    public interface ICategorySupplierService
    {
       

       List<category> getAllCategory();
    }
    
}
