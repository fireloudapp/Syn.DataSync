using Sun.DataFetcher.App.Helpers;
using Sun.DataFetcher.App.HTTPUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemGeneric.Loggers;

namespace Sun.DataFetcher.App
{
    public partial class MainForms : Form
    {
        #region Declaration
        bool _isDebug = false;
        List<LogList> _logLists = new List<LogList>();
        string _jwtToken = string.Empty;
        int _trickInSecond = 0;
        #endregion

        #region Constructor & Initialization
        public MainForms()
        {
            InitializeComponent();
        }

        private async void MainForms_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeConfig();
                Logger.Log.Information("Data Fetcher Initialized");
                btnDebugger.Visible = _isDebug;//If Debug value is true this will get enabled.
                btnSyncTest.Visible = _isDebug;
                //Converts Minutes into Milliseconds.
                timerSync.Interval = int.Parse(txtInterval.Text) * 60 * 1000;
                _trickInSecond = timerSync.Interval / 1000;
                await GenerateTokenAndAssign();
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region Event Methods
        private void timerCountDown_Tick(object sender, EventArgs e)
        {
            TimeSpan time = TimeSpan.FromSeconds(_trickInSecond);
            txtNextTrigger.Text= time.ToString(@"hh\:mm\:ss\:fff");
            _trickInSecond--;
            if(_trickInSecond == 0)
            {
                _trickInSecond = timerSync.Interval / 1000;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            RefreshDataSource(forceClean: true);
        }
        
        private void btnDebugger_Click(object sender, EventArgs e)
        {
            DebuggerForm debuggerForm = new DebuggerForm();
            debuggerForm.ShowDialog();
        }
        private async void btnSyncTest_Click(object sender, EventArgs e)
        {
            await SyncTransInvoke();
            //using SyncForm sync = new SyncForm(_logLists);
            //await sync.SyncTransData(_jwtToken);
        }

        /// <summary>
        /// Time which tricks based on the Time interval.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void timerSync_Tick(object sender, EventArgs e)
        {
            await SyncTransInvoke();//For Trans Invoke
            //If you need another form to invoke follow the same
            //syntax. await Sync{tableName}Invoke();
            //Eg. await SyncWebTransInvoke(); 
        }
        #endregion

        #region Syncronization Methods
        /// <summary>
        /// Syncronization for "Trans" Table, with its Child table.
        /// </summary>
        /// <returns></returns>
        private async Task SyncTransInvoke()
        {
            try
            {
                HttpStatusCode status;
                if (IsFormOpen("SyncForm"))
                {
                    //Sync is in progress
                    _logLists.Add(new LogList() { Message = "Earlier Not yet completed.", Status = "InProgress" });
                }
                else
                {
                    //Start the Syncronization.
                    using (SyncForm sync = new SyncForm(_logLists))
                    {                        
                        status = await sync.SyncTransData(_jwtToken);
                    }
                    await HTTPStatusHandler(status, "Trans");
                    //The Transaction Table name or any meaningful name for the our understanding.
                }
                RefreshDataSource();
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Generates JWT Token
        /// </summary>
        /// <returns></returns>
        private async Task GenerateTokenAndAssign()
        {
            try
            {
                _jwtToken = await new WebAPIHelper().GetAuthenticationAsync();
                txtToken.Text = _jwtToken;
                Logger.Log.Information("Token Generated : " + _jwtToken);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
        }

        private async Task HTTPStatusHandler(HttpStatusCode httpStatusCode, string syncType)
        {
            try
            {
                switch (httpStatusCode)
                {
                    case HttpStatusCode.OK:
                        AddLogList("Sync Completed - " + syncType, Enum.GetName(typeof(HttpStatusCode), httpStatusCode));
                        break;
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.Unauthorized:
                        AddLogList("Generating New Token");
                        await GenerateTokenAndAssign();
                        AddLogList("New Token Generated. Will be used at next sync.");
                        //Generate a new token and it will automaticlly recovered in the next iteration.
                        break;
                    default:
                        AddLogList(Enum.GetName(typeof(HttpStatusCode), httpStatusCode));
                        break;
                }
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
        }

        private void AddLogList(string msg, string status = "-")
        {
            try
            {
                _logLists.Add(new LogList()
                {
                    Date = DateTime.Now,
                    Message = msg,
                    Status = status
                });
                RefreshDataSource();
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
        }

        private void RefreshDataSource(bool forceClean = false)
        {
            try
            {
                if (forceClean)
                {
                    _logLists.Clear();
                }
                if (_logLists.Count > 300)
                {
                    _logLists.Clear();
                    _logLists.Add(new LogList() { Message = " Log List Reached the limit. Cleared all Logs " });
                }
                dgLoglist.DataSource = null;
                _logLists.Sort((x, y) => y.Date.CompareTo(x.Date));//Sort by Date
                dgLoglist.DataSource = _logLists;
                dgLoglist.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
        }

        private bool IsFormOpen(string frmName)
        {
            bool isOpen = false;
            try
            {
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    //iterate through
                    if (frm.Name == frmName )
                    {
                        isOpen = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
            return isOpen;
        }

        private void InitializeConfig()
        {
            try
            {
                txtURL.Text = ConfigurationManager.AppSettings["APIURL"];
                txtUser.Text = ConfigurationManager.AppSettings["UserName"];
                txtSecret.Text = ConfigurationManager.AppSettings["Password"];
                txtInterval.Text = ConfigurationManager.AppSettings["SyncInterval"];
                txtRecLimit.Text = ConfigurationManager.AppSettings["GetLimit"];
                txtQueue.Text = ConfigurationManager.AppSettings["Queue"];
                _isDebug = bool.Parse(ConfigurationManager.AppSettings["IsDebug"]);
                this.Text = this.Text + " - " + txtQueue.Text;
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
        }


        #endregion

        private void btnDownload_Click(object sender, EventArgs e)
        {
            //Download part appears here.
        }
    }

    public class LogList
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string Message { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

}
