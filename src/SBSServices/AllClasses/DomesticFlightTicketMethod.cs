using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using SBSWebSiteAPI.Models.SearchTicketModel;
using SBSWebSiteAPI.Models.ResponseDomesticTicketModel;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace SBSWebSiteAPI.AllClasses
{
    public class DomesticFlightTicketMethod
    {
        public Dictionary<string, IList<ResponseDomesticTicketModel>> GetAllDomesticFlightTicket(DomesticFlightTicketModel domesticFlightTicketModel)
        {
            Dictionary<string, IList<ResponseDomesticTicketModel>> result = new Dictionary<string, IList<ResponseDomesticTicketModel>>();
            result.Add("Departing", GetOneWayTickets(domesticFlightTicketModel, 1));
            if (domesticFlightTicketModel.ReturningDate != "0/0/0")
                result.Add("Returning", GetOneWayTickets(domesticFlightTicketModel, 2));
            return result;
        }
        public IList<AirReserve> GetAllDomesticFlightReserve(ReserveDomesticFlight reserveDomesticFlight)
        {
            IList<AirReserve> result = new List<AirReserve>();
            result.Add(GetReserve(reserveDomesticFlight, 1));
            if (reserveDomesticFlight.R_Airline != null)
                result.Add(GetReserve(reserveDomesticFlight, 2));
            return result;
        }

        private AirReserve GetReserve(ReserveDomesticFlight reserveDomesticFlight, short kind)
        {
            string passengerRout = PassengerString(reserveDomesticFlight.lstAdult, reserveDomesticFlight.lstChild, reserveDomesticFlight.lstInfant);
            if (kind == 1)
                return GetPNR(reserveDomesticFlight.D_Airline, reserveDomesticFlight.Source, reserveDomesticFlight.Target, reserveDomesticFlight.D_FlightClass, reserveDomesticFlight.D_FlightNo, reserveDomesticFlight.D_Day, reserveDomesticFlight.D_Month, reserveDomesticFlight.No, passengerRout);
            else
                return GetPNR(reserveDomesticFlight.R_Airline, reserveDomesticFlight.Target, reserveDomesticFlight.Source, reserveDomesticFlight.R_FlightClass, reserveDomesticFlight.R_FlightNo, reserveDomesticFlight.R_Day, reserveDomesticFlight.R_Month, reserveDomesticFlight.No, passengerRout);
        }
        public AirReserve GetPNR(string airline, string source, string target, string flightClass, string flightNo, string day, string month, string no, string passengerRout)
        {
            string url = @"http://10.30.205.50/cgi-bin/nrsweb.cgi/ReservJS?Airline=" + airline + "&cbSource=" + source + "&cbTarget=" + target + "&FlightClass=" + flightClass + "&FlightNo=" + flightNo + "&Day=" + day + "&Month=" + month + "&No=" + no + passengerRout;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                request.ContentType = @"application/json";
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding(1256));
                    var jsonObject = reader.ReadToEnd();
                    Dictionary<string, List<Dictionary<string, string>>> PNR = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(jsonObject);
                    return new AirReserve
                    {
                        Error = PNR["AirReserve"][0]["Error"],
                        PNR = PNR["AirReserve"][0]["PNR"],
                    };
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }

        }
        private IList<ResponseDomesticTicketModel> GetOneWayTickets(DomesticFlightTicketModel requestInfo, short kind)
        {
            var AvailableDepartureFlights = new List<Dictionary<string, string>>();
            if (kind == 1)
                AvailableDepartureFlights = GetAvailableFlights(requestInfo.Source.OriginIATACODE, requestInfo.Destination.OriginIATACODE, requestInfo.DepartingDate.Split('/')[2], requestInfo.DepartingDate.Split('/')[1], requestInfo.Adult.Number, requestInfo.Child.Number, requestInfo.Infant.Number);
            else
                AvailableDepartureFlights = GetAvailableFlights(requestInfo.Destination.OriginIATACODE, requestInfo.Source.OriginIATACODE, requestInfo.ReturningDate.Split('/')[2], requestInfo.ReturningDate.Split('/')[1], requestInfo.Adult.Number, requestInfo.Child.Number, requestInfo.Infant.Number);
            IList<ResponseDomesticTicketModel> lstResult = new List<ResponseDomesticTicketModel>();
            foreach (var item in AvailableDepartureFlights)
            {
                ResponseDomesticTicketModel flightObj = new ResponseDomesticTicketModel();
                IList<ClassFare> lstClassFare = new List<ClassFare>();
                flightObj.AirLine = item["AirLine"];
                flightObj.Name = NameOfAirLine(item["AirLine"]);
                flightObj.LogoImg = "http://rrfco.com/AirlinesLogo/" + item["AirLine"] + ".png";
                flightObj.Origin = item["Origin"];
                flightObj.OriginIATACODE = item["OriginIATACODE"];
                flightObj.Destination = item["Destination"];
                flightObj.DestinationIATACODE = item["DestinationIATACODE"];
                flightObj.DepartureDateMiladi = item["DepartureDateMiladi"];
                flightObj.DepartureDateShamsi = item["DepartureDateShamsi"];
                flightObj.ArrivalTime = item["ArrivalTime"];
                flightObj.DepartureTime = item["DepartureTime"];
                flightObj.FlightNo = item["FlightNo"];
                flightObj.PlaneType = item["PlaneType"];
                flightObj.PlaneTypeCode = item["PlaneTypeCode"];
                flightObj.selected = false;

                IList<string> lstClass = item["FlightClasses"].Split(' ');
                foreach (string classItem in lstClass)
                {
                    if (CheckAvailableFlightClass(item["AirLine"], classItem))
                    {
                        var AvailableFlightsFare = new Dictionary<string, string>();
                        if (kind == 1)
                            AvailableFlightsFare = GetFlightClassFare(item["AirLine"], requestInfo.Source.OriginIATACODE, requestInfo.Destination.OriginIATACODE, requestInfo.DepartingDate.Split('/')[2], requestInfo.DepartingDate.Split('/')[1], "0", "0", classItem[0].ToString());
                        else
                            AvailableFlightsFare = GetFlightClassFare(item["AirLine"], requestInfo.Destination.OriginIATACODE, requestInfo.Source.OriginIATACODE, requestInfo.ReturningDate.Split('/')[2], requestInfo.ReturningDate.Split('/')[1], "0", "0", classItem[0].ToString());

                        ClassFare classFare = new ClassFare
                        {
                            AdultFare = AvailableFlightsFare["AdultFare"],
                            ChildFare = AvailableFlightsFare["ChildFare"],
                            InfantFare = AvailableFlightsFare["InfantFare"],
                            FlightClass = classItem,
                            selected = false,
                        };
                        lstClassFare.Add(classFare);
                        flightObj.ClassFareList = lstClassFare;
                    }
                }
                if (flightObj.ClassFareList != null)
                    lstResult.Add(flightObj);
            }
            return lstResult;
        }
        public Dictionary<string, string> GetFlightClassFare(string AirLine, string cbSource, string cbTarget, string DepartureDay, string DepartureMonth, string ReturnDay, string ReturnMonth, string FlightClassCode)
        {
            string url = @"http://10.30.205.50/cgi-bin/nrsweb.cgi/FareJS?AirLine=" + AirLine + "&cbSource=" + cbSource + "&cbTarget=" + cbTarget + "&DepartureDay=" + DepartureDay + "&DepartureMonth=" + DepartureMonth + "&ReturnDay=" + ReturnDay + "&ReturnMonth=" + ReturnMonth + "&FlightClassCode=" + FlightClassCode;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                request.ContentType = @"application/json";
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding(1256));
                    var jsonObject = reader.ReadToEnd();
                    Dictionary<string, List<Dictionary<string, string>>> ResponseAvailableFlightsFare = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(jsonObject);
                    return ResponseAvailableFlightsFare["AirFare"][0];
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }

        public List<Dictionary<string, string>> GetAvailableFlights(string source, string target, string day, string month, string adultQty, string childQty, string infantQty)
        {
            string url = @"http://10.30.205.50/cgi-bin/nrsweb.cgi/AvailabilityJS?cbSource=" + source + "&cbTarget=" + target + "&cbDay1=" + day + "&cbMonth1=" + month + "&cbAdultQty=" + adultQty + "&cbChildQty=" + childQty + "&cbInfantQty=" + infantQty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                request.ContentType = @"application/json";
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding(1256));
                    var jsonObject = reader.ReadToEnd();
                    Dictionary<string, List<Dictionary<string, string>>> ResponseAvailableFlights = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(jsonObject);
                    return ResponseAvailableFlights["AvailableFlights"];
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }

        private bool CheckAvailableFlightClass(string airline, string flightClass)
        {
            Dictionary<string, List<char>> dicAir_Cls = SetAirline_Class();
            List<char> list;

            if (dicAir_Cls.TryGetValue(airline, out list))
            {
                foreach (char item in list)
                {
                    if (item == flightClass[0])
                    {
                        if (flightClass[1] == 'A')
                            return true;
                        else
                            return false;
                    }
                }
            }
            return false;
        }
        private string NameOfAirLine(string ataAirlineName)
        {
            switch (ataAirlineName)
            {
                case "IR":
                    {
                        return "ایران ایر";
                    }

                case "EP":
                    {
                        return "آسمان";
                    }
                case "QB":
                    {
                        return "قشم ایر";
                    }
                case "I3":
                    {
                        return "آتا";
                    }
                case "BQ":
                    {
                        return "ایرتور";
                    }
                case "HH":
                    {
                        return "تابان";
                    }
                case "NV":
                    {
                        return "نفت";
                    }
            };
            return null;
        }
        private Dictionary<string, List<char>> SetAirline_Class()
        {
            Dictionary<string, List<char>> dic = new Dictionary<string, List<char>>()
            {
                { "IR",new List<char>() {'Y','V', 'Q', 'M', 'J', 'C', }  },
                { "EP",new List<char>() {'V','S', 'Y', 'Q', 'N', 'M', 'L', 'K', 'H', 'Z', 'I', 'D' }  },
                { "QB",new List<char>() {'Y' }  },
                { "I3",new List<char>() {'Y', 'R', 'P', 'N' }  },
                { "BQ",new List<char>() {'Y', 'V', 'S', 'M', 'R' }  },
                { "NV",new List<char>() {'S', 'B', }  },
                //تابان
            };
            return dic;
        }

        private string PassengerString(List<PassengerFlight> lstAdult, List<PassengerFlight> lstChild, List<PassengerFlight> lstInfant)
        {
            string setPassenger = "";
            int cnt = 1;
            if (lstAdult.Count > 0)
                for (int i = 0; i < lstAdult.Count; i++)
                {
                    setPassenger += "&edtName" + cnt + "=" + lstAdult[i].Name_En;
                    setPassenger += "&edtLast" + cnt + "=" + lstAdult[i].LastName_En;
                    //setPassenger += "&edtAge" + cnt + "=" + lstAdult[i].BD;
                    setPassenger += "&edtAge" + cnt + "=30";
                    setPassenger += "&edtID" + cnt + "=" + lstAdult[i].NationalCode;
                    setPassenger += "&edtContact=" + lstAdult[i].Tel;
                    cnt++;
                }
            if (lstChild.Count > 0)
                for (int i = 0; i < lstChild.Count; i++)
                {
                    setPassenger += "&edtName" + cnt + "=" + lstAdult[i].Name_En;
                    setPassenger += "&edtLast" + cnt + "=" + lstAdult[i].LastName_En;
                    //setPassenger += "&edtAge" + cnt + "=" + lstAdult[i].BD;
                    setPassenger += "&edtAge" + cnt + "=10";
                    setPassenger += "&edtID" + cnt + "=" + lstAdult[i].NationalCode;
                    setPassenger += "&edtContact=" + lstAdult[i].Tel;
                    cnt++;
                }
            if (lstInfant.Count > 0)
                for (int i = 0; i < lstInfant.Count; i++)
                {
                    setPassenger += "&edtName" + cnt + "=" + lstAdult[i].Name_En;
                    setPassenger += "&edtLast" + cnt + "=" + lstAdult[i].LastName_En;
                    //setPassenger += "&edtAge" + cnt + "=" + lstAdult[i].BD;
                    setPassenger += "&edtAge" + cnt + "=2";
                    setPassenger += "&edtID" + cnt + "=" + lstAdult[i].NationalCode;
                    setPassenger += "&edtContact=" + lstAdult[i].Tel;
                    cnt++;
                }
            return setPassenger;
        }
    }
}