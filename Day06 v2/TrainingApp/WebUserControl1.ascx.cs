using CardsAgain.Containers;
using CardsAgain.DAOs;
using CardsAgain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrainingApp
{
    // even for an exercise like this, name the user control to reflect what it is
    public partial class WebUserControl1 : UserControl
    {
        public IProduct ProductDAO { get; set; }
        protected override void OnLoad(EventArgs e)
        {
            IoC.BuildUp(this);
            base.OnLoad(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetSpecificItem(int id)
        {
            Product prod = ProductDAO.GetProduct(id);
            ProdName.Text = prod.ProductName;
            ProdColor.Text = prod.Color;
            ProdPrice.Text = prod.Price.ToString("C");
        }
    }
}