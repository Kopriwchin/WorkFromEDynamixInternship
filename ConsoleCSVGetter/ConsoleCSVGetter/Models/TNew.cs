using System;
using System.Collections.Generic;

namespace ConsoleCSVGetter.Models
{
    public partial class TNew
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string AppPoolId { get; set; }
        public int? SiteId { get; set; }
        public int? ProcessId { get; set; }
        public string Verb { get; set; }
        public string RemoteUserName { get; set; }
        public string UserName { get; set; }
        public string TokenUserName { get; set; }
        public string AuthenticationType { get; set; }
        public string ActivityId { get; set; }
        public string FailureReason { get; set; }
        public string ReasonDescription { get; set; }
        public string StatusCode { get; set; }
        public string TriggerStatusCode { get; set; }
        public long? TimeTaken { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string ServerName { get; set; }
        public string XmlDta { get; set; }
    }
}
