using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser//CHANGE NAMESPACE TO WHATEVER THE PROJECT IS!!!
{
    public class UserStory
    {
        //UserStory properties
        public string story { get; set; }
        public int priority { get; set; }
        public int relativeEstimate { get; set; } 
        public double estimatedCost { get; set; }

        //UserStory() Default constructor
        public UserStory()
        {

        }

        //UserStory() Constructor
        public UserStory(string story, int priority, int relativeEstimate, double estimatedCost)
        {
            this.story = story;
            this.priority = priority;
            this.relativeEstimate = relativeEstimate;
            this.estimatedCost = estimatedCost;
        }
    }
}
