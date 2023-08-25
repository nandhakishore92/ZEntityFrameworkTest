using System.Data.Entity;
using System.Linq;

namespace ZEntityFrameworkTest.Db
{
	public class EntityContext : DbContext
	{
		public EntityContext() : base("name=TestConnectionString")
		{

		}

		public EntityContext(string connectionString) : base(connectionString)
		{

		}

		public DbSet<Parent> Parents { get; set; }

		public IQueryable<Child> Children
		{
			get
			{
				return Parents
					.OfType<Child>();
			}
		}
	}
}
