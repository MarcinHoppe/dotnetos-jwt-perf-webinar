﻿using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnetos.Diagnostics
{
    class TracingHttpClientHandler : DelegatingHandler
    {
        public TracingHttpClientHandler() : base(new HttpClientHandler())
        {
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine(request.RequestUri);
            return base.SendAsync(request, cancellationToken);
        }
    }
}