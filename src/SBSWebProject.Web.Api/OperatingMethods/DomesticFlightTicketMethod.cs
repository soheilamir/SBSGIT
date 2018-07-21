using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SBSWebProject.Web.Api.Models;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using SBSWebProject.Web.Api.MethodsInterface;
using SBSWebProject.Data.DataHandlers;
using System.Collections;
using SBSWebProject.MappingObject;

namespace SBSWebProject.Web.Api.OperatingMethods
{
    public class DomesticFlightTicketMethod : IDomesticFlightTicketMethod
    {
        private readonly IAirlinesMethod _airlinesMethod;
        private readonly IFlightPathMethod _flightPathMethod;
        private readonly IBasicDataHandler<Data.Entities.UserPassenger> _userPassengerDataHandler;
        private readonly IBasicDataHandler<Data.Entities.AirlineClassPathFee> _airlineClassPathFeeDataHandler;
        private readonly IBasicDataHandler<Data.Entities.OnlineFlightTicket> _onlineFlightTicketDataHandler;
        private readonly IBasicDataHandler<Data.Entities.OnlineFlightTicketPassengers> _onlineFlightTicketPassengersDataHandler;
        private readonly IBasicDataHandler<Data.Entities.Passengers> _passengersDataHandler;
        private readonly IBasicDataHandler<Data.Entities.Orders> _ordersDataHandler;
        private readonly IBasicDataHandler<Data.Entities.OnlineFlightTicketPath> _onlineFlightTicketPathDateHandler;
        private readonly IBasicDataHandler<Data.Entities.AirlineClassPath> _airlineClassPathDateHandler;
        private readonly IBasicDataHandler<Data.Entities.FlightPath> _flightPathDateHandler;
        private readonly IBasicDataHandler<Data.Entities.Airplane> _airplaneDateHandler;
        private readonly IBasicDataHandler<Data.Entities.FlightNumbers> _flightNumbersDateHandler;
        private readonly IMappingObject<SBSWebProject.Data.Entities.Passengers, PassengerFlight> _passengerFlightEntityToModel;
        private readonly IMappingObject<PassengerFlight, Data.Entities.Passengers> _passengerFlightModelToEntity;
        private readonly IMappingObject<Data.Entities.Airlines, Airlines> _airlineEntityToModel;
        private readonly IMappingObject<Data.Entities.City, City> _cityEntityToModel;
        private readonly IMappingObject<Data.Entities.OnlineFlightTicket, OnlineFlightTicketModel> _onlineFlightTicketModelEntityToModel;
        public DomesticFlightTicketMethod(IBasicDataHandler<Data.Entities.OnlineFlightTicket> onlineFlightTicketDataHandler,
            IBasicDataHandler<Data.Entities.UserPassenger> userPassengerDataHandler,
            IBasicDataHandler<Data.Entities.AirlineClassPathFee> airlineClassPathFeeDataHandler,
            IBasicDataHandler<Data.Entities.OnlineFlightTicketPassengers> onlineFlightTicketPassengersDataHandler,
            IBasicDataHandler<Data.Entities.Passengers> passengersDataHandler,
            IBasicDataHandler<Data.Entities.Orders> ordersDataHandler,
            IBasicDataHandler<Data.Entities.OnlineFlightTicketPath> onlineFlightTicketPathDateHandler,
            IBasicDataHandler<Data.Entities.AirlineClassPath> airlineClassPathDateHandler,
            IBasicDataHandler<Data.Entities.FlightPath> flightPathDateHandler,
            IBasicDataHandler<Data.Entities.Airplane> airplaneDateHandler,
            IBasicDataHandler<Data.Entities.FlightNumbers> flightNumbersDateHandler,
            IMappingObject<SBSWebProject.Data.Entities.Passengers, SBSWebProject.Web.Api.Models.PassengerFlight> passengerFlightEntityToModel,
            IMappingObject<PassengerFlight, Data.Entities.Passengers> passengerFlightModelToEntity,
            IMappingObject<Data.Entities.Airlines, Airlines> airlineEntityToModel,
            IMappingObject<Data.Entities.OnlineFlightTicket, OnlineFlightTicketModel> onlineFlightTicketModelEntityToModel,
            IAirlinesMethod airlinesMethod,
            IFlightPathMethod flightPathMethod,
            IMappingObject<Data.Entities.City, City> cityEntityToModel)
        {
            _airlinesMethod = airlinesMethod;
            _flightPathMethod = flightPathMethod;
            _userPassengerDataHandler = userPassengerDataHandler;
            _airlineClassPathFeeDataHandler = airlineClassPathFeeDataHandler;
            _onlineFlightTicketDataHandler = onlineFlightTicketDataHandler;
            _onlineFlightTicketPassengersDataHandler = onlineFlightTicketPassengersDataHandler;
            _passengersDataHandler = passengersDataHandler;
            _ordersDataHandler = ordersDataHandler;
            _onlineFlightTicketPathDateHandler = onlineFlightTicketPathDateHandler;
            _airlineClassPathDateHandler = airlineClassPathDateHandler;
            _flightPathDateHandler = flightPathDateHandler;
            _airplaneDateHandler = airplaneDateHandler;
            _flightNumbersDateHandler = flightNumbersDateHandler;
            _passengerFlightEntityToModel = passengerFlightEntityToModel;
            _passengerFlightModelToEntity = passengerFlightModelToEntity;
            _airlineEntityToModel = airlineEntityToModel;
            _cityEntityToModel = cityEntityToModel;
            _onlineFlightTicketModelEntityToModel = onlineFlightTicketModelEntityToModel;
        }
        public Dictionary<string, IList<ResponseDomesticTicketModel>> GetAllDomesticFlightTicket(DomesticFlightTicketModel domesticFlightTicketModel)
        {
            //Get Available Flight
            Dictionary<string, IList<ResponseDomesticTicketModel>> result = new Dictionary<string, IList<ResponseDomesticTicketModel>>();
            result.Add("Departing", GetOneWayTickets(domesticFlightTicketModel, 1));
            if (domesticFlightTicketModel.ReturningDate != "0/0/0")
                result.Add("Returning", GetOneWayTickets(domesticFlightTicketModel, 2));
            return result;
        }
        public Data.Entities.Orders GetAllDomesticFlightReserve(ReserveDomesticFlight reserveDomesticFlight, long userId, string userEmail)
        {
            // Get PNR and TicketNumber
            List<PassengerFlight> lstAllPassenger = reserveDomesticFlight.lstAdult.Concat(reserveDomesticFlight.lstChild).Concat(reserveDomesticFlight.lstInfant).ToList();
            DomFlightTicketModel D_DomFlightTicket = new DomFlightTicketModel();
            DomFlightTicketModel R_DomFlightTicket = new DomFlightTicketModel();
            Data.Entities.OnlineFlightTicketPath D_OnlineFlightTicketPath = new Data.Entities.OnlineFlightTicketPath();
            Data.Entities.OnlineFlightTicketPath R_OnlineFlightTicketPath = new Data.Entities.OnlineFlightTicketPath();
            Data.Entities.OnlineFlightTicket newOnlineDomFlightTicket_R = new Data.Entities.OnlineFlightTicket();
            Data.Entities.OnlineFlightTicket newOnlineDomFlightTicket_D = new Data.Entities.OnlineFlightTicket();

            IList<PnrModel> resultPnr = new List<PnrModel>();
            Dictionary<string, DomFlightTicketModel> resultDomFlightTicket = new Dictionary<string, DomFlightTicketModel>();
            PnrModel PNR;

            Data.Entities.Orders newOrder = new Data.Entities.Orders();
            PNR = GetReserve(reserveDomesticFlight, 1);  //Get PNR for Departing Flight
            if (!String.IsNullOrEmpty(PNR.PNR))
            {
                //create order and save in db
                newOrder = AddNewOrder(userId);
                resultPnr.Add(PNR);
                D_DomFlightTicket.Pnr = PNR;
                D_DomFlightTicket.SourceItem = reserveDomesticFlight.Source;
                D_DomFlightTicket.DestinationItem = reserveDomesticFlight.Target;
                D_DomFlightTicket.PassengerS = lstAllPassenger;
                D_DomFlightTicket.D_Airline = _airlineEntityToModel.Map(_airlinesMethod.GetAirlineEntityByIataCode(reserveDomesticFlight.D_Airline));
                newOnlineDomFlightTicket_D = AddOnlineFlightTicket(newOrder, PNR.PNR, Convert.ToInt64(reserveDomesticFlight.D_AdultFee), Convert.ToInt64(reserveDomesticFlight.D_ChildFee), Convert.ToInt64(reserveDomesticFlight.D_InfanfFee), reserveDomesticFlight.D_Date);
                D_OnlineFlightTicketPath = AddOnlineFlightTicketPath(newOnlineDomFlightTicket_D, reserveDomesticFlight.D_AirlineClassPathFeeId);

                if (reserveDomesticFlight.R_Airline != null)
                {
                    PNR = GetReserve(reserveDomesticFlight, 2); //Get PNR for Returning Flight
                    if (!String.IsNullOrEmpty(PNR.PNR))
                    {
                        resultPnr.Add(PNR);
                        R_DomFlightTicket.Pnr = PNR;
                        R_DomFlightTicket.SourceItem = reserveDomesticFlight.Target;
                        R_DomFlightTicket.DestinationItem = reserveDomesticFlight.Source;
                        R_DomFlightTicket.PassengerS = lstAllPassenger;
                        R_DomFlightTicket.R_Airline = _airlineEntityToModel.Map(_airlinesMethod.GetAirlineEntityByIataCode(reserveDomesticFlight.R_Airline));
                        newOnlineDomFlightTicket_R = AddOnlineFlightTicket(newOrder, PNR.PNR, Convert.ToInt64(reserveDomesticFlight.R_AdultFee), Convert.ToInt64(reserveDomesticFlight.R_ChildFee), Convert.ToInt64(reserveDomesticFlight.R_InfanfFee), reserveDomesticFlight.R_Date);
                        R_OnlineFlightTicketPath = AddOnlineFlightTicketPath(newOnlineDomFlightTicket_R, reserveDomesticFlight.R_AirlineClassPathFeeId);
                    }
                }
            }
            Dictionary<string, DomFlightTicketModel> lstResult = GetTicket(newOnlineDomFlightTicket_D, newOnlineDomFlightTicket_R, D_DomFlightTicket, R_DomFlightTicket, D_OnlineFlightTicketPath, R_OnlineFlightTicketPath, userEmail);

            //return lstResult;
            return newOrder;
        }
        private Dictionary<string, DomFlightTicketModel> GetTicket(Data.Entities.OnlineFlightTicket D_OnlineFlightTicket, Data.Entities.OnlineFlightTicket R_OnlineFlightTicket, DomFlightTicketModel departingTicket, DomFlightTicketModel returningTicket, Data.Entities.OnlineFlightTicketPath D_OnlineFlightTicketPath, Data.Entities.OnlineFlightTicketPath R_OnlineFlightTicketPath, string email)
        {
            Dictionary<string, DomFlightTicketModel> resultDic = new Dictionary<string, DomFlightTicketModel>();
            if (departingTicket.Pnr != null)
            {
                List<PassengerFlight> D_PassengerWithTNumber = GetTicketNumber(departingTicket.D_Airline.IataCode, departingTicket.Pnr.PNR, email, departingTicket.PassengerS);
                departingTicket.PassengerS = AssignTicketNumber(departingTicket.PassengerS, D_PassengerWithTNumber);
                AddOnlineFlightTicketPassengers(D_OnlineFlightTicket, D_OnlineFlightTicketPath, departingTicket.PassengerS);
                resultDic.Add("DepartingTickets", departingTicket);
            }
            if (returningTicket.Pnr != null)
            {
                List<PassengerFlight> R_PassengerWithTNumber = GetTicketNumber(returningTicket.R_Airline.IataCode, returningTicket.Pnr.PNR, email, returningTicket.PassengerS);
                returningTicket.PassengerS = AssignTicketNumber(returningTicket.PassengerS, R_PassengerWithTNumber);
                AddOnlineFlightTicketPassengers(R_OnlineFlightTicket, R_OnlineFlightTicketPath, returningTicket.PassengerS);
                resultDic.Add("ReturningTickets", returningTicket);
            }
            return resultDic;
        }
        private List<PassengerFlight> AssignTicketNumber(List<PassengerFlight> lstPassenger, List<PassengerFlight> lstPassengerWithTNumber)
        {
            foreach (PassengerFlight item in lstPassenger)
            {
                foreach (var itemTicketNumber in lstPassengerWithTNumber)
                {
                    if (item.LastName_En.Trim() == itemTicketNumber.LastName_En.Trim() &&
                        item.Name_En.Trim() == itemTicketNumber.Name_En.Trim())
                    {
                        item.TicketNumber = itemTicketNumber.TicketNumber;
                    }
                }
            }
            return lstPassenger;
        }
        private List<PassengerFlight> GetTicketNumber(string airline, string pnr, string email, List<PassengerFlight> lstPassenger)
        {
            string url = @"http://10.30.205.50/cgi-bin/nrsweb.cgi/IssueETMaskJS?AirLine=" + airline + "&PNR=" + pnr + "&Email=" + email + "&No=" + lstPassenger.Count + PassengerString(lstPassenger);
            //string url = @"http://localhost:9983/api/V1/domestic/ticket/getTicketNumberTest";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                request.ContentType = @"application/json";
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding(1256));
                    var jsonObject = reader.ReadToEnd();

                    Dictionary<string, List<Dictionary<string, string>>> ResponseGetTicket = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(jsonObject);
                    IList<string> sss = ResponseGetTicket["AirIssueET"][0]["ETS"].Split('\r');
                    return GetIssuanceTicket(sss);
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
        private List<PassengerFlight> GetIssuanceTicket(IList<string> issuanceList)
        {
            List<PassengerFlight> resultIssuance = new List<PassengerFlight>();
            foreach (string item in issuanceList)
            {
                PassengerFlight newPassengerFlight = new PassengerFlight
                {
                    LastName_En = item.Trim().Split('/')[0],
                    Name_En = item.Trim().Split('/')[1].Split('=')[0],
                    TicketNumber = item.Trim().Split('/')[1].Split('=')[1],
                };
                resultIssuance.Add(newPassengerFlight);
            }
            return resultIssuance;
        }
        private Data.Entities.Orders AddNewOrder(long userId)
        {
            Data.Entities.Orders newOrder = new Data.Entities.Orders
            {
                UsersItem = new Data.Entities.Users { Id = userId },
                //OrderStatusItem=
                SubmitDateTime = DateTime.Now,
            };
            _ordersDataHandler.Save(newOrder);
            return newOrder;
        }
        private Data.Entities.OnlineFlightTicket AddOnlineFlightTicket(Data.Entities.Orders newOrder, string PNR, long adultFee, long childFee, long infantFee, string ticketDate)
        {
            DateController dc = new DateController();
            Data.Entities.OnlineFlightTicket newOnlineDomFlightTicket = new Data.Entities.OnlineFlightTicket
            {
                //TODO save service of online domestic ticket
                OrdersItem = newOrder,
                PNR = PNR,
                TicketDate = dc.ConvertJalai2Ger(ticketDate)
            };
            _onlineFlightTicketDataHandler.Save(newOnlineDomFlightTicket);
            return newOnlineDomFlightTicket;
        }
        private void AddOnlineFlightTicketPassengers(Data.Entities.OnlineFlightTicket onlineFlightTicket, Data.Entities.OnlineFlightTicketPath onlineFlightTicketPath, List<PassengerFlight> lstAllPassenger)
        {
            foreach (PassengerFlight item in lstAllPassenger)
            {
                Data.Entities.OnlineFlightTicketPassengers oftp = new Data.Entities.OnlineFlightTicketPassengers
                {
                    OnlineFlightTicketItem = onlineFlightTicket,
                    OnlineFlightTicketPathItem = onlineFlightTicketPath,
                    PassengersItem = new Data.Entities.Passengers { Id = (long)item.Id },
                    TicketNumber = item.TicketNumber,
                };
                _onlineFlightTicketPassengersDataHandler.Save(oftp);
            }
        }
        private Data.Entities.OnlineFlightTicketPath AddOnlineFlightTicketPath(Data.Entities.OnlineFlightTicket onlineFlightTicket, long airlineClassPathFeeId)
        {
            Data.Entities.OnlineFlightTicketPath newOnlineFlightTicketPath = new Data.Entities.OnlineFlightTicketPath
            {
                AirlineClassPathFeeItem = new Data.Entities.AirlineClassPathFee { Id = airlineClassPathFeeId },
                OnlineFlightTicketItem = onlineFlightTicket,
                DeparturDate = onlineFlightTicket.TicketDate
            };

            _onlineFlightTicketPathDateHandler.Save(newOnlineFlightTicketPath);
            return newOnlineFlightTicketPath;
        }
        private Data.Entities.AirlineClassPath AddAirlineClassPath(Data.Entities.AirlineSubClasses airlineSubClasses, Data.Entities.FlightPath flightPath, long adultFee, long childFee, long infantFee)
        {
            Data.Entities.AirlineClassPath newAirlineClassPath = new Data.Entities.AirlineClassPath
            {
                AirlineSubClassesItem = airlineSubClasses,
                FlightPathItem = flightPath,
                IsActive = true
            };
            _airlineClassPathDateHandler.Save(newAirlineClassPath);
            Data.Entities.AirlineClassPathFee newAirlineClassPathFee = AddAirlineClassPathFee(newAirlineClassPath, adultFee, childFee, infantFee);
            return newAirlineClassPath;
        }
        private Data.Entities.AirlineClassPathFee AddAirlineClassPathFee(Data.Entities.AirlineClassPath airlineClassPath, long adultFee, long childFee, long infantFee)
        {
            //List<Data.Entities.AirlineClassPathFee> lstCheckFee = _airlineClassPathFeeDataHandler.SelectAll().Cast<Data.Entities.AirlineClassPathFee>().Where(c => c.State == 0 && c.AirlineClassPathItem.Id == airlineClassPath.Id && c.AdultFee == adultFee && c.ChildFee == childFee && c.InfantFee == infantFee).ToList();
            List<Data.Entities.AirlineClassPathFee> lstCheckExistAirlineClassPathInFee = _airlineClassPathFeeDataHandler.SelectAll().Cast<Data.Entities.AirlineClassPathFee>().Where(c => c.State == 0 && c.AirlineClassPathItem.Id == airlineClassPath.Id).ToList();
            if (lstCheckExistAirlineClassPathInFee.Count == 1)
            {
                if (lstCheckExistAirlineClassPathInFee[0].AdultFee == adultFee && lstCheckExistAirlineClassPathInFee[0].ChildFee == childFee && lstCheckExistAirlineClassPathInFee[0].InfantFee == infantFee)
                {
                    return lstCheckExistAirlineClassPathInFee[0];
                }
                else
                {
                    Data.Entities.AirlineClassPathFee newAirlineClassPathFee = AddAirlineClassPathFeeInDb(airlineClassPath, adultFee, childFee, infantFee);
                    lstCheckExistAirlineClassPathInFee[0].IsActive = false;
                    _airlineClassPathFeeDataHandler.Update(lstCheckExistAirlineClassPathInFee[0]);
                    return newAirlineClassPathFee;
                }
            }
            else
            {
                return AddAirlineClassPathFeeInDb(airlineClassPath, adultFee, childFee, infantFee);
                //Data.Entities.AirlineClassPathFee newAirlineClassPathFee = new Data.Entities.AirlineClassPathFee
                //{
                //    AirlineClassPathItem = airlineClassPath,
                //    AdultFee = adultFee,
                //    ChildFee = childFee,
                //    InfantFee = infantFee,
                //    IsActive = true,
                //};
                //_airlineClassPathFeeDataHandler.Save(newAirlineClassPathFee);
                //return newAirlineClassPathFee;
            }

        }
        private Data.Entities.AirlineClassPathFee AddAirlineClassPathFeeInDb(Data.Entities.AirlineClassPath airlineClassPath, long adultFee, long childFee, long infantFee)
        {
            Data.Entities.AirlineClassPathFee newAirlineClassPathFee = new Data.Entities.AirlineClassPathFee
            {
                AirlineClassPathItem = airlineClassPath,
                AdultFee = adultFee,
                ChildFee = childFee,
                InfantFee = infantFee,
                IsActive = true,
            };
            _airlineClassPathFeeDataHandler.Save(newAirlineClassPathFee);
            return newAirlineClassPathFee;
        }
        private Data.Entities.FlightPath AddFlightPath(City source, City destination)
        {
            Data.Entities.FlightPath newFlightPath = new Data.Entities.FlightPath
            {
                DestinationCityItem = new Data.Entities.City { Id = destination.Id },
                SourceCityItem = new Data.Entities.City { Id = source.Id },
            };
            _flightPathDateHandler.Save(newFlightPath);
            return newFlightPath;
        }
        private PnrModel GetReserve(ReserveDomesticFlight reserveDomesticFlight, short kind)
        {
            //kind == 1 means departure and kind == 2 means returning
            string passengerRout = PassengerString(reserveDomesticFlight.lstAdult, reserveDomesticFlight.lstChild, reserveDomesticFlight.lstInfant);
            if (kind == 1)
                return GetPNR(reserveDomesticFlight.D_Airline, reserveDomesticFlight.Source.CharCode, reserveDomesticFlight.Target.CharCode, reserveDomesticFlight.D_FlightClass, reserveDomesticFlight.D_FlightNo, reserveDomesticFlight.D_Day, reserveDomesticFlight.D_Month, reserveDomesticFlight.No, passengerRout);
            else
                return GetPNR(reserveDomesticFlight.R_Airline, reserveDomesticFlight.Target.CharCode, reserveDomesticFlight.Source.CharCode, reserveDomesticFlight.R_FlightClass, reserveDomesticFlight.R_FlightNo, reserveDomesticFlight.R_Day, reserveDomesticFlight.R_Month, reserveDomesticFlight.No, passengerRout);
        }
        public PnrModel GetPNR(string airline, string source, string target, string flightClass, string flightNo, string day, string month, string no, string passengerRout)
        {
            string url = @"http://10.30.205.50/cgi-bin/nrsweb.cgi/ReservJS?Airline=" + airline + "&cbSource=" + source + "&cbTarget=" + target + "&FlightClass=" + flightClass + "&FlightNo=" + flightNo + "&Day=" + day + "&Month=" + month + "&No=" + no + passengerRout;
            //string url = @"http://localhost:9983/api/V1/domestic/ticket/getPnrTest";
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
                    return new PnrModel
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
                AvailableDepartureFlights = GetAvailableFlights(requestInfo.Source, requestInfo.Destination, requestInfo.DepartingDate.Split('/')[2], requestInfo.DepartingDate.Split('/')[1], requestInfo.Adult.Number, requestInfo.Child.Number, requestInfo.Infant.Number);
            else
                AvailableDepartureFlights = GetAvailableFlights(requestInfo.Destination, requestInfo.Source, requestInfo.ReturningDate.Split('/')[2], requestInfo.ReturningDate.Split('/')[1], requestInfo.Adult.Number, requestInfo.Child.Number, requestInfo.Infant.Number);
            IList<ResponseDomesticTicketModel> lstResult = new List<ResponseDomesticTicketModel>();
            foreach (var item in AvailableDepartureFlights)
            {
                Data.Entities.FlightNumbers newFlightNumbers = new Data.Entities.FlightNumbers();
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
                newFlightNumbers.FlightNumber = Convert.ToInt32(item["FlightNo"]); //set flightNumber for new FlghtNumberObjet for save
                newFlightNumbers.TakeOffTime = Convert.ToDateTime(item["DepartureTime"]); //set takeOff Time for new FlghtNumberObjet for save
                newFlightNumbers.LandingTime = Convert.ToDateTime(item["ArrivalTime"]); //set Landing Time for new FlghtNumberObjet for save
                IList<string> lstClass = item["FlightClasses"].Split(' ');
                foreach (string classItem in lstClass)
                {
                    if (CheckAvailableFlightClass(item["AirLine"], classItem))
                    {
                        Data.Entities.AirlineClassPath newAirlineClassPath = new Data.Entities.AirlineClassPath();
                        Data.Entities.Airlines airlineEntiy = _airlinesMethod.GetAirlineEntityByIataCode(item["AirLine"]);
                        if (airlineEntiy != null)
                        {
                            Data.Entities.AirlineSubClasses airlineSubClassesEntity = _airlinesMethod.GetAirlineSubClassEntityByName(airlineEntiy, classItem[0].ToString());
                            if (airlineSubClassesEntity != null)
                            {
                                newFlightNumbers.AirlineSubClassesItem = airlineSubClassesEntity; //set airline subclass for new FlghtNumberObjet for save
                                Data.Entities.FlightPath flightPathEntity = new Data.Entities.FlightPath();
                                if (kind == 1)
                                    flightPathEntity = _flightPathMethod.GetFlightPathEntity(requestInfo.Source, requestInfo.Destination);
                                else if (kind == 2)
                                    flightPathEntity = _flightPathMethod.GetFlightPathEntity(requestInfo.Destination, requestInfo.Source);
                                Data.Entities.AirlineClassPath CheckExistAirlineClassPathObj = CheckExistAirlineClassPath(airlineSubClassesEntity, flightPathEntity);
                                if (CheckExistAirlineClassPathObj == null)
                                {
                                    //insert airlineClassPath if not exist
                                    newAirlineClassPath = new Data.Entities.AirlineClassPath
                                    {
                                        AirlineSubClassesItem = airlineSubClassesEntity,
                                        FlightPathItem = flightPathEntity
                                    };
                                    _airlineClassPathDateHandler.Save(newAirlineClassPath);
                                    newFlightNumbers.AirlineClassPathItem = newAirlineClassPath; // set airlineClassPath to flightNumber for save new
                                }
                                else
                                {
                                    newAirlineClassPath = CheckExistAirlineClassPathObj;
                                    newFlightNumbers.AirlineClassPathItem = newAirlineClassPath; // set airlineClassPath to flightNumber for save new
                                }

                                newFlightNumbers.AirplaneItem = SaveAirplane(flightObj.PlaneType);
                                SaveFlightNumber(newFlightNumbers);
                            }
                        }
                        var AvailableFlightsFare = new Dictionary<string, string>();
                        Data.Entities.AirlineClassPathFee newAirlineClassPathFee;
                        if (kind == 1)
                        {
                            //save airline class path fee
                            AvailableFlightsFare = GetFlightClassFareIfCashed(item["AirLine"], requestInfo.Source, requestInfo.Destination, requestInfo.DepartingDate.Split('/')[2], requestInfo.DepartingDate.Split('/')[1], "0", "0", classItem[0].ToString());
                            newAirlineClassPathFee = AddAirlineClassPathFee(item["AirLine"], newAirlineClassPath, AvailableFlightsFare);
                        }
                        else
                        {
                            //save airline class path fee
                            AvailableFlightsFare = GetFlightClassFareIfCashed(item["AirLine"], requestInfo.Destination, requestInfo.Source, requestInfo.ReturningDate.Split('/')[2], requestInfo.ReturningDate.Split('/')[1], "0", "0", classItem[0].ToString());
                            newAirlineClassPathFee = AddAirlineClassPathFee(item["AirLine"], newAirlineClassPath, AvailableFlightsFare);
                        }
                        ClassFare classFare = new ClassFare
                        {
                            AdultFare = AvailableFlightsFare["AdultFare"],
                            ChildFare = AvailableFlightsFare["ChildFare"],
                            InfantFare = AvailableFlightsFare["InfantFare"],
                            FlightClass = classItem[0].ToString(),
                            AirlineClassPathFeeId = newAirlineClassPathFee.Id,
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
        private void SaveFlightNumber(Data.Entities.FlightNumbers newFlightNumbers)
        {
            _flightNumbersDateHandler.Save(newFlightNumbers);
        }
        private Data.Entities.Airplane SaveAirplane(string airplaneName)
        {
            var ariplane = CheckExistAirplaneByName(airplaneName);
            if (ariplane == null)
            {
                Data.Entities.Airplane newAirplane = new Data.Entities.Airplane { Name = airplaneName };
                _airplaneDateHandler.Save(newAirplane);
                return newAirplane;
            }
            else
                return ariplane;

        }
        private Data.Entities.Airplane CheckExistAirplaneByName(string airplaneName)
        {

            List<Data.Entities.Airplane> lstResult = _airplaneDateHandler.SelectAll().Cast<Data.Entities.Airplane>().Where(c => c.Name == airplaneName).ToList();
            if (lstResult.Count == 1)
                return lstResult[0];
            else
                return null;
        }
        private Data.Entities.AirlineClassPathFee AddAirlineClassPathFee(string airlineCode, Data.Entities.AirlineClassPath airlineClassPath, Dictionary<string, string> availableFlightsFare)
        {
            Data.Entities.AirlineClassPathFee newAirlineClassPathFee;
            newAirlineClassPathFee = CheckExistAirlineClassPathFee(airlineClassPath, availableFlightsFare);
            if (newAirlineClassPathFee == null)
            {
                newAirlineClassPathFee = new Data.Entities.AirlineClassPathFee
                {
                    AirlineClassPathItem = airlineClassPath,
                    AdultFee = Convert.ToInt64(availableFlightsFare["AdultFare"]),
                    ChildFee = Convert.ToInt64(availableFlightsFare["ChildFare"]),
                    InfantFee = Convert.ToInt64(availableFlightsFare["InfantFare"]),
                    RegisterDate = DateTime.Now,
                    IsActive = true
                };
                _airlineClassPathFeeDataHandler.Save(newAirlineClassPathFee);
            }
            return newAirlineClassPathFee;
        }
        private Data.Entities.AirlineClassPathFee CheckExistAirlineClassPathFee(Data.Entities.AirlineClassPath airlineClassPath, Dictionary<string, string> availableFlightsFare)
        {
            List<Data.Entities.AirlineClassPathFee> lst = _airlineClassPathFeeDataHandler.SelectAll().Cast<Data.Entities.AirlineClassPathFee>().Where(c => c.AirlineClassPathItem.Id == airlineClassPath.Id
                        && c.AdultFee == Convert.ToInt64(availableFlightsFare["AdultFare"])
                        && c.ChildFee == Convert.ToInt64(availableFlightsFare["ChildFare"])
                        && c.InfantFee == Convert.ToInt64(availableFlightsFare["InfantFare"])).ToList();
            if (lst.Count == 1)
                return lst[0];
            return null;
        }
        private Data.Entities.AirlineClassPath CheckExistAirlineClassPath(Data.Entities.AirlineSubClasses airlineSubClass, Data.Entities.FlightPath flightPath)
        {
            List<Data.Entities.AirlineClassPath> lst = _airlineClassPathDateHandler.SelectAll().Cast<Data.Entities.AirlineClassPath>().Where(c => c.AirlineSubClassesItem.Id == airlineSubClass.Id && c.FlightPathItem.Id == flightPath.Id).ToList();
            if (lst.Count > 0)
                return lst[0];
            else
                return null;
        }
        public Dictionary<string, string> GetFlightClassFareIfCashed(string AirLine, City cbSource, City cbTarget, string DepartureDay, string DepartureMonth, string ReturnDay, string ReturnMonth, string FlightClassCode)
        {
            List<Data.Entities.AirlineClassPathFee> lstClassPathFee = _airlineClassPathFeeDataHandler.SelectAll().Cast<Data.Entities.AirlineClassPathFee>()
                .Where(c => c.AirlineClassPathItem.AirlineSubClassesItem.AirlinesItem.IataCode.ToUpper() == AirLine.ToUpper() &&
                c.AirlineClassPathItem.AirlineSubClassesItem.AirlineSubClassName.ToUpper() == FlightClassCode.ToUpper() &&
                c.AirlineClassPathItem.FlightPathItem.SourceCityItem.Id == cbSource.Id &&
                c.AirlineClassPathItem.FlightPathItem.DestinationCityItem.Id == cbTarget.Id &&
                c.IsActive == true).ToList();
            if (lstClassPathFee.Count > 0)
            {
                Dictionary<string, string> AirlineClassPathFeeDic = new Dictionary<string, string>();
                AirlineClassPathFeeDic.Add("AdultFare", lstClassPathFee[0].AdultFee.ToString());
                AirlineClassPathFeeDic.Add("ChildFare", lstClassPathFee[0].ChildFee.ToString());
                AirlineClassPathFeeDic.Add("InfantFare", lstClassPathFee[0].InfantFee.ToString());
                return AirlineClassPathFeeDic;
            }
            else
            {
                return GetFlightClassFare(AirLine, cbSource, cbTarget, DepartureDay, DepartureMonth, ReturnDay, ReturnMonth, FlightClassCode);
            }
        }
        public Dictionary<string, string> GetFlightClassFare(string AirLine, City cbSource, City cbTarget, string DepartureDay, string DepartureMonth, string ReturnDay, string ReturnMonth, string FlightClassCode)
        {

            string url = @"http://10.30.205.50/cgi-bin/nrsweb.cgi/FareJS?AirLine=" + AirLine + "&cbSource=" + cbSource.CharCode + "&cbTarget=" + cbTarget.CharCode + "&DepartureDay=" + DepartureDay + "&DepartureMonth=" + DepartureMonth + "&ReturnDay=" + ReturnDay + "&ReturnMonth=" + ReturnMonth + "&FlightClassCode=" + FlightClassCode;
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
        public List<Dictionary<string, string>> GetAvailableFlights(City source, City destination, string day, string month, string adultQty, string childQty, string infantQty)
        {
            if (!CheckExistFlightPath(source, destination))
            {
                AddFlightPath(source, destination);
            }
            string url = @"http://10.30.205.50/cgi-bin/nrsweb.cgi/AvailabilityJS?cbSource=" + source.CharCode + "&cbTarget=" + destination.CharCode + "&cbDay1=" + day + "&cbMonth1=" + month + "&cbAdultQty=" + adultQty + "&cbChildQty=" + childQty + "&cbInfantQty=" + infantQty;
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
        private bool CheckExistFlightPath(City source, City destination)
        {
            IList<Data.Entities.FlightPath> lstFlightPath = _flightPathDateHandler.SelectAll().Cast<Data.Entities.FlightPath>().Where(c => c.SourceCityItem.Id == source.Id && c.DestinationCityItem.Id == destination.Id).ToList();
            if (lstFlightPath.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
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
        private string PassengerString(List<PassengerFlight> lstPassenger)
        {
            string setPassenger = "";
            int cnt = 1;
            if (lstPassenger.Count > 0)
                for (int i = 0; i < lstPassenger.Count; i++)
                {
                    setPassenger += "&edtName" + cnt + "=" + lstPassenger[i].Name_En;
                    setPassenger += "&edtLast" + cnt + "=" + lstPassenger[i].LastName_En;
                    setPassenger += "&edtAge" + cnt + "=" + lstPassenger[i].BD.Replace('/', '-');
                    cnt++;
                }
            return setPassenger;
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
                    setPassenger += "&edtAge" + cnt + "=" + lstAdult[i].BD.Replace('/', '-');
                    //setPassenger += "&edtAge" + cnt + "=30";
                    setPassenger += "&edtID" + cnt + "=" + lstAdult[i].NationalCode;
                    setPassenger += "&edtContact=" + lstAdult[i].Tel;
                    cnt++;
                }
            if (lstChild.Count > 0)
                for (int i = 0; i < lstChild.Count; i++)
                {
                    setPassenger += "&edtName" + cnt + "=" + lstAdult[i].Name_En;
                    setPassenger += "&edtLast" + cnt + "=" + lstAdult[i].LastName_En;
                    setPassenger += "&edtAge" + cnt + "=" + lstAdult[i].BD.Replace('/', '-');
                    //setPassenger += "&edtAge" + cnt + "=10";
                    setPassenger += "&edtID" + cnt + "=" + lstAdult[i].NationalCode;
                    setPassenger += "&edtContact=" + lstAdult[i].Tel;
                    cnt++;
                }
            if (lstInfant.Count > 0)
                for (int i = 0; i < lstInfant.Count; i++)
                {
                    setPassenger += "&edtName" + cnt + "=" + lstAdult[i].Name_En;
                    setPassenger += "&edtLast" + cnt + "=" + lstAdult[i].LastName_En;
                    setPassenger += "&edtAge" + cnt + "=" + lstAdult[i].BD.Replace('/', '-');
                    //setPassenger += "&edtAge" + cnt + "=2";
                    setPassenger += "&edtID" + cnt + "=" + lstAdult[i].NationalCode;
                    setPassenger += "&edtContact=" + lstAdult[i].Tel;
                    cnt++;
                }
            return setPassenger;
        }
        //public IList GetTicketNumberTest()
        //{
        //    string url = @"http://10.30.205.50/cgi-bin/nrsweb.cgi/IssueFakeETMaskJS?AirLine=IR&PNR=NBGFT&Email=hamzian@nirasoftware.com";
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    try
        //    {
        //        request.ContentType = @"application /json";
        //        WebResponse response = request.GetResponse();
        //        using (Stream responseStream = response.GetResponseStream())
        //        {
        //            StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding(1256));
        //            var jsonObject = reader.ReadToEnd();

        //            Dictionary<string, List<Dictionary<string, string>>> ResponseGetTicket = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(jsonObject);
        //            return ResponseGetTicket["AirIssueET"][0]["ETS"].Split('\r');
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        WebResponse errorResponse = ex.Response;
        //        using (Stream responseStream = errorResponse.GetResponseStream())
        //        {
        //            StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
        //            String errorText = reader.ReadToEnd();
        //            // log errorText
        //        }
        //        throw;
        //    }
        //}
        public Dictionary<string, List<PassengerFlight>> SaveOnlineFlightTicketPassenger(List<PassengerFlight> lstAdult, List<PassengerFlight> lstChild, List<PassengerFlight> lstInfant, long userId)
        {
            Dictionary<string, List<PassengerFlight>> dic = new Dictionary<string, List<PassengerFlight>>();
            for (int i = 0; i < lstAdult.Count; i++)
            {
                Data.Entities.Passengers pfEntity = _passengerFlightModelToEntity.Map(lstAdult[i]);
                pfEntity.OwnerUserItem = new Data.Entities.Users { Id = userId };
                _passengersDataHandler.Save(pfEntity);
                lstAdult[i] = _passengerFlightEntityToModel.Map(pfEntity);
            }
            dic.Add("lstAdult", lstAdult);
            for (int i = 0; i < lstChild.Count; i++)
            {
                Data.Entities.Passengers pfEntity = _passengerFlightModelToEntity.Map(lstAdult[i]);
                pfEntity.OwnerUserItem = new Data.Entities.Users { Id = userId };
                _passengersDataHandler.Save(pfEntity);
                lstAdult[i] = _passengerFlightEntityToModel.Map(pfEntity);
            }
            dic.Add("lstChild", lstAdult);
            for (int i = 0; i < lstInfant.Count; i++)
            {
                Data.Entities.Passengers pfEntity = _passengerFlightModelToEntity.Map(lstAdult[i]);
                pfEntity.OwnerUserItem = new Data.Entities.Users { Id = userId };
                _passengersDataHandler.Save(pfEntity);
                lstAdult[i] = _passengerFlightEntityToModel.Map(pfEntity);
            }
            dic.Add("lstInfant", lstAdult);
            return dic;
        }
        public Dictionary<string, List<PassengerFlight>> SaveUserPassengers(List<PassengerFlight> lstAdult, List<PassengerFlight> lstChild, List<PassengerFlight> lstInfant, long userId)
        {
            Dictionary<string, List<PassengerFlight>> resultDic = new Dictionary<string, List<PassengerFlight>>();
            List<PassengerFlight> resultAdultList = new List<PassengerFlight>();
            List<PassengerFlight> resultChildList = new List<PassengerFlight>();
            List<PassengerFlight> resultInfantList = new List<PassengerFlight>();
            foreach (PassengerFlight item in lstAdult)
            {
                Data.Entities.Passengers passenger = _passengerFlightModelToEntity.Map(item);
                _passengersDataHandler.Save(passenger);
                item.Id = passenger.Id;
                resultAdultList.Add(item);
                Data.Entities.UserPassenger newUserPassenger = new Data.Entities.UserPassenger
                {
                    PassengersItem = new Data.Entities.Passengers { Id = (long)item.Id },
                    UsersItem = new Data.Entities.Users { Id = userId }
                };
                _userPassengerDataHandler.Save(newUserPassenger);
            }
            foreach (PassengerFlight item in lstChild)
            {
                _passengersDataHandler.Save(_passengerFlightModelToEntity.Map(item));
                resultChildList.Add(item);
                Data.Entities.UserPassenger newUserPassenger = new Data.Entities.UserPassenger
                {
                    PassengersItem = _passengerFlightModelToEntity.Map(item),
                    UsersItem = new Data.Entities.Users { Id = userId }
                };
                _userPassengerDataHandler.Save(newUserPassenger);
            }
            foreach (PassengerFlight item in lstInfant)
            {
                _passengersDataHandler.Save(_passengerFlightModelToEntity.Map(item));
                resultInfantList.Add(item);
                Data.Entities.UserPassenger newUserPassenger = new Data.Entities.UserPassenger
                {
                    PassengersItem = _passengerFlightModelToEntity.Map(item),
                    UsersItem = new Data.Entities.Users { Id = userId }
                };
                _userPassengerDataHandler.Save(newUserPassenger);
            }
            resultDic.Add("lstAdult", resultAdultList);
            resultDic.Add("lstChild", resultChildList);
            resultDic.Add("lstInfant", resultInfantList);
            return resultDic;
        }
        public List<OnlineFlightTicketModel> GetSavedTicketByOrderMethod(long orderId)
        {
            DateController dc = new DateController();
            Data.Entities.Orders savedOrder = _ordersDataHandler.GetEntity(orderId);
            List<OnlineFlightTicketModel> lstResult = new List<OnlineFlightTicketModel>();
            //foreach (Data.Entities.OnlineFlightTicket item in savedOrder.OnlineFlightTicketS.Where(c => c.State == 0))
            //{
            //    DomFlightTicketModel newDomFlightTicketModel = new DomFlightTicketModel();
            //    PnrModel pnrModel = new PnrModel();
            //    List<PassengerFlight> passengerList = new List<PassengerFlight>();
            //    pnrModel.PNR = item.PNR;
            //    newDomFlightTicketModel.Pnr = pnrModel;
            //    Data.Entities.OnlineFlightTicketPath newOnlineFlightTicketPath = item.OnlineFlightTicketPathS.Where(c => c.State == 0).Cast<Data.Entities.OnlineFlightTicketPath>().ToList()[0];
            //    newDomFlightTicketModel.SourceItem = _cityEntityToModel.Map(newOnlineFlightTicketPath.AirlineClassPathFeeItem.AirlineClassPathItem.FlightPathItem.SourceCityItem);
            //    newDomFlightTicketModel.DestinationItem = _cityEntityToModel.Map(newOnlineFlightTicketPath.AirlineClassPathFeeItem.AirlineClassPathItem.FlightPathItem.DestinationCityItem);
            //    Airlines newAirlines = new Airlines();
            //    newAirlines.Id= newOnlineFlightTicketPath.AirlineClassPathFeeItem.AirlineClassPathItem.AirlineSubClassesItem.AirlineClassesItem.AirlineItem.Id;
            //    newAirlines.IataCode= newOnlineFlightTicketPath.AirlineClassPathFeeItem.AirlineClassPathItem.AirlineSubClassesItem.AirlineClassesItem.AirlineItem.IataCode;
            //    newAirlines.Name = NameOfAirLine(newOnlineFlightTicketPath.AirlineClassPathFeeItem.AirlineClassPathItem.AirlineSubClassesItem.AirlineClassesItem.AirlineItem.IataCode);
            //    newDomFlightTicketModel.D_Airline = newAirlines;
            //    foreach (Data.Entities.OnlineFlightTicketPassengers passengerItem in item.OnlineFlightTicketPassengersS)
            //    {
            //        PassengerFlight newPassengerFlight = new PassengerFlight
            //        {
            //            BD = dc.ConvertGer2Jalai(Convert.ToDateTime(passengerItem.PassengersItem.BirthDate)),
            //            Id = passengerItem.Id,
            //            LastName_En = passengerItem.PassengersItem.InternationalFamily,
            //            Name_En = passengerItem.PassengersItem.InternationalName,
            //            LastName_Fa = passengerItem.PassengersItem.NativeFamily,
            //            Name_Fa = passengerItem.PassengersItem.NativeName,
            //            NationalCode = passengerItem.PassengersItem.NationalCode.ToString(),
            //            Tel = passengerItem.PassengersItem.Tel,
            //            TicketNumber = passengerItem.TicketNumber,
            //        };
            //        passengerList.Add(newPassengerFlight);
            //    }
            //    newDomFlightTicketModel.PassengerS = passengerList;
            //    lstResult.Add(newDomFlightTicketModel);
            //}
            foreach (Data.Entities.OnlineFlightTicket item in savedOrder.OnlineFlightTicketS.Where(c => c.State == 0))
            {
                lstResult.Add(_onlineFlightTicketModelEntityToModel.Map(item));
            }
            return lstResult;
        }

    }
}