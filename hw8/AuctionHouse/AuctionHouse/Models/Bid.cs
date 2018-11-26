namespace AuctionHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bid")]
    public partial class Bid
    {
        public int BidID { get; set; }

        public decimal BidAmount { get; set; }

        public DateTime BidTimeStamp { get; set; }

        public int? ItemID { get; set; }

        public virtual Item Item { get; set; }
    }
}
