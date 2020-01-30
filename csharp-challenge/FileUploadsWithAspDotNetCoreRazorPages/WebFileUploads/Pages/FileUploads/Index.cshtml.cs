using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using WebFileUploads.Models;

namespace WebFileUploads.Pages.FileUploads
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
                Guid guid = Guid.NewGuid();
                string fileName = FileUpload.FormFile.FileName;
                string fileExtension = Path.GetExtension(fileName);
                string newFileName = $"{guid}{fileExtension}";
                string newFilePath = Path.Combine(_saveFilePath, newFileName);

                if (!Directory.Exists(_saveFilePath))
                {
                    Directory.CreateDirectory(_saveFilePath);
                }

                IFormFile formFile = FileUpload.FormFile;

                using (var stream = System.IO.File.Create(newFilePath))
                {
                    await formFile.CopyToAsync(stream);
                }
            }

            Console.WriteLine(FileUpload);

            return Page();
        }
    }
}
