using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ChatServer
{
    public class NetworkInformation
    {
        public static IPAddress GetCurrrentHostIp()
        {
            string host = Dns.GetHostName();
            IPAddress[] addresses = Dns.GetHostEntry(host).AddressList;
            foreach (var address in addresses)
            {
                if (address.GetAddressBytes().Length == 4)
                {
                    return address;
                }
            }
            return null;
        }
    }
}
