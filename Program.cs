using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZEntityFrameworkTest.Models.Db;
using ZEntityFrameworkTest.Models;
using Z.BulkOperations;

namespace ZEntityFrameworkTest
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CreateTestData("73", "99", DateTime.Now.AddDays(-120), "17067227", "18067504", "1965");
			CreateTestData("7654", "9999", DateTime.Now, "17067236", "17067103", "1965");

			PrintTestDataInConsole();

			DeleteTestData();

			PrintTestDataInConsole();

			DropDatabase();

			Console.ReadKey();
		}

		private static void CreateTestData(string releaseNo, string bolNo, DateTime timeStamp, string orderId, string orderId2, string vehicleId)
		{
			using (RecContext db = new RecContext())
			{
				TerminalRelease release = new TerminalRelease()
				{
					ReleaseNo = releaseNo,
					BolNo = bolNo,
					TerminalId = "CLYD",
					TransporterId = "666685",
					VehicleId = "1965",
					Timestamp = timeStamp,
					ChangedTime = timeStamp
				};
				StopProduct product1A = new StopProduct()
				{
					DetailType = RecStopProduct.EDetailType.Actual,
					Volume = 1000,
					ProductId = "141",
					Release = release
				};
				StopProduct product2A = new StopProduct()
				{
					DetailType = RecStopProduct.EDetailType.Actual,
					Volume = 1000,
					ProductId = "203",
					Release = release
				};
				release.Products = new List<StopProduct> { product1A, product2A };
				db.Stops.Add(release);

				StopProduct product1B = new StopProduct()
				{
					DetailType = RecStopProduct.EDetailType.Actual,
					Volume = -1000,
					ProductId = "141",
					Release = release
				};
				CustomerDelivery delivery1 = new CustomerDelivery()
				{
					Timestamp = timeStamp,
					ChangedTime = timeStamp,
					OrderId = orderId,
					VehicleId = vehicleId,
					Products = { product1B }
				};
				db.Stops.Add(delivery1);

				StopProduct product2B = new StopProduct()
				{
					DetailType = RecStopProduct.EDetailType.Actual,
					Volume = -1000,
					ProductId = "203",
					Release = release
				};
				CustomerDelivery delivery2 = new CustomerDelivery()
				{
					Timestamp = timeStamp,
					ChangedTime = timeStamp,
					OrderId = orderId2,
					VehicleId = vehicleId,
					Products = { product2B }
				};
				db.Stops.Add(delivery2);

				db.SaveChanges();
			}
		}

		private static void PrintTestDataInConsole()
		{
			using (RecContext db = new RecContext())
				Console.WriteLine("Number of records available: {0}", db.CustomerDeliveries.Count());
		}

		private static void DeleteTestData()
		{
			try
			{
				using (RecContext db = new RecContext())
				{
					DateTime maxDate = DateTime.Now.Date.AddDays(-90);
					IQueryable<CustomerDelivery> query = db.CustomerDeliveries
						.Where(row => row.Timestamp < maxDate);

					List<CustomerDelivery> list = query.ToList();
					int result = query.DeleteFromQuery(delegate (BulkOperation options)
					{
						options.InternalIsEntityFrameworkPlus = true;
						options.BatchDeleteBuilder = null;
					});

					db.SaveChanges();
					Console.WriteLine("Number of records deleted: {0}", result);
				}
			}
			catch (Exception ex)
			{
				DropDatabase();
			}
		}

		private static void DropDatabase()
		{
			using (RecContext db = new RecContext())
			{
				db.Database.Delete();
			}
		}
	}
}
