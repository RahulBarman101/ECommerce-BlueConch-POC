using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueConch_Ecommerce_Api.Entities
{
	public class Cart
	{
		[Key]
		public int order_id { get; set; }
		public int userid { get; set; }
		public int itemId { get; set; }
		public Int16 quantity { get; set; }
	}
}
