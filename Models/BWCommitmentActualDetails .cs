using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessWarehouseApp.Models
{
    public class BWCommitmentActualDetails
    {
        public int FiscalYear { get; set; }

        public int Period { get; set; }

        public int ICSOrg { get; set; }

        public string AmountType { get; set; }

        public string AmountTypeDescription { get; set; }

        public string AppropFiscalYr { get; set; }

        public string AppropLedgerCd { get; set; }

        public string Appropriation { get; set; }

        public string BusinessArea { get; set; }

        public string BusinessAreaDescription { get; set; }

        public string CIAvailCntrlLvl { get; set; }

        public string CommitmentItem { get; set; }

        public string CommtActualDetail { get; set; }

        public string CostCenter { get; set; }

        public string CostCenterShortCode { get; set; }

        public string CostCenterDescription { get; set; }

        public DateTime? DateOfUpdate { get; set; }

        public string DepOrSecLvl { get; set; }

        public string DocumentItem { get; set; }

        public string DocumentType { get; set; }

        public string DocumentTypeDescription { get; set; }

        public string FCL2BW { get; set; }

        public string FIDocPstngLines { get; set; }

        public string FIDocumentNumber { get; set; }

        public string FMDocumentNumber { get; set; }

        public string FundCenterLevel3 { get; set; }

        public string FundCenterLevel4 { get; set; }

        public string FundSourceForFund { get; set; }

        public string FundType { get; set; }

        public string Fund { get; set; }

        public string FundsCenter { get; set; }

        public string GLAccount { get; set; }

        public string Ledger { get; set; }

        public string OrderAgencyDefin { get; set; }

        public string Order { get; set; }

        public string PredecessorDocumentNumber { get; set; }

        public string RefDocumentNumber { get; set; }

        public string SalesDocType { get; set; }

        public string Vendor { get; set; }

        public string VendorDescription { get; set; }

        public string WBSElement { get; set; }

        public string WBSElementDescription { get; set; }

        public decimal? PurchaseRequisitions { get; set; }

        public decimal? PreCommitments { get; set; }

        public decimal? Commitments { get; set; }

        public decimal? ActualExpenditures { get; set; }

        public decimal? ActualAugmentations { get; set; }

        public decimal? NonAugmentingRevenue { get; set; }
        public string AccountingDocumentNumber { get; set; }
        public DateTime? DocumentDateInDocument { get; set; }
        public DateTime? DayOnWhichAcctDocEntered { get; set; }
        public string TimeOfEntry { get; set; }
        public DateTime? DateOfLastDocChanged { get; set; }
        public string UserName { get; set; }
        public string TransactionCode { get; set; }
        public string RecurringEntryDocNumber { get; set; }
        public string ReverseDocumentNumber { get; set; }
        public string DocumentHeaderText { get; set; }
        public string ReferenceTransaction{ get; set; }
        public string ReferenceKey { get; set; }

        public int NumberOfLineItemInAcctDoc { get; set; }
        public DateTime? ClearingDate { get; set; }
        public DateTime? ClearingEntryDate { get; set; }
        public string DocumentNumberOfTheClearingDocument { get; set; }
        public string PostingKey { get; set; }
        public string DebitCreditIndicator { get; set; }
        public string  AmountInLocalCurrency { get; set; }
        public DateTime? ValueDate { get; set; }
        public string AssignmentNumber { get; set; }
        public string  ItemText { get; set; }
        public string AccountNumberOfVendorOrCreditor { get; set; }
        public string PaymentBlockKey { get; set; }
        public string PurchasingDocumentNumber { get; set; }
        public string  ItemNumberOfPurchasingDocument { get; set; }
        public string ContractType { get; set; }
        public string ContractNumber { get; set; }
        public string BudgetPeriod { get; set; }
        public string DocumentNumberOfEarmarkedFunds { get; set; }
        public string LineItem{ get; set; }
        public string Amount { get; set; }
        public string ObjectNumber { get; set; }
        public string ValueType { get; set; }
    }
}
