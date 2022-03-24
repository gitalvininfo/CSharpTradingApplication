// See https://aka.ms/new-console-template for more information
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;

class Program
{
    static void Main(string[] args)
    {
        IDataService<User> userService = new GenericDataService<User>(new SimpleTraderDbContextFactory());

        User user = userService.Update(20, new User() { Username = "Tenesse" }).Result;

        Console.WriteLine(user.Username);

        //userService.Create(new User
        //{
        //    Email = "testing@gmail.com",
        //    Username = "Alvin",
        //    Password = "123",
        //    DateJoined = new DateTime(2022, 3, 1, 8, 30, 52)
        //}).Wait();


        Console.WriteLine();
    }
}