using Parser;
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
        public string buttonName;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ButtonMessage(TextBlock display, string button)
        {
            //Reset Display
            display.Text = "";

            switch(button)
            {
                case "New":
                    display.Text = $"Project Created!\n\n";
                    break;
                case "Find":
                    display.Text = $"Project Located!\n\n";
                    break;
                case "SprintAdd":
                    display.Text = $"The User Story Has Been Added!\n\n";
                    break;
                case "SprintFind":
                    display.Text = $"Project Located!\nBacklog is ready to be addressed...!\n\n";
                    break;
                case "AddUser":
                    display.Text = $"The User Story has Been Added to The Sprint!\n\n";
                    break;
                case "AddSub":
                    display.Text = $"The Sub Task has Been Added to The User Story!\n\n";
                    break;
                case "AddTMToSub":
                    display.Text = $"The Team Member has Been Added to The Sub Task!\n\n";
                    break;
                case "FindReport":
                    display.Text = $"Project Located!\n\n";
                    break;
            }
        }

        public void InputClear()
        {
            ProjectName.Text = "Project Name";
            TeamName.Text = "Team Name";
            ProductName.Text = "Product Name";
            StartDate.Text = "Start Date";
            HoursPerSP.Text = "Hours Per Story Point";
            EstSP.Text = "Estimated Story Points";
            EstCost.Text = "Team Member (Comma separated)";
        }


        public void Print(TextBlock display, TextBox projectName, Project proj)
        {
            ButtonMessage(display, buttonName);

            //Display project name
            display.Text += $"\tProject Name: {projectName.Text}\n";

            if(buttonName != "SprintFind" && buttonName != "AddUser" && buttonName != "AddSub" && buttonName != "SprintAdd")
            {
                //Display main project info
                display.Text += $"\tTeam Name: {proj.TeamName}\n";
                display.Text += $"\tProduct Name: {proj.ProductName}\n";
                display.Text += $"\tDate: {proj.StartDate}\n";
                display.Text += $"\tStory Point: {proj.HoursToStory}\n";
                display.Text += $"\tEstimated Story Points: {proj.EstStoryPts}\n";
                display.Text += $"\tEstimated Cost: {proj.EstProjectCost.ToString()}\n";

                display.Text += $"Team Members: \n";
                //TeamMembers
                foreach (var t in proj.TeamMembers)
                {
                    //Load team members to combobox
                    //TeamMemberList.Items.Add(t.name);
                    //display team member to screen
                    display.Text += $"\t{t.name}\n";
                }
            }

            //Print sprints to screen
            display.Text += $"Sprints: \n";
            //Check if there are sprints
            if (proj.Sprints != null)
            {
                //Print Sprint and user stories
                foreach (var s in proj.Sprints)
                {
                    display.Text += $"{s.sprintName}\n";

                    //Check if there are user stories
                    if (s.userStories.Count > 0)
                    {
                        foreach (var u in s.userStories)
                        {
                            display.Text += $"\tUser Story:\t{u.story}\n";

                            //Print subtasks to screen
                            display.Text += $"Sub Tasks: \n";

                            if (u.subTasks.Count > 0)
                            {
                                //Print subtasks
                                foreach (var st in u.subTasks)
                                {
                                    display.Text += $"\tDescription: {st.description}\n";
                                    display.Text += $"\t\tEstimate Hours: {st.initialEstimate}\n";
                                    display.Text += $"\t\tHours remaining: {st.hoursRemaining}\n";

                                    //Print the team member
                                    foreach(var h in st.HoursBooked)
                                    {
                                        display.Text += $"\t\tTeam Member: {h.Key}\n";
                                    }
                                    
                                }
                            }
                            else
                            {
                                display.Text += $"\tCurrently, there are no sub tasks.\n";
                            }
                            
                        }
                    }
                    else
                    {
                        display.Text += $"\tCurrently, there are no user stories.\n";
                    }
                }
            }

            display.Text += $"\nList of all User Stories: \n";
            //User Stories

            //Check for user stories
            if (proj.UserStories.Count > 0)
            {
                int count = 1;

                foreach (var u in proj.UserStories)
                {
                    display.Text += $"#{count}: \n";
                    display.Text += $"\tUser Story: {u.story}\n";
                    display.Text += $"\tPriority: {u.priority}\n";
                    display.Text += $"\tIRE: {u.relativeEstimate}\n";
                    display.Text += $"\tIRC: {u.estimatedCost}\n\n";
                    count++;

                    //Print subtasks to screen
                    display.Text += $"\nSub Tasks: \n";
                    //Print Subtasks
                    if (u.subTasks.Count > 0)
                    {

                        foreach (var st in u.subTasks)
                        {
                            display.Text += $"\tDescription: {st.description}\n";
                            display.Text += $"\t\tEstimate Hours: {st.initialEstimate}\n";
                            display.Text += $"\t\tHours remaining: {st.hoursRemaining}\n";

                            //Print the team member
                            foreach (var h in st.HoursBooked)
                            {
                                display.Text += $"\t\tTeam Member: {h.Key}\n";
                            }
                        }
                    }
                    else
                    {
                        display.Text += $"\tCurrently, there are no sub tasks.\n";
                    }
                }
            }
            else
            {
                display.Text += $"\tCurrently, there are no user stories.\n";
            }
        }

        private void NPSubmit_Click(object sender, RoutedEventArgs e)
        {
            buttonName = "New";

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

            Print(display, Project, proj);
            var temp = e.RoutedEvent.Name;
        }

        private void FindSprint_Click(object sender, RoutedEventArgs e)
        {
            buttonName = "Find";
            ParserJson parser = new ParserJson();
            proj = parser.fromJSON(ProjectName.Text);

            //Print results to screen
            Print(display2, ProjectName, proj);

            //Populate combo box with user stories
            foreach (var u in proj.UserStories)
            {
                UserStoryList2.Items.Add(u.story);
            }
        }

        private void AddSprintInfo_Click(object sender, RoutedEventArgs e)
        {
            buttonName = "SprintAdd";

            ParserJson parser = new ParserJson();
            Project temp = new();
            UserStory uS = new UserStory();
            uS.subTasks = new();
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

            Print(display2, ProjectName, temp);

            //Clear ComboBoxes
            UserStoryList2.Items.Clear();

            //Populate combo box with user stories
            foreach (var u in proj.UserStories)
            {
                UserStoryList2.Items.Add(u.story);
            }

        }

        private void LogSprintHours_Click(object sender, RoutedEventArgs e)
        {
            buttonName = "AddTMToSub";

            ParserJson parser = new ParserJson();

            var sprint = proj.Sprints[SprintBox.SelectedIndex];
            var userStory = sprint.userStories[UserStoryList.SelectedIndex];
            var subTask = userStory.subTasks[SubTasks.SelectedIndex];
            var teamMember = TeamMemberList.SelectedItem.ToString();
            var hoursWorked = int.Parse(HoursWorked.Text);
            var hoursRemaining = int.Parse(Reestimate.Text);
            //If the sprint is there, save the user story to it
            if (subTask != null)
            {
                userStory.teamMembers[TeamMemberList.SelectedIndex].hoursWorked += hoursWorked;
                subTask.hoursRemaining = hoursRemaining;
                subTask.HoursBooked.Add(teamMember, hoursWorked);
                //Save user stories to Json
                parser.toJSON(ProjectName2.Text, proj);
            }

            //read details to the screen
            proj = parser.fromJSON(ProjectName2.Text);

            Print(display3, ProjectName2, proj);

            //Clear ComboBoxes
            SprintBox.Items.Clear();
            UserStoryList.Items.Clear();

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
        }

        private void UserStoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FindSprint2_Click(object sender, RoutedEventArgs e)
        {
            buttonName = "SprintFind";

            //read details to the screen
            ParserJson parser = new ParserJson();
            proj = parser.fromJSON(ProjectName2.Text);

            Print(display3, ProjectName2, proj);

            //Clear ComboBoxes
            SprintBox.Items.Clear();
            UserStoryList.Items.Clear();

            //Populate combobox with sprints
            foreach (var s in proj.Sprints)
            {
                SprintBox.Items.Add(s.sprintName);
            }

            //Populate combo box with user stories
            foreach(var u in proj.UserStories)
            {
                UserStoryList.Items.Add(u.story);
            }

            //Populate combobox with teammembers
            foreach (var t in proj.TeamMembers)
            {
                TeamMemberList.Items.Add(t.name);
            }
        }

        private void AddUserStoryToSprint_Click(object sender, RoutedEventArgs e)
        {
            buttonName = "AddUser";

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

            Print(display3, ProjectName2, proj);

            //Clear ComboBoxes
            SprintBox.Items.Clear();
            UserStoryList.Items.Clear();

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
        }

        private void AddSprint_Click(object sender, RoutedEventArgs e)
        {
            buttonName = "addSprint";

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
            buttonName = "pdfSave";

            PDFCreator pdf = new PDFCreator();
            pdf.GenerateSprintRetrospective(proj.Sprints[0]);
        }

        private void AddSubtaskInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddSubTaskToUserStory_Click(object sender, RoutedEventArgs e)
        {
            buttonName = "AddSub";

            ParserJson parser = new ParserJson();

            Subtask st = new Subtask();
            st.description = Description.Text;
            st.initialEstimate = int.Parse(InitialEstimate.Text);
            //st.hoursRemaining = int.Parse(HoursRemaining.Text);
       
            //Save subtask to user story
            if (proj.UserStories[UserStoryList2.SelectedIndex] != null)
            {
                proj.UserStories[UserStoryList2.SelectedIndex].subTasks.Add(st);
                //Save user stories to Json
                //parser.toJSON(ProjectName.Text, proj);
            }

            //Save user stories to Json
            parser.toJSON(ProjectName.Text, proj);

            //read details to the screen
            proj = parser.fromJSON(ProjectName.Text);

            Print(display2, ProjectName, proj);

            //Clear ComboBoxes
            UserStoryList2.Items.Clear();

            //Populate combo box with user stories
            foreach (var u in proj.UserStories)
            {
                UserStoryList2.Items.Add(u.story);
            }

        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            buttonName = "report";

            PDFCreator pdf = new PDFCreator();
            pdf.GenerateTeamSummary(proj.Sprints[0]);
        }

        private void LoadSubtasks_Click(object sender, RoutedEventArgs e)
        {
            //Clear ComboBoxes
            SubTasks.Items.Clear();
            //Populate combo box with sub tasks
            foreach (var u in proj.UserStories[UserStoryList.SelectedIndex].subTasks)
            {
                SubTasks.Items.Add(u.description);
            }
        }

        private void FindSprint3_Click(object sender, RoutedEventArgs e)
        {
            buttonName = "FindReport";
            ParserJson parser = new ParserJson();
            proj = parser.fromJSON(ProjectName3.Text);

            //Print results to screen
            Print(display4, ProjectName3, proj);
        }
    }
}
