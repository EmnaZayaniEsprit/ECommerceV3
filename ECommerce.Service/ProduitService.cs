
using ECommerce.Data.Infrastructure;
using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service
{
    public class ProduitService
    {
        //static IDatabaseFactory dbFact = new DatabaseFactory();
        //IUnitOfWork utOfW = new UnitOfWork(dbFact);

        static IDatabaseFactory dbFact = dbFact = new DatabaseFactory();
       IUnitOfWork utOfW = new UnitOfWork(dbFact);



        public ProduitService()
        {
            
            
        }


        public List<product> displayAllproducts()
        {

            return utOfW.ProductRepository.GetAll().ToList();
        }



        public virtual IList<product> findproductByCategorie(long idCategory)
        {

            return utOfW.ProductRepository.GetMany(p => p.category.idCategory == (int)idCategory).ToList();
        }


        public virtual IList<product> findproductbyName(string productName)
        {

            return utOfW.ProductRepository.GetMany(p => p.name.Equals(productName)).ToList();
        }


        public virtual IList<product> findproductByPriceInterval(float priceDebut, float priceFin)
        {

            return utOfW.ProductRepository.GetMany(p => p.price >= priceDebut && p.price <= priceFin).ToList();
        }


        public virtual IList<product> findproductInDiscount()
        {

            return utOfW.ProductRepository.GetMany(p => p.promotion != null).ToList();
        }



        public virtual IList<product> findproductByAllCriteria(long idCategory, string productName, float priceDebut, float priceFin, bool inDiscount)
        {


            IList<product> resultatRecherche = new List<product>();
            resultatRecherche = displayAllproducts();

            if (idCategory == 99)
            {
                inDiscount = true;
            }
            else
            {
                inDiscount = false;
            }




            if (idCategory != 100 || idCategory != 99)
            {
                resultatRecherche = intersection(resultatRecherche, findproductByCategorie(idCategory));
            }
            


                if (!productName.Equals("All Products"))
                {
                    resultatRecherche = intersection(resultatRecherche, findproductbyName(productName));

                }
               
                    if (priceDebut >= 0 && priceFin > priceDebut)
                    {
                        resultatRecherche = intersection(resultatRecherche, findproductByPriceInterval(priceDebut, priceFin));

                    }
                    



                        if (inDiscount == true)
                        {
                            resultatRecherche = intersection(resultatRecherche, findproductInDiscount());

                        }


            return resultatRecherche;
        }



        public static IList<product> intersection(IList<product> list1, IList<product> list2)
        {
            IList<product> list = new List<product>();


            foreach (product p in list1)
            {
                if (list2.Contains(p))
                {
                    list.Add(p);
                }
            }


            return list;
        }


        public void addCommand(order myOrder)
        {
            utOfW.OrderRepository.Add(myOrder);
            utOfW.Commit();
        }

    }
}