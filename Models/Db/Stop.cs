using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEntityFrameworkTest.Models.Db
{
	public abstract class Stop
	{
		#region ORM

		public int Id { get; set; }
		public DateTime Timestamp { get; set; }
		public string VehicleId { get; set; }
		public string TrailerId { get; set; }
		public string DriverId { get; set; }
		[MaxLength]
		public string Comment { get; set; }
		public string TripId { get; set; }
		public string PartialTripId { get; set; }
		public string ChangedUser { get; set; }
		public DateTime ChangedTime { get; set; }
		public string LastChangedUser { get; set; }
		public DateTime? LastChangedTime { get; set; }
		public virtual ICollection<StopProduct> Products { get; set; }

		#endregion

		public Stop()
		{
			Products = new List<StopProduct>();
		}

		[NotMapped]
		public bool UsesVehicle
		{
			get { return ActualProducts.Any(product => product.InVehicle); }
		}

		[NotMapped]
		public bool UsesTrailer
		{
			get { return ActualProducts.Any(product => product.InTrailer); }
		}

		[NotMapped]
		public IEnumerable<StopProduct> ActualProducts
		{
			get { return Products.Where(product => product.DetailType == RecStopProduct.EDetailType.Actual); }
		}

		public override string ToString()
		{
			return Timestamp.ToString("MM-dd HH:mm");
		}
	}
}
