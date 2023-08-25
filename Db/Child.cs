using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZEntityFrameworkTest.Db
{
	[Table("CustomerDelivery")]
	public class Child: Parent
	{
		public Child()
		{
		}
	}
}
