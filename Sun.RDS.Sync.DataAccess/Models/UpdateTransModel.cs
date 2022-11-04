﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.RDS.Sync.DataAccess.Models
{
    public class UpdateTransModel
    {
        public int TransID { get; set; }

        public string TransNo { get; set; }

        public int TermID { get; set; }

        public DateTime TransDate { get; set; }

        public DateTime LastDate { get; set; }

        public DateTime TransTime { get; set; }

        public string CustomerNumber { get; set; }

        public int CashierID { get; set; }

        public string CashierName { get; set; }

        public int SalesPersonID { get; set; }

        public string SalesPersonName { get; set; }

        public int HasSalesMan { get; set; }

       
        public double SubTotal { get; set; }

        
        public double TaxAmount1 { get; set; }

        
        public double TaxAmount2 { get; set; }

        
        public double TaxAmount3 { get; set; }

        
        public double TaxAmount4 { get; set; }

        
        public double TaxAmount5 { get; set; }

        
        public double TaxAmount6 { get; set; }

        public double Total { get; set; }

        
        public int DiscType { get; set; }

        
        public double DiscAmount { get; set; }
        
        public double DiscValue { get; set; }
       
        public double Points { get; set; }

        [JsonProperty("transStatus")]
        public int TransStatus { get; set; }

        [JsonProperty("manualKey")]
        public string ManualKey { get; set; }

        [JsonProperty("checkOut")]
        public int CheckOut { get; set; }

        [JsonProperty("round")]
        public double Round { get; set; }

        [JsonProperty("memberDiscAmount")]
        public double MemberDiscAmount { get; set; }

        [JsonProperty("memberDiscValue")]
        public double MemberDiscValue { get; set; }

        [JsonProperty("birthDayDiscAmount")]
        public double BirthDayDiscAmount { get; set; }

        [JsonProperty("birthDayDiscValue")]
        public double BirthDayDiscValue { get; set; }


        [JsonProperty("scDiscAmount")]
        public double ScDiscAmount { get; set; }

        [JsonProperty("scDiscValue")]
        public double ScDiscValue { get; set; }
        [JsonProperty("sCCovers")]
        public double SCCovers { get; set; }


        [JsonProperty("scRetTaxAmount")]
        public double ScRetTaxAmount { get; set; }

        [JsonProperty("asDiscAmount")]
        public double AsDiscAmount { get; set; }

        [JsonProperty("asDiscValue")]
        public double AsDiscValue { get; set; }

        [JsonProperty("printed")]
        public int Printed { get; set; }

        [JsonProperty("covers")]
        public int Covers { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("paidTotal")]
        public double PaidTotal { get; set; }

        [JsonProperty("timeStampId")]
        public int TimeStampId { get; set; }

        [JsonProperty("businessDate")]
        public DateTime BusinessDate { get; set; }

        [JsonProperty("voucherTotal")]
        public double VoucherTotal { get; set; }

        [JsonProperty("rdPointsTotal")]
        public double RDPointsTotal { get; set; }

        [JsonProperty("rdFlag")]
        public int RdFlag { get; set; }

        [JsonProperty("rdPointsAmount")]
        public double RDPointsAmount { get; set; }

        [JsonProperty("rdPointValue")]
        public double RDPointValue { get; set; }

        [JsonProperty("tableMenuID")]
        public string TableMenuID { get; set; }

        [JsonProperty("deliverCustNo")]
        public string DeliverCustNo { get; set; }

        [JsonProperty("pdDiscAmount")]
        public double PdDiscAmount { get; set; }

        [JsonProperty("pdDiscValue")]
        public double PdDiscValue { get; set; }

        [JsonProperty("pdCovers")]
        public double PdCovers { get; set; }

        [JsonProperty("geRetTaxAmount")]
        public double GeRetTaxAmount { get; set; }

        [JsonProperty("geCovers")]
        public double GECovers { get; set; }

        [JsonProperty("managerID")]
        public int ManagerID { get; set; }

        [JsonProperty("managerName")]
        public string ManagerName { get; set; }

        [JsonProperty("sendFlag")]
        public int SendFlag { get; set; }

        [JsonProperty("editTransID")]
        public int EditTransID { get; set; }

        [JsonProperty("orderID")]
        public int OrderID { get; set; }

        [JsonProperty("splitBill")]
        public int SplitBill { get; set; }

        [JsonProperty("dueDays")]
        public int DueDays { get; set; }

        [JsonProperty("dueType")]
        public string DueType { get; set; }

        [JsonProperty("previousPoints")]
        public double PreviousPoints { get; set; }

        [JsonProperty("kdsOrderStatus")]
        public int KdsOrderStatus { get; set; }

        [JsonProperty("kdsPriority")]
        public int KdsPriority { get; set; }

        [JsonProperty("kdsCmptTime")]
        public DateTime KdsCmptTime { get; set; }

        [JsonProperty("pdRetTaxAmount")]
        public double PdRetTaxAmount { get; set; }

        [JsonProperty("dOaddress")]
        public string DOaddress { get; set; }

        [JsonProperty("printHold")]
        public int PrintHold { get; set; }

        [JsonProperty("advCustomerID")]
        public string AdvCustomerID { get; set; }

        [JsonProperty("advCountryCode")]
        public string AdvCountryCode { get; set; }

        [JsonProperty("advSVBal")]
        public double AdvSVBal { get; set; }

        [JsonProperty("advVBal")]
        public double AdvVBal { get; set; }

        [JsonProperty("advLPoints")]
        public double AdvLPoints { get; set; }

        [JsonProperty("advLLPoints")]
        public double AdvLLPoints { get; set; }

        [JsonProperty("advLPID")]
        public string AdvLPID { get; set; }

        [JsonProperty("advLPRID")]
        public string AdvLPRID { get; set; }

        [JsonProperty("advSKURID")]
        public string AdvSKURID { get; set; }

        [JsonProperty("advCashBack")]
        public double AdvCashBack { get; set; }

        [JsonProperty("advLCashBack")]
        public double AdvLCashBack { get; set; }

        [JsonProperty("advCBID")]
        public string AdvCBID { get; set; }

        [JsonProperty("advCBRID")]
        public string AdvCBRID { get; set; }

        [JsonProperty("stbcpPrev")]
        public double StbcpPrev { get; set; }

        [JsonProperty("stbcpBal")]
        public double StbcpBal { get; set; }

        [JsonProperty("userid")]
        public int Userid { get; set; }

        [JsonProperty("olStatus")]
        public string OlStatus { get; set; }

        [JsonProperty("deliveryDate")]
        public string DeliveryDate { get; set; }
    }
}
