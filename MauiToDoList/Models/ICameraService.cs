namespace MauiToDoList.Models
{
    public interface ICameraService
    {
        Task<string> CapturePhotoAsync();
        Task<string> PickPhotoAsync();
    }
}
