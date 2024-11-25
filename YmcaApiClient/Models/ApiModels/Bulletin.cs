using System;

namespace YMCA3.YmcaApiClient.Models.ApiModels
{
    public class Bulletin
    {
        public int Id { get; set; }

        public string? Message { get; set; }

        public DateTime Date { get; set; }
    }
}