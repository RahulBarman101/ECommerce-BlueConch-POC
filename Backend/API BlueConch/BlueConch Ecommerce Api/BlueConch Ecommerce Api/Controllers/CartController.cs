using BlueConch_Ecommerce_Api.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueConch_Ecommerce_Api.Controllers
{
	[ApiController]
	[Route("api/cart")]
	[EnableCors("allowcors")]
	public class CartController: ControllerBase
	{
		private readonly ApplicationDbContext context;

		public CartController(ApplicationDbContext context)
		{
			this.context = context;
		}

		[HttpGet("{id}",Name="getOrder")]
		public async Task<ActionResult<List<Cart>>> Get(int id)
		{	
			var orders = await context.tblCart.Where(x => x.userid == id).ToListAsync();
			if(orders == null)
			{
				return NotFound();
			}
			return orders;
		}

		[HttpPost]
		public async Task<ActionResult<Cart>> Post([FromBody] Cart order)
		{
			if(order == null)
			{
				return BadRequest();
			}
			var same_item = await context.tblCart.Where(x => x.userid == order.userid).FirstOrDefaultAsync(x => x.itemId == order.itemId);
			if(same_item !=null)
			{
				same_item.quantity += 1;
				await context.SaveChangesAsync();
			}
			else
			{
				order.order_id = context.tblCart.Max(x => x.order_id) + 1;
				context.tblCart.Add(order);
				await context.SaveChangesAsync();
			}
			
			return new CreatedAtRouteResult("getOrder",new { id = same_item != null ? same_item.userid : order.userid}, same_item != null ? same_item : order);
		}

		[HttpPost("add/{id}")]
		public async Task<ActionResult> PatchAdd(int id)
		{
			var order = await context.tblCart.FirstOrDefaultAsync(x => x.order_id == id);
			if(order == null)
			{
				return BadRequest();
			}
			order.quantity += 1;
			await context.SaveChangesAsync();
			return Ok(order.quantity);
		}

		[HttpPost("remove/{id}")]
		public async Task<ActionResult> PatchRemove(int id)
		{
			var order = await context.tblCart.FirstOrDefaultAsync(x => x.order_id == id);
			if(order == null)
			{
				return BadRequest();
			}
			order.quantity -= 1;
			await context.SaveChangesAsync();
			return Ok(order.quantity);
		}
	}
}
