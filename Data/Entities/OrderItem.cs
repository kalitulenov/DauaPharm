namespace DauaPharm.Data.Entities
{
  public class OrderItem
  {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        //   public Product Product { get; set; }
        public Order Order { get; set; }
  }
}