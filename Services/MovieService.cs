using System;
using MovieMvcProject.Models;
using MovieMvcProject.Repositories;

namespace MovieMvcProject.Services;

public class MovieService : IMovieService
{
    public IMovieRepository _repository { get; }

    public MovieService(IMovieRepository movieService)
    {
        _repository = movieService;
    }

    public bool Create(Movie movie)
    {
        return _repository.Create(movie);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }

    public List<Movie> GetList()
    {
        return _repository.GetList();
    }

    public Movie GetMovieById(int id)
    {
        return _repository.GetMovieById(id);
    }

    public bool Update(Movie movie)
    {
        return _repository.Update(movie);
    }

    public List<Movie> Search(string value)
    {
        return _repository.Search(value);
    }
}
