using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Menu = QuanLyQuanCafe.DTO.Menu;

namespace QuanLyQuanCafe
{
    public partial class fHome : Form
    {
        private Account account;
        public Account Account
        {
            get { return account; }
            set { account = value; LayoutAdmin(account.Type); }

        }
        public fHome(Account account)
        {
            InitializeComponent();
            this.Account = account;
            LoadTable();
            LoadCategoryList();
        }

        #region Method
        /// <summary>
        /// Load list table
        /// </summary>
        private void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> TableList = TableDAO.Instance.GetListTable();
            //Set combo box cbWitchTable
            #region cbSwitchTable
            cbSwitchTable.DataSource = TableList;
            cbSwitchTable.DisplayMember = "Name";

            #endregion
            foreach (Table item in TableList)
            {
                Button btn = new Button()
                {
                    Width = Table.TableWidth,
                    Height = Table.TableHeight,
                    Text = item.Name + Environment.NewLine + item.Status
                };
                btn.BackColor = item.Status == "Empty" ? Color.DarkGray : Color.LightGreen;
                btn.Click += btn_Click;
                btn.Tag = item;
                flpTable.Controls.Add(btn);
            }
        }

        private void LayoutAdmin(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            ProfileToolStripMenuItem.Text += " (" + account.Displayname +")";
        }
        /// <summary>
        /// Show menu when click to table...
        /// </summary>
        /// <param name="id"></param>
        private void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<Menu> Menu = MenuDAO.Instance.GetListMenuByTableId(id);
            float totalPayment = 0;
            foreach (Menu item in Menu)
            {
                ListViewItem lstView = new ListViewItem(item.Name.ToString());
                lstView.SubItems.Add(item.Count.ToString());
                lstView.SubItems.Add(item.Price.ToString());
                lstView.SubItems.Add(item.TotalPrice.ToString());

                lsvBill.Items.Add(lstView);
                totalPayment += item.TotalPrice;
            }
            CultureInfo cul = new CultureInfo("vi-VN");
            txtTotalPayment.Text = totalPayment.ToString("#,###", cul);
        }

        private void LoadCategoryList()
        {
            List<Category> Categories = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = Categories;
            cbCategory.DisplayMember = "Name";
            if (Categories.Count > 0)
            {
                LoadProductByCategoryId(Categories[0].Id);
            }
        }

        private void LoadProductByCategoryId(int id)
        {
            List<Product> products = ProductDAO.Instance.GetListProductById(id);
            cbProduct.DataSource = products;
            cbProduct.DisplayMember = "Name";
            if (products.Count <= 0)
            {
                cbProduct.Text = string.Empty;
            }
        }
        #endregion


        #region Events Handle
        private void btn_Click(object sender, EventArgs e)
        {
            int idTable = ((sender as Button).Tag as Table).Id;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(idTable);
        }
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();
            Hide();
            fAdmin.InsertFood += fAdmin_InsertFood;
            fAdmin.UpdateFood += fAdmin_UpdateFood;
            fAdmin.DeleteFood += fAdmin_DeleteFood;
            fAdmin.ShowDialog();
            Show();
        }

        private void fAdmin_DeleteFood(object sender, EventArgs e)
        {
            LoadProductByCategoryId((cbCategory.SelectedItem as Category).Id);
        }

        private void fAdmin_UpdateFood(object sender, EventArgs e)
        {
            LoadProductByCategoryId((cbCategory.SelectedItem as Category).Id);
            ShowBill((lsvBill.Tag as Table).Id);
        }

        private void fAdmin_InsertFood(object sender, EventArgs e)
        {
            LoadProductByCategoryId((sender as Product).Id);
        }

        //Event click profile
        private void ProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fProfile profile = new fProfile(account);
            Hide();
            profile.ShowDialog();
            Show();
        }
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }

            Category selected = cb.SelectedItem as Category;
            LoadProductByCategoryId(selected.Id);
        }
        private void btnAddproduct_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if (table == null) return;
            int idBill = BillDAO.Instance.GetUncheckOutBillByTableId(table.Id, 0);
            int idProduct = (cbProduct.SelectedItem as Product).Id;
            int count = (int)nmProductcount.Value;
            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.Id);
                BillInfoDAO.Instance.InsertBillInfo(idProduct, BillDAO.Instance.GetBillIdMax(), count);
                LoadTable();
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idProduct, idBill, count);
            }
            ShowBill(table.Id);
        }
        //check out click
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = BillDAO.Instance.GetUncheckOutBillByTableId(table.Id, 0);
            int disCount = (int)nmDiscount.Value;
            string payment = txtTotalPayment.Text.Split(',')[0].Replace(".", string.Empty);
            if (string.IsNullOrWhiteSpace(payment))
            {
                return;
            }

            decimal totalPayment = Convert.ToDecimal(txtTotalPayment.Text.Split(',')[0].Replace(".", string.Empty));
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            decimal pay = totalPayment - totalPayment * disCount / 100;
            if (idBill != -1)
            {
                if (MessageBox.Show("Do you want to checkout " + table.Name + " ?" + $" \n TotalPrice = {pay.ToString("#,###", cul.NumberFormat)} Vnđ", "Confirm!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //Checkout
                    BillDAO.Instance.CheckOut(idBill, disCount, pay);
                    ShowBill(table.Id);
                    LoadTable();
                }
            }
        }
        private void btnSwitchtable_Click(object sender, EventArgs e)
        {
            Table table1 = lsvBill.Tag as Table;
            Table table2 = cbSwitchTable.SelectedItem as Table;
            if (MessageBox.Show($"Do you want to switch {table1.Name} to {table2.Name}?", "Confirm:", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                bool result = TableDAO.Instance.SwitchTable(table1.Id, table2.Id);
                if (result)
                {
                    MessageBox.Show("Success!");
                }
                else
                {
                    MessageBox.Show("Fail!");
                }

                LoadTable();
            }
        }
        #endregion


    }
}
