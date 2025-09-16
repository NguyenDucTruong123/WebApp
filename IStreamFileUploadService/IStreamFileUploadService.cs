using Microsoft.AspNetCore.WebUtilities;

namespace WebApp.Inteface
{
    public interface IStreamFileUploadService
    {
        Task<bool> UploadFile(MultipartReader reader, MultipartSection section);
    }
}
