using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace ConsoleCSVGetter
{
    class Program
    {
        static void Main(string[] args)
        {
            string queryString =
                "SELECT TOP 10 Id,Url,AppPoolId,SiteId,ProcessId,Verb,TokenUserName,AuthenticationType,ActivityId,FailureReason,ReasonDescription,StatusCode,TriggerStatusCode,TimeTaken,StartTime,EndTime,ServerName FROM t_fal_req_log";

            string connectionString = "Server=EDYN-REP-DB-01.CORP.EDYNAMIX.CO.UK\\INTERN;Database=IISFailedRequest;User Id=Uchenici;Password=edynamix12345;";

            var initSb = new StringBuilder();
            var csvContent = new StringBuilder();

            using (SqlConnection connection = new SqlConnection(
               connectionString))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    string firstCsvLine = FirstCsvRow(reader);
                    csvContent.AppendLine(firstCsvLine); 
                    while (reader.Read()) 
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            initSb.Append($"\"{reader[i]}\", ");
                        }
                        initSb.Append($"\"{reader[16]}\"");
                        csvContent.AppendLine(initSb.ToString());
                        initSb.Clear();
                    }
                }
                string csvPath = "D:\\dataInCsv.csv";
                File.AppendAllText(csvPath, csvContent.ToString());
            }
        }
        public static string FirstCsvRow(SqlDataReader reader)
        {
            var columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < columns.Count - 1; i++)
            {
                sb.Append($"\"{columns[i]}\", ");
            }
            sb.Append($"\"{columns[columns.Count - 1]}\"");

            return sb.ToString();
        }
    }
}
