using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace IPv4_Ping
{
    class Program
    {
        public static int sayi=0;
       
        static void Main(string[] args)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            string data = "damla";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1;
            PingReply reply = pingSender.Send("isaoglu.net", timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Address: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                Console.WriteLine("Veri başarı ile iletildi");
                string metin = System.Text.Encoding.UTF8.GetString(reply.Buffer);
                Console.WriteLine("Gönderilen Veri {0}", metin);
            }
            Console.ReadKey();
              
        } 
    } 
}
