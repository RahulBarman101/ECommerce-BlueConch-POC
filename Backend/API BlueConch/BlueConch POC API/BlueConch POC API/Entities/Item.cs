using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueConch_POC_API.Entities
{
	public class Item
	{
		[Key]
		public int itemid { get; set; }
		[StringLength(20)]
		public string itemName { get; set; }
		[StringLength(20)]
		public string itemFrom { get; set; }
		public Int16 itemRating { get; set; }
		[StringLength(30)]
		public string category { get; set; }
		public int itemRatingCount { get; set; }
		public decimal itemPrice { get; set; }
		public string itemUrl { get; set; }
	}
}
