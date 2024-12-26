using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Utils
{
    public static class IpAdress
    {
        public static string GetIPAddress()
        {
            var ipAdress = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in ipAdress.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new NotImplementedException();
        }
    }
}
