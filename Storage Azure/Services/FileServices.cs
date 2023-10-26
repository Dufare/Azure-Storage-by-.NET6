using Azure.Storage.Blobs;
using Storage_Azure.Model;
using System.IO;
using Azure;

namespace Storage_Azure.Services
{

    public class FileServices: IFileServices
    {
        private readonly BlobServiceClient _blobServiceClient;
        public FileServices(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task Upload(FileModel filemodel)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient("logicapp");
            var blobInstance = containerInstance.GetBlobClient(filemodel.ImageFile.FileName);
           await  blobInstance.UploadAsync(filemodel.ImageFile.OpenReadStream());
        }
        
        public async Task<BlobContainerClient> CreateContanier(BlobServiceClient blobServiceClient)
        {

            //string contanierName = "File" + Guid.NewGuid().ToString();
            ////BlobContainerClient blobContainerClient = new BlobContainerClient(,contanierName);

            //BlobContainerClient blobContainerClient = await _blobServiceClient.CreateBlobContainerAsync(contanierName);
            //return blobContainerClient;

            string containerName = "container-" + Guid.NewGuid();

            try
            {
                //Create the container
               BlobContainerClient container = await blobServiceClient.CreateBlobContainerAsync(containerName);

                if (await container.ExistsAsync())
                {
                    Console.WriteLine("Created container {0}", container.Name);
                    return container;
                }
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine("HTTP error code {0}: {1}",
                                    e.Status, e.ErrorCode);
                Console.WriteLine(e.Message);
            }

            return null;
        }

    }
}
