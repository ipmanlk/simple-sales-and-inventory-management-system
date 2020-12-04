using System;
using System.Data;
using System.Diagnostics;
using sales_and_inventory.Dao;
using sales_and_inventory.Entity;

namespace sales_and_inventory.Controller
{
    class ProductController
    {
        public static Product GetOne(int id)
        {
            try
            {
                return ProductDao.GetOne(id);
            } catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new Product();
            }
        }
        
        public static DataTable GetAll()
        {
            try
            {
                return ProductDao.GetAll();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new DataTable();
            }
        }

        public static Boolean Save(Product product)
        {
            try
            {
                ProductDao.Save(product);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public static Boolean Update(Product product)
        {
            try
            {
                ProductDao.Update(product);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public static Boolean Delete(int id)
        {
            try
            {
                ProductDao.Delete(id);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}
