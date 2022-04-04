using Parser;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NPSubmit_Click(object sender, RoutedEventArgs e)
        {
            Project proj = new Project();
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
            Project proj = new Project();
            ParserJson parser = new ParserJson();
            proj = parser.fromJSON(ProjectName.Text);


            display2.Text = $"{ProjectName.Text}\n";

            display2.Text += $"{proj.ProductName}\n";
            display2.Text += $"{proj.TeamName}\n";
            display2.Text += $"{proj.EstProjectCost.ToString()}\n";
            foreach (var t in proj.TeamMembers)
            {
                //Load team members to combobox
                TeamMemberList.Items.Add(t.name);
                //display team member to screen
                display2.Text += $"Team member: {t.name}\n";
            }
        }

        private void AddSprintInfo_Click(object sender, RoutedEventArgs e)
        {
            UserStory uS = new UserStory();
            uS.story = UserStory.Text;
            uS.priority = int.Parse(Priority.Text);
            uS.relativeEstimate = int.Parse(IrE.Text);
            uS.estimatedCost = double.Parse(IrC.Text);

            //TODO: Add user story to project

            //TODO: Read User stories from project to screen

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
            Project proj = new Project();
            ParserJson parser = new ParserJson();
            proj = parser.fromJSON(ProjectName2.Text);


            display3.Text = $"{ProjectName2.Text}\n";

            display3.Text += $"{proj.ProductName}\n";
            display3.Text += $"{proj.TeamName}\n";
            display3.Text += $"{proj.EstProjectCost.ToString()}\n";
            foreach (var t in proj.TeamMembers)
            {
                //Load team members to combobox
                TeamMemberList.Items.Add(t.name);
                //display team member to screen
                display3.Text += $"Team member: {t.name}\n";
            }
        }
    }
}
