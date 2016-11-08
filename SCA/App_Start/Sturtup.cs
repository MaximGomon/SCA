using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Owin;
using SCA.BussinesLogic;
using SCA.DataAccess;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;
using SCA.Domain.Enums;

[assembly: OwinStartup(typeof(SCA.Sturtup))]

namespace SCA
{
    public class Sturtup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<ScaDbContext>(ScaDbContext.Create);
            app.CreatePerOwinContext<ScaUserManager>(ScaUserManager.Create);
            app.CreatePerOwinContext<ScaSignInManager>(ScaSignInManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "1058395896189-bjth2489v2j0uter97gd1v9uqamipcsb.apps.googleusercontent.com",
                ClientSecret = "QiLwRoLVrTLABK4_oiJ6v61h"
            });

            app.UseFacebookAuthentication(
                new FacebookAuthenticationOptions()
                {
                    AppId = ConfigurationManager.AppSettings["AppId"],
                    AppSecret = ConfigurationManager.AppSettings["AppSecret"],
                    Provider = new FacebookAuthenticationProvider()
                    {
                        OnAuthenticated = (OnAuthenticated)
                    }
                });
        }
        private Task OnAuthenticated(FacebookAuthenticatedContext facebookAuthenticatedContext)
        {
            var settingBusinessLogic = new SettingBusinessLogic(new SystemSettingRepository());
            settingBusinessLogic.Add(new SystemSetting
            {
                Key = SettingKeyEnum.AccessToken.ToString(),
                Value = facebookAuthenticatedContext.AccessToken
            });
            return Task.FromResult(0);
        }
    }
}