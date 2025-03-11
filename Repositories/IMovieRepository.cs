using System;
using MovieMvcProject.Models;

namespace MovieMvcProject.Repositories;

public interface IMovieRepository
{
    List<Movie> GetList();

    List<Movie> Search(string value);
    Movie GetMovieById(int id);
    bool Delete(int id);
    bool Create(Movie movie);
    bool Update(Movie movie);
}
