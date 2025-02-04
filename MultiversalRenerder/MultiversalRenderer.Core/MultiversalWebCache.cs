using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;

namespace MultiversalRenderer.Core
{
    public class MultivasalContentData
    {
        public string Url { get; set; }
        public string FileLocation { get; set; }
        public string ContentType { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public string Authority { get; set; }
        public string HtmlContent { get; set; }
        public string Charset { get; set; }
        public int ContentLength { get; set; }
        public MultivasalContentData() { }

    }
    public static class MultiversalWebCache

    {
        internal static string CachedData = "Cachedata.json";
        internal static string TrustedWenAuthorityData = "TrustedWenAuthority.json";
        public static List<string> TrustedWebAuthority = new List<string>();
        public static string StoregePath
        {
            get
            ; set;
        }
        public static Dictionary<string, MultivasalContentData> CacheData = new Dictionary<string, MultivasalContentData>();
        internal static void initHTMLDataStorePath()
        {

            StoregePath = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + System.IO.Path.DirectorySeparatorChar + "MultiversalDataStore";
            if (System.IO.Directory.Exists(StoregePath) == false)
            {
                System.IO.Directory.CreateDirectory(StoregePath);
            }
            if (System.IO.File.Exists(StoregePath + System.IO.Path.DirectorySeparatorChar + CachedData) == true)
            {
                string _cachedData = System.IO.File.ReadAllText(StoregePath + System.IO.Path.DirectorySeparatorChar + CachedData);
                CacheData = JsonSerializer.Deserialize<Dictionary<string, MultivasalContentData>>(_cachedData);
            }
            if (System.IO.File.Exists(StoregePath + System.IO.Path.DirectorySeparatorChar + TrustedWenAuthorityData) == true)
            {
                string _trustedWenAuthorityData = System.IO.File.ReadAllText(StoregePath + System.IO.Path.DirectorySeparatorChar + TrustedWenAuthorityData);
                TrustedWebAuthority = JsonSerializer.Deserialize<List<string>>(_trustedWenAuthorityData);
            }
        }
        static MultiversalWebCache()
        {
            initHTMLDataStorePath();
        }
        public static void SaveCacheData()
        {
            string _cachedData = JsonSerializer.Serialize(CacheData);
            System.IO.File.WriteAllText(StoregePath + System.IO.Path.DirectorySeparatorChar + CachedData, _cachedData);

        }
        public static void SaveTrustedWebAuthority()
        {
            string _trustedWenAuthorityData = JsonSerializer.Serialize(TrustedWebAuthority);
            System.IO.File.WriteAllText(StoregePath + System.IO.Path.DirectorySeparatorChar + TrustedWenAuthorityData, _trustedWenAuthorityData);
        }


        public static MultivasalContentData CreateUrlContentDataPath(string _url, string _contentType)
        {
            MultivasalContentData httpContentData = new MultivasalContentData();
            httpContentData.ContentType = _contentType;
            httpContentData.Url = _url;
            httpContentData.ContentType = _contentType;
            System.Text.StringBuilder _sbFileLocation = new System.Text.StringBuilder();
            string ___prototolString = null;

            Uri uri = new Uri(_url);
            string authority = uri.Authority;
            string dirname = Guid.NewGuid().ToString();
            _sbFileLocation.Append(System.IO.Path.DirectorySeparatorChar);
            _sbFileLocation.Append(authority);
            _sbFileLocation.Append(System.IO.Path.DirectorySeparatorChar);
            _sbFileLocation.Append(dirname);
            string curdirname = MultiversalWebCache.StoregePath + _sbFileLocation;
            if (System.IO.Directory.Exists(curdirname))
            {
                dirname = Guid.NewGuid().ToString();
                _sbFileLocation.Append(System.IO.Path.DirectorySeparatorChar);
                _sbFileLocation.Append(authority);
                _sbFileLocation.Append(System.IO.Path.DirectorySeparatorChar);
                _sbFileLocation.Append(dirname);
            }

            _sbFileLocation.Append(System.IO.Path.DirectorySeparatorChar);
            string _fileextension = System.IO.Path.GetExtension(uri.LocalPath).ToLower();
            string _fileName = System.IO.Path.GetFileName(uri.LocalPath);
            switch (_fileextension)
            {
                case ".html":
                case ".htm":
                case ".css":
                case ".js":
                case ".json":
                case ".cookie":
                case ".hdb":
                case ".gif":
                case ".jpg":
                case ".png":
                case ".webp":
                case ".bmp":
                case ".svg":
                case ".ico":
                case ".woff":
                case ".woff2":
                case ".ttf":
                case ".eot":
                case ".otf":
                case ".mp4":
                case ".webm":
                case ".ogg":
                case ".mp3":
                case ".wav":
                case ".flac":
                case ".m4a":
                case ".aac":
                case ".opus":
                case ".flv":
                case ".avi":
                case ".wmv":
                case ".mov":
                case ".mpg":
                case ".mpeg":
                case ".m4v":
                case ".mkv":
                case ".ogv":
                case ".3gp":
                case ".3g2":
                case ".pdf":
                case ".doc":
                case ".docx":
                case ".xls":
                case ".xlsx":
                case ".ppt":
                case ".pptx":
                case ".txt":
                case ".rtf":
                case ".csv":
                case ".xml":

                    _sbFileLocation.Append(_fileName);
                    break;
                default:
                    bool _IsFileNameAppended = false;
                    if (string.IsNullOrEmpty(_contentType) == false)
                    {
                        string _contentTypeExt = "";
                        if (_contentType.IndexOf(';') > -1)
                        {
                            _contentTypeExt = _contentType.Remove(_contentType.IndexOf(';')).ToLower();
                        }
                        else
                        {
                            _contentTypeExt = _contentType.ToLower();
                        }

                        switch (_contentTypeExt)
                        {
                            case "text/html":
                                _sbFileLocation.Append("index.html");
                                _IsFileNameAppended = true;
                                break;
                            case "text/css":
                                _sbFileLocation.Append("web.css");
                                _IsFileNameAppended = true;
                                break;
                            defalut:
                                break;
                        }
                    }
                    if (_IsFileNameAppended == false)
                    {
                        _sbFileLocation.Append("web.bin");
                    }

                    break;
            }
            httpContentData.FileLocation = _sbFileLocation.ToString();
            httpContentData.ContentType = _contentType;
            httpContentData.Authority = authority;
            return httpContentData;
        }




        private static readonly char[] passwordChars = "123456789abcdefghijklmnopqrstuvwxz".ToCharArray();
        private static int RandomSeed = -1;
        public static string GenerateRandomString(int length)
        {
            StringBuilder sb = new StringBuilder(length);
            if (RandomSeed == -1)
            {
                RandomSeed = System.Environment.TickCount;
            }
            else
            {
                System.Threading.Interlocked.Increment(ref RandomSeed);
            }
            Random r = new Random(RandomSeed);

            for (int i = 0; i < length; i++)
            {

                int pos = r.Next(passwordChars.Length);

                char c = passwordChars[pos];

                sb.Append(c);
            }

            return sb.ToString();
        }
        public static string GetFileExtentionByContentType(string _url)
        {
            string _prototol = string.Empty; ;
            return GetFileExtentionByContentType(_url, _prototol);
        }
        private static string GetFileExtentionByContentType(string _s, string ___prototol)
        {
            switch (_s)
            {
                case "image/gif":
                    return ".gif";
                case "image/jpeg":
                case "image/jpg":
                case "image/jfif":
                case "image/jfi":
                    return ".jpg";
                case "image/png":
                    return ".png";
                case "image/bmp":
                    return ".bmp";
                case "text/dummy":
                case "text/html":
                    return ".html";
                case "text/css":
                    return ".css";
                case "text/javascript":
                case "application/javascript":
                case "application/x-javascript":
                    return ".js";
                case "text/json":
                case "text/x-json":
                case "text/x-jsn":
                case "application/json":
                    return ".json";
                case "text/cookie":
                    return ".cookie";
                case "application/hdb":
                    return ".hdb";
                default:
                    if (string.IsNullOrEmpty(___prototol) == true)
                    {
                        return ".bin";
                    }
                    else
                    {
                        return "." + ___prototol;
                    }

            }

        }
        public static void LoadTrustedWebsites(string trustedWebWites)
        {
            var lines = trustedWebWites.Split("\n");
            if (lines.Length == 1)
            {
                var dataValues = lines[0].Split(",");
                foreach (var valuesplit in dataValues)
                {
                    if (valuesplit.Contains("."))
                    {
                        var _authority = valuesplit.Replace("\"", "").Trim();
                        if (_authority.Length > 5)
                        {
                            char fistLetter = _authority[0];
                            char lastLetter = _authority[_authority.Length - 1];
                            if (char.IsLetter(fistLetter) && char.IsLetter(lastLetter))
                            {
                                if (!TrustedWebAuthority.Contains(_authority))
                                    TrustedWebAuthority.Add(_authority);
                            }
                        }
                    }
                }
            }

            else
                foreach (var line in lines)
                {
                    var eachLine = line.Trim();
                    var dataValues = eachLine.Split(",");
                    foreach (var valuesplit in dataValues)
                    {
                        if (valuesplit.Contains("."))
                        {
                            var _authority = valuesplit.Replace("\"", "").Trim();
                            if (_authority.Length > 5)
                            {
                                char fistLetter = _authority[0];
                                char lastLetter = _authority[_authority.Length - 1];
                                if (char.IsLetter(fistLetter) && char.IsLetter(lastLetter))
                                {
                                    if (!TrustedWebAuthority.Contains(_authority))
                                        TrustedWebAuthority.Add(_authority);
                                }
                            }
                        }
                    }


                }




        }
    }
}

    
