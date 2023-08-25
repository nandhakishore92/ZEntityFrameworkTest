using System.ComponentModel.DataAnnotations.Schema;

namespace ZEntityFrameworkTest.Models.Db
{
	[Table("CustomerDelivery")]
	public class CustomerDelivery: Stop
	{
		public CustomerDelivery()
		{
		}
	}
}
