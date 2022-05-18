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

                // use blank lines to separate logical blocks in a method for readability
                foreach (ProductCategory category in productCategories)
                {
                    DropCategory.Items.Add(category.CategoryName);
                }

                // instead of adding the categories one at a time to the list, I THINK you could
                //  - add Select Category to a new collection
                //  - AddRange the productCategories to the collection
                //  - set the DataSource of the dropdown to the collection (and DataBind if that is necessary)

                // also you should define your dropdowns with the displayed text as you are doing AND a value - the value can then be used as a better way to know what was selected
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


        // always be sure to clean up any methods that end up not having any functionality in them
        protected void ProductGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
    }
}