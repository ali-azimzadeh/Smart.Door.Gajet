using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Azx
{
    public static class HttpContextExtensions
    {
        //https://gist.github.com/jjxtra/3b240b31a1ed3ad783a7dcdb6df12c36

        public static string GetRemoteIPAddress(this HttpContext context, bool allowForwarded = true)
        {
            string strIp = string.Empty;
            if (allowForwarded)
            {
                string header = (context.Request.Headers["CF-Connecting-IP"].FirstOrDefault() ?? context.Request.Headers["X-Forwarded-For"].FirstOrDefault());
                if (IPAddress.TryParse(header, out IPAddress ip))
                {
                    strIp = ip.ToString();
                    return strIp;
                }
            }
            IPAddress iPAddress = context.Connection.RemoteIpAddress;
            if (iPAddress != null)
            {
                if (iPAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    iPAddress = System.Net.Dns.GetHostEntry(iPAddress).AddressList
                        .First(current => current.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        ;
                }
                strIp = iPAddress.ToString();
            }
            return strIp;
        }

        public static async Task<string> GetRemoteIPAddressAsync(this HttpContext context, bool allowForwarded = true)
        {
            string strIp = string.Empty;
            await Task.Run(() =>
            {
                if (allowForwarded)
                {
                    string header = (context.Request.Headers["CF-Connecting-IP"].FirstOrDefault() ?? context.Request.Headers["X-Forwarded-For"].FirstOrDefault());
                    if (IPAddress.TryParse(header, out IPAddress ip))
                    {
                        strIp = ip.ToString();
                        //    return strIp;
                    }
                    else
                    {
                        IPAddress iPAddress = context.Connection.RemoteIpAddress;
                        if (iPAddress != null)
                        {
                            if (iPAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                            {
                                iPAddress = System.Net.Dns.GetHostEntry(iPAddress).AddressList
                                    .First(current => current.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                    ;
                            }
                            strIp = iPAddress.ToString();
                        }
                    }
                }
            });
            return strIp;
        }
    }
}
