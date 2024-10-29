using System;

namespace YmcaApiClient
{
    public class News
    {
        public int Id { get; set; }

        public string? Image { get; set; }

        public string? Headline { get; set; }

        public string? Description { get; set; }

        public DateTime Date { get; set; }
    }
}