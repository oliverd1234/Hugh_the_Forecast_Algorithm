using Forecast_Algorithm.Library;
using System;
using System.Collections.Generic;
using System.Timers;

namespace Forecast_Algorithm
{
    class Program
    {
        public static List<System.Timers.Timer> aTimer = new List<Timer>();

        public static void Main(string[] args)
        {
            //#region Test_Self_Remove
            //List<Batch> B_List = new List<Batch>();
            //var item1 = new Batch(ref B_List)
            //{
            //    Batchname = ".net"
            //};

            //var item2 = new Batch(ref B_List)
            //{
            //    Batchname = "Java"
            //};
            //B_List.Add(item1);
            //B_List.Add(item2);

            //foreach(Batch item in B_List)
            //{
            //    Console.WriteLine(item.Batchname);

            //}
            //B_List[0].removeSelf();
            //foreach (Batch item in B_List)
            //{
            //    Console.WriteLine(item.Batchname);

            //}
            //#endregion

            //List<Batch> timed_Batches = new List<Batch>();

            //timed_Batches.Add(new Batch(ref timed_Batches,"BA"));
            //timed_Batches.Add(new Batch(ref timed_Batches, "DB"));
            //Console.ReadLine();




            ///add three; enter an input befores the third one clocks out
            ///
        
         Worksite Reston = new Worksite(2009); // *L*
            Reston.Add(new Batch(ref Reston, "BA",3000, 20) );
            Reston.Add(new Batch(ref Reston, "Java", 6000, 18));
            Reston.Add(new Batch(ref Reston, ".Net", 9000, 25));

            //Console.ReadLine();
            Reston.Add(new Batch(ref Reston, "Appian", 3000,30));
            //Console.ReadLine();
            string peek = "0";
            while(peek.Equals("0"))
            {
                foreach(Batch item in Reston)
                {
                    Console.WriteLine($"{item.Batchname} and {Reston.get_Agg()}");
                    
                }
                peek = Console.ReadLine();
                Reston.Add(new Batch(ref Reston, "Appian", 3000, 30));
                var hi = Reston[7];
            }
        }

        //private static void SetTimer()
        //{
        //    // Create a timer with a two second interval.
        //    aTimer.Add(new System.Timers.Timer(2000));
        //    aTimer.Add(new System.Timers.Timer(4000));
        //    // Hook up the Elapsed event for the timer. 
        //    aTimer[0].Elapsed += OnTimedEvent;
        //    aTimer[0].AutoReset = true;
        //    aTimer[0].Enabled = true;

        //    aTimer[1].Elapsed += OnTimedEvent;
        //    aTimer[1].AutoReset = true;
        //    aTimer[1].Enabled = true;
        //}

        //private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        //{
        //    Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
        //                      e.SignalTime);

        //}
    }
}
