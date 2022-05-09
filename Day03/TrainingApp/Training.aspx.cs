using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrainingApp.DAOs;
using TrainingApp.Models;

namespace TrainingApp
{
    public partial class Training : System.Web.UI.Page
    {
        public DAO dao = new DAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetListColors();
            }
        }

        protected void SetListColors()
        {
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add("Select Color");
            List<string> colors = dao.GetColors();
            foreach (string color in colors)
            {
                DropDownList1.Items.Add(color);
            }
        }

        protected void SetProducts(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("Select Product");
            List<string> products = dao.GetProducts(DropDownList1.SelectedValue);
            foreach (string product in products)
            {
                DropDownList2.Items.Add(product);
            }
        }

        protected void SetWorkOrders(object sender, EventArgs e)
        {
            List<WorkLoad> workLoads = dao.GetWorkLoads(DropDownList2.SelectedValue);
            GridView1.DataSource = workLoads;
            GridView1.DataBind();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            
        }
    }
}