using BlueConch_Ecommerce_Api.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueConch_Ecommerce_Api.Controllers
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
		[HttpGet("{id}", Name = "getOrders")]
		public async Task<ActionResult<List<Order>>> Get(int id)
		{
			return await context.tblOrder.Where(x => x.userid == id).ToListAsync();
		} 

		[HttpPost]
		public async Task<ActionResult<Order>> Post([FromBody] List<Order> order)
		{
			if(order == null)
			{
				return BadRequest();
			}

			await context.tblOrder.AddRangeAsync(order);
			await context.SaveChangesAsync();
			return new CreatedAtRouteResult("getOrders",new { id = order[order.Count - 1].order_id }, order);
		} 

		[HttpGet("order-id")]
		public ActionResult<int> Get()
		{
			return context.tblOrder.Count() == 0 ? 1 : context.tblOrder.Max(x => x.order_id) + 1;
		}
	}
}
