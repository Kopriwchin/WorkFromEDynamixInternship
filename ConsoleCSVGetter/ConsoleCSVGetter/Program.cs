using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleCSVGetter
{
    class Program
    {
        static void Main(string[] args)
        {
            string queryString =
                ConnectionData.Query;

            string connectionString = ConnectionData.ConnectionString;

            var csvContent = new StringBuilder();
            var xmlEventData = new StringBuilder();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    csvContent.AppendLine(FirstCsvRow(reader));
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount - 1; i++)
                        {
                            csvContent.Append($"\"{reader[i]}\", ");
                        }
                        csvContent.AppendLine();
                        XDocument xml = XDocument.Parse(reader[reader.FieldCount - 1].ToString());

                        var eventData = xml.Root.Elements()
                            .Where(e => e.Name.LocalName == "Event").Elements()
                            .Where(e => e.Name.LocalName == "EventData").ToList();

                        foreach (var data in eventData)
                        {
                            csvContent.AppendLine(data.ToString());
                        }
                        xmlEventData.Clear();
                    }
                }
                File.WriteAllText("../../../CsvFileFolder/csvFile.csv", csvContent.ToString());
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

        //static string PrettyXml(string xml)
        //{
        //    var stringBuilder = new StringBuilder();

        //    var element = XElement.Parse(xml);

        //    var settings = new XmlWriterSettings();
        //    settings.OmitXmlDeclaration = true;
        //    settings.Indent = true;
        //    settings.NewLineOnAttributes = true;

        //    using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
        //    {
        //        element.Save(xmlWriter);
        //    }

        //    return stringBuilder.ToString();
        //}
    }
}
