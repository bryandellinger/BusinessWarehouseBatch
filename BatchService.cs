using BusinessWarehouseApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessWarehouseApp
{
    public class BatchService : IBatchService
    {
        private readonly string connectionString;
        public BatchService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void WriteToEventLog(string message)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into Portal.EventLog (EventMessage, [Type], [Source], CreateDate) values (@message, 'Batch','Business Warehouse', GETDATE())";
            cmd.Parameters.AddWithValue("message", message);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        ZFI_FIFMCO_OUTBOUND IBatchService.getZfiFimcoOutbound(string data)
        {
            var serializer = new XmlSerializer(typeof(ZFI_FIFMCO_OUTBOUND));
            var reader = new StringReader(data);
            return (ZFI_FIFMCO_OUTBOUND)serializer.Deserialize(reader);
        }
    }
}
