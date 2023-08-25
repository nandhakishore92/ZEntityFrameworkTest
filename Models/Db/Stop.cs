using System;
using System.Collections.Generic;

namespace ZEntityFrameworkTest.Models.Db
{
	public abstract class Stop
	{
		#region ORM

		public int Id { get; set; }
		public DateTime Timestamp { get; set; }
		public virtual ICollection<StopProduct> Products { get; set; }

		#endregion

		public Stop()
		{
			Products = new List<StopProduct>();
		}
	}
}
