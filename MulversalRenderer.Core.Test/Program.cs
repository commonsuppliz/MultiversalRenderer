using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;
using MultiversalRenderer.Core;
using MultiversalRenderer.Interfaces;
using NiL.JS.Core;
using NilJsProcessor;
using System.IO.Pipes;
using System.Threading.Tasks;
using System.Data;
using NiL.JS;
namespace Core.Test
{
    internal class Program
    {
        static CHtmlDocument localdocument = null;
        static void Main(string[] args)
        {
            var window = new CHtmlMultiversalWindow();
            MultiversalRenderer.Core.commonLog.LoggingEnabled = true;
            MultiversalRenderer.Core.commonLog.LogLevel = 10;
            var scope = new NilJsScope();
            scope.___initScriptEngine();
            scope.___setMultiversalWindow(window);
            var processor = scope.___getMultiversalScriptProcessor();
            var @delegate = new Action<string>(text => Debug.WriteLine(text));
            scope.context.DefineVariable("window").Assign(scope.context.GlobalContext.ProxyValue(window));

            
            // scope.context.DefineVariable("alert").Assign(scope.context.GlobalContext.ProxyValue(@delegate));

            // Create a function to set `this` to `window`
            scope.context.Eval("function setGlobalThis() { return this; } var globalThis = setGlobalThis.call(window);");

            var windowoobj = scope.context.GetVariable("window");
            Debug.WriteLine(windowoobj);
            var jsValue = scope.context.Eval("window;");
            Debug.WriteLine(jsValue);
            var jsValue2 = scope.context.Eval("globalThis;");

            // 型をデバッグ出力
            Debug.WriteLine($"Type of globalThis: {jsValue2.GetType()}");

            // globalThis のプロパティを確認
            if (jsValue2.Value is JSObject jsObject)
            {
                foreach (var property in jsObject)
                {
                    Debug.WriteLine($"Key: {property.Key}, Value: {property.Value}");
                }
            }
            else if (jsValue2.Value is JSValue jsValue3)
            {
                Debug.WriteLine($"Value: {jsValue3}");
            }
            else
            {
                Debug.WriteLine("jsValue2 is not a JSObject");
            }

            if (jsValue2.Value is IMultiversalWindow || jsValue2.Value is CHtmlMultiversalWindow)
            {
                Debug.WriteLine($"globalThis is set to {jsValue2}");
            }
            else
            {
                throw new Exception("globalThis is not IMultiversalWindow");

            }
            var url = @"http://localhost/";
             LoadUrl(url).Wait();

            Debug.WriteLine("LoadUrl completed.");
            processor.put("document", localdocument);
   
            


        }
        public async static Task LoadUrl(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                MaxRequestContentBufferSize = 1_000_000,
                SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13

            };
            handler.UseProxy = false;

            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestVersion = new Version(1, 0);
                client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;

                client.Timeout = TimeSpan.FromSeconds(30);

                bool IsCharsetFound = false;
                string charset = "UTF -8";

                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");

                Stopwatch sw = new Stopwatch();
                sw.Start();
                StringBuilder sbRsponseReporter = new StringBuilder();

                try
                {
                    var cts = new CancellationTokenSource();
                    cts.CancelAfter(TimeSpan.FromSeconds(60));
                    //HttpResponseMessage response = await client.GetAsync(url, cts.Token);
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    bool IsHreadEndTagfound = false;
                    bool IsContentTypeHTML = false;
                    if (response.Content.Headers.ContentType.MediaType != "text/html")
                    {
                        IsContentTypeHTML = false;
                    }
                    else
                    {
                        IsContentTypeHTML = true;
                    }

                    using (Stream contentStream = await response.Content.ReadAsStreamAsync())
                    {

                        byte[] buffer = new byte[8192 ];
                        int bytesRead;
                        StringBuilder stringBuilder = new StringBuilder();
                        int ___bytesReead = 0;
                        if (IsContentTypeHTML == false)
                        {
                            goto ___StorePhase;
                        }

                        while ((___bytesReead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            string partialContent = Encoding.UTF8.GetString(buffer, 0, ___bytesReead);
                            stringBuilder.Append(partialContent);


                            int headEndPos = stringBuilder.ToString().IndexOf("</head>");

                            if (headEndPos > -1)
                            {
                                sbRsponseReporter.Append("endheadタグが見つかりました。\r");
                                IsHreadEndTagfound = true;
                            }
                            else
                            {
                                sbRsponseReporter.Append("endheadタグが見つかりませんでした。\r");
                            }
                            var match = Regex.Match(stringBuilder.ToString(), @"<meta(?!\s*(?:name|value)\s*=)(?:[^>]*?content\s*=[\s""']*)?([^>]*?)[\s""';]*charset\s*=[\s""']*([^\s""'/>]*)", RegexOptions.IgnoreCase);
                            if (match.Success)
                            {
                                // Debug.WriteLine($"charset match.Value: {match.Value}");
                                //var metaCharset = match.Value;
                                int charsetPos = match.Value.IndexOf("charset", StringComparison.OrdinalIgnoreCase);
                                if (charsetPos > 0)
                                {
                                    var charsetString = match.Value.Substring(charsetPos + 7);
                                    //Debug.WriteLine(charsetString);
                                    var metaCharsetArray = charsetString.ToCharArray();
                                    var sbCharset = new StringBuilder();
                                    for (int i = 0; i < metaCharsetArray.Length; i++)
                                    {
                                        char c = metaCharsetArray[i];
                                        switch (c)
                                        {
                                            case '-':

                                                sbCharset.Append(c);
                                                break;
                                            case char ch when char.IsLetterOrDigit(ch):
                                                sbCharset.Append(ch);
                                                break;
                                        }
                                    }
                                    if (sbCharset.Length > 0)
                                    {
                                        {
                                            IsCharsetFound = true;
                                            charset = sbCharset.ToString();
                                            sbRsponseReporter.Append($"Charset result was {charset}\r");
                                            //Console.WriteLine($"Charset result was {sbCharset.ToString()}");
                                            if (IsCharsetFound)
                                            {
                                                goto ___StorePhase;
                                            }

                                        }


                                    }



                                }

                            }
                            goto ___StorePhase;
                        }


                    ___StorePhase:
                        string __contentType = string.Format("{0}", response.Content.Headers.ContentType.MediaType);


                        var contentData = MultiversalWebCache.CreateUrlContentDataPath(url, __contentType);
                        var contentDataPath = MultiversalWebCache.StoregePath + contentData.FileLocation;
                        System.IO.Directory.CreateDirectory(Path.GetDirectoryName(contentDataPath));
                        if (IsContentTypeHTML)
                        {
                            MemoryStream ms = new MemoryStream();
                            await ms.WriteAsync(buffer, 0, ___bytesReead);
                            while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await ms.WriteAsync(buffer, 0, bytesRead);
                            }
                            Encoding encoding = Encoding.GetEncoding(charset);
                            string content = encoding.GetString(ms.ToArray(), 0, ___bytesReead);
                            localdocument = new CHtmlDocument(CHtmlDomModeType.HTMLDOM);
                            localdocument.___parseDocument(content, charset);
                 
                            await File.WriteAllTextAsync(contentDataPath, content, encoding);
                            sbRsponseReporter.Append($"コンテンツがテキストファイル {contentData.FileLocation} に保存されました。\r");
                            
                        
                        }
                        else
                        {
                            using (var fileStream = new FileStream(contentDataPath, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                await fileStream.WriteAsync(buffer, 0, ___bytesReead);
                                while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                                {
                                    await fileStream.WriteAsync(buffer, 0, bytesRead);
                                }
                            }
                            sbRsponseReporter.Append($"コンテンツがバイナリファイル {contentData.FileLocation} に保存されました。\r");
                        }

                        MultiversalWebCache.CacheData[url] = contentData;
                    }


                    if (response.Headers.TryGetValues("Alt-Svc", out var altSvc))
                    {
                        //Console.WriteLine("Alt-Svc header: " + string.Join(",", altSvc));
                        if (string.Join(",", altSvc).Contains("h3"))
                        {
                            sbRsponseReporter.Append("HTTP/3が利用されています。\r");
                        }
                        else
                        {
                            sbRsponseReporter.Append("HTTP/3は利用されていません。\r");
                        }
                    }
                    else
                    {
                        sbRsponseReporter.Append("Alt-Svc headerは存在しません。\r");
                    }

                }

                catch (HttpRequestException e)
                {
                    sbRsponseReporter.Append($"リクエストエラー: {e.Message}\r");
                }
                sw.Stop();
                Debug.WriteLine($"処理時間: {sw.ElapsedMilliseconds} ミリ秒 ");
                var sbList = sbRsponseReporter.ToString().Split("\r");
                foreach (var item in sbList)
                {
                    Debug.WriteLine(item);
                }

            }

        }

 
        
    }
}
    


