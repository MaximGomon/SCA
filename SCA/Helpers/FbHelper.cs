using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Facebook;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;
using SCA.Domain.Enums;

namespace SCA.Helpers
{
    public static class FbHelper
    {
        public static void Authorize()
        {
            var fb = new FacebookClient();
            var AppId = ConfigurationManager.AppSettings["AppId"];
            var AppSecret = ConfigurationManager.AppSettings["AppSecret"];
            dynamic result = fb.Get("oauth/access_token", new
            {
                client_id = AppId,
                client_secret = AppSecret,
                grant_type = "client_credentials"
            });
            fb.AccessToken = result.access_token;
            var settingBusinessLogic = new SettingBusinessLogic(new SystemSettingRepository());
            settingBusinessLogic.Add(new SystemSetting
            {
                Key = SettingKeyEnum.AccessToken.ToString(),
                Value = fb.AccessToken
            });
            //CookieCollection cookies = new CookieCollection();
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.facebook.com"); 

            //request.CookieContainer = new CookieContainer();
            //request.CookieContainer.Add(cookies);
            ////Get the response from the server and save the cookies from the first request..
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //cookies = response.Cookies;

            //string getUrl = "https://www.facebook.com/login.php?login_attempt=1&response_type=token";
            //string postData = String.Format("email={0}&pass={1}", "gomon-m@ua.fm", "vfrc19");
            //HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(getUrl);
            //getRequest.CookieContainer = new CookieContainer();
            //getRequest.CookieContainer.Add(cookies); //recover cookies First request
            //getRequest.Method = WebRequestMethods.Http.Post;
            //getRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
            //getRequest.AllowWriteStreamBuffering = true;
            //getRequest.ProtocolVersion = HttpVersion.Version11;
            //getRequest.AllowAutoRedirect = true;
            //getRequest.ContentType = "application/x-www-form-urlencoded";

            //byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            //getRequest.ContentLength = byteArray.Length;
            //Stream newStream = getRequest.GetRequestStream(); //open connection
            //newStream.Write(byteArray, 0, byteArray.Length); // Send the data.
            //newStream.Close();

            //HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse();
            //using (var sr = new StreamReader(getResponse.GetResponseStream()))
            //{
            //    string sourceCode = sr.ReadToEnd();
            //}

        }
    }
}