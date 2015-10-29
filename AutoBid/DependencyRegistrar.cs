using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Core.Infrastructure;
using Core.Data;
using Data;
using Core.Fakes;
using Service.Misc;
using Service.CarSeller;
using AutoBid.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Service.CarBuyer;
using Service.AspUser;
using Service.Seller;
using Service.Company;
using Service.Auction;


namespace AutoBid
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //HTTP context and other related stuff
            builder.Register(c =>
                //register FakeHttpContext when HttpContext is not available
                HttpContext.Current != null ?
                (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
                (new FakeHttpContext("~/") as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerHttpRequest();

            //controllers
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());
            builder.RegisterType<ObjectContext>().As<IDbContext>().InstancePerHttpRequest();

            //builder.RegisterType<UserService>().As<IUserService>().InstancePerHttpRequest();
            //builder.RegisterType<UserRoleService>().As<IUserRoleService>().InstancePerHttpRequest();
            builder.RegisterType<CarSellerTypeService>().As<ICarSellerTypeService>().InstancePerHttpRequest();
            builder.RegisterType<BodyTypeService>().As<IBodyTypeService>().InstancePerHttpRequest();
            builder.RegisterType<CarSellingOnService>().As<ICarSellingOnService>().InstancePerHttpRequest();

            builder.RegisterType<AuctionHouseSaleService>().As<IAuctionHouseSaleService>().InstancePerHttpRequest();
            builder.RegisterType<AuctionHouseCarSellingVehicleImagesMoreService>().As<IAuctionHouseCarSellingVehicleImagesMoreService>().InstancePerHttpRequest();

            builder.RegisterType<CarModelService>().As<ICarModelService>().InstancePerHttpRequest();
            builder.RegisterType<MakeService>().As<IMakeService>().InstancePerHttpRequest();
            builder.RegisterType<EngineSizeService>().As<IEngineSizeService>().InstancePerHttpRequest();
            builder.RegisterType<TransmissionTypeService>().As<ITransmissionTypeService>().InstancePerHttpRequest();
            builder.RegisterType<ServiceHistoryAuctionService>().As<IServiceHistoryAuctionService>().InstancePerHttpRequest();
            builder.RegisterType<FuelTypeService>().As<IFuelTypeService>().InstancePerHttpRequest();
            builder.RegisterType<InteriorTrimService>().As<IInteriorTrimService>().InstancePerHttpRequest();
            builder.RegisterType<CheckStatusService>().As<ICheckStatusService>().InstancePerHttpRequest();

            builder.RegisterType<CountryService>().As<ICountryService>().InstancePerHttpRequest();
            builder.RegisterType<CarSellerVehicleInfoService>().As<ICarSellerVehicleInfoService>().InstancePerHttpRequest();
            builder.RegisterType<CarSellerMoreDetailService>().As<ICarSellerMoreDetailService>().InstancePerHttpRequest();
            builder.RegisterType<CarSellerVehicleImagesService>().As<ICarSellerVehicleImagesService>().InstancePerHttpRequest();
            builder.RegisterType<CarBuyerInfoService>().As<ICarBuyerInfoService>().InstancePerHttpRequest();
            builder.RegisterType<AspNetUsersAdditionalInfoService>().As<IAspNetUsersAdditionalInfoService>().InstancePerHttpRequest();
            builder.RegisterType<SellerPersonalInfoService>().As<ISellerPersonalInfoService>().InstancePerHttpRequest();
            builder.RegisterType<CompanyTypeService>().As<ICompanyTypeService>().InstancePerHttpRequest();
            builder.RegisterType<SellerCompanyInfoService>().As<ISellerCompanyInfoService>().InstancePerHttpRequest();
            builder.RegisterType<SellerCompanyLogoService>().As<ISellerCompanyLogoService>().InstancePerHttpRequest();
            builder.RegisterType<CarSellerInfoService>().As<ICarSellerInfoService>().InstancePerHttpRequest();
            builder.RegisterType<AspNetUserService>().As<IAspNetUserService>().InstancePerHttpRequest();
            builder.RegisterType<AuctionHouseService>().As<IAuctionHouseService>().InstancePerHttpRequest();
            builder.RegisterType<AuctionHouseAddEditVehicleService>().As<IAuctionHouseAddEditVehicleService>().InstancePerHttpRequest();
            builder.RegisterType<CarSellerVehicleFuelTypeService>().As<ICarSellerVehicleFuelTypeService>().InstancePerHttpRequest();
            builder.RegisterType<AspNetUserRolesService>().As<IAspNetUserRolesService>().InstancePerHttpRequest();
            builder.RegisterType<AuctionHouseCarSellingVehicleImagesService>().As<IAuctionHouseCarSellingVehicleImagesService>().InstancePerHttpRequest();
            builder.RegisterType<UserStore<ApplicationUser>>().As<IUserStore<ApplicationUser>>().InstancePerHttpRequest();

            builder.RegisterType<RoleStore<IdentityRole>>().As<IRoleStore<IdentityRole>>();
            builder.RegisterType<UserManager<ApplicationUser>>().InstancePerHttpRequest();
            builder.RegisterType<RoleManager<IdentityRole>>().InstancePerHttpRequest();



            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerHttpRequest();

        }

        public int Order
        {
            get { return 0; }
        }
    }

}
