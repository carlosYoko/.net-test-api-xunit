using WebApplication1.Models;

namespace ASPTest.Services;

public class BeerServices : IBeerServices
{
    private List<Beer> _beers = new List<Beer>()
    {
        new Beer() { Id = 1, Name = "Corona", Brand = "Modelo" },
        new Beer() { Id = 2, Name = "Pikantus", Brand = "Erdinger" },
    };
    
    public IEnumerable<Beer> Get()
    {
        return _beers;
    }

    public Beer? Get(int id)
    {
        var beer = _beers.FirstOrDefault(b => b.Id == id);

        return beer;
    }
}