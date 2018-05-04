using System;
using lab2.Enumerations;
using lab2.Persons;

namespace lab2
{
    internal static class Program
    {
        public static void Main()
        {
            var swimmer = new Swimmer(90, "Swimming", 60);
            var swimmer1 = new Swimmer(80, "Swimming", 70);
            swimmer.ActionPerformed += swimmer1.CheckWorking;
            swimmer1.ActionPerformed += swimmer.CheckWorking;
            
            while (true)
            {
                try
                {
                    Console.WriteLine("Please, enter the time during action will be performing:");
                    var time = int.Parse(Console.ReadLine());
                    Console.ReadKey();
                    Console.WriteLine("Please, enter an action you want to perform:");
                    var action = Console.ReadLine();
                    Console.ReadKey();
                    switch (action)
                    {
                        case "Swim":
                            swimmer.DoAction(time, EAction.Swim);
                            break;
                        case "Dive":
                            swimmer.DoAction(time, EAction.Dive);
                            break;
                        case "Emerge":
                            swimmer.DoAction(time, EAction.Emerge);
                            break;
                        case "Stay afloat":
                            swimmer.DoAction(time, EAction.StayAfloat);
                            break;
                        case "Exit":
                            return;
                        default:
                            Console.WriteLine("There is no such command!");
                            break;      
                    } 
                }

                catch (InvalidSwimSpeedExc e)
                {
                    Console.WriteLine("Custom exception:" + e);
                    throw;
                }
                
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}