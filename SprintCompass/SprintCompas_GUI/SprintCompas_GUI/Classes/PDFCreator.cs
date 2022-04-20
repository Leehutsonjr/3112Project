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

            for(int i=0; i<_sprint.userStories.Count; i++)
            {
                SelectPdf.PdfTextElement story = new SelectPdf.PdfTextElement(20, 20 + i * 50, _sprint.userStories[i].story, font);
                SelectPdf.PdfTextElement priority = new SelectPdf.PdfTextElement(5, 20 + i * 50, _sprint.userStories[i].priority.ToString(), font);
                page.Add(story);
                page.Add(priority);
                for (int j=0; j<_sprint.userStories[i].teamMembers.Count; j++)
                {
                    SelectPdf.PdfTextElement memberName = new SelectPdf.PdfTextElement(60, 20 + i * 10, _sprint.userStories[i].teamMembers[j].name, font);
                    SelectPdf.PdfTextElement hoursWorked = new SelectPdf.PdfTextElement(80, 20 + i * 10, _sprint.userStories[i].teamMembers[j].hoursWorked.ToString(), font);
                    page.Add(memberName);
                    page.Add(hoursWorked);
                }
            }



            Console.WriteLine("File Saved!");
            doc.Save("test.pdf");
            doc.Close();
        }



    }
}
