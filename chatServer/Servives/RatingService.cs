using chatServer.Models;

namespace chatServer.Servives;

public class RatingService : IRatingService
{
    private static List<Rating> _ratings = new List<Rating>();

    public RatingService()
    {
        _ratings.Add(new Rating(){Id = 1,Name = "itmar",Review = "cool!",Stars = 3, Time = "05/14/2022 18:30:56	"});
        _ratings.Add(new Rating(){Id = 2,Name = "nadav",Review = "Nice!",Stars = 2, Time = "05/14/2022 16:34:30	"});

    }
    public List<Rating> GetAll()
    {
        return _ratings;
    }

    public Rating Get(int id)
    {
        return _ratings.Find(x => x.Id == id);
    }
    public void Delete(int id)
    {
        Rating rating = Get(id);
        _ratings.Remove(rating);
    }

    public void Add(int star, string name, string review )
    {
        int nextId;
        if (_ratings.Count == 0)
        {
            nextId = 1;
        }
        else
        {
            nextId =_ratings.Max(x => x.Id) + 1;

        }
        DateTime date = DateTime.Now;
        _ratings.Add(new Rating(){ Id = nextId,Name = name,Stars = star,Review = review, Time = date.ToString()});
    }

    public void Update(Rating rating)
    {
         Rating ratingOld = _ratings.Find(x => x.Id == rating.Id);
         ratingOld.Name = rating.Name;
         ratingOld.Review =rating.Review;
         ratingOld.Stars =rating.Stars;
         ratingOld.Time = rating.Time;

    }

    public int AverageStars()
    {
       return _ratings.Sum(x => x.Stars) / _ratings.Count;
    }


}