using System;
using System.Collections.Generic;
using System.Text;

namespace MobileBillGenerate
{
    public class CallRate
    {
        public double CallDuration(DateTime startDateTime, DateTime endDateTime)
        {
            if (endDateTime < startDateTime)
            {
                throw new ArgumentException("\n\nError:: Please check start and end call time!!");
            }
            TimeSpan callDuration = endDateTime.Subtract(startDateTime);
            var callDurationInSeconds = Convert.ToInt32(callDuration.TotalSeconds);
            return callDurationInSeconds;
        }

        public double CallRateGenetate(double callDuration, DateTime startDateTime, DateTime endDateTime)
        {
            var callStartTime = startDateTime - startDateTime.Date;
            var callEndTime = endDateTime - endDateTime.Date;

            var _sp = DateTime.Parse("9:00:00 am");
            var startPeak = _sp - _sp.Date;

            var _ep = DateTime.Parse("10:59:59 pm");
            var endPeak = _ep - _ep.Date;

            var callRate = CallRateByPeakOffPeak(callStartTime, callEndTime, 
                startPeak, endPeak, callDuration);

            return Math.Round(callRate, 1);
        }

        private double CallRateByPeakOffPeak(TimeSpan callStartTime, TimeSpan callEndTime, 
            TimeSpan startPeak, TimeSpan endPeak, double callDuration)
        {
            if (callStartTime >= startPeak && callEndTime <= endPeak)
            {
                //20 second pulse and each pulse rate 30 paisa
                var rate = 0.30;
                return RateGenerator(callDuration, rate);
            }
            else if (callStartTime >= startPeak && callEndTime >= endPeak)
            {
                //20 second pulse and each pulse rate 30 paisa
                //pulse overlap (peak to off-peak)
                var rate = 0.30;
                return RateGenerator(callDuration, rate);
            }
            else if (callStartTime <= startPeak && callEndTime >= startPeak)
            {
                //20 second pulse and each pulse rate 30 paisa
                //pulse overlap (off-peak to peak)
                var rate = 0.30;
                return RateGenerator(callDuration, rate);
            }
            else
            {
                //20 second pulse and each pulse rate 20 paisa
                var rate = 0.20;
                return RateGenerator(callDuration, rate);
            }
        }

        private double RateGenerator(double callDuration, double rate)
        {
            double pulse = callDuration / 20;
            var callRate = callDuration < 20 && callDuration > 0 ? rate : pulse * rate;
            return callRate;
        }

        public string CallRateInCurrency(double callRate)
        {
            if (callRate < 1)
            {
                //if call rate less than 1 taka
                var rate = $"{callRate.ToString(".00")} paisa";
                var callRateInPaisa = rate.Split(".");
                return callRateInPaisa[1];
            }
            else
            {
                //if call rate more than .99 Paisa
                var rate = $"{callRate.ToString(".00")}";
                var callRateInTakaPaisa = rate.Split(".");
                return $"{callRateInTakaPaisa[0]} Taka {callRateInTakaPaisa[1]} Paisa";
            }
        }

    }
}
