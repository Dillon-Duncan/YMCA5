﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMCA3.YmcaApiClient.Models.ApiModels;

namespace YMCA3.Models
{
    public class LoggedUser
    {
        public string? Username { get; set; } = "";
        public string? EmailAddress { get; set; } = "";
        public string? Password { get; set; } = "";
    }
}