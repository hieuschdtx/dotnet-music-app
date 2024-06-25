namespace Music_app.Domain.Models;

public class ResponseBase
{
    public ResponseBase()
    {
    }

    public ResponseBase(string code, string message)
    {
        this.code = code;
        this.message = message;
    }

    public string code { get; set; }
    public string message { get; set; }
}

public class SuccessResponse : ResponseBase
{
    public SuccessResponse() : base("success", "")
    {
    }

    public SuccessResponse(string message) : base("success", message)
    {
    }
}

public class CreateSuccessResponse : ResponseBase
{
    public CreateSuccessResponse(int id, string message) : base("success", message)
    {
        this.id = id;
    }

    public int id { get; set; }
}