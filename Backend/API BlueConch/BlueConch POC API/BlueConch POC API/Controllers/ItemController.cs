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
	[Route("api/item")]
	[EnableCors("allowcors")]
	public class ItemController: ControllerBase
	{
		private readonly ApplicationDbContext context;

		public ItemController(ApplicationDbContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<Item>>> Get()
		{
			return await context.tblItem.ToListAsync();
		}

		[HttpGet("categories")]
		public async Task<ActionResult<List<string>>> GetCategories()
		{
			var categories = await context.tblItem.Select(x => x.category).Distinct().ToListAsync();
			return categories;
		}
	}
}
