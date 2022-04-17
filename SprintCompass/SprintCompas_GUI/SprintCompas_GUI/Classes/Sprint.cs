using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintCompass;
namespace SprintCompas_GUI
{
    public class Sprint
    {
        //sprint properties
        public string sprintName { get; set; }
        public int totalHours { get; set; }
        public List<UserStory> userStories { get; set; }

        //Sprint() default constructor
        public Sprint()
        {

        }

        //Sprint() Constructor 3-arg
        public Sprint(string sprintName, List<UserStory> userStories, int totalHours)
        {
            this.sprintName = sprintName;
            this.userStories = userStories;
            this.totalHours = totalHours;
        }
    }
}
