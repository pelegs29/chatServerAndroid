using chatServer.Models;
using NuGet.Configuration;

namespace chatServer.Servives;

public interface IRatingService
{
    public List<Rating> GetAll();
    public Rating Get(int id);
    public void Delete(int Id);
    public void Add(int star, string name, string review );

    public void Update(Rating rating);

    public int AverageStars();
}