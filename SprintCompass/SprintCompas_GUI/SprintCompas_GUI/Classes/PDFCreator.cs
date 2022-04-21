using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectPdf;
namespace SprintCompas_GUI.Classes
{
    class PDFCreator
    {
       
        public void GenerateSprintRetrospective(Sprint _sprint)
        {
            
            SelectPdf.PdfDocument doc = new SelectPdf.PdfDocument();
            SelectPdf.PdfPage page = doc.AddPage();

            SelectPdf.PdfFont font = doc.AddFont(SelectPdf.PdfStandardFont.Helvetica);
            font.Size = 9;

            SelectPdf.PdfTextElement titleA = new SelectPdf.PdfTextElement(0, 0, "Priority", font);
            SelectPdf.PdfTextElement titleB = new SelectPdf.PdfTextElement(40, 0, "User Stories", font);
            SelectPdf.PdfTextElement titleC = new SelectPdf.PdfTextElement(400, 0, "Team Members", font);
            SelectPdf.PdfTextElement titleD = new SelectPdf.PdfTextElement(500, 0, "Hours Worked", font);
            SelectPdf.PdfTextElement titleE = new SelectPdf.PdfTextElement(0, 20, "----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font);
            page.Add(titleA);
            page.Add(titleB);
            page.Add(titleC);
            page.Add(titleD);
            page.Add(titleE);

            for (int i=0; i<_sprint.userStories.Count; i++)
            {
                SelectPdf.PdfTextElement story = new SelectPdf.PdfTextElement(40, 40 + i * 50, _sprint.userStories[i].story, font);
                SelectPdf.PdfTextElement priority = new SelectPdf.PdfTextElement(10, 40 + i * 50, _sprint.userStories[i].priority.ToString(), font);
                page.Add(story);
                page.Add(priority);
                for (int j=0; j<_sprint.userStories[i].teamMembers.Count; j++)
                {
                    SelectPdf.PdfTextElement memberName = new SelectPdf.PdfTextElement(400, 40 + j * 10 + 50* i, _sprint.userStories[i].teamMembers[j].name, font);
                    SelectPdf.PdfTextElement hoursWorked = new SelectPdf.PdfTextElement(500, 40 + j * 10 + 50 * i, _sprint.userStories[i].teamMembers[j].hoursWorked.ToString(), font);
                    page.Add(memberName);
                    page.Add(hoursWorked);
                }
            }



            Console.WriteLine("File Saved!");
            doc.Save("TeamSummary.pdf");
            doc.Close();
        }

        public void GenerateTeamSummary(Sprint _Sprint)
        {
            SelectPdf.PdfDocument doc = new SelectPdf.PdfDocument();
            SelectPdf.PdfPage page = doc.AddPage();

            SelectPdf.PdfFont font = doc.AddFont(SelectPdf.PdfStandardFont.Helvetica);
            SelectPdf.PdfFont titleFont = doc.AddFont(SelectPdf.PdfStandardFont.Helvetica);
            font.Size = 9;
            titleFont.Size = 7;

            SelectPdf.PdfTextElement titleA = new SelectPdf.PdfTextElement(0, 0, "Priority", titleFont);
            SelectPdf.PdfTextElement titleB = new SelectPdf.PdfTextElement(40, 0, "User Stories/Subtasks", titleFont);
            SelectPdf.PdfTextElement titleC = new SelectPdf.PdfTextElement(295, 0, "Members", titleFont);
            SelectPdf.PdfTextElement titleD = new SelectPdf.PdfTextElement(335, 0, "Original Estimate", titleFont);
            SelectPdf.PdfTextElement titleF = new SelectPdf.PdfTextElement(405, 0, "Actual Hours", titleFont);
            SelectPdf.PdfTextElement titleG= new SelectPdf.PdfTextElement(465, 0, "Re-estimate", titleFont);
            SelectPdf.PdfTextElement titleE = new SelectPdf.PdfTextElement(0, 20, "----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font);
            page.Add(titleA);
            page.Add(titleB);
            page.Add(titleC);
            page.Add(titleD);
            page.Add(titleE);
            page.Add(titleF);
            page.Add(titleG);


            for (int i = 0; i<_Sprint.userStories.Count; i++)
            {
                PdfTextElement priority = new PdfTextElement(10, 50 + i * 50, _Sprint.userStories[i].priority.ToString(), font);
                PdfTextElement story = new PdfTextElement(40, 50 + i * 50, _Sprint.userStories[i].story, font);
                page.Add(story);
                page.Add(priority);

                for(int j = 0; j < _Sprint.userStories[i].subTasks.Count; j++)
                {
                    PdfTextElement subtask = new PdfTextElement(60,60  + j * 10 + 50 * i ,_Sprint.userStories[i].subTasks[j].description,font);
                    page.Add(subtask);
                    
                    for(int l = 0; l<_Sprint.userStories[i].subTasks[j].HoursBooked.Count; l++)
                    {
                        PdfTextElement member = new PdfTextElement(300, 60 + j * 10 + 50 * i, _Sprint.userStories[i].subTasks[j].HoursBooked.Keys.ElementAt(l), font);
                        PdfTextElement hoursWorked = new PdfTextElement(420, 60 + j * 10 + 50 * i, _Sprint.userStories[i].subTasks[j].HoursBooked.Values.ElementAt(l).ToString(), font);
                        PdfTextElement initialEstimate = new PdfTextElement(350, 60 + j * 10 + 50 * i, _Sprint.userStories[i].subTasks[j].initialEstimate.ToString(), font);
                        PdfTextElement hoursRemaining = new PdfTextElement(480, 60 + j * 10 + 50 * i, _Sprint.userStories[i].subTasks[j].hoursRemaining.ToString(), font);
                        page.Add(member);
                        page.Add(hoursWorked);
                        page.Add(initialEstimate);
                        page.Add(hoursRemaining);
                       
                    }
                }
            }
            Console.WriteLine("File Saved!");
            doc.Save("SprintRetrospective.pdf");
            doc.Close();
        }

    }
}
