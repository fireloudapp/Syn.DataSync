using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.RDS.Sync.DataAccess.Models
{    
    public class CreateTransDetailModel
    {
        [JsonProperty("transID")]
        public int TransID { get; set; }

        [JsonProperty("itemID")]
        public int ItemID { get; set; }

        [JsonProperty("barCode")]
        public string BarCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("inventoryDesc")]
        public string InventoryDesc { get; set; }

        [JsonProperty("stockCode")]
        public string StockCode { get; set; }

        [JsonProperty("void")]
        public int Void { get; set; }

        [JsonProperty("noPriceShift")]
        public int NoPriceShift { get; set; }

        [JsonProperty("categoryNumber")]
        public string CategoryNumber { get; set; }

        [JsonProperty("group1")]
        public string Group1 { get; set; }

        [JsonProperty("group2")]
        public string Group2 { get; set; }

        [JsonProperty("group3")]
        public string Group3 { get; set; }

        [JsonProperty("group4")]
        public string Group4 { get; set; }

        [JsonProperty("group5")]
        public string Group5 { get; set; }

        [JsonProperty("class")]
        public int Class { get; set; }
        [JsonProperty("qty")]
        public double Qty { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("priceType")]
        public int PriceType { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("actualPrice")]
        public double ActualPrice { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("shiftMixedFlag")]
        public int ShiftMixedFlag { get; set; }

        [JsonProperty("quantityShiftType")]
        public int QuantityShiftType { get; set; }

        [JsonProperty("shiftValue")]
        public double ShiftValue { get; set; }

        [JsonProperty("oddDisc")]
        public int OddDisc { get; set; }

        [JsonProperty("realPrice")]
        public double RealPrice { get; set; }

        [JsonProperty("quantityFrom")]
        public double QuantityFrom { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("discQty")]
        public double DiscQty { get; set; }

        [JsonProperty("psDiscAmount")]
        public double PsDiscAmount { get; set; }

        [JsonProperty("psDiscValue")]
        public double PsDisValue { get; set; }

        [JsonProperty("actualPSDiscAmount")]
        public double ActualPSDiscAmount { get; set; }

        [JsonProperty("qtyRemain")]
        public double QtyRemain { get; set; }

        [JsonProperty("totalSoldQty")]
        public double TotalSoldQty { get; set; }

        [JsonProperty("totalDiscQty")]
        public double TotalDiscQty { get; set; }

        [JsonProperty("discType")]
        public int DiscType { get; set; }

        [JsonProperty("discValue")]
        public double DiscValue { get; set; }


        [JsonProperty("manualDisc")]
        public double ManualDisc { get; set; }
        [JsonProperty("points")]
        public double Points { get; set; }

        [JsonProperty("checkout")]
        public int Checkout { get; set; }

        [JsonProperty("takeAway")]
        public int TakeAway { get; set; }

        [JsonProperty("memberDisc")]
        public double MemberDisc { get; set; }

        [JsonProperty("salesMan")]
        public int SalesMan { get; set; }

        [JsonProperty("orderTime")]
        public int OrderTime { get; set; }

        [JsonProperty("printed")]
        public int Printed { get; set; }

        [JsonProperty("bufferPrinted")]
        public int BufferPrinted { get; set; }

        [JsonProperty("priceID")]
        public int PriceID { get; set; }

        [JsonProperty("condimented")]
        public int Condimented { get; set; }

        [JsonProperty("kitchenPrint")]
        public int KitchenPrint { get; set; }

        [JsonProperty("kitchenPrintFlag")]
        public string KitchenPrintFlag { get; set; }

        [JsonProperty("taxAmount1")]
        public double TaxAmount1 { get; set; }

        [JsonProperty("taxAmount2")]
        public double TaxAmount2 { get; set; }

        [JsonProperty("taxAmount3")]
        public double TaxAmount3 { get; set; }

        [JsonProperty("taxAmount4")]
        public double TaxAmount4 { get; set; }

        [JsonProperty("taxAmount5")]
        public double TaxAmount5 { get; set; }

        [JsonProperty("taxAmount6")]
        public double TaxAmount6 { get; set; }

        [JsonProperty("itemStatus")]
        public int ItemStatus { get; set; }

        [JsonProperty("taxableAmount")]
        public double TaxableAmount { get; set; }

        [JsonProperty("taxFlag")]
        public string TaxFlag { get; set; }

        [JsonProperty("taxInfo")]
        public string TaxInfo { get; set; }

        [JsonProperty("parentID")]
        public int ParentID { get; set; }

        [JsonProperty("printedVoid")]
        public int PrintedVoid { get; set; }

        [JsonProperty("voidDate")]
        public DateTime VoidDate { get; set; }

        [JsonProperty("allowDecimalValue")]
        public int AllowDecimalValue { get; set; }

        [JsonProperty("totalDisc")]
        public double TotalDisc { get; set; }

        [JsonProperty("totalMemberDisc")]
        public double TotalMemberDisc { get; set; }

        [JsonProperty("totalPSDisc")]
        public double TotalPSDisc { get; set; }
        [JsonProperty("rdPoints")]
        public double RDPoints { get; set; }

        [JsonProperty("itemSCDiscAmount")]
        public double ItemSCDiscAmount { get; set; }

        [JsonProperty("itemSCDiscValue")]
        public double ItemSCDiscValue { get; set; }
        [JsonProperty("itemSCCovers")]
        public double ItemSCCovers { get; set; }


        [JsonProperty("itemSCRetTaxAmount")]
        public double ItemSCRetTaxAmount { get; set; }

        [JsonProperty("warranty")]
        public int Warranty { get; set; }

        [JsonProperty("unitCost")]
        public double UnitCost { get; set; }

        [JsonProperty("managerID")]
        public int ManagerID { get; set; }

        [JsonProperty("managerName")]
        public string ManagerName { get; set; }

        [JsonProperty("kitchenStatus")]
        public int KitchenStatus { get; set; }

        [JsonProperty("fireQuantity")]
        public int FireQuantity { get; set; }

        [JsonProperty("commission")]
        public int Commission { get; set; }

        [JsonProperty("commissionValue")]
        public double CommissionValue { get; set; }

        [JsonProperty("kdsItemStatus")]
        public int KdsItemStatus { get; set; }

        [JsonProperty("kdsDoneQty")]
        public int KdsDoneQty { get; set; }

        [JsonProperty("kdsItemPriority")]
        public int KdsItemPriority { get; set; }

        [JsonProperty("kdsItemCmptTime")]
        public string KdsItemCmptTime { get; set; }

        [JsonProperty("mParentID")]
        public int MParentID { get; set; }

        [JsonProperty("mChildID")]
        public int MChildID { get; set; }

    }
}
