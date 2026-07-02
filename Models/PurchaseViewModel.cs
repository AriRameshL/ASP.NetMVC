namespace AudioSeller.Models
{
    public class PurchaseViewModel
    {
        public int AudioId { get; set; }
        public string AudioName { get; set; }
        public string AuthorName { get; set; }
        public int TranNo { get; set; }
        public DateTime TranDate { get; set; }
        public int Pieces { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Cancel { get; set; }
        public string CoverImage { get; set; }
        public Customer Customer { get; set; }=new Customer();
    }
}
