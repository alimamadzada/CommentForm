using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ali.Helpers
{
    public static class Extensions
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }
        public static bool IsSmallerThan(this IFormFile file, int kb)
        {
            return file.Length / 1024 > kb;
        }
        public static async Task<string> Upload(this IFormFile file,string path) 
        {
            string filename = Guid.NewGuid().ToString() + file.FileName;
            string final = Path.Combine(path, filename);
            using (FileStream stream = new FileStream(final, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return filename; ;
        }
    }
}
