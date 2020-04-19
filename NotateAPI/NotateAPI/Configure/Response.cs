using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
namespace NotateAPI.Configure
{
    public class Response
    {
        [JsonProperty("OK")]
        public bool IsSuccess { get; set; }
        [JsonProperty("StatusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("Message")]
        public string Message { get; set; }
        [JsonProperty("ErrorMessage")]
        public string Error { get; set; }
        [JsonProperty("Data")]
        public object Data { get; set; }
    }
}