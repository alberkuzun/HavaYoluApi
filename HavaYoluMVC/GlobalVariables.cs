﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HavaYoluMVC
{
    public static class GlobalVariables
    {

        public static HttpClient WebApClient = new HttpClient();

        static GlobalVariables()
        {
            WebApClient.BaseAddress = new Uri("https://localhost:44328/api/"); //apiye bağlanmak için properties web kısmından url kopyaladık buraya yazdık
            WebApClient.DefaultRequestHeaders.Clear();
            WebApClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



        }
    }
}