using LaundryManagementBlazor.Interfaces;

namespace LaundryManagementBlazor.Services.AbstractFactory
{
    // ── Standard Products ────────────────────────────────────────
    public class PlasticBagPackaging : IPackaging
    {
        public string PackagingType => "Plastic Bag";
        public string Describe() => "Standard plastic bag packaging";
    }

    public class StandardDelivery : IDeliveryMethod
    {
        public string Method => "Standard 2-Day Delivery";
        public string Describe() => "Standard 2-day delivery";
    }

    public class RegularDetergent : IDetergentType
    {
        public string Detergent => "Regular Detergent";
        public string Describe() => "Regular detergent";
    }

    // ── Premium Products ─────────────────────────────────────────
    public class BrandedBoxPackaging : IPackaging
    {
        public string PackagingType => "Branded Box";
        public string Describe() => "Branded box with tissue paper";
    }

    public class ExpressDelivery : IDeliveryMethod
    {
        public string Method => "Next-Day Express Delivery";
        public string Describe() => "Next-day express delivery";
    }

    public class HypoallergenicDetergent : IDetergentType
    {
        public string Detergent => "Hypoallergenic Detergent";
        public string Describe() => "Hypoallergenic detergent";
    }

    // ── Business Products ────────────────────────────────────────
    public class GarmentBagPackaging : IPackaging
    {
        public string PackagingType => "Sealed Garment Bags";
        public string Describe() => "Sealed garment bags on hangers";
    }

    public class SameDayCourier : IDeliveryMethod
    {
        public string Method => "Same-Day Courier";
        public string Describe() => "Same-day courier delivery";
    }

    public class CommercialDetergent : IDetergentType
    {
        public string Detergent => "Commercial-Grade Fabric Care";
        public string Describe() => "Commercial-grade fabric care solution";
    }
}
