using adventofcode2020.Puzzles.Day1;
using adventofcode2020.Puzzles.Day10;
using adventofcode2020.Puzzles.Day11;
using adventofcode2020.Puzzles.Day12;
using adventofcode2020.Puzzles.Day13;
using adventofcode2020.Puzzles.Day14;
using adventofcode2020.Puzzles.Day15;
using adventofcode2020.Puzzles.Day16;
using adventofcode2020.Puzzles.Day17;
using adventofcode2020.Puzzles.Day2;
using adventofcode2020.Puzzles.Day3;
using adventofcode2020.Puzzles.Day4;
using adventofcode2020.Puzzles.Day5;
using adventofcode2020.Puzzles.Day6;
using adventofcode2020.Puzzles.Day7;
using adventofcode2020.Puzzles.Day8;
using adventofcode2020.Puzzles.Day9;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace adventofcode2020
{
    class Program
    {
        static Task Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            var day = 16;
            switch(day)
            {
                case 1:
                    var svc = host.Services.GetService<IExpensesService>();
                    svc.Execute();
                    break;
                case 2:
                    var svc2 = host.Services.GetService<IDay2Service>();
                    svc2.Execute();
                    break;
                case 3:
                    var svc3 = host.Services.GetService<IDay3Service>();
                    svc3.Execute();
                    break;
                case 4:
                    var svc4 = host.Services.GetService<IDay4Service>();
                    svc4.Execute();
                    break;
                case 5:
                    var svc5 = host.Services.GetService<IDay5Service>();
                    svc5.Execute();
                    break;
                case 6:
                    var svc6 = host.Services.GetService<IDay6Service>();
                    svc6.Execute();
                    break;
                case 7:
                    var svc7 = host.Services.GetService<IDay7Service>();
                    svc7.Execute();
                    break;
                case 8:
                    var svc8 = host.Services.GetService<IDay8Service>();
                    svc8.Execute();
                    break;
                case 9:
                    var svc9 = host.Services.GetService<IDay9Service>();
                    svc9.Execute();
                    break;
                case 10:
                    var svc10 = host.Services.GetService<IDay10Service>();
                    svc10.Execute();
                    break;
                case 11:
                    var svc11 = host.Services.GetService<IDay11Service>();
                    svc11.Execute();
                    break;
                case 12:
                    var svc12 = host.Services.GetService<IDay12Service>();
                    svc12.Execute();
                    break;
                case 13:
                    var svc13 = host.Services.GetService<IDay13Service>();
                    svc13.Execute();
                    break;
                case 14:
                    var svc14 = host.Services.GetService<IDay14Service>();
                    svc14.Execute();
                    break;
                case 15:
                    var svc15 = host.Services.GetService<IDay15Service>();
                    svc15.Execute();
                    break;
                case 16:
                    var svc16 = host.Services.GetService<IDay16Service>();
                    svc16.Execute();
                    break;
                case 17:
                    var svc17 = host.Services.GetService<IDay17Service>();
                    svc17.Execute();
                    break;
            }

            return host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
                   Host.CreateDefaultBuilder(args)
                       .ConfigureServices((_, services) =>
                        {
                            services.AddTransient<IFileDataReader, FileDataReader>();
                            services.AddTransient<IExpensesService, ExpensesService>();
                            services.AddTransient<IExpensesEngine, ExpensesEngine2>();
                            services.AddTransient<IDay2Service, Day2Service>();
                            services.AddTransient<IDay2Engine, Day2Engine>();
                            services.AddTransient<IDay3Service, Day3Service>();
                            services.AddTransient<IDay3Engine, Day3Engine>();
                            services.AddTransient<IDay4Service, Day4Service>();
                            services.AddTransient<IDay4Engine, Day4Engine>();
                            services.AddTransient<IDay5Service, Day5Service>();
                            services.AddTransient<IDay5Engine, Day5Engine>();
                            services.AddTransient<IDay6Service, Day6Service>();
                            services.AddTransient<IDay6Engine, Day6Engine>();
                            services.AddTransient<IDay7Service, Day7Service>();
                            services.AddTransient<IDay7Engine, Day7Engine>();
                            services.AddTransient<IDay8Service, Day8Service>();
                            services.AddTransient<IDay8Engine, Day8Engine>();
                            services.AddTransient<IDay9Service, Day9Service>();
                            services.AddTransient<IDay9Engine, Day9Engine>();
                            services.AddTransient<IDay10Service, Day10Service>();
                            services.AddTransient<IDay10Engine, Day10Engine>();
                            services.AddTransient<IDay11Service, Day11Service>();
                            services.AddTransient<IDay11Engine, Day11Engine>();
                            services.AddTransient<IDay12Service, Day12Service>();
                            services.AddTransient<IDay12Engine, Day12Engine>();
                            services.AddTransient<IDay13Service, Day13Service>();
                            services.AddTransient<IDay13Engine, Day13Engine>();
                            services.AddTransient<IDay14Service, Day14Service>();
                            services.AddTransient<IDay14Engine, Day14Engine>();
                            services.AddTransient<IDay15Service, Day15Service>();
                            services.AddTransient<IDay15Engine, Day15Engine>();
                            services.AddTransient<IDay16Service, Day16Service>();
                            services.AddTransient<IDay16Engine, Day16Engine>();
                            services.AddTransient<IDay17Service, Day17Service>();
                            services.AddTransient<IDay17Engine, Day17Engine>();
                        });
    }
}
