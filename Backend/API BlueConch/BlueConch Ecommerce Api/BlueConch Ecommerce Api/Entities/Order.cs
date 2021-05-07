using System;
using System.ComponentModel.DataAnnotations;

namespace BlueConch_Ecommerce_Api.Entities
{
	public class Order
	{
		[Key]
		public int order_id { get; set; }
		public int userid { get; set; }
		public Int16 quantity { get; set; }
		public int itemId { get; set; }
		public decimal totalPrice { get; set; }
	}
}
