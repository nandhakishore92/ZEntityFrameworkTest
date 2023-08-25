using System;
using System.Linq;
using Z.EntityFramework.Plus;
using ZEntityFrameworkTest.Db;

namespace ZEntityFrameworkTest
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CreateTestData();

			DeleteTestData();

			DropDatabase();

			Console.ReadKey();
		}

		private static void CreateTestData()
		{
			using (EntityContext db = new EntityContext())
			{
				Child delivery1 = new Child();
				db.Parents.Add(delivery1);
				db.SaveChanges();
			}
		}

		private static void DeleteTestData()
		{
			try
			{
				using (EntityContext db = new EntityContext())
				{
					int beforeDeleteCount = db.Children.Count();
					Console.WriteLine("Number of records before delete: {0}", beforeDeleteCount);

					int result = db.Children.Delete();
					db.SaveChanges();
					Console.WriteLine("Number of records deleted: {0}", result);

					int afterDeleteCount = db.Children.Count();
					Console.WriteLine("Number of records after delete: {0}", afterDeleteCount);
				}
			}
			catch (Exception ex)
			{
				DropDatabase();
			}
		}

		private static void DropDatabase()
		{
			using (EntityContext db = new EntityContext())
			{
				db.Database.Delete();
			}
		}
	}
}
