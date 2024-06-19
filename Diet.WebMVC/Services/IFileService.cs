namespace Diet.WebMVC.Services;

public interface IFileService
{
    Task CreateFile(IFormFile file, string dest, string fileName);
    void DeleteFile(string directory, string fileName);
}
