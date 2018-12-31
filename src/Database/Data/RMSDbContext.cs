using ApplicationCore.Entities;
using ApplicationCore.Entities.Share;
using ApplicationCore.Entities.Static;
using Microsoft.EntityFrameworkCore;

namespace Database.Data
{
    public class RmsDbContext : DbContext
    {
        public RmsDbContext(DbContextOptions<RmsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<BaseInfoGroup> BaseInfoGroups { get; set; }
        public DbSet<BaseInfo> BaseInfos { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<StuffGroup> StuffGroups { get; set; }
        public DbSet<Barcode> BarCodes { get; set; }
        public DbSet<Stuff> Stuffs { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Holding> Holdings { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<CashDesk> CashDesks { get; set; }
        public DbSet<Utility> Utilities { get; set; }
        public DbSet<UtilityDetail> UtilityDetails { get; set; }
        public DbSet<CashDeskUtility> CashDeskUtilities { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<PaymentGroup> PaymentGroups { get; set; }
        public DbSet<DrawerPayment> DrawerPayments { get; set; }
        public DbSet<Drawer> Drawers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<NetworkInfo> NetworkInfos { get; set; }
        public DbSet<PriceConsumer> PriceConsumers { get; set; }
        public DbSet<PriceTag> PriceTags { get; set; }
        public DbSet<ManagementAppMenu> ManagementAppMenus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<RoleGroup> RoleGroups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<BranchContact> BranchContacts { get; set; }
        public DbSet<PersonContact> PersonContacts { get; set; }
        public DbSet<WarehouseContact> WarehouseContacts { get; set; }

        public DbSet<SupplierContact> SupplierContacts { get; set; }

        public DbSet<CompanyContact> CompanyContacts { get; set; }


        public DbSet<HoldingContact> HoldingContacts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<UserGroupRole> UserGroupRoles { get; set; }
        public DbSet<UserCashDesk> UserCashDesks { get; set; }
        public DbSet<StuffSupplier> StuffSuppliers { get; set; }
        public DbSet<PersonGroup> PersonGroups { get; set; }
        public DbSet<WarehouseStuff> WarehouseStuffs { get; set; }
        public DbSet<LogType> LogTypes { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<StuffUnit> StuffUnits { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
    }




}
