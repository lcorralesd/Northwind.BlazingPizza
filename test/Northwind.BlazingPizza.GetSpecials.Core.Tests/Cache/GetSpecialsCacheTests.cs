using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Northwind.BlazingPizza.GetSpecials.Core.Cache;

namespace Northwind.BlazingPizza.GetSpecials.Core.Tests.Cache;
public class GetSpecialsCacheTests
{
    [Fact]
    public async Task SetSpecialsAsync_Should_Save_And_GetSpecialsAsync_Should_Return_SameValue_From_Cache()
    {
        // Arrange
        var expectedSpecials = new List<PizzaSpecialDto>
        {
            new PizzaSpecialDto(3, "s3", 30, "d3", "i3"),
            new PizzaSpecialDto(4, "s4", 40, "d4", "i4"),
            new PizzaSpecialDto(5, "s5", 50, "d5", "i5")
        };

        var cacheOptions = Options.Create(new MemoryDistributedCacheOptions());
        IDistributedCache cache = new MemoryDistributedCache(cacheOptions);

        ILogger<GetSpecialsCache> logger = new NullLogger<GetSpecialsCache>();

        var getSpecialsCache = new GetSpecialsCache(cache, logger);

        // Act
        await getSpecialsCache.SetSpecialsAsync(expectedSpecials);
        var returnedSpecials = await getSpecialsCache.GetSpecialsAsync();

        // Assert
        Assert.Equal(expectedSpecials.Count, returnedSpecials.Count());

        var pairs = expectedSpecials.Zip(returnedSpecials, (expected, returned) => new { expected, returned });

        // Mejor para identificar problemas específicos en propiedades individuales debido a mensajes de error detallados. Facilita la depuración.
        Assert.All(pairs, pair =>
        {
            Assert.Equal(pair.expected.Id, pair.returned.Id);
            Assert.Equal(pair.expected.Name, pair.returned.Name);
            Assert.Equal(pair.expected.BasePrice, pair.returned.BasePrice);
            Assert.Equal(pair.expected.Description, pair.returned.Description);
            Assert.Equal(pair.expected.ImageUrl, pair.returned.ImageUrl);
        });

        // Alternativa Menos detallada en caso de fallo, pero más concisa en términos de código. Podría ser útil si no es relevante conocer exactamente qué propiedad falla.
        //Assert.All(pairs, pair =>
        //Assert.True(pair.expected.Id == pair.returned.Id &&
        //    pair.expected.Name == pair.returned.Name &&
        //    pair.expected.BasePrice == pair.returned.BasePrice &&
        //    pair.expected.Description == pair.returned.Description &&
        //    pair.expected.ImageUrl == pair.returned.ImageUrl));


    }
}
