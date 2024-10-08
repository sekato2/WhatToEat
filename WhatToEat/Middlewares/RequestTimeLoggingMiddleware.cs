﻿
using System.Diagnostics;

namespace WhatToEat.API.Middlewares;

public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var stopWacth = Stopwatch.StartNew();
        await next.Invoke(context);
        stopWacth.Stop();

        if (stopWacth.ElapsedMilliseconds/1000 > 4)
        {
            logger.LogInformation("Request [{Verb}] at {Path} took {Time} ms",
                context.Request.Method,
                context.Request.Path,
                stopWacth.ElapsedMilliseconds);
        }
    }
}
