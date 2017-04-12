using System;
using System.Text;
using System.Net;

namespace TextMessage_Alerter
{
    class SendSMS
    {
        private const string REQUEST_URL = "https://redoxygen.net/sms.dll?Action=SendSMS";
        public static int sendSMSViaRedOxygen(String AccountID, String Email, String Password, String Recipient, String Message)
        {
            WebClient Client = new WebClient();

            string RequestData = "AccountId=" + AccountID
                + "&Email=" + System.Web.HttpUtility.UrlEncode(Email)
                + "&Password=" + System.Web.HttpUtility.UrlEncode(Password)
                + "&Recipient=" + System.Web.HttpUtility.UrlEncode(Recipient)
                + "&Message=" + System.Web.HttpUtility.UrlEncode(Message);

            byte[] PostData = Encoding.ASCII.GetBytes(RequestData);
            byte[] Response = Client.UploadData(REQUEST_URL, PostData);

            String Result = Encoding.ASCII.GetString(Response);
            int ResultCode = System.Convert.ToInt32(Result.Substring(0, 4));

            return ResultCode;
        }
    }
}
