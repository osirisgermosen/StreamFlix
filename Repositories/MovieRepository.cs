using System;
using System.Data;
using Microsoft.Data.SqlClient;
using MovieMvcProject.Helpers;
using MovieMvcProject.Models;

namespace MovieMvcProject.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly IConfiguration _config;

    public MovieRepository(IConfiguration configuration)
    {
        _config = configuration;
    }

    public bool Create(Movie movie)
    {
        int numRows = 0;
        bool bValue = false;

        using (SqlConnection oConn = new SqlConnection(_config.GetConnectionString("Default")))
        {
            try
            {
                oConn.Open();
                SqlCommand oCmd = oConn.CreateCommand();
                oCmd.CommandText = "sp_CreateMovie";
                oCmd.CommandType = CommandType.StoredProcedure;

                oCmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = movie.Title;
                oCmd.Parameters.Add("ReleaseDate", SqlDbType.DateTime).Value = movie.ReleaseDate;
                oCmd.Parameters.Add("Genre", SqlDbType.NVarChar).Value = movie.Genre;
                oCmd.Parameters.Add("Year", SqlDbType.Int).Value = movie.Year;
                oCmd.Parameters.Add("Price", SqlDbType.Decimal).Value = movie.Price;
                oCmd.Parameters.Add("Active", SqlDbType.Bit).Value = movie.Active;

                numRows = oCmd.ExecuteNonQuery();

                bValue = numRows > 0;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        return bValue;
    }

    public bool Delete(int id)
    {
        bool bValue = false;

        using (SqlConnection oConn = new SqlConnection(_config.GetConnectionString("Default")))
        {
            try
            {
                oConn.Open();
                SqlCommand oCmd = oConn.CreateCommand();
                oCmd.CommandText = "sp_DeleteMovie";
                oCmd.CommandType = CommandType.StoredProcedure;

                oCmd.Parameters.Add("Id", SqlDbType.Int).Value = id;

                int numRows = oCmd.ExecuteNonQuery();

                bValue = numRows > 0;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        return bValue;
    }

    public List<Movie> GetList()
    {
        List<Movie> movies = new();

        using (SqlConnection oConn = new SqlConnection(_config.GetConnectionString("Default")))
        {
            try
            {
                oConn.Open();
                SqlCommand oCmd = oConn.CreateCommand();
                oCmd.CommandText = "sp_SelectMovies";
                oCmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader oReader = oCmd.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        Movie movie = new();
                        movie.Id = SqlValidate.GetInt32(oReader, "Id");
                        movie.Title = SqlValidate.GetString(oReader, "Title");
                        movie.Genre = SqlValidate.GetString(oReader, "Genre");
                        movie.ReleaseDate = SqlValidate.GetDateTime(oReader, "ReleaseDate");
                        movie.Year = SqlValidate.GetInt32(oReader, "Year");
                        movie.Price = SqlValidate.GetDecimal(oReader, "Price");
                        movie.Active = SqlValidate.GetBoolean(oReader, "Active");
                        movies.Add(movie);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        return movies;
    }

    public Movie GetMovieById(int id)
    {
        Movie movie = new();

        using (SqlConnection oConn = new SqlConnection(_config.GetConnectionString("Default")))
        {
            try
            {
                oConn.Open();
                SqlCommand oCmd = oConn.CreateCommand();
                oCmd.CommandText = "sp_SelectMovieById";
                oCmd.CommandType = CommandType.StoredProcedure;

                oCmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                SqlDataReader oReader = oCmd.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        movie.Id = SqlValidate.GetInt32(oReader, "Id");
                        movie.Title = SqlValidate.GetString(oReader, "Title");
                        movie.Genre = SqlValidate.GetString(oReader, "Genre");
                        movie.ReleaseDate = SqlValidate.GetDateTime(oReader, "ReleaseDate");
                        movie.Year = SqlValidate.GetInt32(oReader, "Year");
                        movie.Price = SqlValidate.GetDecimal(oReader, "Price");
                        movie.Active = SqlValidate.GetBoolean(oReader, "Active");
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        return movie;
    }

    public List<Movie> Search(string value)
    {
        List<Movie> movies = new();

        using (SqlConnection oConn = new SqlConnection(_config.GetConnectionString("Default")))
        {
            try
            {
                oConn.Open();
                SqlCommand oCmd = oConn.CreateCommand();
                oCmd.CommandText = "sp_SearchMovies";
                oCmd.CommandType = CommandType.StoredProcedure;


                oCmd.Parameters.Add("@Search", SqlDbType.NVarChar).Value = $"%{value}%";

                SqlDataReader oReader = oCmd.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        Movie movie = new();
                        movie.Id = SqlValidate.GetInt32(oReader, "Id");
                        movie.Title = SqlValidate.GetString(oReader, "Title");
                        movie.Genre = SqlValidate.GetString(oReader, "Genre");
                        movie.ReleaseDate = SqlValidate.GetDateTime(oReader, "ReleaseDate");
                        movie.Year = SqlValidate.GetInt32(oReader, "Year");
                        movie.Price = SqlValidate.GetDecimal(oReader, "Price");
                        movie.Active = SqlValidate.GetBoolean(oReader, "Active");
                        movies.Add(movie);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        return movies;
    }

    public bool Update(Movie movie)
    {
        bool bValue = false;

        using (SqlConnection oConn = new SqlConnection(_config.GetConnectionString("Default")))
        {
            try
            {
                oConn.Open();
                SqlCommand oCmd = oConn.CreateCommand();
                oCmd.CommandText = "sp_UpdateMovie";
                oCmd.CommandType = CommandType.StoredProcedure;

                oCmd.Parameters.Add("Id", SqlDbType.Int).Value = movie.Id;
                oCmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = movie.Title;
                oCmd.Parameters.Add("ReleaseDate", SqlDbType.DateTime).Value = movie.ReleaseDate;
                oCmd.Parameters.Add("Genre", SqlDbType.NVarChar).Value = movie.Genre;
                oCmd.Parameters.Add("Year", SqlDbType.Int).Value = movie.Year;
                oCmd.Parameters.Add("Price", SqlDbType.Decimal).Value = movie.Price;
                oCmd.Parameters.Add("Active", SqlDbType.Bit).Value = movie.Active;

                int numRows = oCmd.ExecuteNonQuery();

                bValue = numRows > 0;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        return bValue;
    }
}
