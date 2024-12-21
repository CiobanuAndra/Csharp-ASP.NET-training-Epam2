using System.Xml.Serialization;

namespace XmlSerializationBasics.PurchaseOrderExample
{
    [XmlRoot("items", Namespace = "http://www.cpandl.com/purchase-order-item")]

    public class OrderedItem
    {
        [XmlAttribute("unit-price")]
        public decimal UnitPrice { get; set; }

        [XmlAttribute("quantity")]
        public int Quantity { get; set; }

        [XmlElement("order-item-name")]
        public string? ItemName { get; set; }

        [XmlElement("order-item-description")]
        public string? Description { get; set; }

        public decimal LineTotal { get; set; }

        public void CalculateLineTotal()
        {
            this.LineTotal = this.UnitPrice * this.Quantity;
        }
    }
}
