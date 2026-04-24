namespace Online_Laundry_System.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string orderId { get; set; } 
        public string customerName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string totalItems { get; set; }

        public string totalAmount { get; set; }

        public string status { get; set; }

        public string pants { get; set; }

        public string jeans { get; set; }

        public string shirts { get; set; }

        public string bedSheets { get; set; }

        public string pillowCovers { get; set; }

        public string blankets { get; set; }

        public string others { get; set; }
    }
}
