using BlueConch_POC_API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BlueConch_POC_API
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
		{
		}

		public DbSet<User> tblUser { get; set;}
		public DbSet<Item> tblItem { get; set;}
		public DbSet<Order> tblOrder { get; set;}
	}
}
