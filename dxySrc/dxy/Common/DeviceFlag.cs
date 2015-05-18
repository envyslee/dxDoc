using Microsoft.Phone.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Common
{
    public static class DeviceFlag
    {
      public static string GetDeviceFlag()
      {
          string deviceName = DeviceStatus.DeviceName;
          //string deviceManufacturer = DeviceStatus.DeviceManufacturer;
          return deviceName;
           
      }
    }
}
