using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            TimeSpan peakHourStart = new TimeSpan(9, 0, 0); // 9.00.00 am
            TimeSpan peakHourEnd = new TimeSpan(22, 59, 59); //10.59.59 pm

            TimeSpan offHourStart1 = new TimeSpan(0, 0, 0); // 12.00.00 am
            TimeSpan offHourEnd1 = new TimeSpan(8, 59, 59); //8.59.59 am
            TimeSpan offHourStart2 = new TimeSpan(23, 0, 0); // 11.00.00 pm
            TimeSpan offHourEnd2 = new TimeSpan(23, 59, 59); //11.59.59 pm

            double peakHourRate = 0.30;
            double offPeakHourRate = 0.20;
            double totalBill = 0.00;

            try
            {
                Console.Write("Enter Start Time (2022-02-25 10:10:25 AM): ");
                DateTime startTime = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter End Time (2022-02-25 10:10:25 PM): ");
                DateTime endTime = DateTime.Parse(Console.ReadLine());
                
                if (endTime < startTime)
                {
                    Console.WriteLine("Please insert valid time. End time can't be previous time than the start time ");
                }

                TimeSpan difference = endTime.Subtract(startTime);
                double totalSeconds = difference.TotalSeconds;
               
                int upToCount = (int)(totalSeconds / 20);

                DateTime calculativeStartTime = startTime;
                double timeToAdd = 20;
                for (int i = 0; i <= upToCount; i++)
                {
                    DateTime calculativeEndTime;
                    if (i == upToCount)
                    {
                        timeToAdd = totalSeconds - (upToCount * 20);
                    }

                    calculativeEndTime = calculativeStartTime.AddSeconds(timeToAdd);

                    TimeSpan onlyTimeStart = calculativeStartTime.TimeOfDay;
                    TimeSpan onlyTimeEnd = calculativeEndTime.TimeOfDay;
                    double billToAdd = 0.00;


                    if ((onlyTimeStart > peakHourStart && onlyTimeStart < peakHourEnd) ||
                        (onlyTimeEnd > peakHourStart && onlyTimeEnd < peakHourEnd)
                        )
                    {
                        billToAdd = peakHourRate;
                    }
                    else
                    {
                        billToAdd = offPeakHourRate;
                    }


                    totalBill += billToAdd;
                    Console.WriteLine(calculativeStartTime + " + " + timeToAdd + " seconds (" + calculativeEndTime + ") = " + (int)(billToAdd * 100) + " paisa");
                    calculativeStartTime = calculativeEndTime;

                }


                Console.WriteLine("Total bill: " + Math.Round(totalBill, 2)  + " Taka");

            }
            catch (Exception e) {
                Console.WriteLine("Invalid Time Input Format. Please Enter Time as -'2022-02-25 10:10:25 AM'");
            }
           
          
            
            
        }
    }
}
