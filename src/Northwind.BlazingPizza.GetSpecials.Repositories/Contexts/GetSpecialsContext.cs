namespace Northwind.BlazingPizza.GetSpecials.Repositories.Contexts;
internal class GetSpecialsContext : DbContext
{
    readonly IOptions<GetSpecialsDBOptions> _options;

    public GetSpecialsContext(IOptions<GetSpecialsDBOptions> options)
    {
        _options = options;
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_options.Value.ConnectionString);
    }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PizzaSpecialConfiguration).Assembly);
    }

    public DbSet<PizzaSpecial> PizzaSpecials { get; set; }
}
