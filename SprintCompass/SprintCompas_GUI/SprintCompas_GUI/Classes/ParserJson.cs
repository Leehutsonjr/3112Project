using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using SprintCompass;

namespace Parser
{
    public class ParserJson
    {
        //Converts .Net Object to JSON
        //LEE NOTES: I added these values to the method because Im not sure how I am supposed to get these values into the project.  Yani, can you set this 
        //up the way you'd like (not hard coded) then I can feed the values to it
        public void toJSON(string filename, string team, string product, DateTime start, int hours, int points, double dollars)
        {
            Project proj = new Project(team, product, start, hours, points, dollars);
            proj = createProject();

           

            File.WriteAllText(filename, JsonConvert.SerializeObject(proj));

            using (StreamWriter file = File.CreateText(filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, proj);
            }


        }

        //Converts JSON to .Net object
        public void fromJSON(string filename)
        {
            
            
            if (File.Exists(filename))
            {
                string justText = File.ReadAllText(filename);
                
                Project proj = JsonConvert.DeserializeObject<Project>(justText);

                //The following is an example of what u can do with the data that was Deserialized from the JSON, you can now access each property of the object on its own
                Console.WriteLine("Team name is: {0}",proj.TeamName);
            }
            else
            {
                Console.WriteLine("File doesnt exist");
            }

        }


        //You can use this method to pass data members from the GUI and create project Objects with it
        //the toJson() method calls this to convert the object to a JSON string
        static Project createProject()
        {
            DateTime timeNow = DateTime.Now;

            Project p = new Project("testteam", "testproduct", timeNow, 20, 30, 1000);

            p.AddTeamMember("yanni");
            p.AddTeamMember("tsakos");
            
            return p;

        }
    }
}
