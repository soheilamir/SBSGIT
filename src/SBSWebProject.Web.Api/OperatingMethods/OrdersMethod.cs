using SBSWebProject.Web.Api.MethodsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SBSWebProject.Web.Api.Models;
using SBSWebProject.Data.DataHandlers;
using SBSWebProject.MappingObject;
using System.Web.Http;

namespace SBSWebProject.Web.Api.OperatingMethods
{
    public class OrdersMethod : IOrdersMethod
    {
        private readonly IBasicDataHandler<Data.Entities.Orders> _ordersHandler;
        private readonly IBasicDataHandler<Data.Entities.Users> _usersHandler;
        private readonly IBasicDataHandler<Data.Entities.RequestAirplaneService> _requestAirplaneServiceHandler;
        private readonly IBasicDataHandler<Data.Entities.RequestAirplaneTicket> _requestAirplaneTicketHandler;

        private readonly IMappingObject<Data.Entities.Orders, Orders> _ordersEntityToModel;
        private readonly IMappingObject<Orders, Data.Entities.Orders> _ordersModelToEntity;
        private readonly IMappingObject<RequestAirplaneService, Data.Entities.RequestAirplaneService> _requestAirplaneServiceModelToEntity;
        private readonly IMappingObject<RequestAirplaneTicket, Data.Entities.RequestAirplaneTicket> _requestAirplaneTicketModelToEntity;
        public OrdersMethod(IBasicDataHandler<Data.Entities.Orders> ordersHandler,
            IBasicDataHandler<Data.Entities.Users> usersHandler,
            IBasicDataHandler<Data.Entities.RequestAirplaneService> requestAirplaneServiceHandler,
            IBasicDataHandler<Data.Entities.RequestAirplaneTicket> requestAirplaneTicketHandler,
            IMappingObject<Data.Entities.Orders, Orders> ordersEntityToModel,
            IMappingObject<Orders, Data.Entities.Orders> ordersModelToEntity,
            IMappingObject<RequestAirplaneService, Data.Entities.RequestAirplaneService> requestAirplaneServiceModelToEntity,
            IMappingObject<RequestAirplaneTicket, Data.Entities.RequestAirplaneTicket> requestAirplaneTicketModelToEntity)
        {
            _ordersHandler = ordersHandler;
            _usersHandler = usersHandler;
            _requestAirplaneServiceHandler = requestAirplaneServiceHandler;
            _requestAirplaneTicketHandler = requestAirplaneTicketHandler;
            _ordersEntityToModel = ordersEntityToModel;
            _ordersModelToEntity = ordersModelToEntity;
            _requestAirplaneServiceModelToEntity = requestAirplaneServiceModelToEntity;
            _requestAirplaneTicketModelToEntity = requestAirplaneTicketModelToEntity;
        }
        public IList<Orders> GetOrdersByUserId(long userId)
        {
            return _usersHandler.GetEntity(userId).OrdersS.Select(item => _ordersEntityToModel.Map(item)).Cast<Orders>().ToList();
        }

        public Orders AddOrder(Orders orderToSave)
        {
            Data.Entities.Orders orderEntity = _ordersModelToEntity.Map(orderToSave);
            IList<Data.Entities.RequestAirplaneService> EntityFlightPackageList = orderToSave.lstFlightPackage.Select(item => _requestAirplaneServiceModelToEntity.Map(item)).Cast<Data.Entities.RequestAirplaneService>().ToList();
            _ordersHandler.Save(orderEntity);
            foreach (RequestAirplaneService packageItem in orderToSave.lstFlightPackage)
            {
                IList<RequestAirplaneTicket> lstTickets = packageItem.lstFlight;
                Data.Entities.RequestAirplaneService airplaneServiceEntity = _requestAirplaneServiceModelToEntity.Map(packageItem);
                airplaneServiceEntity.OrdersItem = orderEntity;
                airplaneServiceEntity.SubmitDate = DateTime.Now;
                _requestAirplaneServiceHandler.Save(airplaneServiceEntity);
                foreach (RequestAirplaneTicket ticketItem in lstTickets)
                {
                    Data.Entities.RequestAirplaneTicket ticket = _requestAirplaneTicketModelToEntity.Map(ticketItem);
                    ticket.RequestAirplaneServiceItem = airplaneServiceEntity;

                    _requestAirplaneTicketHandler.Save(ticket);
                }
            }
            //return _usersHandler.GetEntity(userId).OrdersS.Select(item => _ordersEntityToModel.Map(item)).Cast<Orders>().ToList();
            return null;
        }

    }
}