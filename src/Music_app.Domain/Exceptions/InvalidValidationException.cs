using System.Net;

namespace Music_app.Domain.Exceptions
{
    public class InvalidValidationException : BaseDomainException
    {
        public InvalidValidationException(string code, string message) : base(code, message, HttpStatusCode.BadRequest)
        {
        }

        public InvalidValidationException(string code, string message, List<InvalidValidationItemDto> items) : base(
            code, message,
            HttpStatusCode.BadRequest)
        {
            if (items != null && items.Count > 1)
            {
                errors = items;
            }
        }

        public List<InvalidValidationItemDto> errors { get; }

        public override dynamic GetMessage()
        {
            return new { code, message = Message, errors };
        }
    }

    public class InvalidValidationItemDto
    {
        public InvalidValidationItemDto(string code, string message)
        {
            this.code = code;
            this.message = message;
        }

        public string code { get; set; }
        public string message { get; set; }
    }
}