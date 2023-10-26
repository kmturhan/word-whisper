namespace WordWhisper.WebAPI.Models
{
    public class RequestLog
    {
        public string RequestMethod { get; set; }
        public string RequestUrl { get; set; }
        public string RequestBody { get; set; }
        public string ClientIpAddress { get; set; }
        public DateTime RequestTime { get; set; }
        public string JsonRequest { get; set; }
    }
}
