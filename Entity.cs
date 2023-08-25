using System.Data.Entity;

namespace ZEntityFrameworkTest
{
	public class Parent
	{
		public int Id { get; set; }
	}

	public class Child : Parent { }

	public class EntityContext : DbContext
	{
		public EntityContext() : base("name=TestConnectionString") { }

		public EntityContext(string connectionString) : base(connectionString) { }

		public DbSet<Parent> Parents { get; set; }

		public DbSet<Child> Children { get; set; }
	}
}
