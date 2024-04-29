using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZAAppliciation
{
    // Parent class
    public class UserOrder
    {
        public int? UserID { get; set; }
        public int? TicketID { get; set; }
        public string? TicketReference { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DateAttending { get; set; }
        public int? Points { get; set; }
        public UserOrder(int? ticketID, string? ticketReference, DateTime? purchaseDate, decimal? price, DateTime? dateAttending, int? points)
        {
            TicketID = ticketID;
            TicketReference = ticketReference;
            PurchaseDate = purchaseDate;
            Price = price;
            DateAttending = dateAttending;
            Points = points;
        }
    }

    // Child class
    public class ZooOrder : UserOrder
    {
        public int? Adults { get; set; }
        public int? Child { get; set; }
        public int? Student { get; set; }
        public Boolean? Extra1 { get; set; }
        public Boolean? Extra2 { get; set; }
        public Boolean? Extra3 { get; set; }

        public ZooOrder(int? ticketID, string? ticketReference, DateTime? purchaseDate, decimal? price, DateTime? dateAttending, int? points, int? adults, int? child, int? studnet, Boolean? extra1, Boolean? extra2, Boolean? extra3) : base(ticketID, ticketReference, purchaseDate, price, dateAttending, points)
        {
            Adults = adults;
            Child = child;
            Student = studnet;
            Extra1 = extra1;
            Extra2 = extra2;
            Extra3 = extra3;
        }
    }
    // Child class
    public class HotelOrder : UserOrder
    {
        public DateTime? DateTill { get; set; }
        public int? NightsStaying { get; set; }
        public string? RoomType { get; set; }
        public string? RoomNumber { get; set; }

        public HotelOrder(int? ticketID, string? ticketReference, DateTime? purchaseDate, decimal? price, DateTime? dateAttending, int? points, DateTime? datetill, int? nightsStaying, string? roomType, string roomNumber) : base(ticketID, ticketReference, purchaseDate, price, dateAttending, points)
        {
            DateTill = datetill;
            NightsStaying = nightsStaying;
            RoomType = roomType;
            RoomNumber = roomNumber;
        }
    }
}
