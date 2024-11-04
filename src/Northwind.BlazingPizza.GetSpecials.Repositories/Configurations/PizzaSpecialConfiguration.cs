namespace Northwind.BlazingPizza.GetSpecials.Repositories.Configurations;
internal class PizzaSpecialConfiguration : IEntityTypeConfiguration<PizzaSpecial>
{
    public void Configure(EntityTypeBuilder<PizzaSpecial> builder)
    {
        builder.Property(s => s.BasePrice).HasPrecision(8, 2);

        builder.HasData(
            new PizzaSpecial
            {
                Id = 1,
                Name = "Pizza clásica de queso",
                Description = "Es de queso y delicioso. ¿Por qué no querrías una?",
                BasePrice = 9.99,
                ImageUrl = "cheese.jpg"
            },
            new PizzaSpecial
            {
                Id = 2,
                Name = "Tocinator",
                Description = "Tiene TODO tipo de tocino",
                BasePrice = 15.99,
                ImageUrl = "bacon.jpg"
            },
            new PizzaSpecial
            {
                Id = 3,
                Name = "Clásica de pepperoni",
                Description = "Es la pizza con la que creciste, ¡pero ardientemente deliciosa!",
                BasePrice = 11.99,
                ImageUrl = "pepperoni.jpg"
            },
            new PizzaSpecial
            {
                Id = 4,
                Name = "Pollo búfalo",
                Description = "Pollo picante, salsa picante y queso azul, garantizado que entrarás en calor",
                BasePrice = 16.99,
                ImageUrl = "meaty.jpg"
            },
            new PizzaSpecial
            {
                Id = 5,
                Name = "Amantes del champiñón",
                Description = "Tiene champiñones. ¿No es obvio?",
                BasePrice = 7.99,
                ImageUrl = "mushroom.jpg"
            },
            new PizzaSpecial
            {
                Id = 6,
                Name = "Hawaiian",
                Description = "It's got pineapple, which is good for you",
                BasePrice = 13.50,
                ImageUrl = "hawaiian.jpg"
            },
            new PizzaSpecial
            {
                Id = 7,
                Name = "Delicia vegetariana",
                Description = "Es como una ensalada, pero en una pizza",
                BasePrice = 8.75,
                ImageUrl = "salad.jpg"
            },
            new PizzaSpecial
            {
                Id = 8,
                Name = "Margarita",
                Description = "Pizza italiana tradicional con tomates y albahaca",
                BasePrice = 13.99,
                ImageUrl = "margherita.jpg"
            });
    }
}
