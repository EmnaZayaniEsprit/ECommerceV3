using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service
{
    public class UserSupplierService : IUserSupplierService
    {
        static DatabaseFactory dbfactory = new DatabaseFactory();
        UnitOfWork utow = new UnitOfWork(dbfactory);
        public List<user> getAllUser()
        {
            return utow.UserRepository.GetAll().ToList();
        }
    }




    public interface IUserSupplierService
    {


        List<user> getAllUser();
    }

}
