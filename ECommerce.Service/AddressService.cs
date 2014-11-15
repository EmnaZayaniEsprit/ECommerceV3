using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service
{
    public class AddressService : IAddressService
    {
        static DatabaseFactory dbfactory = new DatabaseFactory();
        UnitOfWork utow = new UnitOfWork(dbfactory);

        public void addAddress(address address)
        {
            utow.AddressRepository.Add(address);
            utow.Commit();
        }

        public void updateAddress(address address)
        {
            utow.AddressRepository.updateAddress(address);
            utow.Commit();
        }

        public address getAddressByUser(user user)
        {
            int id = user.idUser;
            return utow.AddressRepository.GetMany(a => a.user_idUser == id).Single();
            
        }

    }

    public interface IAddressService
    {
        void addAddress(address address);
        void updateAddress(address address);
        address getAddressByUser(user user);

    }
}
