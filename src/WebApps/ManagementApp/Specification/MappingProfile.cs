using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Entities.Static;
using ApplicationCore.ViewModel.Account;
using ApplicationCore.ViewModel.BaseInfo;
using ApplicationCore.ViewModel.Branch;
using ApplicationCore.ViewModel.CashDesk;
using ApplicationCore.ViewModel.Currency;
using ApplicationCore.ViewModel.Location;
using ApplicationCore.ViewModel.Log;
using ApplicationCore.ViewModel.Menu;
using ApplicationCore.ViewModel.Network;
using ApplicationCore.ViewModel.Person;
using ApplicationCore.ViewModel.Stuff;
using ApplicationCore.ViewModel.User;
using AutoMapper;
using Microsoft.CodeAnalysis;

namespace ManagementApp.Specification
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, LoginViewModel>();
            CreateMap<LoginViewModel, User>();

            CreateMap<Province, ProvinceViewModel>();
            CreateMap<ProvinceViewModel, Province>();

            CreateMap<City, CityViewModel>();
            CreateMap<CityViewModel, City>();

            CreateMap<CountryViewModel, Country>();
            CreateMap<Country, CountryViewModel>();

            CreateMap<Location, LocationViewModel>();

            CreateMap<BaseInfoGroup, BaseInfoGroupViewModel>();

            CreateMap<BaseInfo, BaseInfoViewModel>();
            CreateMap<LogType, LogTypeViewModel>();
            CreateMap<UserGroup, UserGroupViewModel>();
            CreateMap<Currency, CurrencyViewModel>();

            CreateMap<PersonGroup, PersonGroupViewModel>();
            CreateMap<PersonGroupViewModel, PersonGroup>();

            CreateMap<Measure, MeasureViewModel>();
            CreateMap<MeasureViewModel, Measure>();

            CreateMap<Role, RoleViewModel>();
            CreateMap<RoleViewModel, Role>();

            CreateMap<Permission, PermissionViewModel>();
            CreateMap<PermissionViewModel, Permission>();

            CreateMap<UserRole, UserRoleViewModel>();
            CreateMap<UserRoleViewModel, UserRole>();

            CreateMap<Drawer, DrawerViewModel>();
            CreateMap<DrawerViewModel, Drawer>();


            CreateMap<UserCashDesk, UserCashDeskViewModel>();
            CreateMap<UserCashDeskViewModel, UserCashDesk>();

            CreateMap<StuffSupplier, StuffSupplierViewModel>();
            CreateMap<StuffSupplierViewModel, UserCashDesk>();


            CreateMap<StuffGroup, StuffGroupViewModel>();
            CreateMap<StuffGroupViewModel, StuffGroup>();

            CreateMap<ManagementAppMenu, ManagementAppMenuViewModel>();
            CreateMap<ManagementAppMenuViewModel, ManagementAppMenu>();

            CreateMap<CashDesk, UserCashDeskViewModel>();
            CreateMap<UserCashDeskViewModel, CashDesk>();

            CreateMap<UserGroupRole, UserGroupRoleViewModel>();
            CreateMap<UserGroupRoleViewModel, UserGroupRole>();

            CreateMap<RolePermission, RolePermissionViewModel>();
            CreateMap<RolePermissionViewModel, RolePermission>();

            CreateMap<Barcode, BarcodeViewModel>();
            CreateMap<BarcodeViewModel, Barcode>();

            CreateMap<WarehouseStuff, WarehouseStuffViewModel>();
            CreateMap<WarehouseStuffViewModel, WarehouseStuff>();

            CreateMap<PriceTag, PriceTagViewModel>();
            CreateMap<PriceTagViewModel, PriceTag>();

            CreateMap<PriceConsumer, PriceConsumerViewModel>();
            CreateMap<PriceConsumerViewModel, PriceConsumer>();

            CreateMap<ApplicationCore.Entities.Share.Utility, UtilityViewModel>();
            CreateMap<UtilityViewModel, ApplicationCore.Entities.Share.Utility>();

            CreateMap<ApplicationCore.Entities.Share.UtilityDetail, UtilityDetailViewModel>();
            CreateMap<UtilityDetailViewModel, ApplicationCore.Entities.Share.UtilityDetail>();

            CreateMap<CashDeskUtility, CashDeskUtilityViewModel>();
            CreateMap<CashDeskUtilityViewModel, CashDeskUtility>();

            
        }
    }
}
