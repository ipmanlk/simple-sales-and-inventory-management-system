namespace sales_and_inventory.Entity
{
    class User
    {
       public int id { get; set; }
       public string username { get; set; }
       public string password { get; set; }
       public string name { get; set; }
       public string nic { get; set; }
       public string mobile { get; set; }
        public string email { get; set; }
       public byte[] photo { get; set; }
       public string registeredDate { get; set; }
    }
}
