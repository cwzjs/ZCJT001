/*************************************************************************
 * 文件名称 ：ZipCompress.cs                          
 * 描述说明 ：压缩为ZIP
 
**************************************************************************/

using System.IO;
//using ZCJT.Utils.Ionic.Zip;

namespace ZCJT.Core
{
    public class ZipCompress: ICompress
    {
        public string Suffix(string orgSuffix)
        {
            return "zip";
        }

        public Stream Compress(Stream fileStream,string fullName)
        {
            using (var zip = new ZipFile())
            {
                zip.AddEntry(fullName, fileStream);
                Stream zipStream = new MemoryStream();
                zip.Save(zipStream);
                return zipStream;
            }
        }
    }
}
