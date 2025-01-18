
using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using MultiversalRenderer.Core;
using System.Threading.Tasks;

namespace MultiversalRenderer.Core
{
    public class ContentBuilder
    {
       public static async Task<CHttpContentDownload> GetCHtttpContentAsyc(HttpClient client, string requestUri, string destinationPath, CHttpContentDownload contentDownload, IProgress<(string, CHttpContentDownload)> progress = null, CancellationToken cancellationToken = default)
        {
            using (var response = await client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                System.Diagnostics.Debug.WriteLine($"HttpStatusCode : {response.StatusCode} {requestUri} {destinationPath}");

                var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                var canReportProgress = totalBytes != -1 && progress != null;
                contentDownload.ContentLength = (int)totalBytes;

                Stream stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                /*
                using (var contentHttpDocumentStream = stream, documentFileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                */
                using (var contentHttpDocumentStream = await response.Content.ReadAsStreamAsync())
                using (var documentFileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                {

                    var totalRead = 0L;
                    var buffer = new byte[8192];
                    var isMoreToRead = true;
                    var memoryDocumentStream = new MemoryStream();
                    do
                    {
                        //

                        var read = await contentHttpDocumentStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
                        if (read == 0)
                        {
                            isMoreToRead = false;
                            var progressPercentage = (float)totalRead / (float)totalBytes * 100;

                            contentDownload.Progress = progressPercentage;
                            progress.Report((requestUri, contentDownload));
                        }
                        else
                        {
                            totalRead += read;
                            var progressPercentage = (float)totalRead / (float)totalBytes * 100;
                            contentDownload.Progress = progressPercentage;



                            //  contentDownload.__documentMemStream

                            if (canReportProgress)
                            {
                                progress.Report((requestUri, contentDownload));

                            }
                            await documentFileStream.WriteAsync(buffer, 0, read, cancellationToken);




                        }
                    }
                    while (isMoreToRead);
                }

                return contentDownload;

            }
        }
    }
     public class CancellationToken<T1, T2> : IProgress<(string, CHttpContentDownload)>
    {
        public void Report((string, CHttpContentDownload) value)
        {
            System.Diagnostics.Debug.WriteLine($"{value.Item1}  {value.Item2.ContentLength} {value.Item2.Progress}%");
        }
    }
}
