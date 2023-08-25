﻿using System;
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
			CreateTestData(DateTime.Now.AddDays(-120));
			CreateTestData(DateTime.Now);

			PrintTestDataInConsole();

			DeleteTestData();

			PrintTestDataInConsole();

			DropDatabase();

			Console.ReadKey();
		}

		private static void CreateTestData(DateTime timeStamp)
		{
			using (RecContext db = new RecContext())
			{
				StopProduct product1B = new StopProduct();
				CustomerDelivery delivery1 = new CustomerDelivery()
				{
					Timestamp = timeStamp,
					Products = { product1B }
				};
				db.Stops.Add(delivery1);

				StopProduct product2B = new StopProduct();
				CustomerDelivery delivery2 = new CustomerDelivery()
				{
					Timestamp = timeStamp,
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
						options.InternalIsEntityFrameworkPlus = false;
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
