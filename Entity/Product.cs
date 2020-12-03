namespace sales_and_inventory.Entity
{
    class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public byte[] photo { get; set; }
        public decimal price { get; set; }
        public decimal salePrice { get; set; }
        public int qty { get; set; }
        public string description { get; set; }
        public string addedDate { get; set; }
        public int addedUserId { get; set; }
    }
}
