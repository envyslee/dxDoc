using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Windows.Phone.Storage.SharedAccess;

namespace dxy.Common
{
    class AssociationUriMapper : UriMapperBase
    {
        private string tempUri;
     
        public override Uri MapUri(Uri uri)
        {
            tempUri = uri.ToString();
            // 根据文件类型打开程序
            if (tempUri.Contains("/FileTypeAssociation"))
            {
                // 获取fileID (after "fileToken=").
                int fileIDIndex = tempUri.IndexOf("fileToken=") + 10;
                string fileID = tempUri.Substring(fileIDIndex);
                // 获取文件名.
                string incommingFileName = SharedStorageAccessManager.GetSharedFileName(fileID);
                // 获取文件后缀
                int extensionIndex = incommingFileName.LastIndexOf('.') + 1;
                string incommingFileType = incommingFileName.Substring(extensionIndex).ToLower();
                // 根据不同文件类型，跳转不同参数的地址
                switch (incommingFileType)
                {
                    case "wx23c4db6d0d03d3f9":
                        return new Uri("/Page/WeixinPage.xaml?fileToken=" + fileID, UriKind.Relative);
                    default:
                        return new Uri("/MainPage.xaml", UriKind.Relative);
                }
            }
            else
            {
                return uri;
            }
        }

    }
}
