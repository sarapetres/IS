using Shop.Domain.DomainModels;

namespace Shop.Services.Interface;

public interface IMovieService
{
    public void CreateNewMovie(Movie t);

    public void DeleteMovie(int id);

    public List<Movie> GetAllMovies();

    public Movie GetDetailsForMovie(int id);
    
    public void UpdateExistingMovie(Movie t);
}