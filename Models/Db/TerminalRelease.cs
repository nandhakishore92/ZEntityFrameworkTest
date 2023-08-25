using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEntityFrameworkTest.Models.Db
{
	// A release is a shipment release from a terminal. In other words, a terminal pick-up.
	[Table("TerminalRelease")]
	public class TerminalRelease : Stop
	{
		#region ORM
		// BolNo - Bill of Lading number - a BOL number is specific to the generated BOL and used for a specific load or shipment.
		// It is a reference number that helps tie the shipment to a tracking system.
		[Required]
		public string BolNo { get; set; }
		[Required]
		[Index(IsUnique = true)]
		[StringLength(100)]
		public string ReleaseNo { get; set; }
		[Required]
		[Index(IsUnique = false)]
		[StringLength(100)]
		public string TerminalId { get; set; }
		[Index(IsUnique = false)]
		[StringLength(100)]
		public string TransporterId { get; set; }
		[Index(IsUnique = false)]
		public RecRelease.EStatus Status { get; set; }
		// Valid = false means one or more fields on the Release are invalid. For example, see the BolNo validation.
		public bool Valid { get; set; }
		// Approved = false means this needs to be approved by a user manually
		// Approved = true means user validation was not needed or a user approved it manually
		public bool Approved { get; set; }
		// Did we link all the deliveries attached to this release (all the products and all the volumes)?
		public bool Reconciled { get; set; }
		public bool Skipped { get; set; }
		public bool NeedResend { get; set; }
		public string QueryReason { get; set; }
		public string QueryUser { get; set; }

		public virtual ICollection<StopProduct> ReleaseProducts { get; set; }

		#endregion

		public TerminalRelease()
		{
			ReleaseProducts = new List<StopProduct>();
		}

		/// <summary>
		/// Returns true if any customer stop (delivery or pickup) that points to this release lies before this release
		/// - Uses Release.ReleaseProducts
		/// </summary>
		public bool HasStopBeforeRelease()
		{
			return ReleaseProducts
				.Any(productPart => productPart.Stop.Timestamp < Timestamp);
		}

		public override string ToString()
		{
			string flags = "";
			if (!Valid)
				flags += ",!V";
			if (!Reconciled)
				flags += ",!R";
			if (!Approved)
				flags += ",!A";
			if (!Skipped)
				flags += ",!S";
			if (NeedResend)
				flags += ",N";
			return string.Format("{0}: Release No {1} ({2}{3})", base.ToString(), ReleaseNo, Status, flags);
		}
	}
}
