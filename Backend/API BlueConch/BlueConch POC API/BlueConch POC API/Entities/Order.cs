using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueConch_POC_API.Entities
{
	public class Order
	{
		public int order_id { get; set; }
		public int userid { get; set; }
		public int itemId { get; set; }
		public Int16 quantity { get; set; }
	}
}
