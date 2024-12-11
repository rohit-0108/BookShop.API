using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.API.Services
{
    public class UtilityService : IUtilityService
    {
        private IWebHostEnvironment _env;
        private IHttpContextAccessor _contextAccessor;

        public UtilityService(IWebHostEnvironment env, IHttpContextAccessor contextAccessor)
        {
            _env = env;
            _contextAccessor = contextAccessor;
        }

        public Task DeleteImage(string ContainerName, string dbPath)
        {
           if(string.IsNullOrEmpty(dbPath))
            {
                return Task.CompletedTask;
            }
           var filename=Path.GetFileName(dbPath);
            var completePath=Path.Combine(_env.WebRootPath,ContainerName, filename);
            if(File.Exists(completePath))
            {
                File.Delete(completePath);
            }
            return Task.CompletedTask;
        }

        public async Task<string> EditImage(string ContainerName, IFormFile file, string dbPath)
        {
            await DeleteImage(ContainerName, dbPath);
            return await SaveImage(ContainerName, file);
        }

        public async Task<string> SaveImage(string ContainerName, IFormFile file)
        {
           var extension= Path.GetExtension(file.FileName);
            var filename= $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(_env.WebRootPath, ContainerName);
            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string filePath=Path.Combine(folder,filename);
            using (var memorystreem=new MemoryStream())
            {
                await file.CopyToAsync(memorystreem);
                var content = memorystreem.ToArray();
                await File.WriteAllBytesAsync(filePath, content);
            }
            var basepath = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";

            var completePath = Path.Combine(basepath, ContainerName, filename).Replace("\\", "/");

            return completePath;
        }
    }
}
