using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintCompass;
namespace SprintCompass
{
    public class UserStory
    {
        //UserStory properties
        public string story { get; set; }
        public int priority { get; set; }
        public int relativeEstimate { get; set; } 
        public double estimatedCost { get; set; }

        public List<TeamMember> teamMembers { get; set; }
        public List<Subtask> subTasks { get; set; }
        //UserStory() Default constructor
        public UserStory()
        {

        }

        //UserStory() Constructor
        public UserStory(string story, int priority, int relativeEstimate, double estimatedCost, List<TeamMember> teamMembers)
        {
            this.story = story;
            this.priority = priority;
            this.relativeEstimate = relativeEstimate;
            this.estimatedCost = estimatedCost;
            this.teamMembers = teamMembers;
            subTasks = new();
        }
    }
}
