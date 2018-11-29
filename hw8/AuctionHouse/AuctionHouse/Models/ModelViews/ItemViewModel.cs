using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionHouse.Models.ModelViews
{
    public class ItemViewModel
    {
        public Buyer ThisBuyer { get; set; }

        public Item ThisItem { get; set; }

        public Bid ThisBid { get; set; }

        public List<Bid> TheseBids { get; set; }
    }
}