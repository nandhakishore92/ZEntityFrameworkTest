using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEntityFrameworkTest.Models
{
	/// <summary>
	/// Class for a stop. A release (terminal pick-up), a delivery (customer delivery), a pick-up (customer pick-up) are stops for example.
	/// </summary>
	public class RecStop
	{
		/// <summary>
		/// Timestamp
		/// </summary>
		public DateTime Timestamp { get; set; }
		/// <summary>
		/// Vehicle Id
		/// </summary>
		public string VehicleId { get; set; }
		/// <summary>
		/// Trailer Id
		/// </summary>
		public string TrailerId { get; set; }
		/// <summary>
		/// Driver Id
		/// </summary>
		public string DriverId { get; set; }
		/// <summary>
		/// Comment
		/// </summary>
		public string Comment { get; set; }
		/// <summary>
		/// Trip Id
		/// </summary>
		public string TripId { get; set; }
		/// <summary>
		/// Partial Trip Id
		/// </summary>
		public string PartialTripId { get; set; }
		/// <summary>
		/// Changed User
		/// </summary>
		public string ChangedUser { get; set; }
		/// <summary>
		/// Changed Time
		/// </summary>
		public DateTime ChangedTime { get; set; }
		/// <summary>
		/// Last Changed User
		/// </summary>
		public string LastChangedUser { get; set; }
		/// <summary>
		/// Last Changed Time
		/// </summary>
		public DateTime LastChangedTime { get; set; }
		/// <summary>
		/// List of Products
		/// </summary>
		public List<RecStopProduct> Products { get; set; }
	}
}
