using System;

namespace ZEntityFrameworkTest.Models.Db
{
	public abstract class Stop
	{
		#region ORM
		public int Id { get; set; }
		public DateTime Timestamp { get; set; }
		#endregion

		public Stop()
		{
		}
	}
}
