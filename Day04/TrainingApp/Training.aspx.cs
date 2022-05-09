using CardsAgain.DAOs;
using CardsAgain.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using TrainingApp.DAOs;
using TrainingApp.Models;

namespace TrainingApp
{
    public partial class Training : System.Web.UI.Page
    {
        public DAO dao = new DAO();
        public DAOProduct prodDao = new DAOProduct();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetListColors();
                SetCategories();
            }
        }

        protected void SetCategories()
        {
            DropCategory.Items.Clear();
            DropCategory.Items.Add("Select Category");
            List<ProductCategory> productCategories = prodDao.GetProductCategories();
            foreach (ProductCategory category in productCategories)
            {
                DropCategory.Items.Add(category.CategoryName);
            }
        }

        protected void SetSubCategories(object sender, EventArgs e)
        {
            DropSubCategory.Items.Clear();
            DropSubCategory.Items.Add("Select Subcategory");
            List<ProductSubCategory> subCategories = prodDao.GetProductSubcategories(DropCategory.SelectedValue);
            foreach(ProductSubCategory subCategory in subCategories)
            {
                DropSubCategory.Items.Add(subCategory.SubCategoryName);
            }
        }

        protected void SetCardsProducts(object sender, EventArgs e)
        {
            List<Product> products = prodDao.GetProducts(DropSubCategory.SelectedValue);
            ProductGrid.DataSource = products;
            ProductGrid.DataBind();
        }

        protected void SelectProduct(object sender, GridViewCommandEventArgs e)
        {
            int productId = Convert.ToInt32(ProductGrid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
            uc.SetSpecificItem(productId);
            ucdiv.Visible = true;
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

        protected void ProductGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
    }
}