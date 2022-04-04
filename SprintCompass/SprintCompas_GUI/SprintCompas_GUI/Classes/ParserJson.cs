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
        //Create Project
        public Project createProject(string team, string product, DateTime start, int hour, int points, double dollars)
        {


            Project p = new Project(team, product, start, hour, points, dollars);



            return p;

        }

        //Converts .Net Object to JSON
        public void toJSON(string filename, Project proj)
        {
            //Project proj = new Project(team, product, start, hour, points, dollars);

            File.WriteAllText($"{filename}.json", JsonConvert.SerializeObject(proj));

            using (StreamWriter file = File.CreateText(filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, proj);
            }


        }

        //Converts JSON to .Net object
        public Project fromJSON(string filename)
        {


            if (File.Exists($"{filename}.json"))
            {
                string justText = File.ReadAllText($"{filename}.json");

                Project proj = JsonConvert.DeserializeObject<Project>(justText);

                //The following is an example of what u can do with the data that was Deserialized from the JSON, you can now access each property of the object on its own
                Console.WriteLine("Team name is: {0}", proj.TeamName);

                return proj;
            }
            else
            {
                Console.WriteLine("File doesnt exist");
                return null;
            }

        }



    }
}
