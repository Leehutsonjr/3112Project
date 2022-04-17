using Parser;
using System;
using System.Collections.Generic;

namespace SprintCompass
{
    public class Project
    {
        public string TeamName { get; set; }
        public string ProductName { get; set; }
        public DateTime StartDate { get; set; }
        public int HoursToStory { get; set; }
        public int EstStoryPts { get; set; }
        public double EstProjectCost { get; set; } //in Canadian Dollars (CAD)
        public List<TeamMember> TeamMembers { get; set; }
        public List<UserStory> UserStories { get; set; }

        public Project()
        {

        }

        public Project(string team, string product, DateTime start, int hours, int points, double dollars)
        {
            TeamName = team;
            ProductName = product;
            StartDate = start;
            HoursToStory = hours;
            EstStoryPts = points;
            EstProjectCost = dollars;
            TeamMembers = new();
            UserStories = new();
        }

        public void AddTeamMember(string name)
        {
            TeamMembers.Add(new TeamMember(name));
        }
    }
}
