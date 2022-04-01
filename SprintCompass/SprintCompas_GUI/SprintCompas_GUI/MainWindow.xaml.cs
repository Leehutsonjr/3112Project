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
            //This is not final I wil lchange this based on how you set up the parser value entry
            //ParserJson parser = new ParserJson();
            //parser.toJSON(Project.Text, TeamName.Text, ProductName.Text, Convert.ToDateTime(StartDate.Text), int.Parse(HoursPerSP.Text), int.Parse(EstSP.Text), double.Parse(EstCost.Text));

            //Read Results to screen
            display.Text = "Sprint Created!";
        }

        private void AddTeamMember_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FindSprint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddSprintInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogSprintHours_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
