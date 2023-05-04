using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using Microsoft.AspNetCore.Http.Internal;

namespace FortuneAI.AzureBlobStorage
{
    internal class AzureBlobStorageService
    {
        public async void ReplaceFile(string content)
        {
            var accountName = System.Environment.GetEnvironmentVariable("AccountName", EnvironmentVariableTarget.Process); ;
            var accessKey = System.Environment.GetEnvironmentVariable("AzureBlobStorageAccessKey", EnvironmentVariableTarget.Process);
            var containerName = System.Environment.GetEnvironmentVariable("ContainerName", EnvironmentVariableTarget.Process);
            var blobName = System.Environment.GetEnvironmentVariable("BlobName", EnvironmentVariableTarget.Process);

            var credential = new StorageCredentials(accountName, accessKey);
            var storageAccount = new CloudStorageAccount(credential, true);

            var blobServiceClient = storageAccount.CreateCloudBlobClient();
            var container = blobServiceClient.GetContainerReference(containerName);
            var blockBlob = container.GetBlockBlobReference(blobName);

            blockBlob.Properties.ContentType = "text/html";
            await blockBlob.UploadTextAsync(content);
        }
    }
}
