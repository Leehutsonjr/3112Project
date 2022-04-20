﻿using Parser;
using SprintCompas_GUI.Classes;
using SprintCompass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SprintCompas_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Project proj = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NPSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Project proj = new Project();
            ParserJson parser = new ParserJson();
            proj = parser.createProject(TeamName.Text, ProductName.Text, Convert.ToDateTime(StartDate.Text), int.Parse(HoursPerSP.Text), int.Parse(EstSP.Text), double.Parse(EstCost.Text));

            //Add team members 
            string[] members = TeamMember.Text.Split(',');
            foreach(var m in members)
            {
                proj.AddTeamMember(m);
            }

            parser.toJSON(Project.Text, proj);

            //Read Results to screen
            display.Text = "Sprint Created!\n";

            //read details to the screen
            proj = parser.fromJSON(Project.Text);

            display.Text += $"{Project.Text}\n";
            display.Text += $"{proj.ProductName}\n";
            display.Text += $"{proj.TeamName}\n";
            display.Text += $"{proj.EstProjectCost.ToString()}\n";
            foreach (var t in proj.TeamMembers)
            {
                display.Text += $"Team member: {t.name}\n";
            }
        }

        private void FindSprint_Click(object sender, RoutedEventArgs e)
        {
            //read details to the screen
            //proj = new Project();
            ParserJson parser = new ParserJson();
            proj = parser.fromJSON(ProjectName.Text);


            display2.Text = $"{ProjectName.Text}\n";

            display2.Text += $"{proj.ProductName}\n";
            display2.Text += $"{proj.TeamName}\n";
            display2.Text += $"{proj.EstProjectCost.ToString()}";
            display2.Text += $"\n\nTeam Members: \n";
            foreach (var t in proj.TeamMembers)
            {
                //Load team members to combobox
                TeamMemberList.Items.Add(t.name);
                //display team member to screen
                display2.Text += $"Team member: {t.name}\n";
            }

            //Print user stories to screen
            display2.Text += $"\nUser Stories: \n";
            int count = 1;
            foreach (var u in proj.UserStories)
            {
                display2.Text += $"#{count}: \n";
                display2.Text += $"User Story: {u.story}\n";
                display2.Text += $"Priority: {u.priority}\n";
                display2.Text += $"IRE: {u.relativeEstimate}\n";
                display2.Text += $"IRC: {u.estimatedCost}\n\n";
                count++;
                
            }
        }

        private void AddSprintInfo_Click(object sender, RoutedEventArgs e)
        {
            ParserJson parser = new ParserJson();
            Project temp = new();
            UserStory uS = new UserStory();
            uS.story = UserStory.Text;
            uS.priority = int.Parse(Priority.Text);
            uS.relativeEstimate = int.Parse(IrE.Text);
            uS.estimatedCost = double.Parse(IrC.Text);
            uS.teamMembers = proj.TeamMembers;

            //Save to Project Object
            proj.UserStories.Add(uS);

            //Save user stories to Json
            parser.toJSON(ProjectName.Text, proj);

            //Read file contents to screen
            temp = parser.fromJSON(ProjectName.Text);

            //TODO: Fix format of screen reading
            display2.Text += $"User Story: {temp.UserStories[0].story}\n";
            display2.Text += $"Priority: {temp.UserStories[0].priority}\n"; 
            display2.Text += $"IRE: {temp.UserStories[0].relativeEstimate}\n"; 
            display2.Text += $"IRC: {temp.UserStories[0].estimatedCost}\n"; 

        }

        private void LogSprintHours_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserStoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FindSprint2_Click(object sender, RoutedEventArgs e)
        {
            //read details to the screen
            ParserJson parser = new ParserJson();
            proj = parser.fromJSON(ProjectName2.Text);


            display3.Text = $"{ProjectName2.Text}\n";

            display3.Text += $"{proj.ProductName}\n";
            display3.Text += $"{proj.TeamName}\n";
            display3.Text += $"{proj.EstProjectCost.ToString()}";
            display3.Text += $"\n\nTeam Members: \n";
            foreach (var t in proj.TeamMembers)
            {
                //Load team members to combobox
                TeamMemberList.Items.Add(t.name);
                //display team member to screen
                display3.Text += $"Team member: {t.name}\n";
            }

            //Populate combobox with sprints
            foreach(var s in proj.Sprints)
            {
                SprintBox.Items.Add(s.sprintName);
            }

            //Populate combo box with user stories
            foreach(var u in proj.UserStories)
            {
                UserStoryList.Items.Add(u.story);
            }

            if(proj.Sprints != null)
            {
                //Print Sprint and user stories
                foreach (var s in proj.Sprints)
                {
                    display3.Text += s.sprintName + "\n";
                    foreach (var u in s.userStories)
                    {
                        display3.Text += u.story + "\n";
                        
                    }
                }
            }
        }

        private void AddUserStoryToSprint_Click(object sender, RoutedEventArgs e)
        {
            ParserJson parser = new ParserJson();

            //If sprint doesnt exists, add it first
            if (proj.Sprints.Count < SprintBox.SelectedIndex)
            {
                //Save sprint to Json
                parser.toJSON(ProjectName2.Text, proj);
            }

            //If the sprint is there, save the user story to it
            if(proj.Sprints[SprintBox.SelectedIndex] != null)
            {
                proj.Sprints[SprintBox.SelectedIndex].userStories.Add(proj.UserStories[UserStoryList.SelectedIndex]);
                //Save user stories to Json
                parser.toJSON(ProjectName2.Text, proj);
            }

            //read details to the screen
            proj = parser.fromJSON(ProjectName2.Text);

            display3.Text = $"{ProjectName2.Text}\n";

            display3.Text += $"{proj.ProductName}\n";
            display3.Text += $"{proj.TeamName}\n";
            display3.Text += $"{proj.EstProjectCost.ToString()}";
            display3.Text += $"\n\nTeam Members: \n";
            foreach (var t in proj.TeamMembers)
            {
                //Load team members to combobox
                TeamMemberList.Items.Add(t.name);
                //display team member to screen
                display3.Text += $"Team member: {t.name}\n";
            }

            //Populate combobox with sprints
            foreach (var s in proj.Sprints)
            {
                SprintBox.Items.Add(s.sprintName);
            }

            //Populate combo box with user stories
            foreach (var u in proj.UserStories)
            {
                UserStoryList.Items.Add(u.story);
            }

            //Print Sprint and user stories
            foreach(var s in proj.Sprints)
            {
                display3.Text += s.sprintName + "\n";
                foreach(var u in s.userStories)
                {
                    display3.Text += u.story + "\n";
                }
            }

        }

        private void AddSprint_Click(object sender, RoutedEventArgs e)
        {
            proj.AddEmptySprint(proj);

            //Clear combo box and populate with sprints
            SprintBox.Items.Clear();
            foreach (var s in proj.Sprints)
            {
                SprintBox.Items.Add(s.sprintName);
            }
        }

        private void SaveToPdf_Click(object sender, RoutedEventArgs e)
        {
            PDFCreator pdf = new PDFCreator();
            pdf.GenerateSprintRetrospective(proj.Sprints[0]);
        }
    }
}
