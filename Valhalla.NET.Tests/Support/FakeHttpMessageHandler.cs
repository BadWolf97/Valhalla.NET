// ----------------------------------------------------------------------------
// <copyright file="FakeHttpMessageHandler.cs" company="Freie Programme Hohenstein">
// Copyright (c) Freie Programme Hohenstein.
// Licensed under Apache-2.0 license. See LICENSE file in the project root for full license information.
// </copyright>
// ----------------------------------------------------------------------------

namespace FPH.ValhallaNET.Tests.Support
{
    /// <summary>
    /// An <see cref="HttpMessageHandler"/> stub that returns a canned response and records the
    /// last request it received, so unit tests can drive <see cref="ValhallaService"/> without
    /// hitting the network.
    /// </summary>
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> responder;

        public FakeHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> responder)
        {
            this.responder = responder;
        }

        public HttpRequestMessage? LastRequest { get; private set; }

        public string? LastRequestUri => this.LastRequest?.RequestUri?.ToString();

        public string? LastRequestBody { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            this.LastRequest = request;
            this.LastRequestBody = request.Content == null
                ? null
                : await request.Content.ReadAsStringAsync(cancellationToken);
            return this.responder(request);
        }
    }
}
