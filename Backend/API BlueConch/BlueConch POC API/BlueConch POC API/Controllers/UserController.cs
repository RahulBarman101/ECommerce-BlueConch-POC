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
	[Route("api/user")]
	[EnableCors("allowcors")]
	public class UserController: ControllerBase
	{
		private readonly ApplicationDbContext context;

		public UserController(ApplicationDbContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<User>>> Get()
		{
			return await context.tblUser.ToListAsync();
		}

		[HttpGet("{id}",Name ="getGenre")]
		public async Task<ActionResult<User>> Get(int id)
		{
			var user = await context.tblUser.FirstOrDefaultAsync(x => x.userid == id);
			if(user == null)
			{
				return NotFound();
			}
			return user;
		}

		[HttpGet("login")]
		public async Task<ActionResult<User>> Get(string username, string passwd)
		{
			if(username == null || passwd == null)
			{
				return BadRequest();
			}
			var user = await context.tblUser.Where(x => x.username == username).FirstOrDefaultAsync(y => y.passwd == passwd);
			if(user == null)
			{
				return NotFound();
			}
			return user;
		}

		[HttpPost]
		public async Task<ActionResult<User>> Post([FromBody] User user)
		{
			user.userid = context.tblUser.Max(x => x.userid) + 1;
			context.Add(user);
			await context.SaveChangesAsync();
			return new CreatedAtRouteResult("getGenre", new { id =  user.userid}, user);
		}
	}
}
