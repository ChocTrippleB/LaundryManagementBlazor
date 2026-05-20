namespace LaundryManagementBlazor.Models
{
    public class PlaceOrderRequest
    {
        public string CustomerName  { get; set; } = "John Doe";
        public string Address       { get; set; } = "12 Main St, Summerstrand";
        public string PackageName   { get; set; } = "";
        public string ServiceName   { get; set; } = "";
        public decimal BasePrice    { get; set; }
        public bool AddStainRemoval     { get; set; }
        public bool AddPerfumeTreatment { get; set; }
        public string PaymentMethod { get; set; } = "EFT"; // "CreditCard" | "EFT"
        public string CardName      { get; set; } = "";
        public string CardNumber    { get; set; } = "";
        public string CardExpiry    { get; set; } = "";
        public string CardCvv       { get; set; } = "";
    }


    public class OrderViewModel
    {
        public string OrderId { get; set; } = "";
        public string CustomerName { get; set; } = "";
        public string Address { get; set; } = "";
        public string Package { get; set; } = "";
        public string PackagingType { get; set; } = "";
        public string DeliveryMethod { get; set; } = "";
        public string DetergentType { get; set; } = "";
        public string ServiceType { get; set; } = "";
        public string Extras { get; set; } = "";
        public decimal Total { get; set; }
        public string Payment { get; set; } = "";
        public string Status { get; set; } = "Placed";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class NotificationEntry
    {
        public string Role { get; set; } = "";
        public string OrderId { get; set; } = "";
        public string Message { get; set; } = "";
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }

    public class LogEntry
    {
        public string Message { get; set; } = "";
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
