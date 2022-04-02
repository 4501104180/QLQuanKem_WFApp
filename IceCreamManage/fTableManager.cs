using IceCreamManage.DAO;
using IceCreamManage.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;



namespace IceCreamManage
{
    public partial class fTableManager : Form
    {
        private Account loginAccount;
        
        
        public fTableManager(Account acc)
        {
            InitializeComponent();


            this.LoginAccount = acc;
            LoadTable();
            LoadCategory();
            LoadComboboxTable(cbSwitchTable);
        }
        #region Method

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";
        }

        void LoadIceCreamListByCategoryID(int id)
        {
            List<IceCream> listIceCream = IceCreamDAO.Instance.GetIceCreamByCategoryID(id);
            cbIceCream.DataSource = listIceCream;
            cbIceCream.DisplayMember = "Name";
        }
        
        void LoadTable()
        {
            flpTable.Controls.Clear();

            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                btn.TextAlign = ContentAlignment.BottomCenter;
                
                btn.ImageAlign = ContentAlignment.TopCenter;
                switch (item.Status) // Color Button
                {
                    case "Empty":
                        btn.BackColor = Color.Thistle;
                        btn.Image = new Bitmap(Application.StartupPath + @"\ban.png");
                        break;
                    default:
                        btn.BackColor = Color.Wheat;
                        btn.Image = new Bitmap(Application.StartupPath + @"\nguoiban3.png");
                        break;
                }

                flpTable.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<IceCreamManage.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            double tienkhachdua = 0;
            double tienthoi = 0;
            foreach(IceCreamManage.DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
               
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
                
            }
            CultureInfo culture = new CultureInfo("vi-VN"); // "vi-VN"
            //Thread.CurrentThread.CurrentCulture = culture;
            txbTotalPrice.Text = totalPrice.ToString(); //ToString("c", culture)
            txbPrice.Text = tienkhachdua.ToString();
            txbTienThoi.Text = tienthoi.ToString();
            
 
        }

        #endregion
        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }

        void ChangeAccount(string type)
        {
            adminToolStripMenuItem.Visible = type == "Admin";
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }

        
        #region Events
        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(LoginAccount);
            f.UpdateAccount += f_UpdateAccount;
            f.ShowDialog();
        }

        void f_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Account Infomation (" + e.Acc.DisplayName + ")";
            
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideUnhide f = new HideUnhide();
            f.loginAccount = LoginAccount;
            f.InsertIceCream += f_InsertIceCream;
            f.DeleteIceCream += f_DeleteIceCream;
            f.UpdateIceCream += f_UpdateIceCream;
            f.InsertTable += f_InsertTable;
            f.UpdateTable += f_UpdateTable;
            f.DeleteTable += f_DeleteTable;
            f.InsertCategory += f_InsertCategory;
            f.UpdateCategory += f_UpdateCategory;
            f.DeleteCategory += f_DeleteCategory;
            f.ShowDialog();
        }

        void f_UpdateIceCream(object sender, EventArgs e)
        {
            LoadIceCreamListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }

        void f_DeleteIceCream(object sender, EventArgs e)
        {
            LoadIceCreamListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
            LoadTable();
        }

        void f_InsertIceCream(object sender, EventArgs e)
        {
            LoadIceCreamListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }
        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }

        void f_InsertTable(object sender, EventArgs e)
        {
            LoadTable();
        }
        void f_UpdateTable(object sender, EventArgs e)
        {
            LoadTable();
        }
        void f_DeleteTable(object sender, EventArgs e)
        {
            LoadTable();
        }
        void f_InsertCategory(object sender, EventArgs e)
        {
            LoadCategory();
        }
        void f_UpdateCategory(object sender, EventArgs e)
        {
            LoadCategory();
        }
        void f_DeleteCategory(object sender, EventArgs e)
        {
            LoadCategory();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadIceCreamListByCategoryID(id);
        }
        private void cbIceCream_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            IceCream selectIceCream = cb.SelectedItem as IceCream;
            txbSelectFood.Text = selectIceCream.Name.ToString();
            txbPriceFood.Text = selectIceCream.Price.ToString();

        }
        List<IceCream> iceCreamsName;
        private void cbSearchFoodByName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ComboBox cb = sender as ComboBox;
            txbSelectFood.Text = cb.SelectedItem.ToString();
           foreach (IceCream item in iceCreamsName)
            {
                if(item.Name == cb.SelectedItem.ToString())
                {
                    txbPriceFood.Tag = item.Price;
                    
                }
            }
            txbPriceFood.Text = txbPriceFood.Tag.ToString();
        }

        
        private void btnAddIceCream_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if(table == null)
            {
                MessageBox.Show("You haven't selected a table yet !", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
                int idBill = BillDAO.Instance.GetUnCheckBillIDByTableID(table.ID);
                int idIceCream = IceCreamDAO.Instance.getIDIceCreamByName(txbSelectFood.Text);
                int count = (int)nmFoodCount.Value;
                if (idBill == -1) // chưa có bill
                {
                    BillDAO.Instance.InsertBill(table.ID);
                    BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), idIceCream, count);

                }
                else // bill đã có
                {
                    BillInfoDAO.Instance.InsertBillInfo(idBill, idIceCream, count);
                }

                ShowBill(table.ID);

                LoadTable();

                
            }
            
        }
        public static bool hasSpecialChar(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("You have not selected a table for payment", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int idBill = BillDAO.Instance.GetUnCheckBillIDByTableID(table.ID);
                int discount = (int)nmDiscount.Value;
                double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0].Replace(".", ""));
                double tienkhachdua = 0;
                if (Regex.IsMatch(txbPrice.Text, @"^[a-zA-Z]+$" ) || hasSpecialChar(txbPrice.Text))
                {
                    MessageBox.Show("Error cannot enter letters, special characters", "Announcement", MessageBoxButtons.OK,MessageBoxIcon.Error); return;
                    
                }
                else
                {
                    tienkhachdua = Convert.ToDouble(txbPrice.Text.Split(',')[0].Replace(".", ""));
                }
                
                double finalTotalPrice = (totalPrice - (totalPrice / 100) * discount);
                double tienthoi = tienkhachdua - finalTotalPrice;
                CultureInfo culture = new CultureInfo("vi-VN");
                
                string a = tienthoi.ToString("c", culture);
                string s = finalTotalPrice.ToString("c", culture);
                string ss = tienkhachdua.ToString("c", culture);
                txbTienThoi.Text = tienthoi.ToString();
                if(tienthoi < 0)
                {
                    txbTienThoi.Text = "0";

                }
                if (idBill != -1)
                {
                    if(tienkhachdua < finalTotalPrice)
                    {
                        if (MessageBox.Show("Pay " + table.Name + "\nTotal money after discount: \n" + s, "Announcement", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            BillDAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);
                            ShowBill(table.ID);

                            LoadTable();
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Pay " + table.Name + "\nTotal money after discount: \n" + s + "\nMoney paid by customers: " + ss + "\nMoney give back to customers: " + a, "Announcement", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            BillDAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);
                            ShowBill(table.ID);

                            LoadTable();
                        }
                    }
                   
                }
            }
            
        }
        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("You haven't selected a table to switch tables !", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                int id1 = (lsvBill.Tag as Table).ID;
                int id2 = (cbSwitchTable.SelectedItem as Table).ID;
                if ((lsvBill.Tag as Table).Status == "Empty" && (cbSwitchTable.SelectedItem as Table).Status == "Empty")
                {
                    MessageBox.Show("Unable to switch tables !", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if((lsvBill.Tag as Table).ID == (cbSwitchTable.SelectedItem as Table).ID)
                {
                    MessageBox.Show("The same table cannot be switch !", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (MessageBox.Show(string.Format("Do you really want to switch {0} to {1}", (lsvBill.Tag as Table).Name, (cbSwitchTable.SelectedItem as Table).Name), "Announcement", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    TableDAO.Instance.SwitchTable(id1, id2);


                    LoadTable();
                }
            }
        }
            
        #endregion

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fPassword password = new fPassword(LoginAccount);
            password.Show();
        }

        private void SearchIceCreamByName(string name)
        {
            cbSearchFoodByName.Items.Clear();
            List<IceCream> iceCreams = IceCreamDAO.Instance.SearchIceCreamByName(name);
            iceCreamsName = iceCreams;
            MessageBox.Show("Found " + iceCreams.Count() + " result", "Announcement", MessageBoxButtons.OK);
            foreach (IceCream item in iceCreams)
            {
                cbSearchFoodByName.Items.Add(item.Name);
            }
            
            

        }
        private void btnSearchFoodByName_Click(object sender, EventArgs e)
        {
            SearchIceCreamByName(txbSearchFood.Text);
        }

        private void fTableManager_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Left = 0;
            this.Top = 0;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void functionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddIceCream_Click(this, new EventArgs());
        }

        private void payToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCheckOut_Click(this, new EventArgs());
        }

        private void searchFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSearchFoodByName_Click(this, new EventArgs());
        }

        private void switchTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSwitchTable_Click(this, new EventArgs());
        }
    }
}
