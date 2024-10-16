﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Diet.WebMVC.Services;

public class FileService : IFileService
{
    public async Task CreateFileAsync(IFormFile file, string directory, string fileName)
    {
        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

        await using var stream = new FileStream(Path.Combine(directory, fileName), FileMode.Create);
        await file.CopyToAsync(stream);
    }

    public void DeleteFile(string directory, string fileName)
    {
        var destination = Path.Combine(directory, fileName);

        if (File.Exists(destination)) File.Delete(destination);
    }

    public string GetRootPath(string extra) => Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{extra}");

    public async Task ReplaceFilesAsync(IFormFile image1,string directory,string fileName, string image2Path)
    {
        var image1Path = Path.Combine(directory, image1.FileName);

        if (File.Exists(image2Path))
            File.Delete(image2Path);  // Delete original file1

        // Upload new image1
        using (var stream = new FileStream(image1Path, FileMode.Create)) await image1.CopyToAsync(stream);
    }

    public async Task SaveThumbnail(IFormFile image, string directory, string fileName, int width, int height)
    {
        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

        // TODO:Implement this
    }
}