using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DataSync.Domain.Generate
{
    public class TransGenerateCode
    {
        public static TransactionModel GetTrans()
        {
            TransactionModel transactionModel = new TransactionModel();
            transactionModel.ModelTypeValue = Enumerables.ModelType.Trans;

            #region Trans
            var fakeTrans = new Faker<Trans>()
                .RuleFor(o => o.TransID, f => f.Random.Int(min: 1, max: 200))
                .RuleFor(o => o.TransNo, f => f.Random.Replace("000###"))
                .RuleFor(o => o.TermID, f => f.Random.Int(min: 1, max: 20))
                .RuleFor(o => o.TransDate, DateTime.Now)
                .RuleFor(o => o.LastDate, DateTime.Now)
                .RuleFor(o => o.TransTime, DateTime.Now)
                .RuleFor(o => o.CustomerNumber, f => f.Random.Replace("###"))
                .RuleFor(o => o.CashierID, f => f.Random.Int(min: 1, max: 20))
                .RuleFor(o => o.CashierName, f => f.Person.FirstName)

                .RuleFor(o => o.SalesPersonID, f => f.Random.Int(min: 1, max: 20))
                .RuleFor(o => o.SalesPersonName, f => f.Person.FirstName)
                .RuleFor(o => o.HasSalesMan, f => f.Random.Int(min: 0, max: 1))
                .RuleFor(o => o.SubTotal, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.TaxAmount1, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.TaxAmount2, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.TaxAmount3, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.TaxAmount4, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.TaxAmount5, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.TaxAmount6, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.Total, f => f.Random.Double(min: 10, max: 60))

                .RuleFor(o => o.DiscType, f => f.Random.Int(min: 1, max: 20))
                .RuleFor(o => o.DiscAmount, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.DiscValue, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.Points, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.TransStatus, f => f.Random.Int(min: 1, max: 20))
                .RuleFor(o => o.ManualKey, f => f.Random.Replace("O-*"))
                .RuleFor(o => o.CheckOut, f => f.Random.Int(min: 1, max: 20))
                .RuleFor(o => o.Round, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.MemberDiscAmount, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.MemberDiscValue, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.BirthDayDiscAmount, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.BirthDayDiscValue, f => f.Random.Double(min: 1, max: 20))

                .RuleFor(o => o.ScDiscAmount, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.ScDiscValue, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.SCCovers, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.ScRetTaxAmount, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.AsDiscAmount, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.AsDiscValue, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.Printed, f => f.Random.Int(min: 1, max: 20))
                .RuleFor(o => o.Covers, f => f.Random.Int(min: 1, max: 20))
                .RuleFor(o => o.Notes, f => f.Person.Company.Name)
                .RuleFor(o => o.PaidTotal, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.TimeStampId, f => f.Random.Int(min: 1, max: 20))

                .RuleFor(o => o.BusinessDate, DateTime.Now)
                .RuleFor(o => o.VoucherTotal, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.RDPointsTotal, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.RdFlag, f => f.Random.Int(min: 0, max: 1))
                .RuleFor(o => o.RDPointsAmount, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.RDPointValue, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.TableMenuID, f => f.Random.Replace("##"))
                .RuleFor(o => o.DeliverCustNo, f => f.Random.Replace("##"))
                .RuleFor(o => o.PdDiscAmount, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.PdDiscValue, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.PdCovers, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.GeRetTaxAmount, f => f.Random.Double(min: 1, max: 20))

                .RuleFor(o => o.GECovers, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.ManagerID, f => f.Random.Int(min: 1, max: 20))
                .RuleFor(o => o.ManagerName, f => f.Person.FirstName)
                .RuleFor(o => o.SendFlag, f => f.Random.Int(min: 0, max: 1))
                .RuleFor(o => o.EditTransID, f => f.Random.Int(min: 1, max: 20))
                .RuleFor(o => o.OrderID, f => f.Random.Int(min: 1, max: 20))
                .RuleFor(o => o.SplitBill, f => f.Random.Int(min: 1, max: 20))
                .RuleFor(o => o.DueDays, f => f.Random.Int(min: 1, max: 20))
                .RuleFor(o => o.DueType, f => f.Random.Replace("**"))
                .RuleFor(o => o.PreviousPoints, f => f.Random.Double(min: 1, max: 20))

                .RuleFor(o => o.KdsOrderStatus, f => f.Random.Int(min: 1, max: 20))
                .RuleFor(o => o.KdsPriority, f => f.Random.Int(min: 1, max: 20))
                .RuleFor(o => o.KdsCmptTime, DateTime.Now)
                .RuleFor(o => o.PdRetTaxAmount, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.DOaddress, f => f.Person.Address.State)
                .RuleFor(o => o.PrintHold, f => f.Random.Int(min: 1, max: 20))
                .RuleFor(o => o.AdvCustomerID, f => f.Random.Replace("##"))
                .RuleFor(o => o.AdvCountryCode, f => f.Random.Replace("**"))

                .RuleFor(o => o.AdvSVBal, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.AdvVBal, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.AdvLPoints, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.AdvLLPoints, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.AdvLPID, f => f.Random.Replace("##"))
                .RuleFor(o => o.AdvLPRID, f => f.Random.Replace("##"))
                .RuleFor(o => o.AdvSKURID, f => f.Random.Replace("##"))
                .RuleFor(o => o.AdvCashBack, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.AdvLCashBack, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.AdvCBID, f => f.Random.Replace("##"))
                .RuleFor(o => o.AdvCBRID, f => f.Random.Replace("##"))
                .RuleFor(o => o.StbcpPrev, f => f.Random.Double(min: 1, max: 20))
                .RuleFor(o => o.StbcpBal, f => f.Random.Double(min: 1, max: 20))

                .RuleFor(o => o.Userid, f => f.Random.Int(min: 1, max: 20))
                .RuleFor(o => o.OlStatus, f => f.Random.Replace("##"))
                .RuleFor(o => o.DeliveryDate, DateTime.Now.ToShortDateString())
                ;
            #endregion

            var trans = fakeTrans.Generate();
            IList<TransDetail> transDetailsList = new List<TransDetail>();

            //Loop for 5 Times
            for (int transCount = 1; transCount <= 3; transCount++)
            {
                #region Trans Details

                var fakeTransDetail = new Faker<TransDetail>()
                    .RuleFor(o => o.ItemID, f => f.Random.Int(min: 100, max: 200))
                    .RuleFor(o => o.BarCode, f => f.Random.Replace("?##"))
                    .RuleFor(o => o.Name, f => f.Commerce.Product())
                    .RuleFor(o => o.InventoryDesc, f => f.Commerce.ProductDescription())
                    .RuleFor(o => o.StockCode, f => f.Random.Replace("?**##"))
                    .RuleFor(o => o.Void, f => f.Random.Int(5))
                    .RuleFor(o => o.NoPriceShift, f => f.Random.Int(5))
                    .RuleFor(o => o.CategoryNumber, f => f.Random.Replace("####"))
                    .RuleFor(o => o.Group1, f => f.Random.String(length: 10))
                    .RuleFor(o => o.Group2, f => f.Random.String(length: 10))
                    .RuleFor(o => o.Group3, f => f.Random.String(length: 10))
                    .RuleFor(o => o.Group4, f => f.Random.String(length: 10))
                    .RuleFor(o => o.Group5, f => f.Random.String(length: 10))

                    .RuleFor(o => o.Class, f => f.Random.Int(min: 100, max: 200))
                    .RuleFor(o => o.Qty, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.Unit, f => f.Random.Replace("***"))
                    .RuleFor(o => o.PriceType, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.Price, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.ActualPrice, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.Amount, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.ShiftMixedFlag, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.QuantityShiftType, f => f.Random.Int(min: 1, max: 5))

                    .RuleFor(o => o.ShiftValue, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.OddDisc, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.RealPrice, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.QuantityFrom, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.Description, f => f.Random.String(length: 50))
                    .RuleFor(o => o.DiscQty, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.PsDiscAmount, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.PsDisValue, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.ActualPSDiscAmount, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.QtyRemain, f => f.Random.Double(min: 10, max: 30))

                    .RuleFor(o => o.TotalSoldQty, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.TotalDiscQty, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.DiscType, f => f.Random.Int(min: 10, max: 30))
                    .RuleFor(o => o.DiscValue, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.ManualDisc, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.Points, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.Checkout, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.TakeAway, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.MemberDisc, f => f.Random.Double(min: 10, max: 30))

                    .RuleFor(o => o.SalesMan, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.OrderTime, f => f.Random.Int(min: 5, max: 50))
                    .RuleFor(o => o.Printed, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.BufferPrinted, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.PriceID, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.Condimented, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.KitchenPrint, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.KitchenPrintFlag, f => f.Random.Replace("###"))
                    .RuleFor(o => o.TaxAmount1, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.TaxAmount2, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.TaxAmount3, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.TaxAmount4, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.TaxAmount5, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.TaxAmount6, f => f.Random.Double(min: 10, max: 30))

                    .RuleFor(o => o.ItemStatus, f => f.Random.Int(min: 10, max: 30))
                    .RuleFor(o => o.TaxableAmount, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.TaxFlag, f => f.Random.Replace("****"))
                    .RuleFor(o => o.TaxInfo, f => f.Random.Replace("****"))
                    .RuleFor(o => o.ParentID, f => f.Random.Int(min: 10, max: 30))
                    .RuleFor(o => o.PrintedVoid, f => f.Random.Int(min: 10, max: 30))
                    .RuleFor(o => o.VoidDate, DateTime.Now)
                    .RuleFor(o => o.AllowDecimalValue, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.TaxableAmount, f => f.Random.Double(min: 10, max: 30))

                    .RuleFor(o => o.TotalDisc, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.TotalMemberDisc, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.TotalPSDisc, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.RDPoints, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.ItemSCDiscAmount, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.ItemSCDiscValue, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.ItemSCCovers, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.ItemSCRetTaxAmount, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.Warranty, f => f.Random.Int(min: 10, max: 30))

                    .RuleFor(o => o.UnitCost, f => f.Random.Double(min: 10, max: 30))
                    .RuleFor(o => o.ManagerID, f => f.Random.Int(min: 10, max: 30))
                    .RuleFor(o => o.ManagerName, f => f.Person.FirstName)
                    .RuleFor(o => o.KitchenStatus, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.FireQuantity, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.Commission, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.CommissionValue, f => f.Random.Double(min: 1, max: 5))
                    .RuleFor(o => o.KdsItemStatus, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.KdsDoneQty, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.KdsItemPriority, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.KdsItemCmptTime, DateTime.Now.ToShortDateString())
                    .RuleFor(o => o.MParentID, f => f.Random.Int(min: 1, max: 5))
                    .RuleFor(o => o.MChildID, f => f.Random.Int(min: 1, max: 5))
                    ;
                

                #endregion

                var transDetail =  fakeTransDetail.Generate();
                transDetail.TransID = trans.TransID;
                transDetailsList.Add(transDetail);
            }

            //transactionModel.Transaction = trans;
            //transactionModel.TransDetailList = transDetailsList;
            transactionModel.MasterTable = trans;
            transactionModel.ChildList1 = transDetailsList;
            return transactionModel;
        }
    }
}
