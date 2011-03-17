using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebExample
{
    public partial class RaiseError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void errorButton_Click(object sender, EventArgs e)
        {
            throw new InvalidOperationException("Test error triggered by the Progstr.Log samples.");
        }
    }
}