﻿using Newtonsoft.Json;
using System.Net;

namespace Music_app.Domain.Exceptions;

public class BaseDomainException : Exception
{
    public BaseDomainException()
    {
    }

    public BaseDomainException(string code, string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) :
        base(message)
    {
        this.code = code;
        status = (int)statusCode;
    }

    public string code { get; set; }

    public int status { get; set; }

    public virtual dynamic GetMessage()
    {
        return new { code, message = Message };
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(GetMessage(),
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
    }
}