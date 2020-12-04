namespace sales_and_inventory.Entity
{
    class Invoice
    {
        public int id { get; set; }
        public decimal grandTotal { get; set; }
        public decimal discountRatio { get; set; }
        public decimal netTotal { get; set; }
        public string addedDate { get; set; }
        public int addedUserId { get; set; }

    }
}
