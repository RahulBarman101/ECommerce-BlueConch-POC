using BlueConch_POC_API.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueConch_POC_API.Controllers
{
	[ApiController]
	[Route("api/order")]
	[EnableCors("allowcors")]
	public class OrderController: ControllerBase
	{
		private readonly ApplicationDbContext context;

		public OrderController(ApplicationDbContext context)
		{
			this.context = context;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<Order>>> Get(int id)
		{	
			var orders = await context.tblOrder.Where(x => x.itemId == id).ToListAsync();
			if(orders == null)
			{
				return NotFound();
			}
			return orders;
		}
	}
}
