using System;

namespace MobileBillGenerate
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var start = "2019-08-31 08:59:13 am";
                Console.Write("Call Start Time: ");
                var start = Console.ReadLine();

                //var start = "2019-09-30 09:00:16 am";
                var callStartDateTime = DateTime.Parse(start);

                //var end = "2019-08-31 09:00:39 am";
                //var end = "2019-09-30 09:00:36 am";
                Console.Write("Call End Time: ");
                var end = Console.ReadLine();
                var callEndDateTime = DateTime.Parse(end);



                CallRate callRate = new CallRate();

                var totalCallDuration = callRate.CallDuration(callStartDateTime, callEndDateTime);
                var calculateCallRate = callRate.CallRateGenetate(totalCallDuration, callStartDateTime, callEndDateTime);
                var callRateInCurrency = callRate.CallRateInCurrency(calculateCallRate);

                Console.WriteLine($"call Start at {callStartDateTime}");
                Console.WriteLine($"Call End at {callEndDateTime}");
                Console.WriteLine($"Call Duration {totalCallDuration} second");
                Console.WriteLine($"Call Rate {calculateCallRate} taka");
                Console.WriteLine();
                Console.WriteLine("................... Final Output ...................");
                Console.WriteLine();

                Console.WriteLine($"{callStartDateTime} + {totalCallDuration} Second ({callEndDateTime}) = {callRateInCurrency}");
                
                Console.WriteLine();
                Console.WriteLine(".....................................................");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }
    }
}
