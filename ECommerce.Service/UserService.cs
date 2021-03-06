﻿using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service
{
    public class UserService : IUserService
    {
        static DatabaseFactory dbfactory = null;
        UnitOfWork utow = null;
        public UserService()
        {  dbfactory = new DatabaseFactory();
           utow = new UnitOfWork(dbfactory);
        }
      
        public bool LoginExists(string login)
        {
            
            user user = utow.UserRepository.Get( u=> u.login == login);

            if (user == null)
            {

                return false;

              
            }
            else return true;

        }
      
        public Object AutentificationUser(string login, string password)
        {
            Object qs = null;
            IEnumerable<user> users = utow.UserRepository.GetAll();

            if (qs == null)
            {

                try
                {
                    qs = (user)(from usr in users where usr.login == login && usr.password == password select usr).Single();

                }
                catch (System.InvalidOperationException e)
                {

                }
            }
            
            
            return qs;
        }
       
        public void addUser(user user)

        {
            utow.UserRepository.Add(user);
         utow.Commit();
         
        }

        public void updateUser(user user)
        { 
            utow.UserRepository.updateUser(user);
            utow.Commit();
        }


        public IEnumerable<user> getAllUsers()
        {
            return utow.UserRepository.GetAll().ToList();
        }


        public user getUser(int id)
        {
            return utow.UserRepository.GetById(id);
        }

        //public IEnumerable<user> getUsersByType(string type)
        //{
        //    return utow.UserRepository.GetMany(u => u.DTYPE == type);
        //}


        public void deleteUser(user user)
        {
            utow.UserRepository.Delete(user);
            utow.Commit();
        }
    }
    public interface IUserService 
    {
        void addUser(user user);
        user getUser(int id);
        void updateUser(user user);
        void deleteUser(user user);

        bool LoginExists(string login);
        Object AutentificationUser(string login, string password);
       // IEnumerable<user> getUsersByType(string type);
        IEnumerable<user> getAllUsers();

    }

    
}
