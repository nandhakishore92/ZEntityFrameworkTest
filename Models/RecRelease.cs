using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEntityFrameworkTest.Models
{
	public class RecRelease : RecStop
	{
		/// <summary>
		/// BOL number (BOL:Bill of Lading), provided by ERP
		/// </summary>
		public string BolNo { get; set; }
		/// <summary>
		/// Release number
		/// </summary>
		public string ReleaseNo { get; set; }
		/// <summary>
		/// Terminal Id
		/// </summary>
		public string TerminalId { get; set; }
		/// <summary>
		/// Transporter Id
		/// </summary>
		public string TransporterId { get; set; }
		/// <summary>
		/// Status
		/// </summary>
		public EStatus Status { get; set; }

		/// <summary>
		/// Enum for describing release status
		/// </summary>
		public enum EStatus
		{
			// Do not change the integer value of any enum value (or you will ruin data)
			/// <summary>
			/// Open
			/// </summary>
			Open = 0,
			/// <summary>
			/// Rti = Ready to invoice
			/// </summary>
			Rti = 1,
			/// <summary>
			/// ///
			/// </summary>
			Query = 2,
			/// <summary>
			/// Partially invoiced
			/// </summary>
			PartiallyInvoiced = 3,
			/// <summary>
			/// Invoiced
			/// </summary>
			Invoiced = 4
		}
	}
}
