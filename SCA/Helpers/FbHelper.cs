using System.Configuration;
using System.Linq;
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
            var appId = ConfigurationManager.AppSettings["AppId"];
            var appSecret = ConfigurationManager.AppSettings["AppSecret"];
            dynamic result = fb.Get("oauth/access_token", new
            {
                client_id = appId,
                client_secret = appSecret,
                grant_type = "client_credentials"
            });
            fb.AccessToken = result.access_token;
            var settingBusinessLogic = new SettingBusinessLogic(new SystemSettingRepository());
            settingBusinessLogic.Add(new SystemSetting
            {
                Key = SettingKeyEnum.AccessToken.ToString(),
                Value = fb.AccessToken
            });
        }
    }
}