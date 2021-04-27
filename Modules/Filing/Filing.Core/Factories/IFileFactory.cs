using System.Drawing;
using System.Threading.Tasks;
using Filing.Base.Entities;
using Filing.Base.Enums;
using Iqt.Base.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Filing.Core.Factories
{
    public interface IFileFactory
    {
        Task<ImageFile<T>> UploadImageAndSaveToDbAsync<T>(IFormFile upload, string oldFileId, string rootFolderPath,
            ImageType type, Point point, Size defaultSize, string parentId = null, bool perserveAspectRatio = false)
            where T : IEntityBase;

        Task<ImageFile<T>> UploadImageAsync<T>(IFormFile file, string rootFolderPath, Point point,
            Size defaultSize, ImageType type, string parentId, bool perserveAspectRatio);

        Task<File<T>> UploadFileAndSaveToDbAsync<T>(IFormFile upload, string oldFileId, string name, string description,
            string rootFolderPath, string parentId = null) where T : IEntityBase;

        Task<AudioFile<T>> UploadAudioAndSaveToDbAsync<T>(IFormFile upload, string oldFileId, string audioName,
            string audioDescription, string rootFolderPath, string parentId = null) where T : IEntityBase;

        Task<Video<T>> UploadVideoAndSaveToDbAsync<T>(IFormFile upload, string oldFileId, string videoName,
            string videoDescription, string rootFolderPath, string parentId = null) where T : IEntityBase;

        Task DeleteImageAndRemoveFormDbAsync<T>(ImageFile<T> file) where T : IEntityBase;

        void CreateDirectory(string path);
    }
}
