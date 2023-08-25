using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEntityFrameworkTest.Models.Db
{
	public class StopProduct
	{
		#region ORM
		public int Id { get; set; }
		public int StopId { get; set; }
		// This field is used to link a product delivery to a (terminal) release. It is the main purpose of Reconciliation.
		public int? TerminalReleaseId { get; set; }
		[Required]
		public string ProductId { get; set; }
		public decimal Volume { get; set; }
		// Vehicle compartment > 0, trailer compartment < 0
		public int? Compartment { get; set; }
		public string Tank { get; set; }
		public RecStopProduct.EDetailType DetailType { get; set; }

		public virtual Stop Stop { get; set; }
		public virtual TerminalRelease Release { get; set; }

		#endregion

		public StopProduct()
		{ }

		public StopProduct(IStopProduct product, int? releaseId, bool hasNegativeVolume)
		{
			Update(product, hasNegativeVolume);
			DetailType = RecStopProduct.EDetailType.Actual;
			TerminalReleaseId = releaseId;
		}

		public StopProduct(StopProduct product, int releaseId)
		{
			StopId = product.StopId;
			TerminalReleaseId = releaseId;
			ProductId = product.ProductId;
			Volume = 0;
			Compartment = product.Compartment;
			Tank = product.Tank;
			DetailType = product.DetailType;
		}

		public void Update(IStopProduct product, bool hasNegativeVolume)
		{
			// Sanity check
			if (product.EVolumeType != EProductVolumeType.Actual)
				throw new Exception("Attempting to update no-actual product");
			ProductId = product.ProductId;
			Tank = product.Tank;
			Compartment = product.CompartmentId;
			Volume = (hasNegativeVolume ? -1 : 1) * ((decimal)product.Volume);
		}

		public override string ToString()
		{
			string stopId = "";
			if (TerminalReleaseId != null && TerminalReleaseId != StopId)
				stopId = string.Format(" (Release ID {0}, Delivery ID {1})", TerminalReleaseId, StopId);

			return string.Format("{0} {1} (#{2}, {3}): {4}{5}", DetailType, ProductId, Compartment, Tank, Volume, stopId);
		}

		public bool InVehicle
		{
			get { return Compartment > 0; }
		}

		public bool InTrailer
		{
			get { return Compartment < 0; }
		}
	}

	public enum EProductVolumeType
	{
		Ordered,
		Planned,
		Actual
	}

	public interface IStopProduct
	{
		string Id { get; }
		string ProductId { get; }
		string Tank { get; }
		int? CompartmentId { get; }
		EProductVolumeType EVolumeType { get; }
		double Volume { get; }
		bool IsLeftOnBoard { get; }
	}
}
