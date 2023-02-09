using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HttpClientSample
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string? Login { get; set; }
        [Display(Name = "Is Deleted?")]
        public bool IsDeleted { get; set; }
    }

    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowUser(User user)
        {
            Console.WriteLine($"Name: {user.Name}\tSurname: {user.Surname}\tDate Of Birth: {user.DateOfBirth}\tLogin: {user.Login}\tIs Deleted: {user.IsDeleted}");
        }

        static async Task<Uri> CreateUserAsync(User user)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/UsersApi", user);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<User> GetUserAsync(string path)
        {
            User? user = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
            }
            return user;
        }

        static async Task<User> UpdateUserAsync(User user)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/UsersApi/{user.Id}", user);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated user from the response body.
            user = await response.Content.ReadAsAsync<User>();
            return user;
        }

        static async Task<User> DeleteUserAsync(User user)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/UsersApi/{user.Id}", user);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated user from the response body.
            user = await response.Content.ReadAsAsync<User>();
            return user;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://localhost:7263/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {/*
                // Create a new user
                User user = new User
                {
                    Name = "Mario",
                    Surname = "Bros",
                    DateOfBirth = DateTime.Parse("2000-01-01"),
                    Login = "mb@gmail.com",
                    IsDeleted = false
                };

                var url = await CreateUserAsync(user);
                Console.WriteLine($"Created at {url}");

                // Get the user
                user = await GetUserAsync(url.PathAndQuery);
                ShowUser(user);

                // Update the user
                Console.WriteLine("Updating login...");
                user.Login = "mario@gmail.com";
                await UpdateUserAsync(user);

                // Get the updated user
                user = await GetUserAsync(url.PathAndQuery);
                ShowUser(user);

            */}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}