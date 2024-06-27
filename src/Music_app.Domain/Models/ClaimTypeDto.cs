namespace Music_app.Domain.Models
{
    public sealed class ClaimTypeDto
    {
        public string id { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string refresh_token { get; set; }
        public string role { get; set; }
    }
}