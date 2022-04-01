using System;
using System.Collections.Generic;

namespace SprintCompass
{
    public class Project
    {
        private string TeamName { get; }
        private string ProductName { get; }
        private DateTime StartDate { get; }
        private int HoursToStory { get; }
        private int EstStoryPts { get; }
        private double EstProjectCost { get; } //in Canadian Dollars (CAD)
        private List<TeamMember> TeamMembers {get;}

        public Project(string team, string product, DateTime start, int hours, int points, double dollars)
        {
            TeamName = team;
            ProductName = product;
            StartDate = start;
            HoursToStory = hours;
            EstStoryPts = points;
            EstProjectCost = dollars;
            TeamMembers = new();
        }

        public void AddTeamMember(string name)
        {
            TeamMembers.Add(new TeamMember(name));
        }
    }
}
