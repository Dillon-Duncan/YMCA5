using System;

namespace YMCA3.YmcaApiClient.Models.ApiModels
{
    public class Event
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime Date { get; set; }
    }
}