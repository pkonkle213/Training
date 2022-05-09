using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace CardsAgain.Containers
{
    public class BasePageWithIoC : Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            IoC.BuildUp(this);
        }
    }
}
