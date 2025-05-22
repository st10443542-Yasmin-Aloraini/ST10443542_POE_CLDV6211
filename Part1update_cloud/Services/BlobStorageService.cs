using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;



namespace Part1update_cloud.Services
{


    public class BlobStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly string _containerName;
        private readonly string _connectionString;

        public BlobStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            _containerName = _configuration["AzureBlobStorage:ContainerName"];
            _connectionString = _configuration["AzureBlobStorage:ConnectionString"];
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var blobServiceClient = new BlobServiceClient(_connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
            await containerClient.CreateIfNotExistsAsync();
            await containerClient.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var blobClient = containerClient.GetBlobClient(fileName);

            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, true);
            }

            return blobClient.Uri.ToString();
        }
    }
}
