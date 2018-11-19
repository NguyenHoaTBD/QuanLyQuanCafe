using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fAdmin : Form
    {
        private BindingSource AccountList = new BindingSource();
        private BindingSource productList = new BindingSource();
        int pageBillSize = 14;
        public fAdmin()
        {

            InitializeComponent();

            Load();
        }
        #region Method
        private void Load()
        {
            dtgvAccount.DataSource = AccountList;
            dtgvProduct.DataSource = productList;
            LoadDateTimeBill();

            GetListBillCheckedByDate();
            ShowListProduct();
            AddFoodBinding();

            GetListAccount();
            AddBindingAccount();


        }
        #region Account
        public void GetListAccount()
        {
            AccountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        public void AddBindingAccount()
        {
            txtUsername.DataBindings.Add("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never);
            txtDisplayname.DataBindings.Add("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never);
            txtRole.DataBindings.Add("Text", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never);
        }
        #endregion

        #region Revenue
        private void LoadDateTimeBill()
        {
            DateTime today = DateTime.Now;

            dpkBegindate.Value = new DateTime(today.Year, today.Month, 1);
            dpkEnddate.Value = dpkBegindate.Value.AddMonths(1).AddDays(-1);
        }
        public void GetListBillCheckedByDate()
        {
            DateTime dateCheckin = dpkBegindate.Value;
            DateTime dateCheckout = dpkEnddate.Value;

            DataTable data = BillDAO.Instance.GetListBillCheckedByDate(dateCheckin, dateCheckout);

            dtgvRevenue.DataSource = data;

            int recortCount = BillDAO.Instance.GetCountBillCheckedByDate(dateCheckin, dateCheckout);
            int pageCount = recortCount / pageBillSize;
            if ((recortCount % pageBillSize) > 0) pageCount++;
            lblTotalPageBill.Text = pageCount.ToString();
        }
        #endregion

        #region Product
        public void ShowListProduct()
        {
            productList.DataSource = ProductDAO.Instance.GetListProduct();
            LoadListCategoryToCbBox(cbCateoryProduct);
        }
        public void LoadListCategoryToCbBox(ComboBox cb)
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cb.DataSource = listCategory;
            cb.DisplayMember = "Name";
        }
        public void AddFoodBinding()
        {
            txtProductProduct.DataBindings.Add("Text", dtgvProduct.DataSource, "name", true, DataSourceUpdateMode.Never);
            txtIdPr.DataBindings.Add("Text", dtgvProduct.DataSource, "id", true, DataSourceUpdateMode.Never);
            txtPriceProduct.DataBindings.Add("Text", dtgvProduct.DataSource, "price", true, DataSourceUpdateMode.Never);
        }

        private List<Product> SearchFoodByName(string name)
        {
            List<Product> products = ProductDAO.Instance.SearchProductByName(name);
            return products;
        }
        #endregion

        #endregion

        #region Event Handle 
        #region Account
        private void btnShowaccount_Click(object sender, EventArgs e)
        {
            GetListAccount();
        }

        private void btnSearchacount_Click(object sender, EventArgs e)
        {
            string query = "";
            string username = txtSearchAccount.Text;
            if (!string.IsNullOrWhiteSpace(username))
            {
                query = "EXEC dbo.USP_GetAccountByUserName @username";
                dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { username });
            }
            else
            {
                query = "SELECT * FROM dbo.Account";
                dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query);
            }
        }

        #endregion

        #region Product
        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            ShowListProduct();
        }
        private void txtIdCat_TextChanged(object sender, EventArgs e)
        {
            try
            {

                int id = (int)dtgvProduct.SelectedCells[0].OwningRow.Cells["idCategory"].Value;
                Category category = CategoryDAO.Instance.GetCategoryById(id);
                int index = 0;
                int i = 0;
                foreach (Category item in cbCateoryProduct.Items)
                {
                    if (item.Id == category.Id)
                    {
                        index = i;
                    }

                    i++;
                }
                cbCateoryProduct.SelectedIndex = index;
            }
            catch { }
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txtProductProduct.Text;
            int price = int.Parse(txtPriceProduct.Text);
            int idCategory = (cbCateoryProduct.SelectedItem as Category).Id;
            bool result = ProductDAO.Instance.InsertNewProduct(name, idCategory, price);
            if (result)
            {
                MessageBox.Show("Succes!");
                ShowListProduct();
                insertFood?.Invoke(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Faild!");
            }

        }
        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (txtIdPr.Text.Length > 0)
            {
                int id = int.Parse(txtIdPr.Text);
                string name = txtProductProduct.Text;
                int price = int.Parse(txtPriceProduct.Text);
                int idCategory = (cbCateoryProduct.SelectedItem as Category).Id;
                Product product = new Product(id, name, idCategory, price);
                bool result = ProductDAO.Instance.UpdateProduct(product);
                if (result)
                {
                    MessageBox.Show("Succes!");
                    ShowListProduct();
                    updateFood?.Invoke(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Faild!");
                }
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (txtIdPr.Text.Length > 0)
            {
                int id = int.Parse(txtIdPr.Text);
                if (MessageBox.Show($"Are you sure want to delete {txtProductProduct.Text}?", "Confirm!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    bool result = ProductDAO.Instance.DeleteProductById(id);
                    if (result)
                    {
                        MessageBox.Show("Succes!");
                        ShowListProduct();
                        deleteFood?.Invoke(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Faild!");
                    }
                }
            }
        }
        private void btnSearchcategory_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchProduct.Text.Trim()))
            {
                productList.DataSource = SearchFoodByName(txtSearchProduct.Text);
            }
            else
            {
                ShowListProduct();
            }
        }
        #region Added event
        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }
        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }
        #endregion
        #endregion

        #region Revenue
        private void btnstatistical_Click(object sender, EventArgs e)
        {
            GetListBillCheckedByDate();
        }

        #endregion

        #endregion

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (AccountDAO.Instance.ResetPassWord(txtUsername.Text))
            {
                MessageBox.Show("Succes!");
            }
            else
            {
                MessageBox.Show("Faild!");
            }
        }

        private void btnFirstBill_Click(object sender, EventArgs e)
        {
            txtPageBill.Text = "1";
        }

        private void btnLastBill_Click(object sender, EventArgs e)
        {
            DateTime dateCheckin = dpkBegindate.Value;
            DateTime dateCheckout = dpkEnddate.Value;
            int recortCount = BillDAO.Instance.GetCountBillCheckedByDate(dateCheckin, dateCheckout);
            int pageCount = recortCount / pageBillSize;
            if ((recortCount % pageBillSize) > 0) pageCount++;
            txtPageBill.Text = pageCount.ToString();
        }

        private void txtPageBill_TextChanged(object sender, EventArgs e)
        {
            DateTime dateCheckin = dpkBegindate.Value;
            DateTime dateCheckout = dpkEnddate.Value;
            int pageNumber = 0;
            if(int.TryParse(txtPageBill.Text, out pageNumber))
            {
                DataTable data = BillDAO.Instance.GetListBillCheckedByDate(dateCheckin, dateCheckout, pageBillSize, pageNumber);

                dtgvRevenue.DataSource = data;

                int recortCount = BillDAO.Instance.GetCountBillCheckedByDate(dateCheckin, dateCheckout);
                int pageCount = recortCount / pageBillSize;
                if ((recortCount % pageBillSize) > 0) pageCount++;
                lblTotalPageBill.Text = pageCount.ToString();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int pageNumber = 0;
            if (int.TryParse(txtPageBill.Text, out pageNumber))
            {
                if (pageNumber > 1)
                {
                    pageNumber--;
                    txtPageBill.Text = pageNumber.ToString();
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int pageNumber = 0;
            DateTime dateCheckin = dpkBegindate.Value;
            DateTime dateCheckout = dpkEnddate.Value;

            
            if (int.TryParse(txtPageBill.Text, out pageNumber))
            {
                int recortCount = BillDAO.Instance.GetCountBillCheckedByDate(dateCheckin, dateCheckout);
                int pageCount = recortCount / pageBillSize;
                if ((recortCount % pageBillSize) > 0) pageCount++;
                txtPageBill.Text = pageCount.ToString();

                if (pageNumber < pageCount)
                {
                    pageNumber++;
                    txtPageBill.Text = pageNumber.ToString();
                }
            }
        }
    }
}
