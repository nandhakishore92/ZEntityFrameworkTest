using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZEntityFrameworkTest.Models.Db
{
	[Table("CustomerDelivery")]
	public class CustomerDelivery : Stop
	{
		#region ORM
		[Required]
		[Index(IsUnique = true)]
		[StringLength(100)]
		public string OrderId { get; set; }
		public string SiteId { get; set; }
		#endregion

		public CustomerDelivery()
		{
		}

		public IEnumerable<int> ReleaseIds()
		{
			IEnumerable<int> releaseIds = Products
				.Where(product => product.TerminalReleaseId.HasValue)
				.Select(product => product.TerminalReleaseId.Value);
			return releaseIds;
		}

		public override string ToString()
		{
			return string.Format("Customer delivery: {0}: OrderId {1}", base.ToString(), OrderId);
		}
	}
}
