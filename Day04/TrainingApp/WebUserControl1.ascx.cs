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
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        DAOProduct prodDao = new DAOProduct();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetSpecificItem(int id)
        {
            Product prod = prodDao.GetProduct(id);
            ProdName.Text = prod.ProductName;
            ProdColor.Text = prod.Color;
            ProdPrice.Text = Convert.ToString(prod.Price);
            
        }
    }
}