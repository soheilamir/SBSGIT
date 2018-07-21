using FluentNHibernate.Automapping;
using log4net.Config;
using Ninject;
using SBSWebProject.Common;
using SBSWebProject.Common.Logging;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using Ninject.Activation;
using Ninject.Web.Common;
using SBSWebProject.Common.Security;
using SBSWebProject.Data.QueryProcessors;
using SBSWebProject.Data.SqlServer.Mapping;
using SBSWebProject.Data.SqlServer.DataHandler;
using SBSWebProject.Data.SqlServer.QueryProcessors;
using SBSWebProject.Web.Common;
using SBSWebProject.Web.Common.Security;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.MaintenanceProcessing;
using SBSWebProject.Web.Api.Security;
using SBSWebProject.Web.Api.InquiryProcessing;
using SBSWebProject.Web.Api.LinkServices;
using SBSWebProject.MappingObject;
using SBSWebProject.Data.DataHandlers;
using SBSWebProject.Web.Api.OperatingMethods;
using SBSWebProject.Web.Api.MethodsInterface;
using SBSWebProject.Data.SqlServer.DomainEntities;

namespace SBSWebProject.Web.Api
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            AddBindings(container);
        }
        private void AddBindings(IKernel container)
        {
            ConfigureLog4net(container);
            ConfigureUserSession(container);
            ConfigureNHibernate(container);
            ConfigureDomainEntity(container);
            ConfigureDataHandler(container);
            ConfigureMappingObject(container);
            ConfigureOperatingMethods(container);
            container.Bind<IDateTime>().To<DateTimeAdapter>().InSingletonScope();
            container.Bind<IAddTaskQueryProcessor>().To<AddTaskQueryProcessor>().InRequestScope();
            container.Bind<ITaskByIdQueryProcessor>().To<TaskByIdQueryProcessor>().InRequestScope();
            container.Bind<IUpdateTaskStatusQueryProcessor>().To<UpdateTaskStatusQueryProcessor>().InRequestScope();
            container.Bind<IUpdateTaskQueryProcessor>().To<UpdateTaskQueryProcessor>().InRequestScope();
            container.Bind<IUpdateablePropertyDetector>().To<JObjectUpdateablePropertyDetector>().InSingletonScope();
            container.Bind<IPagedDataRequestFactory>().To<PagedDataRequestFactory>().InSingletonScope();
            container.Bind<IAllTasksQueryProcessor>().To<AllTasksQueryProcessor>().InRequestScope();
            container.Bind<ICommonLinkService>().To<CommonLinkService>().InRequestScope();
            container.Bind<IUserLinkService>().To<UserLinkService>().InRequestScope();
            container.Bind<ITaskLinkService>().To<TaskLinkService>().InRequestScope();
        }
        private void ConfigureLog4net(IKernel container)
        {
            XmlConfigurator.Configure();
            var logManager = new LogManagerAdapter();
            container.Bind<ILogManager>().ToConstant(logManager);
        }
        private void ConfigureNHibernate(IKernel container)
        {
            var sessionFactory = Fluently.Configure()
            .Database(
            MsSqlConfiguration.MsSql2008.ConnectionString(
                c => c.FromConnectionStringWithKey("SBSWebProjectDb"))).CurrentSessionContext("web")
                //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<TaskMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UsersMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AirlineClassPathFeeMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AirlineClassesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AirlineClassPathMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AirlineMembersMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AirlineNameByLanguageMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AirlinesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AirlineSubClassesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AirplaneTicketPreferedAirlinesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AirplaneMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AirportNameByLanguageMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AirportsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BlogsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CityMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CityNameByLanguageMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CompanyAttachmentMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CompanyEmployeeMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CompanyMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CompanyOrdersConfirmationMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CompanyServiceFeeMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ConditionTypeMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ConditionValueMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ContinentMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CountryIpAddressesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CountryMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CountryNameByLanguageMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EarthRegionMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ExtensionsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FilesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FlightConditionMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FlightFreeServiceMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FlightNumbersMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FlightPathMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FlightStopOverMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FoldersMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<JobOpportunityMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<LanguagesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<MessagesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NewsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NewsTagsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OnlineFlightTicketMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OnlineFlightTicketPassengersMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OnlineFlightTicketPathMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OrdersMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PassengersMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ReceivedResumeMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RequestAirplaneServiceMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RequestAirplaneTicketMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RequestAirplaneTicketPassengerMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RequestStatusMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ResponseAirplaneTicketMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RolesInSectionMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SbsBranchAwardsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SbsBranchesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SbsBranchImagesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SbsBranchTeamMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SbsRolesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SbsSectionsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SbsTagsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ServicesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StateProvinceMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StateProvinceNameByLanguageMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TicketNumberMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserAddressesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserAndPassengerDocumentsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserCreditInfoMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserEmailsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserFavoriteAirlinesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserLanguagesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserLoginLogMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserPassengerMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserTelsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<WebPageBannersMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<WebPageContextMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<WebPagesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<WebsiteCategoryMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<WebsiteFAQsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CityPublicPlaceMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CityPublicPlaceNameByLanguageMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FacilitiesCategoryMap>())
                //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<FacilitiesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FacilitiesNameByLanguageMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CompanyEmployeePositionMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CompanySectionMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HotelAccessibilityMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HotelCommentsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HotelFacilitiesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HotelNameByLanguageMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HotelOrRoomConditionsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HotelPhotosMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HotelRoomBedsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HotelRoomCommentsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HotelRoomMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HotelRoomNightPriceMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HotelRoomPhotosMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HotelsMap>())
                .BuildSessionFactory();
            container.Bind<ISessionFactory>().ToConstant(sessionFactory);
            container.Bind<ISession>().ToMethod(CreateSession).InRequestScope();
            container.Bind<IActionTransactionHelper>().To<ActionTransactionHelper>().InRequestScope();
            container.Bind<IBasicSecurityService>().To<BasicSecurityService>().InSingletonScope();
        }
        private ISession CreateSession(IContext context)
        {
            var sessionFactory = context.Kernel.Get<ISessionFactory>();
            if (!CurrentSessionContext.HasBind(sessionFactory))
            {
                var session = sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
            }
            return sessionFactory.GetCurrentSession();
        }
        private void ConfigureUserSession(IKernel container)
        {
            var userSession = new UserSession();
            container.Bind<IUserSession>().ToConstant(userSession).InSingletonScope();
            container.Bind<IWebUserSession>().ToConstant(userSession).InSingletonScope();
        }

        private void ConfigureDomainEntity(IKernel container)
        {
            container.Bind<IDomainEntity<AirlineClasses>>().To<AirlineClassesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<AirlineClassPath>>().To<AirlineClassPathDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<AirlineClassPathFee>>().To<AirlineClassPathFeeDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<AirlineMembers>>().To<AirlineMembersDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<AirlineNameByLanguage>>().To<AirlineNameByLanguageDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Airlines>>().To<AirlinesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<AirlineSubClasses>>().To<AirlineSubClassesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Airplane>>().To<AirplaneDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<AirplaneTicketPreferedAirlines>>().To<AirplaneTicketPreferedAirlinesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<AirportNameByLanguage>>().To<AirportNameByLanguageDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Airports>>().To<AirportsDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Blogs>>().To<BlogsDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<CityNameByLanguage>>().To<CityNameByLanguageDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<CompanyAttachment>>().To<CompanyAttachmentDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Company>>().To<CompanyDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<CompanyOrdersConfirmation>>().To<CompanyOrdersConfirmationDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<CompanyEmployee>>().To<CompanyEmployeeDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<CompanyServiceFee>>().To<CompanyServiceFeeDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<ConditionType>>().To<ConditionTypeDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<ConditionValues>>().To<ConditionValuesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Continent>>().To<ContinentDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Country>>().To<CountryDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<CountryIpAddresses>>().To<CountryIpAddressesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<CountryNameByLanguage>>().To<CountryNameByLanguageDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<EarthRegion>>().To<EarthRegionDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Extensions>>().To<ExtensionsDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Files>>().To<FilesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<FlightCondition>>().To<FlightConditionDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<FlightFreeServices>>().To<FlightFreeServicesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<FlightNumbers>>().To<FlightNumbersDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<FlightPath>>().To<FlightPathDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<FlightStopOver>>().To<FlightStopOverDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Folders>>().To<FoldersDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<JobOpportunity>>().To<JobOpportunityDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Languages>>().To<LanguagesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Messages>>().To<MessagesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<NewsTags>>().To<NewsTagsDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<OnlineFlightTicket>>().To<OnlineFlightTicketDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<OnlineFlightTicketPassengers>>().To<OnlineFlightTicketPassengersDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<OnlineFlightTicketPath>>().To<OnlineFlightTicketPathDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Orders>>().To<OrdersDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Passengers>>().To<PassengersDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<ReceivedResume>>().To<ReceivedResumeDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<RequestAirplaneService>>().To<RequestAirplaneServiceDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<RequestAirplaneTicket>>().To<RequestAirplaneTicketDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<RequestAirplaneTicketPassenger>>().To<RequestAirplaneTicketPassengerDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<RequestStatus>>().To<RequestStatusDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<ResponseAirplaneTicket>>().To<ResponseAirplaneTicketDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<RolesInSection>>().To<RolesInSectionDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<SbsBranchAwards>>().To<SbsBranchAwardsDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<SbsBranches>>().To<SbsBranchesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<SbsBranchImages>>().To<SbsBranchImagesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<SbsBranchTeam>>().To<SbsBranchTeamDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<SbsRoles>>().To<SbsRolesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<SbsSections>>().To<SbsSectionsDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<SbsTags>>().To<SbsTagsDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Services>>().To<ServicesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<StateProvince>>().To<StateProvinceDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<StateProvinceNameByLanguage>>().To<StateProvinceNameByLanguageDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<TicketNumbers>>().To<TicketNumberDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<UserAddresses>>().To<UserAddressesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<UserAndPassengerDocuments>>().To<UserAndPassengerDocumentsDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<UserCreditInfo>>().To<UserCreditInfoDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<UserEmails>>().To<UserEmailsDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<UserFavoriteAirlines>>().To<UserFavoriteAirlinesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<UserLanguages>>().To<UserLanguagesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<UserLoginLog>>().To<UserLoginLogDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<UserPassenger>>().To<UserPassengerDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Users>>().To<UsersDomainEntity>().InRequestScope();
            //container.Bind<IDomainEntity<UsersInGroup>>().To<UsersInGroupDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<UserTels>>().To<UserTelsDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<WebPageBanners>>().To<WebPageBannersDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<WebPageContext>>().To<WebPageContextDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<WebPages>>().To<WebPagesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<WebsiteCategory>>().To<WebsiteCategoryDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<WebsiteFAQs>>().To<WebsiteFAQsDomainEntity>().InRequestScope();

            container.Bind<IDomainEntity<CityPublicPlace>>().To<CityPublicPlaceDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<CityPublicPlaceNameByLanguage>>().To<CityPublicPlaceNameByLanguageDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<FacilitiesCategory>>().To<FacilitiesCategoryDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Facilities>>().To<FacilitiesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<FacilitiesNameByLanguage>>().To<FacilitiesNameByLanguageDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<CompanyEmployeePosition>>().To<CompanyEmployeePositionDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<CompanySection>>().To<CompanySectionDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<HotelAccessibility>>().To<HotelAccessibilityDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<HotelComments>>().To<HotelCommentsDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<HotelFacilities>>().To<HotelFacilitiesDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<HotelNameByLanguage>>().To<HotelNameByLanguageDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<HotelOrRoomConditions>>().To<HotelOrRoomConditionsDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<HotelPhotos>>().To<HotelPhotosDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<HotelRoom>>().To<HotelRoomDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<HotelRoomBeds>>().To<HotelRoomBedsDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<HotelRoomComments>>().To<HotelRoomCommentsDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<HotelRoomNightPrice>>().To<HotelRoomNightPriceDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<HotelRoomPhotos>>().To<HotelRoomPhotosDomainEntity>().InRequestScope();
            container.Bind<IDomainEntity<Hotels>>().To<HotelsDomainEntity>().InRequestScope();
        }
        private void ConfigureDataHandler(IKernel container)
        {
            container.Bind<IBasicDataHandler<AirlineClasses>>().To<AirlineClassesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<AirlineClassPath>>().To<AirlineClassPathDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<AirlineClassPathFee>>().To<AirlineClassPathFeeDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<AirlineMembers>>().To<AirlineMembersDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<AirlineNameByLanguage>>().To<AirlineNameByLanguageDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Airlines>>().To<AirLinesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<AirlineSubClasses>>().To<AirlineSubClassesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Airplane>>().To<AirplaneDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<AirplaneTicketPreferedAirlines>>().To<AirplaneTicketPreferedAirlinesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<AirportNameByLanguage>>().To<AirportNameByLanguageDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Airports>>().To<AirportsDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Blogs>>().To<BlogsDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<CityNameByLanguage>>().To<CityNameByLanguageDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<CompanyAttachment>>().To<CompanyAttachmentDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Company>>().To<CompanyDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<CompanyOrdersConfirmation>>().To<CompanyOrdersConfirmationDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<CompanyEmployee>>().To<CompanyEmployeeDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<CompanyServiceFee>>().To<CompanyServiceFeeDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<ConditionType>>().To<ConditionTypeDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<ConditionValues>>().To<ConditionValuesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Continent>>().To<ContinentDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Country>>().To<CountryDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<CountryIpAddresses>>().To<CountryIpAddressesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<CountryNameByLanguage>>().To<CountryNameByLanguageDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<EarthRegion>>().To<EarthRegionDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Extensions>>().To<ExtensionsDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Files>>().To<FilesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<FlightCondition>>().To<FlightConditionDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<FlightFreeServices>>().To<FlightFreeServiceDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<FlightNumbers>>().To<FlightNumbersDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<FlightPath>>().To<FlightPathDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<FlightStopOver>>().To<FlightStopOverDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Folders>>().To<FoldersDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<JobOpportunity>>().To<JobOpportunityDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Languages>>().To<LanguagesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Messages>>().To<MessagesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<NewsTags>>().To<NewsTagsDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<OnlineFlightTicket>>().To<OnlineFlightTicketDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<OnlineFlightTicketPassengers>>().To<OnlineFlightTicketPassengersDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<OnlineFlightTicketPath>>().To<OnlineFlightTicketPathDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Orders>>().To<OrdersDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Passengers>>().To<PassengersDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<ReceivedResume>>().To<ReceivedResumeDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<RequestAirplaneService>>().To<RequestAirplaneServiceDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<RequestAirplaneTicket>>().To<RequestAirplaneTicketDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<RequestAirplaneTicketPassenger>>().To<RequestAirplaneTicketPassengerDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<RequestStatus>>().To<RequestStatusDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<ResponseAirplaneTicket>>().To<ResponseAirplaneTicketDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<RolesInSection>>().To<RolesInSectionDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<SbsBranchAwards>>().To<SbsBranchAwardsDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<SbsBranches>>().To<SbsBranchesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<SbsBranchImages>>().To<SbsBranchImagesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<SbsBranchTeam>>().To<SbsBranchTeamDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<SbsRoles>>().To<SbsRolesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<SbsSections>>().To<SbsSectionsDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<SbsTags>>().To<SbsTagsDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Services>>().To<ServicesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<StateProvince>>().To<StateProvinceDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<StateProvinceNameByLanguage>>().To<StateProvinceNameByLanguageDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<TicketNumbers>>().To<TicketNumberDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<UserAddresses>>().To<UserAddressesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<UserAndPassengerDocuments>>().To<UserAndPassengerDocumentsDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<UserCreditInfo>>().To<UserCreditInfoDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<UserEmails>>().To<UserEmailsDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<UserFavoriteAirlines>>().To<UserFavoriteAirlinesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<UserLanguages>>().To<UserLanguagesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<UserLoginLog>>().To<UserLoginLogDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<UserPassenger>>().To<UserPassengerDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Users>>().To<UsersDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<UsersInGroup>>().To<UsersInGroupDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<UserTels>>().To<UserTelsDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<WebPageBanners>>().To<WebPageBannersDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<WebPageContext>>().To<WebPageContextDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<WebPages>>().To<WebPagesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<WebsiteCategory>>().To<WebsiteCategoryDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<WebsiteFAQs>>().To<WebsiteFaqsDataHandler>().InRequestScope();

            container.Bind<IBasicDataHandler<CityPublicPlace>>().To<CityPublicPlaceDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<CityPublicPlaceNameByLanguage>>().To<CityPublicPlaceNameByLanguageDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<CompanyEmployeePosition>>().To<CompanyEmployeePositionDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<CompanySection>>().To<CompanySectionDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Facilities>>().To<FacilitiesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<FacilitiesCategory>>().To<FacilitiesCategoryDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<FacilitiesNameByLanguage>>().To<FacilitiesNameByLanguageDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<HotelAccessibility>>().To<HotelAccessibilityDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<HotelComments>>().To<HotelCommentsDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<HotelFacilities>>().To<HotelFacilitiesDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<HotelNameByLanguage>>().To<HotelNameByLanguageDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<HotelOrRoomConditions>>().To<HotelOrRoomConditionsDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<HotelPhotos>>().To<HotelPhotosDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<HotelRoom>>().To<HotelRoomDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<HotelRoomBeds>>().To<HotelRoomBedsDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<HotelRoomComments>>().To<HotelRoomCommentsDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<HotelRoomNightPrice>>().To<HotelRoomNightPriceDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<HotelRoomPhotos>>().To<HotelRoomPhotosDataHandler>().InRequestScope();
            container.Bind<IBasicDataHandler<Hotels>>().To<HotelsDataHandler>().InRequestScope();

        }
        private void ConfigureMappingObject(IKernel container)
        {
            #region Entity To Model
            container.Bind<IMappingObject<Data.Entities.AirlineClasses, Web.Api.Models.AirlineClasses>>().To<MappingObject.EntityToModel.AirlineClassesMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.AirlineClassPath, Web.Api.Models.AirlineClassPath>>().To<MappingObject.EntityToModel.AirlineClassPathMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.AirlineMembers, Web.Api.Models.AirlineMembers>>().To<MappingObject.EntityToModel.AirlineMemberMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.AirlineNameByLanguage, Web.Api.Models.AirlineNameByLanguage>>().To<MappingObject.EntityToModel.AirlineNameByLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Airlines, Web.Api.Models.Airlines>>().To<MappingObject.EntityToModel.AirlineMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.AirlineSubClasses, Web.Api.Models.AirlineSubClasses>>().To<MappingObject.EntityToModel.AirlineSubClassesMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Airplane, Web.Api.Models.Airplane>>().To<MappingObject.EntityToModel.AirplaneMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.AirportNameByLanguage, Web.Api.Models.AirportNameByLanguage>>().To<MappingObject.EntityToModel.AirportNameByLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Airports, Web.Api.Models.Airports>>().To<MappingObject.EntityToModel.AirportMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Blogs, Web.Api.Models.Blogs>>().To<MappingObject.EntityToModel.BlogsMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.City, Web.Api.Models.City>>().To<MappingObject.EntityToModel.CityMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.CityNameByLanguage, Web.Api.Models.CityNameByLanguage>>().To<MappingObject.EntityToModel.CityNameByLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Company, Web.Api.Models.Company>>().To<MappingObject.EntityToModel.CompanyMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.CompanyOrdersConfirmation, Web.Api.Models.CompanyOrdersConfirmation>>().To<MappingObject.EntityToModel.CompanyOrdersConfirmationMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.CompanyAttachment, Web.Api.Models.CompanyAttachment>>().To<MappingObject.EntityToModel.CompanyAttachmentMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.CompanyEmployee, Web.Api.Models.CompanyEmployee>>().To<MappingObject.EntityToModel.CompanyEmployeeMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.CompanyServiceFee, Web.Api.Models.CompanyServiceFee>>().To<MappingObject.EntityToModel.CompanyServiceFeeMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.ConditionType, Web.Api.Models.ConditionType>>().To<MappingObject.EntityToModel.ConditionTypeMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.ConditionValues, Web.Api.Models.ConditionValues>>().To<MappingObject.EntityToModel.ConditionValuesMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Continent, Web.Api.Models.Continent>>().To<MappingObject.EntityToModel.ContinentMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Country, Web.Api.Models.Country>>().To<MappingObject.EntityToModel.CountryMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.CountryIpAddresses, Web.Api.Models.CountryIpAddresses>>().To<MappingObject.EntityToModel.CountryIpAddressMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.CountryNameByLanguage, Web.Api.Models.CountryNameByLanguage>>().To<MappingObject.EntityToModel.CountryNameByLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.EarthRegion, Web.Api.Models.EarthRegion>>().To<MappingObject.EntityToModel.EarthRegionMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Extensions, Web.Api.Models.Extensions>>().To<MappingObject.EntityToModel.ExtensionsMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Files, Web.Api.Models.Files>>().To<MappingObject.EntityToModel.FilesMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.FlightCondition, Web.Api.Models.FlightCondition>>().To<MappingObject.EntityToModel.FlightConditionMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.FlightFreeServices, Web.Api.Models.FlightFreeServices>>().To<MappingObject.EntityToModel.FlightFreeServiceMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.FlightNumbers, Web.Api.Models.FlightNumbers>>().To<MappingObject.EntityToModel.FlightNumbersMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.FlightPath, Web.Api.Models.FlightPath>>().To<MappingObject.EntityToModel.FlightPathMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.FlightStopOver, Web.Api.Models.FlightStopOver>>().To<MappingObject.EntityToModel.FlightStopOverMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Folders, Web.Api.Models.Folders>>().To<MappingObject.EntityToModel.FoldersMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.JobOpportunity, Web.Api.Models.JobOpportunity>>().To<MappingObject.EntityToModel.JobOpportunityMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Languages, Web.Api.Models.Languages>>().To<MappingObject.EntityToModel.LanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Messages, Web.Api.Models.Messages>>().To<MappingObject.EntityToModel.MessagesMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.News, Web.Api.Models.News>>().To<MappingObject.EntityToModel.NewsMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.NewsTags, Web.Api.Models.NewsTags>>().To<MappingObject.EntityToModel.NewsTagsMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.OnlineFlightTicket, Web.Api.Models.OnlineFlightTicket>>().To<MappingObject.EntityToModel.OnlineFlightTicketMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.OnlineFlightTicketPassengers, Web.Api.Models.OnlineFlightTicketPassengers>>().To<MappingObject.EntityToModel.OnlineFlightTicketPassengersMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.OnlineFlightTicketPath, Web.Api.Models.OnlineFlightTicketPath>>().To<MappingObject.EntityToModel.OnlineFlightTicketPathMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Orders, Web.Api.Models.Orders>>().To<MappingObject.EntityToModel.OrdersMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Passengers, Web.Api.Models.Passengers>>().To<MappingObject.EntityToModel.PassengerMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.ReceivedResume, Web.Api.Models.ReceivedResume>>().To<MappingObject.EntityToModel.ReceivedResumeMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.RequestAirplaneService, Web.Api.Models.RequestAirplaneService>>().To<MappingObject.EntityToModel.RequestAirplaneServiceMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.RequestAirplaneTicket, Web.Api.Models.RequestAirplaneTicket>>().To<MappingObject.EntityToModel.RequestAirplaneTicketMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.RequestAirplaneTicketPassenger, Web.Api.Models.RequestAirplaneTicketPassenger>>().To<MappingObject.EntityToModel.RequestAirplaneTicketPassengerMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.RequestStatus, Web.Api.Models.RequestStatus>>().To<MappingObject.EntityToModel.RequestStatusMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.ResponseAirplaneTicket, Web.Api.Models.ResponseAirplaneTicket>>().To<MappingObject.EntityToModel.ResponseAirplaneTicketMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.RolesInSection, Web.Api.Models.RolesInSection>>().To<MappingObject.EntityToModel.RolesInSectionMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.SbsBranchAwards, Web.Api.Models.SbsBranchAwards>>().To<MappingObject.EntityToModel.SbsBranchAwardsMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.SbsBranches, Web.Api.Models.SbsBranches>>().To<MappingObject.EntityToModel.SbsBranchesMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.SbsBranchImages, Web.Api.Models.SbsBranchImages>>().To<MappingObject.EntityToModel.SbsBranchImagesMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.SbsBranchTeam, Web.Api.Models.SbsBranchTeam>>().To<MappingObject.EntityToModel.SbsBranchTeamMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.SbsRoles, Web.Api.Models.SbsRoles>>().To<MappingObject.EntityToModel.SbsRoleMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.SbsSections, Web.Api.Models.SbsSections>>().To<MappingObject.EntityToModel.SbsSectionMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.SbsTags, Web.Api.Models.SbsTags>>().To<MappingObject.EntityToModel.SbsTagsMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Services, Web.Api.Models.Services>>().To<MappingObject.EntityToModel.ServicesMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.StateProvince, Web.Api.Models.StateProvince>>().To<MappingObject.EntityToModel.StateProvinceMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.StateProvinceNameByLanguage, Web.Api.Models.StateProvinceNameByLanguage>>().To<MappingObject.EntityToModel.StateProvinceNameByLanguageMapper>().InRequestScope();
            //container.Bind<IMappingObject<Data.Entities.Status, Web.Api.Models.Status>>().To<MappingObject.EntityToModel.StatusMapper>();
            container.Bind<IMappingObject<Data.Entities.TicketNumbers, Web.Api.Models.TicketNumbers>>().To<MappingObject.EntityToModel.TicketNumberMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.UserAddresses, Web.Api.Models.UserAddresses>>().To<MappingObject.EntityToModel.UserAddressMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.UserAndPassengerDocuments, Web.Api.Models.UserAndPassengerDocuments>>().To<MappingObject.EntityToModel.UserAndPassengerDocumentMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.UserCreditInfo, Web.Api.Models.UserCreditInfo>>().To<MappingObject.EntityToModel.UserCreditInfoMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.UserEmails, Web.Api.Models.UserEmails>>().To<MappingObject.EntityToModel.UserEmailMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.UserFavoriteAirlines, Web.Api.Models.UserFavoriteAirlines>>().To<MappingObject.EntityToModel.UserFavoriteAirlineMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.UserLanguages, Web.Api.Models.UserLanguages>>().To<MappingObject.EntityToModel.UserLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.UserLoginLog, Web.Api.Models.UserLoginLog>>().To<MappingObject.EntityToModel.UserLoginLogMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.UserPassenger, Web.Api.Models.UserPassenger>>().To<MappingObject.EntityToModel.UserPassengerMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Users, Web.Api.Models.Users>>().To<MappingObject.EntityToModel.UsersMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.UserTels, Web.Api.Models.UserTels>>().To<MappingObject.EntityToModel.UserTelMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.WebPageBanners, Web.Api.Models.WebPageBanners>>().To<MappingObject.EntityToModel.WebPageBannersMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.WebPageContext, Web.Api.Models.WebPageContext>>().To<MappingObject.EntityToModel.WebPageContextMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.WebPages, Web.Api.Models.WebPages>>().To<MappingObject.EntityToModel.WebPagesMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.WebsiteCategory, Web.Api.Models.WebsiteCategory>>().To<MappingObject.EntityToModel.WebsiteCategoryMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.WebsiteFAQs, Web.Api.Models.WebsiteFAQs>>().To<MappingObject.EntityToModel.WebsiteFAQsMapper>().InRequestScope();

            container.Bind<IMappingObject<Data.Entities.Passengers, Web.Api.Models.PassengerFlight>>().To<MappingObject.EntityToModel.PassengerFlightMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.OnlineFlightTicket, Web.Api.Models.OnlineFlightTicketModel>>().To<MappingObject.EntityToModel.OnlineFlightTicketModelMapper>().InRequestScope();


            container.Bind<IMappingObject<Data.Entities.CityPublicPlace, Web.Api.Models.CityPublicPlace>>().To<MappingObject.EntityToModel.CityPublicPlaceMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.CityPublicPlaceNameByLanguage, Web.Api.Models.CityPublicPlaceNameByLanguage>>().To<MappingObject.EntityToModel.CityPublicPlaceNameByLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Facilities, Web.Api.Models.Facilities>>().To<MappingObject.EntityToModel.FacilitiesMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.FacilitiesCategory, Web.Api.Models.FacilitiesCategory>>().To<MappingObject.EntityToModel.FacilitiesCategoryMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.FacilitiesNameByLanguage, Web.Api.Models.FacilitiesNameByLanguage>>().To<MappingObject.EntityToModel.FacilitiesNameByLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.HotelAccessibility, Web.Api.Models.HotelAccessibility>>().To<MappingObject.EntityToModel.HotelAccessibilityMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.HotelComments, Web.Api.Models.HotelComments>>().To<MappingObject.EntityToModel.HotelCommentsMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.HotelFacilities, Web.Api.Models.HotelFacilities>>().To<MappingObject.EntityToModel.HotelFacilitiesMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.HotelNameByLanguage, Web.Api.Models.HotelNameByLanguage>>().To<MappingObject.EntityToModel.HotelNameByLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.HotelOrRoomConditions, Web.Api.Models.HotelOrRoomConditions>>().To<MappingObject.EntityToModel.HotelOrRoomConditionsMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.HotelPhotos, Web.Api.Models.HotelPhotos>>().To<MappingObject.EntityToModel.HotelPhotosMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.HotelRoom, Web.Api.Models.HotelRoom>>().To<MappingObject.EntityToModel.HotelRoomMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.HotelRoomBeds, Web.Api.Models.HotelRoomBeds>>().To<MappingObject.EntityToModel.HotelRoomBedsMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.HotelRoomComments, Web.Api.Models.HotelRoomComments>>().To<MappingObject.EntityToModel.HotelRoomCommentsMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.HotelRoomNightPrice, Web.Api.Models.HotelRoomNightPrice>>().To<MappingObject.EntityToModel.HotelRoomNightPriceMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.HotelRoomPhotos, Web.Api.Models.HotelRoomPhotos>>().To<MappingObject.EntityToModel.HotelRoomPhotosMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.HotelRoomType, Web.Api.Models.HotelRoomType>>().To<MappingObject.EntityToModel.HotelRoomTypeMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.HotelRoomTypeNameByLanguage, Web.Api.Models.HotelRoomTypeNameByLanguage>>().To<MappingObject.EntityToModel.HotelRoomTypeNameByLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Data.Entities.Hotels, Web.Api.Models.Hotels>>().To<MappingObject.EntityToModel.HotelsMapper>().InRequestScope();
            #endregion
            #region Model To Entity
            container.Bind<IMappingObject<Web.Api.Models.AirlineClasses, Data.Entities.AirlineClasses>>().To<MappingObject.ModelToEntity.AirlineClassesMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.AirlineClassPath, Data.Entities.AirlineClassPath>>().To<MappingObject.ModelToEntity.AirlineClassPathMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.AirlineMembers, Data.Entities.AirlineMembers>>().To<MappingObject.ModelToEntity.AirlineMemberMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.AirlineNameByLanguage, Data.Entities.AirlineNameByLanguage>>().To<MappingObject.ModelToEntity.AirlineNameByLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Airlines, Data.Entities.Airlines>>().To<MappingObject.ModelToEntity.AirlineMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.AirlineSubClasses, Data.Entities.AirlineSubClasses>>().To<MappingObject.ModelToEntity.AirlineSubClassesMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Airplane, Data.Entities.Airplane>>().To<MappingObject.ModelToEntity.AirplaneMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.AirportNameByLanguage, Data.Entities.AirportNameByLanguage>>().To<MappingObject.ModelToEntity.AirportNameByLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Airports, Data.Entities.Airports>>().To<MappingObject.ModelToEntity.AirportMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Blogs, Data.Entities.Blogs>>().To<MappingObject.ModelToEntity.BlogsMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.City, Data.Entities.City>>().To<MappingObject.ModelToEntity.CityMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.CityNameByLanguage, Data.Entities.CityNameByLanguage>>().To<MappingObject.ModelToEntity.CityNameByLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Company, Data.Entities.Company>>().To<MappingObject.ModelToEntity.CompanyMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.CompanyOrdersConfirmation, Data.Entities.CompanyOrdersConfirmation>>().To<MappingObject.ModelToEntity.CompanyOrdersConfirmationMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.CompanyAttachment, Data.Entities.CompanyAttachment>>().To<MappingObject.ModelToEntity.CompanyAttachmentMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.CompanyEmployee, Data.Entities.CompanyEmployee>>().To<MappingObject.ModelToEntity.CompanyEmployeeMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.CompanyServiceFee, Data.Entities.CompanyServiceFee>>().To<MappingObject.ModelToEntity.CompanyServiceFeeMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.ConditionType, Data.Entities.ConditionType>>().To<MappingObject.ModelToEntity.ConditionTypeMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.ConditionValues, Data.Entities.ConditionValues>>().To<MappingObject.ModelToEntity.ConditionValuesMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Continent, Data.Entities.Continent>>().To<MappingObject.ModelToEntity.ContinentMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Country, Data.Entities.Country>>().To<MappingObject.ModelToEntity.CountryMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.CountryIpAddresses, Data.Entities.CountryIpAddresses>>().To<MappingObject.ModelToEntity.CountryIpAddressMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.CountryNameByLanguage, Data.Entities.CountryNameByLanguage>>().To<MappingObject.ModelToEntity.CountryNameByLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.EarthRegion, Data.Entities.EarthRegion>>().To<MappingObject.ModelToEntity.EarthRegionMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Extensions, Data.Entities.Extensions>>().To<MappingObject.ModelToEntity.ExtensionsMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Files, Data.Entities.Files>>().To<MappingObject.ModelToEntity.FilesMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.FlightCondition, Data.Entities.FlightCondition>>().To<MappingObject.ModelToEntity.FlightConditionMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.FlightFreeServices, Data.Entities.FlightFreeServices>>().To<MappingObject.ModelToEntity.FlightFreeServiceMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.FlightNumbers, Data.Entities.FlightNumbers>>().To<MappingObject.ModelToEntity.FlightNumbersMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.FlightPath, Data.Entities.FlightPath>>().To<MappingObject.ModelToEntity.FlightPathMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.FlightStopOver, Data.Entities.FlightStopOver>>().To<MappingObject.ModelToEntity.FlightStopOverMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Folders, Data.Entities.Folders>>().To<MappingObject.ModelToEntity.FoldersMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.JobOpportunity, Data.Entities.JobOpportunity>>().To<MappingObject.ModelToEntity.JobOpportunityMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Languages, Data.Entities.Languages>>().To<MappingObject.ModelToEntity.LanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Messages, Data.Entities.Messages>>().To<MappingObject.ModelToEntity.MessagesMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.News, Data.Entities.News>>().To<MappingObject.ModelToEntity.NewsMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.NewsTags, Data.Entities.NewsTags>>().To<MappingObject.ModelToEntity.NewsTagsMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.OnlineFlightTicket, Data.Entities.OnlineFlightTicket>>().To<MappingObject.ModelToEntity.OnlineFlightTicketMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.OnlineFlightTicketPassengers, Data.Entities.OnlineFlightTicketPassengers>>().To<MappingObject.ModelToEntity.OnlineFlightTicketPassengersMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.OnlineFlightTicketPath, Data.Entities.OnlineFlightTicketPath>>().To<MappingObject.ModelToEntity.OnlineFlightTicketPathMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Orders, Data.Entities.Orders>>().To<MappingObject.ModelToEntity.OrdersMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Passengers, Data.Entities.Passengers>>().To<MappingObject.ModelToEntity.PassengerMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.ReceivedResume, Data.Entities.ReceivedResume>>().To<MappingObject.ModelToEntity.ReceivedResumeMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.RequestAirplaneService, Data.Entities.RequestAirplaneService>>().To<MappingObject.ModelToEntity.RequestAirplaneServiceMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.RequestAirplaneTicket, Data.Entities.RequestAirplaneTicket>>().To<MappingObject.ModelToEntity.RequestAirplaneTicketMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.RequestAirplaneTicketPassenger, Data.Entities.RequestAirplaneTicketPassenger>>().To<MappingObject.ModelToEntity.RequestAirplaneTicketPassengerMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.RequestStatus, Data.Entities.RequestStatus>>().To<MappingObject.ModelToEntity.RequestStatusMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.ResponseAirplaneTicket, Data.Entities.ResponseAirplaneTicket>>().To<MappingObject.ModelToEntity.ResponseAirplaneTicketMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.RolesInSection, Data.Entities.RolesInSection>>().To<MappingObject.ModelToEntity.RolesInSectionMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.SbsBranchAwards, Data.Entities.SbsBranchAwards>>().To<MappingObject.ModelToEntity.SbsBranchAwardsMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.SbsBranches, Data.Entities.SbsBranches>>().To<MappingObject.ModelToEntity.SbsBranchesMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.SbsBranchImages, Data.Entities.SbsBranchImages>>().To<MappingObject.ModelToEntity.SbsBranchImagesMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.SbsBranchTeam, Data.Entities.SbsBranchTeam>>().To<MappingObject.ModelToEntity.SbsBranchTeamMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.SbsRoles, Data.Entities.SbsRoles>>().To<MappingObject.ModelToEntity.SbsRoleMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.SbsSections, Data.Entities.SbsSections>>().To<MappingObject.ModelToEntity.SbsSectionMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.SbsTags, Data.Entities.SbsTags>>().To<MappingObject.ModelToEntity.SbsTagsMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Services, Data.Entities.Services>>().To<MappingObject.ModelToEntity.ServicesMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.StateProvince, Data.Entities.StateProvince>>().To<MappingObject.ModelToEntity.StateProvinceMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.StateProvinceNameByLanguage, Data.Entities.StateProvinceNameByLanguage>>().To<MappingObject.ModelToEntity.StateProvinceNameByLanguageMapper>().InRequestScope();
            //container.Bind<IMappingObject<Web.Api.Models.Status, Data.Entities.Status>>().To<MappingObject.ModelToEntity.StatusMapper>();
            container.Bind<IMappingObject<Web.Api.Models.TicketNumbers, Data.Entities.TicketNumbers>>().To<MappingObject.ModelToEntity.TicketNumberMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.UserAddresses, Data.Entities.UserAddresses>>().To<MappingObject.ModelToEntity.UserAddressMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.UserAndPassengerDocuments, Data.Entities.UserAndPassengerDocuments>>().To<MappingObject.ModelToEntity.UserAndPassengerDocumentMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.UserCreditInfo, Data.Entities.UserCreditInfo>>().To<MappingObject.ModelToEntity.UserCreditInfoMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.UserEmails, Data.Entities.UserEmails>>().To<MappingObject.ModelToEntity.UserEmailMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.UserFavoriteAirlines, Data.Entities.UserFavoriteAirlines>>().To<MappingObject.ModelToEntity.UserFavoriteAirlineMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.UserLanguages, Data.Entities.UserLanguages>>().To<MappingObject.ModelToEntity.UserLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.UserLoginLog, Data.Entities.UserLoginLog>>().To<MappingObject.ModelToEntity.UserLoginLogMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.UserPassenger, Data.Entities.UserPassenger>>().To<MappingObject.ModelToEntity.UserPassengerMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Users, Data.Entities.Users>>().To<MappingObject.ModelToEntity.UsersMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.UserTels, Data.Entities.UserTels>>().To<MappingObject.ModelToEntity.UserTelMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.WebPageBanners, Data.Entities.WebPageBanners>>().To<MappingObject.ModelToEntity.WebPageBannersMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.WebPageContext, Data.Entities.WebPageContext>>().To<MappingObject.ModelToEntity.WebPageContextMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.WebPages, Data.Entities.WebPages>>().To<MappingObject.ModelToEntity.WebPagesMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.WebsiteCategory, Data.Entities.WebsiteCategory>>().To<MappingObject.ModelToEntity.WebsiteCategoryMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.WebsiteFAQs, Data.Entities.WebsiteFAQs>>().To<MappingObject.ModelToEntity.WebsiteFAQsMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.PassengerFlight, Data.Entities.Passengers>>().To<MappingObject.ModelToEntity.PassengerFlightMapper>().InRequestScope();
            //new of model
            container.Bind<IMappingObject<Web.Api.Models.NewUser, Data.Entities.Users>>().To<MappingObject.ModelToEntity.NewUserMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.ExcelReaderCountry, Data.Entities.Country>>().To<MappingObject.ModelToEntity.ExcelCountryMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.NewCompany, Data.Entities.Company>>().To<MappingObject.ModelToEntity.NewCompanyMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.NewFlightCondition, Data.Entities.FlightCondition>>().To<MappingObject.ModelToEntity.NewFlightConditionMapper>().InRequestScope();




            container.Bind<IMappingObject<Web.Api.Models.CityPublicPlace, Data.Entities.CityPublicPlace>>().To<MappingObject.ModelToEntity.CityPublicPlaceMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.CityPublicPlaceNameByLanguage, Data.Entities.CityPublicPlaceNameByLanguage>>().To<MappingObject.ModelToEntity.CityPublicPlaceNameByLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Facilities, Data.Entities.Facilities>>().To<MappingObject.ModelToEntity.FacilitiesMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.FacilitiesCategory, Data.Entities.FacilitiesCategory>>().To<MappingObject.ModelToEntity.FacilitiesCategoryMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.FacilitiesNameByLanguage, Data.Entities.FacilitiesNameByLanguage>>().To<MappingObject.ModelToEntity.FacilitiesNameByLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.HotelAccessibility, Data.Entities.HotelAccessibility>>().To<MappingObject.ModelToEntity.HotelAccessibilityMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.HotelComments, Data.Entities.HotelComments>>().To<MappingObject.ModelToEntity.HotelCommentsMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.HotelFacilities, Data.Entities.HotelFacilities>>().To<MappingObject.ModelToEntity.HotelFacilitiesMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.HotelNameByLanguage, Data.Entities.HotelNameByLanguage>>().To<MappingObject.ModelToEntity.HotelNameByLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.HotelOrRoomConditions, Data.Entities.HotelOrRoomConditions>>().To<MappingObject.ModelToEntity.HotelOrRoomConditionsMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.HotelPhotos, Data.Entities.HotelPhotos>>().To<MappingObject.ModelToEntity.HotelPhotosMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.HotelRoom, Data.Entities.HotelRoom>>().To<MappingObject.ModelToEntity.HotelRoomMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.HotelRoomBeds, Data.Entities.HotelRoomBeds>>().To<MappingObject.ModelToEntity.HotelRoomBedsMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.HotelRoomComments, Data.Entities.HotelRoomComments>>().To<MappingObject.ModelToEntity.HotelRoomCommentsMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.HotelRoomNightPrice, Data.Entities.HotelRoomNightPrice>>().To<MappingObject.ModelToEntity.HotelRoomNightPriceMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.HotelRoomPhotos, Data.Entities.HotelRoomPhotos>>().To<MappingObject.ModelToEntity.HotelRoomPhotosMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.HotelRoomType, Data.Entities.HotelRoomType>>().To<MappingObject.ModelToEntity.HotelRoomTypeMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.HotelRoomTypeNameByLanguage, Data.Entities.HotelRoomTypeNameByLanguage>>().To<MappingObject.ModelToEntity.HotelRoomTypeNameByLanguageMapper>().InRequestScope();
            container.Bind<IMappingObject<Web.Api.Models.Hotels, Data.Entities.Hotels>>().To<MappingObject.ModelToEntity.HotelsMapper>().InRequestScope();



            #endregion
        }
        private void ConfigureOperatingMethods(IKernel container)
        {
            container.Bind<IAirlineClassesMethod>().To<AirlineClassesMethod>().InRequestScope();
            container.Bind<IAirlineClassPathMethod>().To<AirlineClassPathMethod>().InRequestScope();
            container.Bind<IAirlineMembersMethod>().To<AirlineMembersMethod>().InRequestScope();
            container.Bind<IAirlineNameByLanguageMethod>().To<AirlineNameByLanguageMethod>().InRequestScope();
            container.Bind<IAirlinesMethod>().To<AirlinesMethod>().InRequestScope();
            container.Bind<IAirlineSubClassesMethod>().To<AirlineSubClassesMethod>().InRequestScope();
            container.Bind<IAirplaneMethod>().To<AirplaneMethod>().InRequestScope();
            container.Bind<IAirportNameByLanguageMethod>().To<AirportNameByLanguageMethod>().InRequestScope();
            container.Bind<IAirportsMethod>().To<AirportsMethod>().InRequestScope();
            container.Bind<IBlogsMethod>().To<BlogsMethod>().InRequestScope();
            container.Bind<ICityMethod>().To<CityMethod>().InRequestScope();
            container.Bind<ICityNameByLanguageMethod>().To<CityNameByLanguageMethod>().InRequestScope();
            container.Bind<ICompanyAttachmentMethod>().To<CompanyAttachmentMethod>().InRequestScope();
            container.Bind<ICompanyEmployeeMethod>().To<CompanyEmployeeMethod>().InRequestScope();
            container.Bind<ICompanyMethod>().To<CompanyMethod>().InRequestScope();
            container.Bind<ICompanyServiceFeeMethod>().To<CompanyServiceFeeMethod>().InRequestScope();
            container.Bind<IConditionTypeMethod>().To<ConditionTypeMethod>().InRequestScope();
            container.Bind<IConditionValuesMethod>().To<ConditionValuesMethod>().InRequestScope();
            container.Bind<IContinentMethod>().To<ContinentMethod>().InRequestScope();
            container.Bind<ICountryIpAddressesMethod>().To<CountryIpAddressesMethod>().InRequestScope();
            container.Bind<ICountryMethod>().To<CountryMethod>().InRequestScope();
            container.Bind<ICountryNameByLanguageMethod>().To<CountryNameByLanguageMethod>().InRequestScope();
            container.Bind<IEarthRegionMethod>().To<EarthRegionMethod>().InRequestScope();
            container.Bind<IExtensionsMethod>().To<ExtensionsMethod>().InRequestScope();
            container.Bind<IFilesMethod>().To<FilesMethod>().InRequestScope();
            container.Bind<IFlightConditionMethod>().To<FlightConditionMethod>().InRequestScope();
            container.Bind<IFlightFreeServicesMethod>().To<FlightFreeServicesMethod>().InRequestScope();
            container.Bind<IFlightNumbersMethod>().To<FlightNumbersMethod>().InRequestScope();
            container.Bind<IFlightPathMethod>().To<FlightPathMethod>().InRequestScope();
            container.Bind<IFlightStopOverMethod>().To<FlightStopOverMethod>().InRequestScope();
            container.Bind<IFoldersMethod>().To<FoldersMethod>().InRequestScope();
            container.Bind<IJobOpportunityMethod>().To<JobOpportunityMethod>().InRequestScope();
            container.Bind<ILanguagesMethod>().To<LanguagesMethod>().InRequestScope();
            container.Bind<INewsMethod>().To<NewsMethod>().InRequestScope();
            container.Bind<INewsTagsMethod>().To<NewsTagsMethod>().InRequestScope();
            container.Bind<IOnlineFlightTicketMethod>().To<OnlineFlightTicketMethod>().InRequestScope();
            container.Bind<IOnlineFlightTicketPassengersMethod>().To<OnlineFlightTicketPassengersMethod>().InRequestScope();
            container.Bind<IOnlineFlightTicketPathMethod>().To<OnlineFlightTicketPathMethod>().InRequestScope();
            container.Bind<IOrdersMethod>().To<OrdersMethod>().InRequestScope();
            container.Bind<IPassengersMethod>().To<PassengersMethod>().InRequestScope();
            container.Bind<IReceivedResumeMethod>().To<ReceivedResumeMethod>().InRequestScope();
            container.Bind<IRequestAirplaneServiceMethod>().To<RequestAirplaneServiceMethod>().InRequestScope();
            container.Bind<IRequestAirplaneTicketMethod>().To<RequestAirplaneTicketMethod>().InRequestScope();
            container.Bind<IRequestAirplaneTicketPassengerMethod>().To<RequestAirplaneTicketPassengerMethod>().InRequestScope();
            container.Bind<IRequestStatusMethod>().To<RequestStatusMethod>().InRequestScope();
            container.Bind<IResponseAirplaneTicketMethod>().To<ResponseAirplaneTicketMethod>().InRequestScope();
            container.Bind<IResponsibleForConfirmationMethod>().To<ResponsibleForConfirmationMethod>().InRequestScope();
            container.Bind<IRolesInSectionMethod>().To<RolesInSectionMethod>().InRequestScope();
            container.Bind<ISbsBranchAwardsMethod>().To<SbsBranchAwardsMethod>().InRequestScope();
            container.Bind<ISbsBranchesMethod>().To<SbsBranchesMethod>().InRequestScope();
            container.Bind<ISbsBranchImagesMethod>().To<SbsBranchImagesMethod>().InRequestScope();
            container.Bind<ISbsBranchTeamMethod>().To<SbsBranchTeamMethod>().InRequestScope();
            container.Bind<ISbsRolesMethod>().To<SbsRolesMethod>().InRequestScope();
            container.Bind<ISbsSectionsMethod>().To<SbsSectionsMethod>().InRequestScope();
            container.Bind<IServicesMethod>().To<ServicesMethod>().InRequestScope();
            container.Bind<IStateProvinceMethod>().To<StateProvinceMethod>().InRequestScope();
            container.Bind<IStateProvinceNameByLanguageMethod>().To<StateProvinceNameByLanguageMethod>().InRequestScope();
            container.Bind<ITicketNumberMethod>().To<TicketNumberMethod>().InRequestScope();
            container.Bind<IUserAddressesMethod>().To<UserAddressesMethod>().InRequestScope();
            container.Bind<IUserAndPassengerDocumentsMethod>().To<UserAndPassengerDocumentsMethod>().InRequestScope();
            container.Bind<IUserCreditInfoMethod>().To<UserCreditInfoMethod>().InRequestScope();
            container.Bind<IUserEmailsMethod>().To<UserEmailsMethod>().InRequestScope();
            container.Bind<IUserFavoriteAirlinesMethod>().To<UserFavoriteAirlinesMethod>().InRequestScope();
            container.Bind<IUserLanguagesMethod>().To<UserLanguagesMethod>().InRequestScope();
            container.Bind<IUserLoginLogMethod>().To<UserLoginLogMethod>().InRequestScope();
            container.Bind<IUserPassengerMethod>().To<UserPassengerMethod>().InRequestScope();
            container.Bind<IUsersInGroupMethod>().To<UsersInGroupMethod>().InRequestScope();
            container.Bind<IUsersMethod>().To<UsersMethod>().InRequestScope();
            container.Bind<IUserTelsMethod>().To<UserTelsMethod>().InRequestScope();
            container.Bind<IWebPageBannersMethod>().To<WebPageBannersMethod>().InRequestScope();
            container.Bind<IWebPageContextMethod>().To<WebPageContextMethod>().InRequestScope();
            container.Bind<IWebPagesMethod>().To<WebPagesMethod>().InRequestScope();
            container.Bind<IWebsiteCategoryMethod>().To<WebsiteCategoryMethod>().InRequestScope();
            container.Bind<IWebsiteFAQsMethod>().To<WebsiteFAQsMethod>().InRequestScope();
            container.Bind<IBaseWebSiteInfoMethod>().To<BaseWebSiteInfoMethod>().InRequestScope();


            container.Bind<IDomesticFlightTicketMethod>().To<DomesticFlightTicketMethod>().InRequestScope();
            container.Bind<IFacilitiesMethod>().To<FacilitiesMethod>().InRequestScope();
        }
    }
}