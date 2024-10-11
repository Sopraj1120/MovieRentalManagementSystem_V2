using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace MovieRentalManagementSystem_V2
{
    public class MovieRepository
    {
        private string connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MovieRentalManagement;Integrated Security=True;Trust Server Certificate=True";

        public void AddMovie(Movies movies)
        {
            try
            {


                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    var commit = connection.CreateCommand();
                    commit.CommandText = @"INSERT INTO Movies(MovieId,Title,Director,RentalPrice)
                    VALUES (@MovieId, @Title, @Director, @RentalPrice)";
                    commit.Parameters.AddWithValue("@MovieId",movies.MovieId);
                    commit.Parameters.AddWithValue("@Title",movies.Title);
                    commit.Parameters.AddWithValue("@Director",movies.Director);
                    commit.Parameters.AddWithValue("@RentalPrice",movies.RentalPrice);

                    commit.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void ViewMovie()
        {
            try
            {


                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    var commit = connection.CreateCommand();
                    commit.CommandText = @"SELECT * FROM Movies";

                    SqlDataReader reader = commit.ExecuteReader();

                    if (reader.Read())
                    {
                        Console.WriteLine($"Id:{reader.GetInt32(0)},Title:{reader.GetString(1)}, Director:{reader.GetString(2)}, RentalPrice:{reader.GetDecimal(3)}");
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void UpdateMovie(Movies movies)
        {
            try
            {


                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    var commit = connection.CreateCommand();
                    commit.CommandText = @"UPDATE Movies SET Title=@Title, Director=@Director, RentalPrice=@RentalPrice WHERE MovieId=@MovieId";
                    commit.Parameters.AddWithValue("@MovieId", movies.MovieId);
                    commit.Parameters.AddWithValue("@Title", movies.Title);
                    commit.Parameters.AddWithValue("@Director", movies.Director);
                    commit.Parameters.AddWithValue("@RentalPrice", movies.RentalPrice);

                    commit.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void DeleteMovie(int movieId)
        {
            try
            {


                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    var commit = connection.CreateCommand();
                    commit.CommandText = @"DELETE Movies WHERE MovieId=@MOvieId";
                    commit.Parameters.AddWithValue("@MovieId", movieId);


                    commit.ExecuteNonQuery();


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //public string Capitalize(string title)
        //{
        //    if (title.IsNullOrEmpty())
        //    {
        //        return title;
                
        //    }

        //    var words = title.Split(' ');
        //    for (int i = 0; i < words.Length; i++)
        //    {
        //        if (words.Length > 0)
        //        {
        //            words[0] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
        //        }
        //    }

        //    return title = words.Join(" ");
        //}
    }
}
