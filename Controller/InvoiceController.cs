using System;
using System.Diagnostics;
using sales_and_inventory.Entity;
using sales_and_inventory.Dao;

namespace sales_and_inventory.Controller
{
    class InvoiceController
    {
        public static Boolean Save(Invoice invoice)
        {
            try
            {
                InvoiceDao.Save(invoice);
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
