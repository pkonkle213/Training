using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrainingApp
{
    public partial class Training : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                time.Text = DateTime.Now.ToString("hh:mm:ss.fff");
            }
        }

        protected void NewLabel(object sender, EventArgs e)
        {
            Label1.Text = input.Text;
        }
    }
}