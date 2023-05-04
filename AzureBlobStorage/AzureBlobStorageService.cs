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
        private static string _accountName = System.Environment.GetEnvironmentVariable("AccountName", EnvironmentVariableTarget.Process);
        private static string _accessKey = System.Environment.GetEnvironmentVariable("AzureBlobStorageAccessKey", EnvironmentVariableTarget.Process);
        private static string _containerName = System.Environment.GetEnvironmentVariable("ContainerName", EnvironmentVariableTarget.Process);
        private static string _blobName = System.Environment.GetEnvironmentVariable("BlobName", EnvironmentVariableTarget.Process);

        private CloudBlockBlob CreateCloudBlockBlobInstance()
        {
            var credential = new StorageCredentials(_accountName, _accessKey);
            var storageAccount = new CloudStorageAccount(credential, true);
            var blobServiceClient = storageAccount.CreateCloudBlobClient();
            var container = blobServiceClient.GetContainerReference(_containerName);
            return container.GetBlockBlobReference(_blobName);
        }

        /// <summary>
        /// 1日1回占いが更新されるが、
        /// 更新失敗や占いが出力されなかった場合には一日に複数回実行される
        /// </summary>
        public async Task<bool> CheckRequireUpdate()
        {
            var blockBlob = CreateCloudBlockBlobInstance();

            var text = await blockBlob.DownloadTextAsync();
            //厳密な判定ではないが、更新日時を使用してその日に更新済みかを判定する
            return !text.Contains(DateTime.Today.ToString("yyyy/MM/dd"));
        }

        public async void ReplaceFile(string content)
        {
            var blockBlob = CreateCloudBlockBlobInstance();

            blockBlob.Properties.ContentType = "text/html";
            await blockBlob.UploadTextAsync(content);
        }
    }
}
