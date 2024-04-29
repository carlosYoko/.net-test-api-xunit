using WebApplication1.Models;

namespace ASPTest.Services;

public interface IBeerServices
{
    public IEnumerable<Beer> Get();
    public Beer? Get(int id);
}