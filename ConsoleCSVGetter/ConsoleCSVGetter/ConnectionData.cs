using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCSVGetter
{
    public static class ConnectionData
    {
        private const string query = "SELECT TOP 1 Id,Url,AppPoolId,SiteId,ProcessId,Verb,TokenUserName,AuthenticationType,ActivityId,FailureReason,ReasonDescription,StatusCode,TriggerStatusCode,TimeTaken,StartTime,EndTime,ServerName, xml_dta FROM t_fal_req_log";
        private const string connectionString = "Server=EDYN-REP-DB-01.CORP.EDYNAMIX.CO.UK\\INTERN;Database=IISFailedRequest;User Id=Uchenici;Password=edynamix12345";

        public static string Query
        {
            get { return query; }
        }
        public static string ConnectionString
        {
            get { return connectionString; }
        }
    }
}
