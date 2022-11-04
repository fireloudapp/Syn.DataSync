using Newtonsoft.Json;
using Sun.DataFetcher.App.HTTPUtility;
using Sun.DataFetcher.DateAccess.Implementation.TransHandler;
using Sun.DataFetcher.DateAccess.Implementation.TransHandler.Command;
using Sun.DataFetcher.DateAccess.Interface;
using Sun.DataSync.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Linq.Expressions;
using SystemGeneric.Loggers;
using System.Reflection;
using Sun.DataFetcher.App.Helpers;

namespace Sun.DataFetcher.App
{
    public partial class SyncForm : Form
    {
        string _connString = string.Empty;
        public SyncForm()
        {
            InitializeComponent();
        }
        List<LogList> _lists;
        public SyncForm(List<LogList> logLists)
        {
            _lists = logLists;
            _connString = AESHelper.Decrypt( ConfigurationManager.AppSettings["LocalDataBase"], ConfigurationManager.AppSettings["Key"]);
        }

        private async void SyncForm_Load(object sender, EventArgs e)
        {
            Logger.Log.Information("Syncronization Initiated : " + nameof(SyncForm));
        }

        #region Syncronization 
        public async Task<HttpStatusCode> SyncTransData(string jwtToken = "")
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.OK;
            try
            {
                await Task.Run(() =>
                {
                    // Call HTTP code here
                    string conString = _connString;
                    string limit = ConfigurationManager.AppSettings["GetLimit"];
                    AddLogList(string.Format("Reading {0} Data From Local Database", nameof(Trans)));
                    IQueryByIsSync<TransactionModel> getTransToSync = new GetTransToSync(conString);
                    IEnumerable<TransactionModel> transModelList = getTransToSync.GetHandler(isSync: 0, limit: limit);
                    AddLogList("Read Data Completed for " + nameof(Trans));
                    string logMsg = string.Format("Sending {0}", nameof(Trans));
                    AddLogList(logMsg);

                    foreach (var objToSend in transModelList)
                    {
                        bool canBreak = false;
                        Send2WebAPI(jwtToken, out httpStatusCode, conString, objToSend, out canBreak);
                        if (canBreak) break;
                        //Break if error or not authorized and it will retry in the next iteration.
                    }
                    if (transModelList.Count() == 0)
                    {
                        AddLogList("No Trans Data to Sync");
                    }

                    //Close the form.
                    this.Close();
                });
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
            return httpStatusCode;
        }


        #endregion

        #region Sync Helper Methods
        private void Send2WebAPI(string jwtToken, out HttpStatusCode httpStatusCode, string conString, TransactionModel objToSend, out bool canBreak)
        {
            httpStatusCode = HttpStatusCode.BadRequest;
            try
            {
                WebAPIHelper helper = new WebAPIHelper();
                string jsonData = JsonConvert.SerializeObject(objToSend, Formatting.Indented);
                httpStatusCode = helper.PostData(jwtToken, jsonData, APIConstant.SEND_TRANS);
                canBreak = HTTPStatusHandler(conString, objToSend, httpStatusCode);
            }
            catch (Exception ex)
            {
                canBreak = false;
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }            
        }

        private bool HTTPStatusHandler(string conString, TransactionModel objToSend, HttpStatusCode httpStatusCode)
        {
            bool canBeak = false;
            try
            {
                switch (httpStatusCode)
                {
                    case HttpStatusCode.OK:
                        UpdateTransOnSuccess(conString, objToSend, httpStatusCode);
                        canBeak = false;
                        break;
                    case HttpStatusCode.BadRequest:
                        AddLogList("Bad Request try after sometimes or check the Web API.", Enum.GetName(typeof(HttpStatusCode), httpStatusCode));
                        canBeak = true;
                        break;
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.Unauthorized:
                        AddLogList("Not Authorized, Token Invalid/Expired Token", Enum.GetName(typeof(HttpStatusCode), httpStatusCode));
                        //Try to generate a new token and try again.
                        canBeak = true;
                        break;
                    default:
                        AddLogList(Enum.GetName(typeof(HttpStatusCode), httpStatusCode));
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
            return canBeak;
        }

        private void UpdateTransOnSuccess(string conString, TransactionModel objToSend, HttpStatusCode httpStatusCode)
        {
            try
            {
                Trans transObj = objToSend.MasterTable as Trans;
                if (transObj == null)
                {
                    AddLogList("TransactionModel.MasterTable cannot be converted to " + nameof(Trans), "w");
                }
                else
                {
                    //Update the Record to IsSync "1"
                    IUpdate<Trans> updateTrans = new TransUpdateHandler(conString);
                    updateTrans.GetHandler(parentId: transObj.TransID, isSync: 1);
                    AddLogList(string.Format("Updating Local DB for Transaction Id: {0} ", transObj.TransID), Enum.GetName(typeof(HttpStatusCode), httpStatusCode));
                }
            }
            catch (Exception ex)
            {
                AddLogList(ex.Message, "Error");
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
        }

        private void AddLogList(string msg, string status = "-")
        {
            _lists.Add(new LogList()
            {
                Date = DateTime.Now,
                Message = msg,
                Status = status
            });
            if (status == "w")
            {
                Logger.Log.Warning(msg);
            }
            else
            {
                Logger.Log.Information(msg);
            }
        }
        #endregion
    }
}
