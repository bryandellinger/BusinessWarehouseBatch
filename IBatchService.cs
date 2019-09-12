using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessWarehouseApp.Models;

namespace BusinessWarehouseApp
{
    public interface IBatchService
    {
        void WriteToEventLog(string message);
        ZFI_FIFMCO_OUTBOUND getZfiFimcoOutbound(string data);
    }
}
