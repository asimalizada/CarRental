using System;
using System.IO;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public static class FileHelper
    {
        public static string Add(IFormFile file)
        {
            string sourcePath = Path.GetTempFileName();

            if (file != null)
            {
                using (var upload = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(upload);
                }
            }
            string filepath = FilePath(file);
            File.Move(sourcePath, filepath);
            return filepath;

        }
        public static IResult Delete(string path)
        {
            File.Delete(path);
            return new SuccessResult();
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            string result = FilePath(file);
            if (sourcePath.Length != 0)
            {
                using (var upload = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(upload);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static string FilePath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            string path = Environment.CurrentDirectory + @"\uploads";
            string newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        } 
    }
}
