using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEntityFrameworkTest.Models
{
	public class RecStopProduct
	{
		/// <summary>
		/// Product Id
		/// </summary>
		public string ProductId { get; set; }
		/// <summary>
		/// Volume
		/// </summary>
		public decimal Volume { get; set; }
		/// <summary>
		/// Compartment
		/// </summary>
		public int? Compartment { get; set; }
		/// <summary>
		/// Tank
		/// </summary>
		public string Tank { get; set; }

		/// <summary>
		/// Status of the parent release. Defaults to 'Open' if parent is no release (ReleaseNo is null).
		/// </summary>
		public RecRelease.EStatus ReleaseStatus { get; set; }
		/// <summary>
		/// Detail Type
		/// </summary>
		public EDetailType DetailType { get; set; }
		/// <summary>
		/// Release number
		/// </summary>
		public string ReleaseNo { get; set; }

		/// <summary>
		/// Detail Type possibilities
		/// </summary>
		public enum EDetailType
		{
			// Do not change the integer value of any enum value (or you will ruin data)
			/// <summary>
			/// Ordered
			/// </summary>
			Ordered = 0,
			/// <summary>
			/// Planned
			/// </summary>
			Planned = 1,
			/// <summary>
			/// Actual
			/// </summary>
			Actual = 2
		}
	}
}
