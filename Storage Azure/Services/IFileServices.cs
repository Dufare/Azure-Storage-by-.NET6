using Azure.Storage.Blobs;
using Storage_Azure.Model;

namespace Storage_Azure.Services
{
    public interface IFileServices
    {
        Task Upload(FileModel filemodel);

        Task<BlobContainerClient> CreateContanier(BlobServiceClient blobServiceClient);

    }
}
