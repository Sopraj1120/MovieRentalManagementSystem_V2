using Microsoft.Identity.Client.Kerberos;

namespace MovieRentalManagementSystem_V2
{
    internal class Program
    {
        private static Movies movies;

        static void Main(string[] args)
        {
            MovieRepository repository = new MovieRepository();
            int option;

            do
            {
                Console.WriteLine("Movie Rental Management System: ");
                Console.WriteLine("1. Add a Movie ");
                Console.WriteLine("2. View All Movies");
                Console.WriteLine("3. Update a Movie");
                Console.WriteLine("4. Delete a Movie");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose an option:");

                if (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 5)
                {
                    Console.WriteLine("Invalid Input Please put valid input!");
                }

                switch (option)
                {
                    case 1:
                        AddMovie(repository); break;
                    case 2:
                        repository.ViewMovie(); break;
                    case 3:
                        Updatemovie(repository); break;
                    case 4:
                        DeleteMovie(repository); break;
                    case 5:
                        Console.WriteLine("Exit this System...");
                        break;
                }
            }
            while (option != 5);
        }

        static void AddMovie(MovieRepository repository)
        {
            Console.Write("Enter Movie Id: ");
            int MovieId = int.Parse(Console.ReadLine());

            Console.Write("Enter Movie Title: ");
            string Title = Console.ReadLine();

            Console.Write("Enter Movie Director: ");
            string Director = Console.ReadLine();

            Console.Write("Enter Movie RentalPrice: ");
            string RentalPrice = Console.ReadLine();



            repository.AddMovie(movies);

            Console.Clear();

        }

        static void Updatemovie(MovieRepository repository)
        {
            Console.Write("Enter Movie Id: ");
            int MovieId =int.Parse( Console.ReadLine());

            Console.Write("Enter Movie Title: ");
            string Title = Console.ReadLine();

            Console.Write("Enter Movie Director: ");
            string Director = Console.ReadLine();

            Console.Write("Enter Movie RentalPrice: ");
            string RentalPrice = Console.ReadLine();

            repository.UpdateMovie(movies);

            Console.Clear();

        }

        static void DeleteMovie(MovieRepository repository)
        {
            Console.Write("Enter Movie Id: ");
            int MovieId =int.Parse( Console.ReadLine());

            repository.DeleteMovie(MovieId);

            Console.Clear();
        }

    }
}

