using Parser;
using SprintCompas_GUI;
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
        public List<Sprint> Sprints { get; set; }

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
            Sprints = new();

            //Add 12 Sprints to the project
            Sprint sprint = new Sprint();
            sprint.sprintName = "Sprint #1";
            Sprints.Add(sprint);
            
        }

        public void AddTeamMember(string name)
        {
            TeamMembers.Add(new TeamMember(name));
        }

        public void AddEmptySprint(Project proj)
        {
            //Find the last sprint number
            var temp = proj.Sprints.Count;
            Sprint sprint = new Sprint();
            sprint.sprintName = $"Sprint #{(temp + 1)}";
            Sprints.Add(sprint);
            
        }
    }
}
