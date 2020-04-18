using System;
using System.Collections.Generic;

namespace DauaPharm.Data.Entities
{
  public class Order
  {
    public int ID { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderNumber { get; set; }
    public ICollection<OrderItem> Items { get; set; }
    //public StoreUser User { get; set; }
  }
}
