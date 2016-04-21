using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SCA.Domain;

namespace SCA.DataAccess
{
    public class ScaDbContext : IdentityDbContext<ScaIdentityUser>
    {
        public ScaDbContext() : base("DbConnection")
        {
            //var connectionString = this.Database.Connection.ConnectionString;
        }

        public static ScaDbContext Create()
        {
            return new ScaDbContext();
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<AgeDirection> AgeDirections { get; set; }
        public DbSet<ClientSite> ClientSites { get; set; }
        public DbSet<ClientSitePage> ClientSitePages { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanySector> CompanySectors { get; set; }
        public DbSet<CompanySize> CompanySizes { get; set; }
        public DbSet<CompanyStatus> CompanyStatuses { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactStatus> ContactStatuses { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<ReadyToSellState> ReadyToSellStates { get; set; }
        public DbSet<SocialNetworkEvent> SocialNetworks { get; set; }
        public DbSet<SocialNetworkType> SoxiSocialNetworkTypes { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<SystemUserType> SystemUserTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<LeadType> LeadTypes { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            //modelBuilder.Conventions.Remove<DecimalPropertyConvention>();

            modelBuilder.Conventions.Add<ColumnAttributeConvention>();
            modelBuilder.Conventions.Add<DatabaseGeneratedAttributeConvention>();
            modelBuilder.Conventions.Add<KeyAttributeConvention>();
            modelBuilder.Conventions.Add<IndexAttributeConvention>();
            modelBuilder.Conventions.Add<MaxLengthAttributeConvention>();
            modelBuilder.Conventions.Add<NotMappedPropertyAttributeConvention>();
            modelBuilder.Conventions.Add<PropertyMaxLengthConvention>();
            modelBuilder.Conventions.Add<RequiredNavigationPropertyAttributeConvention>();
            modelBuilder.Conventions.Add<RequiredPrimitivePropertyAttributeConvention>();
            modelBuilder.Conventions.Add<StoreGeneratedIdentityKeyConvention>();
            modelBuilder.Conventions.Add<StringLengthAttributeConvention>();
            modelBuilder.Conventions.Add<TableAttributeConvention>();
            modelBuilder.Conventions.Add<TimestampAttributeConvention>();

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Activity>()
                .HasMany(s => s.Tag);
            modelBuilder.Entity<Company>()
                .HasMany(x => x.Sites);

            base.OnModelCreating(modelBuilder);


        }
    }

    public sealed class DbContextSingle
    {
        private static ScaDbContext _context;
        private static object syncRoot = new Object();
        public static ScaDbContext Instance
        {
            get
            {
                if (_context == null)
                {
                    lock (syncRoot)
                    {
                        if (_context == null)
                        {
                            _context = new ScaDbContext();
                            _context.Database.Initialize(true);
                        }
                    }
                }
                return _context;
            }
        }
    }

    public class ScaUserManager : UserManager<ScaIdentityUser>
    {

        public ScaUserManager(IUserStore<ScaIdentityUser> store) : base(store)
        {
        }

        public static ScaUserManager Create(IdentityFactoryOptions<ScaUserManager> options, IOwinContext context)
        {
            var manager = new ScaUserManager(new UserStore<ScaIdentityUser>(context.Get<ScaDbContext>()));
            return manager;
        }

    }

    public class ScaIdentityUser : IdentityUser
    {
        public ScaIdentityUser()
        {
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ScaIdentityUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }


    public class ScaSignInManager : SignInManager<ScaIdentityUser, string>
    {
        public ScaSignInManager(ScaUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ScaIdentityUser user)
        {
            return user.GenerateUserIdentityAsync((ScaUserManager)UserManager);
        }

        public static ScaSignInManager Create(IdentityFactoryOptions<ScaSignInManager> options, IOwinContext context)
        {
            return new ScaSignInManager(context.GetUserManager<ScaUserManager>(), context.Authentication);
        }
    }

}
