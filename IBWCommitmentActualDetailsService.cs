using System.Collections.Generic;
using BusinessWarehouseApp.Models;

namespace BusinessWarehouseApp
{
    public interface IBWCommitmentActualDetailsService
    {
        BWCommitmentActualDetails ConvertToOpenCommitment(ZFIITEM zfitem, ZFIHEAD zfhead);
        void Insert(List<BWCommitmentActualDetails> bwCommitmentActualDetails);
    }
}