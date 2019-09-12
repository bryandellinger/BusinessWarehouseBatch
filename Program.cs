using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BusinessWarehouseApp.Models;

namespace BusinessWarehouseApp
{
    class Program
    {
        private readonly string filesToProcessPath;
        private readonly string processedPath;
        private readonly string connectionString;
        private readonly IBatchService service;

        public Program(IBatchService batchservice)
        {
            service = batchservice;
            filesToProcessPath = ConfigurationManager.AppSettings["FilesToProcessPath"];
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            processedPath = Path.Combine(filesToProcessPath, "Processed");
        }
        static void Main(string[] args)
        {
            var p = new Program(new BatchService());
            p.service.WriteToEventLog("Business Warehouse Batch -- Starting");
            try
            {
                if (Directory.EnumerateFiles(p.filesToProcessPath).Count() < 1)
                {
                    p.service.WriteToEventLog($"Business Warehouse Batch Error: there are no files to process in {p.filesToProcessPath}");
                }
                else
                {
                    foreach (var file in Directory.EnumerateFiles(p.filesToProcessPath))
                    {
                        p.service.WriteToEventLog($"Starting to process  { Path.GetFileName(file)}");
                        ZFI_FIFMCO_OUTBOUND iesData = p.service.getZfiFimcoOutbound(File.ReadAllText(file));
                        File.Move(file, Path.Combine(p.processedPath, Path.GetFileName(file)));
                        p.service.WriteToEventLog($"Completed processing  { Path.GetFileName(file)}");

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
