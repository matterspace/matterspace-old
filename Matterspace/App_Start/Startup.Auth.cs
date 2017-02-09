using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Configuration;
using Matterspace.Lib;
using Matterspace.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using Microsoft.Owin.Security.Facebook;
using Matterspace.Lib.OAuth;
using Matterspace.Model.Entities;

namespace Matterspace
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(MatterspaceDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
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
                ClientId = WebConfigurationManager.AppSettings[AppSettingsConstants.GoogleClientId],
                ClientSecret = WebConfigurationManager.AppSettings[AppSettingsConstants.GoogleClientSecret],
                Provider = new GoogleOAuth2AuthenticationProvider()
                {
                    OnAuthenticated = (context) =>
                    {
                        context.Identity.AddClaim(new Claim("name", context.Identity.FindFirstValue(ClaimTypes.Name)));
                        context.Identity.AddClaim(new Claim("email", context.Identity.FindFirstValue(ClaimTypes.Email)));
                        //This following line is need to retrieve the profile image
                        context.Identity.AddClaim(new Claim("accesstoken", context.AccessToken, ClaimValueTypes.String, "Google"));

                        // Gets the profile picture
                        var pictureUrl = context.User["image"].Value<string>("url");
                        context.Identity.AddClaim(new Claim("pictureUrl", pictureUrl));

                        return Task.FromResult(0);
                    }
                }
            });

            app.UseFacebookAuthentication(new FacebookAuthenticationOptions()
            {
                AppId = WebConfigurationManager.AppSettings[AppSettingsConstants.FacebookAppId],
                AppSecret = WebConfigurationManager.AppSettings[AppSettingsConstants.FacebookAppSecret],
                BackchannelHttpHandler = new FacebookBackchannelHttpHandler(),
                UserInformationEndpoint = WebConfigurationManager.AppSettings[AppSettingsConstants.FacebookUserInformationEndpoint],
                Provider = new FacebookAuthenticationProvider()
                {
                    OnAuthenticated = (context) =>
                    {
                        context.Identity.AddClaim(new Claim("name", context.Identity.FindFirstValue(ClaimTypes.Name)));
                        context.Identity.AddClaim(new Claim("email", context.Identity.FindFirstValue(ClaimTypes.Email)));

                        // Gets profile picture Facebook mode.
                        context.Identity.AddClaim(new Claim("pictureUrl", context.User["picture"]["data"]["url"].ToString()));

                        return Task.FromResult(0);
                    }
                }
            });

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");


        }
    }
}