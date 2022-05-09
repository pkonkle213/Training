using CardsAgain.Containers;
using CardsAgain.DAOs;
using CardsAgain.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using TrainingApp.DAOs;
using TrainingApp.Models;

namespace TrainingApp
{
    public partial class Training : BasePageWithIoC
    {
        public ILogic ProductDAO { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropCategory.Items.Clear();
                DropCategory.Items.Add("Select Category");
                IEnumerable<ProductCategory> productCategories = ProductDAO.GetProductCategories();
                foreach (ProductCategory category in productCategories)
                {
                    DropCategory.Items.Add(category.CategoryName);
                }
            }
        }

        protected void SetSubCategories(object sender, EventArgs e)
        {
            DropSubCategory.Items.Clear();
            DropSubCategory.Items.Add("Select Subcategory");
            IEnumerable<ProductSubCategory> subCategories = ProductDAO.GetProductSubCategories(DropCategory.SelectedIndex);
            foreach(ProductSubCategory subCategory in subCategories)
            {
                DropSubCategory.Items.Add(subCategory.SubCategoryName);
            }
        }

        protected void SetCardsProducts(object sender, EventArgs e)
        {
            IEnumerable<Product> products = ProductDAO.GetProducts(DropSubCategory.SelectedIndex);
            ProductGrid.DataSource = products;
            ProductGrid.DataBind();
        }

        protected void SelectProduct(object sender, GridViewCommandEventArgs e)
        {
            int productId = Convert.ToInt32(ProductGrid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
            uc.SetSpecificItem(productId);
            ucdiv.Visible = true;
        }

        protected void ProductGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
    }
}