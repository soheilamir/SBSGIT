using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBSWebProject.Web.Api.Models;
using System.Collections;

namespace SBSWebProject.Web.Api.MethodsInterface
{
    public interface IDomesticFlightTicketMethod
    {
        Dictionary<string, IList<ResponseDomesticTicketModel>> GetAllDomesticFlightTicket(DomesticFlightTicketModel domesticFlightTicketModel);
        Data.Entities.Orders GetAllDomesticFlightReserve(ReserveDomesticFlight reserveDomesticFlight, long userId, string userEmail);
        PnrModel GetPNR(string airline, string source, string target, string flightClass, string flightNo, string day, string month, string no, string passengerRout);
        Dictionary<string, string> GetFlightClassFareIfCashed(string AirLine, City cbSource, City cbTarget, string DepartureDay, string DepartureMonth, string ReturnDay, string ReturnMonth, string FlightClassCode);
        Dictionary<string, string> GetFlightClassFare(string AirLine, City cbSource, City cbTarget, string DepartureDay, string DepartureMonth, string ReturnDay, string ReturnMonth, string FlightClassCode);
        List<Dictionary<string, string>> GetAvailableFlights(City source, City target, string day, string month, string adultQty, string childQty, string infantQty);
        //IList GetTicketNumberTest();
        Dictionary<string, List<PassengerFlight>> SaveOnlineFlightTicketPassenger(List<PassengerFlight> lstAdult, List<PassengerFlight> lstChild, List<PassengerFlight> lstInfant, long userId);
        Dictionary<string, List<PassengerFlight>> SaveUserPassengers(List<PassengerFlight> lstAdult, List<PassengerFlight> lstChild, List<PassengerFlight> lstInfant, long userId);
        List<OnlineFlightTicketModel> GetSavedTicketByOrderMethod(long orderId);

    }
}
