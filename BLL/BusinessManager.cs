using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;
namespace BLL
{
    public class BusinessManager
    {
       /* public static usermanager GetProduct(int id)
        {
            // return new Product { ID = id, Title = "Gerbera", Description = "wedding Flower", UnitPrice = 6, Quantity = 5000 };
            //  return DBManager.GetByID(id);
            return DBManager.GetByID(id);
        }
       */

     /*   public static List<usermanager> GetAllManagers()
        {
            List<usermanager> allManagers = new List<usermanager>();
            allManagers = DBManager.GetAllManagers();
            return allManagers;
        }

        */
        public static Manager GetManager(int id)
        {
            // return new Product { ID = id, Title = "Gerbera", Description = "wedding Flower", UnitPrice = 6, Quantity = 5000 };
            //  return DBManager.GetByID(id);
            return DBManager.GetByIDM(id);
        }

        public static List<Manager> GetAllManagers()
        {
            List<Manager> allManagers = new List<Manager>();
            allManagers = DBManager.GetAllManagers();
            return allManagers;

            /*  allProducts.Add(new Product { ID = 1, Title = "Gerbera", Description = "Wedding Flower", UnitPrice = 6, Quantity = 5000 });
              allProducts.Add(new Product { ID = 2, Title = "Rose", Description = "Valentine Flower", UnitPrice = 15, Quantity = 7000 });
              allProducts.Add(new Product { ID = 3, Title = "Lotus", Description = "Worship Flower", UnitPrice = 26, Quantity = 0 });
              allProducts.Add(new Product { ID = 4, Title = "Carnation", Description = "Pink carnations signify a mother's love, red is for admiration and white for good luck", UnitPrice = 16, Quantity = 27000 });
              allProducts.Add(new Product { ID = 5, Title = "Lily", Description = "Lilies are among the most popular flowers in the U.S.", UnitPrice = 6, Quantity = 1000 });
              allProducts.Add(new Product { ID = 7, Title = "Daisy", Description = "Give a gift of these cheerful flowers as a symbol of your loyalty and pure intentions.", UnitPrice = 36, Quantity = 159 });
              allProducts.Add(new Product { ID = 8, Title = "Aster", Description = "Asters are the September birth flower and the the 20th wedding anniversary flower.", UnitPrice = 16, Quantity = 67 });
              allProducts.Add(new Product { ID = 9, Title = "Daffodil", Description = "Wedding Flower", UnitPrice = 6, Quantity = 5000 });
              allProducts.Add(new Product { ID = 10, Title = "Dahlia", Description = "Dahlias are a popular and glamorous summer flower.", UnitPrice = 7, Quantity = 0 });
              allProducts.Add(new Product { ID = 11, Title = "Hydrangea", Description = "Hydrangea is the fourth wedding anniversary flower", UnitPrice = 12, Quantity = 0 });
              allProducts.Add(new Product { ID = 12, Title = "Orchid", Description = "Orchids are exotic and beautiful, making a perfect bouquet for anyone in your life.", UnitPrice = 10, Quantity = 700 });
              allProducts.Add(new Product { ID = 13, Title = "Statice", Description = "Surprise them with this fresh, fabulous array of Statice flowers", UnitPrice = 16, Quantity = 1500 });
              allProducts.Add(new Product { ID = 14, Title = "Sunflower", Description = "Sunflowers express your pure love.", UnitPrice = 8, Quantity = 2300 });
              allProducts.Add(new Product { ID = 15, Title = "Tulip", Description = "Tulips are the quintessential spring flower and available from January to June.", UnitPrice = 17, Quantity = 10000 });

              return allProducts;
            */
        }

        public static bool InsertM(Manager newManager)
        {
            return DBManager.InsertM(newManager);
        }

    /*    public static bool UpdateM(Manager newManager)
        {
            return DBManager.UpdateM(newManager);
        }
    */
        public static bool UpdateM(Manager existingManager)
        {
            return DBManager.UpdateM(existingManager);
        }


    }
}
