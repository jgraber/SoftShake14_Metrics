using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Serilog;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebApplicationExercise.Models;

namespace WebApplicationExercise.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = new UserManager();
                ApplicationUser user = manager.Find(UserName.Text, Password.Text);
                if (user != null)
                {
                    IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                    LogSuccessfulLogin(user);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    FailureText.Text = "Invalid username or password.";
                    ErrorMessage.Visible = true;
                }
            }
        }

        private void LogSuccessfulLogin(ApplicationUser user)
        {
            // Minimalistic log message => only the operating system is logged
            //Log.Information("Successful login using {os}", Context.Request.Browser.Platform);

            // Log more information at login => UserName and operating system 
            //Log.Information("Successful login by {user} using {os}", user.UserName, Context.Request.Browser.Platform);

            // Log even more information at login => UserName, operating system and session
            Log.Information("Successful login by {user} using {os} in session {session}", user.UserName, Context.Request.Browser.Platform, Context.Session.SessionID);
        }
    }
}