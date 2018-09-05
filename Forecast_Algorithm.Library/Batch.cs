using System;
using System.Collections.Generic;
using System.Timers;

namespace Forecast_Algorithm.Library
{
    public class Batch
    {
        public delegate void ListRefGiver(List<Batch> BatchList);
        public Timer aTimer ;
        
        public List<Batch> ListRef { get; set; }
        public Worksite Worksite_Ref { get; set; }
        public Batch(ref List<Batch> BatchList)
        {
            ListRef = BatchList;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true; 
        }
        public Batch(ref List<Batch> BatchList, string batchname)
        {
            Batchname = batchname;
            ListRef = BatchList;
            aTimer = new System.Timers.Timer(3000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public Batch ( ref Worksite BatchList, string batchname, int e_time, int batchsize) //*L*
        {
            Batchname = batchname;
            Worksite_Ref = BatchList;
            Batchsize = batchsize;
            aTimer = new System.Timers.Timer(e_time);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public void removeSelf()
        {

            //ListRef.Remove(this);
            Worksite_Ref.Remove(this);
            Console.WriteLine("remove Succesful");
        }
        public string Batchname { get; set; }
        public int Batchsize { get; set; }
        public DateTime timer { get; set; }
        public DateTime allottedTime { get; set; }




        //    Console.WriteLine("\nPress the Enter key to exit the application...\n");
        //    Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
        //    Console.ReadLine();
        //    foreach (System.Timers.Timer item in aTimer)
        //    {
        //        item.Stop();
        //        item.Dispose();
        //    }
        //Console.WriteLine("Terminating the application...");
        

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //foreach (Batch item in Worksite_Ref) // ListRef / Worksite Ref
            //{
            //    Console.WriteLine(item.Batchname);

            //}
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
            Console.WriteLine($"{source.ToString()}");
            this.removeSelf();
            aTimer.Stop();
            aTimer.Dispose();
            //foreach (Batch item in Worksite_Ref)
            //{
            //    Console.WriteLine(item.Batchname);

            //}
        }

    }
    

}