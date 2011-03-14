using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Progstr.Log;

namespace WebExample
{
    public partial class WebFormExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        public void logButton_Click(object sender, EventArgs e)
        {
            var severity = severityList.SelectedValue;
            var message = logMessage.Text;
            switch (severity)
            {
                case "Info": 
                    this.Log().Info(message);
                    break;
                case "Warning": 
                    this.Log().Warning(message);
                    break;
                case "Error": 
                    this.Log().Error(message);
                    break;
                case "Fatal": 
                    this.Log().Fatal(message);
                    break;
                default:
                    this.Log().Info(message);
                    break;
            }
            
            messageArea.Text = "Log sent to server.";
        }
    }
}