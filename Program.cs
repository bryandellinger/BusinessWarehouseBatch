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
        private readonly IBatchService batchService;
        private readonly IBWCommitmentActualDetailsService bwCommitmentActualDetailsService;

        public Program(IBatchService batchservice, IBWCommitmentActualDetailsService bwcommitmentactualdetailsaervice) 
        {
            bwCommitmentActualDetailsService = bwcommitmentactualdetailsaervice;
            batchService = batchservice;
            filesToProcessPath = ConfigurationManager.AppSettings["FilesToProcessPath"];
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            processedPath = Path.Combine(filesToProcessPath, "Processed");
        }
        static void Main(string[] args)
        {
            var p = new Program(new BatchService(), new BWCommitmentActualDetailsService());
            p.batchService.WriteToEventLog("Business Warehouse Batch -- Starting");
            try
            {
                if (Directory.EnumerateFiles(p.filesToProcessPath).Count() < 1)
                {
                    p.batchService.WriteToEventLog($"Business Warehouse Batch Error: there are no files to process in {p.filesToProcessPath}");
                }
                else
                {
                    foreach (var file in Directory.EnumerateFiles(p.filesToProcessPath))
                    {
                        p.batchService.WriteToEventLog($"Starting to process  { Path.GetFileName(file)}");
                        List<BWCommitmentActualDetails> bwCommitmentActualDetails = new List<BWCommitmentActualDetails>();
                        ZFI_FIFMCO_OUTBOUND iesData = p.batchService.getZfiFimcoOutbound(File.ReadAllText(file));
                        foreach (ZFIFMCOKEY zfifmcokey in iesData.ZFIFMCOKEY)
                        {
                            if (zfifmcokey.ZFIHEAD != null)
                            {
                                foreach (ZFIITEM zfitem in zfifmcokey?.ZFIHEAD.ZFIITEM)
                                {
                                    bwCommitmentActualDetails.Add(p.bwCommitmentActualDetailsService.ConvertToOpenCommitment(zfitem, zfifmcokey.ZFIHEAD));
                                }
                            }
                        }
                        p.bwCommitmentActualDetailsService.Insert(bwCommitmentActualDetails);
                        File.Move(file, Path.Combine(p.processedPath, Path.GetFileName(file)));
                        p.batchService.WriteToEventLog($"Completed processing  { Path.GetFileName(file)}");

                    }
                }
            }
            catch (Exception ex)
            {
                if (ex != null && !string.IsNullOrEmpty(ex.Message))
                {
                    p.batchService.WriteToEventLog($"Business Warehouse Batch Error: {ex.Message}");
                }
                else
                {
                    p.batchService.WriteToEventLog($"Business Warehouse Batch Error");
                }
              
                throw;
            }
        }

    }
}
