using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.StorageServices
{
    public class BlobService
    {
        private string _blobConnString;
        private string _containerName;

        public BlobService()
        {
            _blobConnString = Environment.GetEnvironmentVariable("BLOB_CONN_STRING");
            _containerName = "quickly"; //Environment.GetEnvironmentVariable("BLOB_CONTAINER");
        }

        public string UploadFileToBlob(string strFileName, IFormFile file)
        {
            try
            {

                var _task = Task.Run(() => this.UploadFileToBlobAsync(strFileName, file));
                _task.Wait();
                string fileUrl = _task.Result;
                return fileUrl;
            }
            catch (Exception)
            {
                return "";
            }
        }
        private async Task<string> UploadFileToBlobAsync(string strFileName, IFormFile file)
        {
            try
            {
                BlobServiceClient blobServiceClient = new BlobServiceClient(_blobConnString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
                BlobClient blobClient = containerClient.GetBlobClient(strFileName);
                using (var stream = file.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream, true);
                }
                return blobClient.Uri.AbsoluteUri;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
