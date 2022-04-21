using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintCompass
{
    //Everything is public, so no need for anything besides default constructor. See sampleTask below
    public class Subtask
    {
        public string description;
        public int initialEstimate;
        public int hoursRemaining;
        public Dictionary<string, int> HoursBooked;

        public Subtask()
        {
            HoursBooked = new();
        }


        //Example only, don't use in production
        private static Subtask sampleTask()
        {
            Subtask sample = new()
            {
                description = "sample",
                initialEstimate = 12,
                hoursRemaining = 4,
                HoursBooked = new(),
            };
            sample.HoursBooked.Add("Lee", 2);
            return sample;
        }
    }
}
