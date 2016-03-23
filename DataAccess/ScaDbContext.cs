using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SCA.Domain;

namespace SCA.DataAccess
{
    public class ScaDbContext : DbContext
    {
        public ScaDbContext() : base("DbConnection")
        {
            //var connectionString = this.Database.Connection.ConnectionString;
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<AgeDirection> AgeDirections { get; set; }
        public DbSet<ClientSite> ClientSites { get; set; }
        public DbSet<ClientSitePage> ClientSitePages { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyRelation> CompanyRelations { get; set; }
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
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<SocialNetworkType> SoxiSocialNetworkTypes { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<SystemUserType> SystemUserTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Activity>()
                .HasMany(s => s.Tag);
        }
    }

    public sealed class DbContextSingle
    {
        private static ScaDbContext _context;

        public static ScaDbContext Instance
        {
            get { return _context ?? (_context = new ScaDbContext()); }
        }
    }
}
