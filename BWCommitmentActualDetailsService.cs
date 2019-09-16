using System;
using System.Collections.Generic;
using BusinessWarehouseApp.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace BusinessWarehouseApp
{
    public class BWCommitmentActualDetailsService : IBWCommitmentActualDetailsService
    {
        private readonly string connectionString;
        public BWCommitmentActualDetailsService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
  
        }
        public BWCommitmentActualDetails ConvertToOpenCommitment(ZFIITEM zfitem, ZFIHEAD zfhead)
        {
            BWCommitmentActualDetails bwCommitmentActualDetails = new BWCommitmentActualDetails();

            bwCommitmentActualDetails.FiscalYear = ConvertStringToInt(zfhead.GJAHR);
            bwCommitmentActualDetails.Period = ConvertStringToInt(zfhead.MONAT);
            bwCommitmentActualDetails.AmountType = zfitem.BTART;
            bwCommitmentActualDetails.BusinessArea = zfitem.GSBER;
            bwCommitmentActualDetails.CommitmentItem = zfitem.FIPOS;
            bwCommitmentActualDetails.CostCenter = zfitem.KOSTL;
            bwCommitmentActualDetails.CostCenterShortCode = zfitem.KOSTL == null || zfitem.KOSTL.Length <= 7 ? zfitem.KOSTL : zfitem.KOSTL.Substring(0, 7);
            bwCommitmentActualDetails.DateOfUpdate =  getDate(zfhead.BUDAT);
            bwCommitmentActualDetails.DocumentItem = zfitem.KBLPOS;
            bwCommitmentActualDetails.DocumentType = zfhead.BLART;
            bwCommitmentActualDetails.FIDocumentNumber = zfitem.REFBN;
            bwCommitmentActualDetails.Fund = zfitem.GEBER;
            bwCommitmentActualDetails.FundsCenter = zfitem.FISTL;
            bwCommitmentActualDetails.GLAccount = zfitem.HKONT;
            bwCommitmentActualDetails.Order = zfitem.AUFNR;
            bwCommitmentActualDetails.RefDocumentNumber = zfitem.XBLNR;
            bwCommitmentActualDetails.WBSElement = zfitem.PROJK;
            //added attributes
            bwCommitmentActualDetails.AccountingDocumentNumber = zfhead.BELNR;
            bwCommitmentActualDetails.DocumentDateInDocument = getDate(zfhead.BLDAT);
            bwCommitmentActualDetails.DayOnWhichAcctDocEntered  = getDate(zfhead.CPUDT);
            bwCommitmentActualDetails.TimeOfEntry = zfhead.CPUTM;
            bwCommitmentActualDetails.DateOfLastDocChanged = getDate(zfhead.AEDAT);
            bwCommitmentActualDetails.UserName = zfhead.USNAM;
            bwCommitmentActualDetails.TransactionCode = zfhead.TCODE;
            bwCommitmentActualDetails.RecurringEntryDocNumber = zfhead.DBBLG;
            bwCommitmentActualDetails.ReverseDocumentNumber = zfhead.STBLG;
            bwCommitmentActualDetails.DocumentHeaderText = zfhead.BKTXT;
            bwCommitmentActualDetails.ReferenceTransaction = zfhead.AWTYP;
            bwCommitmentActualDetails.ReferenceKey = zfhead.AWKEY;
            bwCommitmentActualDetails.NumberOfLineItemInAcctDoc = ConvertStringToInt(zfitem.BUZEI);
            bwCommitmentActualDetails.ClearingDate = getDate(zfitem.AUGDT);
            bwCommitmentActualDetails.ClearingEntryDate = getDate(zfitem.AUGCP);
            bwCommitmentActualDetails.DocumentNumberOfTheClearingDocument = zfitem.AUGBL;
            bwCommitmentActualDetails.PostingKey = zfitem.BSCHL;
            bwCommitmentActualDetails.DebitCreditIndicator = zfitem.SHKZG;
            bwCommitmentActualDetails.AmountInLocalCurrency = zfitem.DMBTR;
            bwCommitmentActualDetails.ValueDate = getDate(zfitem.VALUT);
            bwCommitmentActualDetails.AssignmentNumber = zfitem.ZUONR;
            bwCommitmentActualDetails.ItemText = zfitem.SGTXT;
            bwCommitmentActualDetails.AccountNumberOfVendorOrCreditor = zfitem.LIFNR;
            bwCommitmentActualDetails.PaymentBlockKey = zfitem.ZLSPR;
            bwCommitmentActualDetails.PurchasingDocumentNumber = zfitem.EBELN;
            bwCommitmentActualDetails.ItemNumberOfPurchasingDocument = zfitem.EBELP;
            bwCommitmentActualDetails.ContractType = zfitem.VERTT;
            bwCommitmentActualDetails.BudgetPeriod = zfitem.BUDGET_PD;
            bwCommitmentActualDetails.DocumentNumberOfEarmarkedFunds = zfitem.KBLNR;
            bwCommitmentActualDetails.LineItem = zfitem.RFPOS;
            bwCommitmentActualDetails.Amount = zfitem.FKBTR;
            bwCommitmentActualDetails.ObjectNumber = zfitem.OBJNRZ;
            bwCommitmentActualDetails.ValueType = zfitem.WRTTP;

            return bwCommitmentActualDetails;
        }

        private DateTime? getDate(string s)
        {
            try
            {
                if (String.IsNullOrEmpty(s)){
                    return null;
                }
            else
                {
                    return DateTime.ParseExact(s, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                }
              
            }
            catch (Exception)
            {

                return null;
            }
        }

        private int ConvertStringToInt(string s)
        {
            int i = 0;
            if (!Int32.TryParse(s, out i))
            {
                i = -1;
            }
            return i;
        }

        public void Insert(List<BWCommitmentActualDetails> bwCommitmentActualDetails)
        {
            var dt = new DataTable();
            dt.Columns.Add("BWCommitmentActualDetailId");
            dt.Columns.Add("FiscalYear"); //GJAHR
            dt.Columns.Add("Period"); //MONAT
            dt.Columns.Add("ICSOrg"); //not provided in file
            dt.Columns.Add("AmountType"); //BTART
            dt.Columns.Add("AmountTypeDescription");  //not provided in file
            dt.Columns.Add("AppropFiscalYr");  //not provided in file
            dt.Columns.Add("AppropLedgerCd");  //not provided in file
            dt.Columns.Add("Appropriation");  //not provided in file
            dt.Columns.Add("BusinessArea");   //GSBER
            dt.Columns.Add("BusinessAreaDescription"); //not provided in file
            dt.Columns.Add("CIAvailCntrlLvl"); //not provided in file
            dt.Columns.Add("CommitmentItem"); //FIPOS
            dt.Columns.Add("CommtActualDetail"); //not provided in file
            dt.Columns.Add("CostCenter"); //KOSTL
            dt.Columns.Add("CostCenterShortCode"); //first 7 of KOSTL
            dt.Columns.Add("CostCenterDescription"); //not provided in file
            dt.Columns.Add("DateOfUpdate"); //BUDAT
            dt.Columns.Add("DepOrSecLvl"); //not provided in file
            dt.Columns.Add("DocumentItem"); //KBLPOS
            dt.Columns.Add("DocumentType"); //BLART
            dt.Columns.Add("DocumentTypeDescription"); //not provided in file
            dt.Columns.Add("FCL2BW"); //not provided in file
            dt.Columns.Add("FIDocPstngLines"); //not provided in file
            dt.Columns.Add("FIDocumentNumber"); //REFBN
            dt.Columns.Add("FMDocumentNumber"); //not provided in file
            dt.Columns.Add("FundCenterLevel3"); // not provided in file
            dt.Columns.Add("FundCenterLevel4"); // not provided in file
            dt.Columns.Add("FundSourceForFund"); // not provided in file
            dt.Columns.Add("FundType"); // not provided in file
            dt.Columns.Add("Fund"); //GEBER
            dt.Columns.Add("FundsCenter"); //FISTL,
            dt.Columns.Add("GLAccount"); //HKONT
            dt.Columns.Add("Ledger"); // not provided in file
            dt.Columns.Add("OrderAgencyDefin"); // not provided in file
            dt.Columns.Add("Order"); //AUFNR
            dt.Columns.Add("PredecessorDocumentNumber"); // not provided in file
            dt.Columns.Add("RefDocumentNumber"); //XBLNR
            dt.Columns.Add("SalesDocType"); // not provided in file
            dt.Columns.Add("Vendor"); // not provided in file
            dt.Columns.Add("VendorDescription"); // not provided in file
            dt.Columns.Add("WBSElement"); //PROJK
            dt.Columns.Add("PurchaseRequisitions"); // not provided in file
            dt.Columns.Add("PreCommitments"); // not provided in file
            dt.Columns.Add("Commitments"); // not provided in file
            dt.Columns.Add("ActualExpenditures"); // not provided in file
            dt.Columns.Add("ActualAugmentations"); // not provided in file
            dt.Columns.Add("NonAugmentingRevenue"); // not provided in file
            dt.Columns.Add("CreatedDate");
            //***************ADDED COLUMNS******************************//
            dt.Columns.Add("AccountingDocumentNumber"); //BELNR
            dt.Columns.Add("DocumentDateInDocument"); //BLDAT
            dt.Columns.Add("DayOnWhichAcctDocEntered"); //CPUDT
            dt.Columns.Add("TimeOfEntry"); //CPUTM
            dt.Columns.Add("DateOfLastDocChanged"); //AEDAT
            dt.Columns.Add("UserName"); //USNAME
            dt.Columns.Add("TransactionCode"); //TCODE
            dt.Columns.Add("RecurringEntryDocNumber"); //DBBLG
            dt.Columns.Add("ReverseDocumentNumber"); //STBLG
            dt.Columns.Add("DocumentHeaderText"); //BKTXT
            dt.Columns.Add("ReferenceTransaction"); //AWTYP
            dt.Columns.Add("ReferenceKey"); //AWKEY
            dt.Columns.Add("NumberOfLineItemInAcctDoc"); //BUZEI
            dt.Columns.Add("ClearingDate"); //AUGDT
            dt.Columns.Add("ClearingEntryDate"); //AUGCP
            dt.Columns.Add("DocumentNumberOfTheClearingDocument"); //AUGBL
            dt.Columns.Add("PostingKey"); //BSCHL
            dt.Columns.Add("DebitCreditIndicator"); //SHKZG
            dt.Columns.Add("AmountInLocalCurrency"); //DMBTR
            dt.Columns.Add("ValueDate"); //VALUT
            dt.Columns.Add("AssignmentNumber"); //ZUONR
            dt.Columns.Add("ItemText"); //SGTXT
            dt.Columns.Add("AccountNumberOfVendorOrCreditor"); //LIFNR
            dt.Columns.Add("PaymentBlockKey"); //ZLSPR
            dt.Columns.Add("PurchasingDocumentNumber"); //EBELN
            dt.Columns.Add("ItemNumberOfPurchasingDocument"); //EBELP
            dt.Columns.Add("ContractType"); //VERTT
            dt.Columns.Add("ContractNumber"); //VERTN
            dt.Columns.Add("BudgetPeriod"); //BUDGET_PD
            dt.Columns.Add("DocumentNumberOfEarmarkedFunds"); //KBLNR
            dt.Columns.Add("LineItem"); //RFPOS
            dt.Columns.Add("Amount"); //FKBTR
            dt.Columns.Add("ObjectNumber"); //OBJNRZ
            dt.Columns.Add("ValueType"); //OBJNRZ



            foreach (BWCommitmentActualDetails bwCommitmentActualDetail in bwCommitmentActualDetails)
            {
                dt.Rows.Add(1,
                            getIntValue(bwCommitmentActualDetail.FiscalYear),
                            getIntValue(bwCommitmentActualDetail.Period),
                            bwCommitmentActualDetail.ICSOrg,
                            bwCommitmentActualDetail.AmountType,
                            bwCommitmentActualDetail.AmountTypeDescription,
                            bwCommitmentActualDetail.AppropFiscalYr,
                            bwCommitmentActualDetail.AppropLedgerCd,
                            bwCommitmentActualDetail.Appropriation,
                            bwCommitmentActualDetail.BusinessArea,
                            bwCommitmentActualDetail.BusinessAreaDescription,
                            bwCommitmentActualDetail.CIAvailCntrlLvl,
                            bwCommitmentActualDetail.CommitmentItem,
                            bwCommitmentActualDetail.CommtActualDetail,
                            bwCommitmentActualDetail.CostCenter,
                            bwCommitmentActualDetail.CostCenterShortCode,
                            bwCommitmentActualDetail.CostCenterDescription,
                            bwCommitmentActualDetail.DateOfUpdate,
                            bwCommitmentActualDetail.DepOrSecLvl,
                            bwCommitmentActualDetail.DocumentItem,
                            bwCommitmentActualDetail.DocumentType,
                            bwCommitmentActualDetail.DocumentTypeDescription,
                            bwCommitmentActualDetail.FCL2BW,
                            bwCommitmentActualDetail.FIDocPstngLines,
                            bwCommitmentActualDetail.FIDocumentNumber,
                            bwCommitmentActualDetail.FMDocumentNumber,
                            bwCommitmentActualDetail.FundCenterLevel3,
                            bwCommitmentActualDetail.FundCenterLevel4,
                            bwCommitmentActualDetail.FundSourceForFund,
                            bwCommitmentActualDetail.FundType,
                            bwCommitmentActualDetail.Fund,
                            bwCommitmentActualDetail.FundsCenter,
                            bwCommitmentActualDetail.GLAccount,
                            bwCommitmentActualDetail.Ledger,
                            bwCommitmentActualDetail.OrderAgencyDefin,
                            bwCommitmentActualDetail.Order,
                            bwCommitmentActualDetail.PredecessorDocumentNumber,
                            bwCommitmentActualDetail.RefDocumentNumber,
                            bwCommitmentActualDetail.SalesDocType,
                            bwCommitmentActualDetail.Vendor,
                            bwCommitmentActualDetail.VendorDescription,
                            bwCommitmentActualDetail.WBSElement,
                            bwCommitmentActualDetail.PurchaseRequisitions,
                            bwCommitmentActualDetail.PreCommitments,
                            bwCommitmentActualDetail.Commitments,
                            bwCommitmentActualDetail.ActualExpenditures,
                            bwCommitmentActualDetail.ActualAugmentations,
                            bwCommitmentActualDetail.NonAugmentingRevenue,
                            DateTime.Now,
                            bwCommitmentActualDetail.AccountingDocumentNumber,
                            bwCommitmentActualDetail.DocumentDateInDocument,
                            bwCommitmentActualDetail.DayOnWhichAcctDocEntered,
                            bwCommitmentActualDetail.TimeOfEntry,
                            bwCommitmentActualDetail.DateOfLastDocChanged,
                            bwCommitmentActualDetail.UserName,
                            bwCommitmentActualDetail.TransactionCode,
                            bwCommitmentActualDetail.RecurringEntryDocNumber,
                            bwCommitmentActualDetail.ReverseDocumentNumber,
                            bwCommitmentActualDetail.DocumentHeaderText,
                            bwCommitmentActualDetail.ReferenceTransaction,
                            bwCommitmentActualDetail.ReferenceKey,
                            bwCommitmentActualDetail.NumberOfLineItemInAcctDoc,
                            bwCommitmentActualDetail.ClearingDate,
                            bwCommitmentActualDetail.ClearingEntryDate,
                            bwCommitmentActualDetail.DocumentNumberOfTheClearingDocument,
                            bwCommitmentActualDetail.PostingKey,
                            bwCommitmentActualDetail.DebitCreditIndicator,
                            bwCommitmentActualDetail.AmountInLocalCurrency,
                            bwCommitmentActualDetail.ValueDate,
                            bwCommitmentActualDetail.AssignmentNumber,
                            bwCommitmentActualDetail.ItemText,
                            bwCommitmentActualDetail.AccountNumberOfVendorOrCreditor,
                            bwCommitmentActualDetail.PaymentBlockKey,
                            bwCommitmentActualDetail.PurchasingDocumentNumber,
                            bwCommitmentActualDetail.ItemNumberOfPurchasingDocument,
                            bwCommitmentActualDetail.ContractType,
                            bwCommitmentActualDetail.ContractNumber,
                            bwCommitmentActualDetail.BudgetPeriod,
                            bwCommitmentActualDetail.DocumentNumberOfEarmarkedFunds,
                            bwCommitmentActualDetail.LineItem,
                            bwCommitmentActualDetail.Amount,
                            bwCommitmentActualDetail.ObjectNumber,
                             bwCommitmentActualDetail.ValueType
                            );
                  
            }

            using (SqlBulkCopy bc = new SqlBulkCopy(connectionString))
            {
                bc.DestinationTableName = "[Fiscal].[BWCommitmentActualDetailsTest]";
                bc.WriteToServer(dt);
            }
        }

        private object getIntValue(int i) => i >= 0 ? i.ToString() : null;
       
    }
}