using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu = QuanLyQuanCafe.DTO.Menu;

namespace QuanLyQuanCafe
{
    public partial class fHome : Form
    {
        public fHome()
        {
            InitializeComponent();

            LoadTable();
        }

        #region Method
        private void LoadTable()
        {
            List<Table> TableList = TableDAO.Instance.GetListTable();
            foreach (Table item in TableList)
            {
                Button btn = new Button()
                {
                    Width = Table.TableWidth,
                    Height = Table.TableHeight,
                    Text = item.Name + Environment.NewLine + item.Status
                };
                btn.BackColor = item.Status == "Trống" ? Color.LightGreen : Color.Maroon;
                btn.Click += btn_Click;
                btn.Tag = item;
                flpTable.Controls.Add(btn);
            }
        }

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
            txtTotalPayment.Text = totalPayment.ToString("c", cul);
        }
        #endregion

        #region Events Handle
        private void btn_Click(object sender, EventArgs e)
        {
             int idTable = ((sender as Button).Tag as Table).Id;
             ShowBill(idTable);
        }
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();
            this.Hide();
            fAdmin.ShowDialog();
            this.Show();
        }
        //event click profile
        private void ProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fProfile profile = new fProfile();
            this.Hide();
            profile.ShowDialog();
            this.Show();
        }
        #endregion
    }
}
