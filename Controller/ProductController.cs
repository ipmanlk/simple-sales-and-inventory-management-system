using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sales_and_inventory.Dao;
using sales_and_inventory.Entity;

namespace sales_and_inventory.Controller
{
    class ProductController
    {
        public static DataTable GetAll()
        {
            return ProductDao.GetAll();
        }

        public static Product getOne(int id)
        {
            return ProductDao.GetOne(id);
        }
    }
}
