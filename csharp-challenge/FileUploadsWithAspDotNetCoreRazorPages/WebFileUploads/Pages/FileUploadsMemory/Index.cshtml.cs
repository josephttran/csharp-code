using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.FileIO;
using WebFileUploads.Models;

namespace WebFileUploads.Pages.FileUploadsMemory
{
    public class IndexModel : PageModel
    {
        private readonly long _fileSizeLimit;
        private readonly string _saveFilePath;

        public IndexModel(IConfiguration config)
        {
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");
            _saveFilePath = config.GetValue<string>("SaveFilePath");
        }

        [BindProperty]
        public FileUpload FileUpload { get; set; }
        public List<Person> People { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            if (FileUpload.FormFile.Length < _fileSizeLimit)
            {
                IFormFile formFile = FileUpload.FormFile;

                People = GetPeople(formFile);
            }

            Console.WriteLine(FileUpload);

            return Page();
        }

        private List<Person> GetPeople(IFormFile formFile)
        {
            List<Person> people = new List<Person>();
            Stream stream = formFile.OpenReadStream();

            using (TextFieldParser csvReader = new TextFieldParser(stream))
            {
                csvReader.SetDelimiters(new string[]{ "," });

                while (!csvReader.EndOfData)
                {
                    string[] fields = csvReader.ReadFields();

                    Person person = new Person
                    {
                        FirstName = fields[0],
                        LastName = fields[1],
                        Email = fields[2]
                    };

                    people.Add(person);
                }
            }

            return people;
        }
    }
}
