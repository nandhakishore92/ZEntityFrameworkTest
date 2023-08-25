using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ZEntityFrameworkTest.Models.Db
{
	public class RecContext : DbContext
	{
		public RecContext() : base("name=TWPConnectionString")
		{

		}

		public RecContext(string connectionString) : base(connectionString)
		{

		}

		[BaseEntity]
		public DbSet<Stop> Stops { get; set; }

		[SpecializedEntity]
		public IQueryable<CustomerDelivery> CustomerDeliveries
		{
			get
			{
				return Stops
					.OfType<CustomerDelivery>();
			}
		}
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class BaseEntityAttribute : Attribute
	{
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class SpecializedEntityAttribute : Attribute
	{
	}
}
