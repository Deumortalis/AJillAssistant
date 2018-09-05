using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Net;
using System.IO;

namespace AJillAssistant
{
    class HTTP
    {
        public static void GetGETResponse(Uri uri, Action<string> callback)
        {
            WebClient wc = new WebClient();
            wc.OpenReadCompleted += (o, a) =>
            {
                if (callback != null)
                {
                    byte[] bytes = new byte[a.Result.Length];
                    a.Result.Read(bytes, 0, (int)a.Result.Length);
                    System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                    string message = encoding.GetString(bytes);
                    callback(message);
                }
            };
            wc.OpenReadAsync(uri);
        }

        public static void GetPOSTResponse(Uri uri, string data, Action<string> callback)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);

            request.Method = "POST";
            request.ContentType = "text/plain;charset=utf-8";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] bytes = encoding.GetBytes(data);

            request.ContentLength = bytes.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                // Send the data.
                requestStream.Write(bytes, 0, bytes.Length);
            }

            request.BeginGetResponse((x) =>
            {
                using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(x))
                {
                    if (callback != null)
                    {
                        int length = (int)response.ContentLength;
                        byte[] bytesBack = new byte[length];
                        response.GetResponseStream().Read(bytesBack, 0, length);
                        System.Text.UTF8Encoding encodingBack = new System.Text.UTF8Encoding();
                        string message = encodingBack.GetString(bytesBack);
                        callback(message);
                    }
                }
            }, null);
        }
    }
}
