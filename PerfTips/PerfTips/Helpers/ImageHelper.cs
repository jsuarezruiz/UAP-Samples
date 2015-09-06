namespace PerfTips.Helpers
{
    using System.Net;
    using System.IO;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class ImageHelper
    {
        public enum ImageType
        {
            Unknown,
            Jpeg,
            Png,
            Gif,
            Bmp,
            Tiff,
        }

        public static async Task<string[]> RemoveInvalidFileTypes(string[] files)
        {
            var validFiles = new List<string>();

            foreach (var file in files)
            {
                if (await IsValidImageAsync(file))
                    validFiles.Add(file);
            }

            return validFiles.ToArray();
        }

        public static string[] RemoveInvalidFileTypesInParallel(string[] files)
        {
            var validFiles = new ConcurrentBag<string>();

            Parallel.ForEach(files, async file =>
            {
                if (await IsValidImageAsync(file))
                    validFiles.Add(file);
            });

            return validFiles.ToArray();
        }

        public static async Task<bool> IsValidImageAsync(string file)
        {
            var imageType = await GetFileImageTypeFromHeader(file);

            return imageType == ImageType.Jpeg;
        }

        public static async Task<byte[]> GetHttpAsBytesAsync(string url)
        {
            // Build request
            var request = WebRequest.CreateHttp(url);
            request.UseDefaultCredentials = true;
            byte[] bytes;

            // Get response
            var response = await request.GetResponseAsync();
            using (var br = new BinaryReader(response.GetResponseStream()))
            {
                using (var ms = new MemoryStream())
                {
                    var lineBuffer = br.ReadBytes(1024);

                    while (lineBuffer.Length > 0)
                    {
                        ms.Write(lineBuffer, 0, lineBuffer.Length);
                        lineBuffer = br.ReadBytes(1024);
                    }

                    bytes = new byte[(int)ms.Length];
                    ms.Position = 0;
                    ms.Read(bytes, 0, bytes.Length);
                }
            }

            return bytes;
        }

        public static async Task<ImageType> GetFileImageTypeFromHeader(string file)
        {
            var headerBytes = await GetHttpAsBytesAsync(file);

            //Sources:
            //http://stackoverflow.com/questions/9354747
            //http://en.wikipedia.org/wiki/Magic_number_%28programming%29#Magic_numbers_in_files
            //http://www.mikekunz.com/image_file_header.html

            //JPEG:
            if (headerBytes[0] == 0xFF &&//FF D8
                headerBytes[1] == 0xD8 &&
                (
                 (headerBytes[6] == 0x4A &&//'JFIF'
                  headerBytes[7] == 0x46 &&
                  headerBytes[8] == 0x49 &&
                  headerBytes[9] == 0x46)
                  ||
                 (headerBytes[6] == 0x45 &&//'EXIF'
                  headerBytes[7] == 0x78 &&
                  headerBytes[8] == 0x69 &&
                  headerBytes[9] == 0x66)
                ) &&
                headerBytes[10] == 00)
            {
                return ImageType.Jpeg;
            }
            //PNG 
            if (headerBytes[0] == 0x89 && //89 50 4E 47 0D 0A 1A 0A
                headerBytes[1] == 0x50 &&
                headerBytes[2] == 0x4E &&
                headerBytes[3] == 0x47 &&
                headerBytes[4] == 0x0D &&
                headerBytes[5] == 0x0A &&
                headerBytes[6] == 0x1A &&
                headerBytes[7] == 0x0A)
            {
                return ImageType.Png;
            }
            //GIF
            if (headerBytes[0] == 0x47 &&//'GIF'
                headerBytes[1] == 0x49 &&
                headerBytes[2] == 0x46)
            {
                return ImageType.Gif;
            }
            //BMP
            if (headerBytes[0] == 0x42 &&//42 4D
                headerBytes[1] == 0x4D)
            {
                return ImageType.Bmp;
            }
            //TIFF
            if ((headerBytes[0] == 0x49 &&//49 49 2A 00
                 headerBytes[1] == 0x49 &&
                 headerBytes[2] == 0x2A &&
                 headerBytes[3] == 0x00)
                 ||
                (headerBytes[0] == 0x4D &&//4D 4D 00 2A
                 headerBytes[1] == 0x4D &&
                 headerBytes[2] == 0x00 &&
                 headerBytes[3] == 0x2A))
            {
                return ImageType.Tiff;
            }

            return ImageType.Unknown;
        }
    

        public static bool IsValidImage(string file)
        {
            return file.EndsWith(".jpg");
        }
    }
}