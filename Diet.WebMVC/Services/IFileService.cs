namespace Diet.WebMVC.Services;

public interface IFileService
{
    string GetRootPath(string extra);
    Task CreateFileAsync(IFormFile file, string directory, string fileName);
    void DeleteFile(string directory, string fileName);
    Task SaveThumbnail(IFormFile image, string directory, string fileName, int width, int height);
    Task ReplaceFilesAsync(IFormFile image1, string directory, string fileName, string image2);
}
