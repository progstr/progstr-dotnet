using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Progstr.Log;

namespace WebExample
{
    public partial class PageError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var errorMessage = Request.QueryString["error"];
            if (!string.IsNullOrEmpty(errorMessage))
                this.message.Text = errorMessage;
        }

        protected void errorButton_Click(object sender, EventArgs e)
        {
            throw new InvalidOperationException("Test error triggered by the progstr.log samples.");
        }

        protected override void OnError(EventArgs e)
        {
            var error = Server.GetLastError();
            this.Log().Error("Unhandled exception while executing page.", error);

            var message = "An error occurred: " + error.Message;

            Response.Redirect("~/Examples/PageError.aspx?error=" + HttpUtility.UrlEncode(message));
        }
    }
}