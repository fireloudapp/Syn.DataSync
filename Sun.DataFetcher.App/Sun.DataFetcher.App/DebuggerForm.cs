using Newtonsoft.Json;
using Sun.DataFetcher.App.Helpers;
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
using System.Windows.Forms;

namespace Sun.DataFetcher.App
{
    public partial class DebuggerForm : Form
    {
        public DebuggerForm()
        {
            InitializeComponent();
        }

        private void btnGetRecords_Click(object sender, EventArgs e)
        {
            string conString = AESHelper.Decrypt(ConfigurationManager.AppSettings["LocalDataBase"], ConfigurationManager.AppSettings["Key"]); ;
            string limit = ConfigurationManager.AppSettings["GetLimit"];

            IQueryByIsSync<TransactionModel> getTransToSync = new GetTransToSync(conString);
            IEnumerable<TransactionModel> transModelList = getTransToSync.GetHandler(isSync: 0, limit: limit);   
            
            rchText.Text = JsonConvert.SerializeObject(transModelList, Formatting.Indented);

        }

        private void btnUpdateTest_Click(object sender, EventArgs e)
        {
            string conString = AESHelper.Decrypt( ConfigurationManager.AppSettings["LocalDataBase"], ConfigurationManager.AppSettings["Key"]);
            int transId = int.Parse(txtTransID.Text);
            IUpdate<Trans> updateTrans = new TransUpdateHandler(conString);
            bool isUpdated = updateTrans.GetHandler(transId, 1);
            if (isUpdated)
            {
                rchText.Text = "Transaction Updat Succeeded. Trans Id: " + transId;
            }
            else
            {
                rchText.Text = "Transaction Updated Failed. Trans Id: " + transId;
            }
        }

        private void btnRabbitSend_Click(object sender, EventArgs e)
        {
            string conString = AESHelper.Decrypt(ConfigurationManager.AppSettings["LocalDataBase"], ConfigurationManager.AppSettings["Key"]); ;
            string limit = ConfigurationManager.AppSettings["GetLimit"];

            IQueryByIsSync<TransactionModel> getTransToSync = new GetTransToSync(conString);
            IEnumerable<TransactionModel> transModelList = getTransToSync.GetHandler(isSync: 0, limit: limit);
            string token = new WebAPIHelper().GetAuthenticate();
            foreach (var objToSend in transModelList)
            {
                WebAPIHelper helper = new WebAPIHelper();
                HttpStatusCode httpStatusCode = helper.PostData(token, JsonConvert.SerializeObject(objToSend), APIConstant.SEND_TRANS);                
                if (httpStatusCode == HttpStatusCode.OK)
                {
                    rchText.Text = rchText.Text + Environment.NewLine + "Data Sent to Web API";
                }
                else
                {
                    rchText.Text = rchText.Text + Environment.NewLine + "Failed to send Web API" + httpStatusCode;
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string token = new WebAPIHelper().GetAuthenticate();
            rchText.Text = token;
        }

        private async void btnSyncTest_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                txtEnc_Dec.Text = AESHelper.Encrypt(txtEnc_Dec.Text, ConfigurationManager.AppSettings["Key"]);
            }
            catch(Exception ex)
            {

            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            txtEnc_Dec.Text = AESHelper.Decrypt(txtEnc_Dec.Text, ConfigurationManager.AppSettings["Key"]);
        }

        private void txtEnc_Dec_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
