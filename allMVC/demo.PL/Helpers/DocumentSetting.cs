using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace demo.PL.Helpers
{
    public class DocumentSetting
    {
        public static string UploadFile(IFormFile file,string folderName)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\", folderName);

            string fileName = $"{Guid.NewGuid()}{file.FileName}";

            string filePath=Path.Combine(folderPath, fileName);

            var fileSteam = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fileSteam);
            return fileName;
        }

        public static void DeleteFile(string fileName,string folderName)
        {
            string filePath=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files\\",folderName,fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
