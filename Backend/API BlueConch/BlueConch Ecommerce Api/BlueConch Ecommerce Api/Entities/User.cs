using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueConch_Ecommerce_Api.Entities
{
	public class User
	{
		[Required]
		[Key]
		public int userid { get; set; }
		public string firstname { get; set; }
		public string lastname { get; set; }
		public string username { get; set; }
		public string middlename { get; set; }
		public string passwd { get; set; }

	}
}
