using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using IceCreamManage.DAO;
using IceCreamManage.DTO;

namespace IceCreamManage
{
    public partial class HideUnhide : Form
    {
        BindingSource IceCreamList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource tableList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        public Account loginAccount;

        public HideUnhide()
        {
          

            InitializeComponent();
            LoadInfo();
            LoadDateTimePickerBill();
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            dtgvIceCreamCategory.Columns["CategoryID"].Visible = false;
            dtgvAccount.Columns["Password"].Visible = false;
            dtgvAccount.Columns["Password2"].Visible = false;

        }

        #region methods
        // Đưa thông tin thức an
        void LoadInfo()
        {
            dtgvIceCreamCategory.DataSource = IceCreamList;
            dtgvAccount.DataSource = accountList;
            dtgvTable.DataSource = tableList;
            dtgvCategory1.DataSource = categoryList;
            

            LoadDateTimePickerBill();

            LoadListIceCream();
            LoadCategory();
            LoadAccount();
            LoadListTable();
            LoadCategoryIntoCombobox(cbIceCreamCategory);
            AddIceCreamBinding();
            AddAccountBinding();
            AddTableBinding();
            AddCategoryBinding();
        }

        void AddAccountBinding()
        {
            txbAccountName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            dupType.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
            nupSex.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Sex", true, DataSourceUpdateMode.Never));
            nupAge.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "age", true, DataSourceUpdateMode.Never));
            txbNumber.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Number", true, DataSourceUpdateMode.Never));
            txbEmail.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Email", true, DataSourceUpdateMode.Never));
            txbAddress.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Address", true, DataSourceUpdateMode.Never));
           
        }


        void AddIceCreamBinding()
        {
            txbIceCreamName.DataBindings.Add(new Binding("Text", dtgvIceCreamCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbIceCreamID.DataBindings.Add(new Binding("Text", dtgvIceCreamCategory.DataSource, "ID",true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvIceCreamCategory.DataSource, "Price", true, DataSourceUpdateMode.Never));
            txbdesFood.DataBindings.Add(new Binding("Text", dtgvIceCreamCategory.DataSource, "DescriptionFood", true, DataSourceUpdateMode.Never));
        }

        void AddTableBinding()
        {
            txbTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "id", true, DataSourceUpdateMode.Never));
            txbTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbTBstatus.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Status", true, DataSourceUpdateMode.Never));
        }
        void AddCategoryBinding()
        {
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory1.DataSource, "id", true, DataSourceUpdateMode.Never));
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory1.DataSource, "Name", true, DataSourceUpdateMode.Never));
            
        }

        // Lấy thông tin tài khoản
        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }


        // Load THống kê daonh thu

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }

     
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }
        void LoadListIceCream()
        {
            IceCreamList.DataSource = IceCreamDAO.Instance.GetListIceCream();
        }

        void LoadListTable()
        {
            tableList.DataSource = TableDAO.Instance.GetListTable();
        }
        #endregion
       
        void LoadCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }

 

        //Khai báo List Tìm đồ ăn
        List<IceCream> SearchIceCreamByName(string name)
        {
            List<IceCream> listIceCream = IceCreamDAO.Instance.SearchIceCreamByName(name);

            return listIceCream;
        }

        private void btnShowIceCream_Click(object sender, EventArgs e)
        {
            LoadListIceCream();
        }

        private void txbIceCreamID_TextChanged(object sender, EventArgs e)
        {
            LoadCategory();
            if (dtgvIceCreamCategory.SelectedCells.Count > 0)
            {
                if (dtgvIceCreamCategory.SelectedCells[0].OwningRow.Cells["CategoryID"].Value != null)
                {
                    int id = (int)dtgvIceCreamCategory.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                    Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                    cbIceCreamCategory.SelectedItem = cateogory;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbIceCreamCategory.Items)
                    {
                        if (item.ID == cateogory.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbIceCreamCategory.SelectedIndex = index;
                }
            }
        }
        //Các hàm thao tác với account
        void AddAccount(string userName, string displayName, string type, string sex,int age,string number,string email,string address)
        {
            if(txbAccountName.Text == null || txbAccountName.Text == "")
            {
                MessageBox.Show("Username must not be empty !", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (AccountDAO.Instance.InsertAccount(userName, displayName, type,sex,age,number,email,address))
            {
                MessageBox.Show("Add account success", "Announcement", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Add accounts failed !", "Announcement", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            LoadAccount();
        }

        void EditAccount(string userName, string displayName, string type, string sex, int age, string number, string email, string address)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type, sex, age, number, email, address))
            {
                MessageBox.Show("Edit account success", "Announcement", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Add accounts failed !", "Announcement", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
            if (MessageBox.Show("Are you sure you want to Delete ?", "Announcement", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {

            }
            else
            {

                if (loginAccount.UserName.Equals(userName))
                {
                    MessageBox.Show("You can't delete yourself", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (AccountDAO.Instance.DeleteAccount(userName))
                {
                    MessageBox.Show("Delete account success", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Delete accounts failed !", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LoadAccount();
            }
        }

        void ResetPass(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Reset password success", "Announcement", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Reset password failed", "Announcement", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        //*******

        //thêm món ăn
        private void btnAddIceCream_Click(object sender, EventArgs e)
        {
            string name = txbIceCreamName.Text;
            if(cbIceCreamCategory.SelectedItem as Category == null)
            {
                MessageBox.Show("Error", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int categoryID = (cbIceCreamCategory.SelectedItem as Category).ID;

                float price = (float)nmFoodPrice.Value;
                string desFood = txbdesFood.Text;

                if (IceCreamDAO.Instance.InsertIceCream(name, categoryID, price, desFood))
                {
                    MessageBox.Show("Add food success", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListIceCream();
                    if (insertIceCream != null)
                        insertIceCream(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("There are errors when adding food", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        //Sửa món ăn
        private void btnEditIceCream_Click(object sender, EventArgs e)
        {
            string name = txbIceCreamName.Text;
            if (cbIceCreamCategory.SelectedItem as Category == null)
            {
                MessageBox.Show("Error", "Announcement",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                int categoryID = (cbIceCreamCategory.SelectedItem as Category).ID;
                float price = (float)nmFoodPrice.Value;
                string desFood = txbdesFood.Text;
                int id = Convert.ToInt32(txbIceCreamID.Text);

                if (IceCreamDAO.Instance.UpdateIceCream(id, name, categoryID, price, desFood))
                {
                    MessageBox.Show("Edit food success", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListIceCream();
                    if (updateIceCream != null)
                        updateIceCream(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("There was an error editing food", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        //Xóa món ăn
        private void btnDeleteIceCream_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbIceCreamID.Text);

            if (MessageBox.Show("Are you sure you want to Delete ?", "Announcement", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {

            }
            else if (IceCreamDAO.Instance.DeleteIceCream(id))
            {
                MessageBox.Show("Delete food success", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListIceCream();
                if (deleteIceCream != null)
                    deleteIceCream(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("There are errors when delete food", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //tạo Event để thao tác với IceCream
        private event EventHandler insertIceCream;
        public event EventHandler InsertIceCream
        {
            add { insertIceCream += value; }
            remove { insertIceCream -= value; }
        }

        private event EventHandler deleteIceCream;
        public event EventHandler DeleteIceCream
        {
            add { deleteIceCream += value; }
            remove { deleteIceCream -= value; }
        }

        private event EventHandler updateIceCream;
        public event EventHandler UpdateIceCream
        {
            add { updateIceCream += value; }
            remove { updateIceCream -= value; }
        }
        //button tim kem
        private void btnSearchIceCream_Click(object sender, EventArgs e)
        {
            IceCreamList.DataSource = SearchIceCreamByName(txbSearchIceCream.Text);
        }

        //Xem tất cả tài khoản
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }
        //btn thêm acc
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbAccountName.Text;
            string displayName = txbDisplayName.Text;
            string type = dupType.Text;
            //int type = (int)nmTypeAcc.Value;
            string sex = nupSex.Text;
            int age = (int)nupAge.Value;
         
            string number = txbNumber.Text;
            string email = txbEmail.Text;
            string address = txbAddress.Text;

            AddAccount(userName, displayName,type,sex,age,number,email,address);
        }
        //btn xóa acc
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txbAccountName.Text;

            DeleteAccount(userName);
        }
       // btn sửa acc
        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txbAccountName.Text;
            string displayName = txbDisplayName.Text;
            string type = dupType.Text;
            //int type = (int)nmTypeAcc.Value;
            string sex = nupSex.Text;
            int age = (int)nupAge.Value;
            string number = txbNumber.Text;
            string email = txbEmail.Text;
            string address = txbAddress.Text;

            EditAccount(userName, displayName, type, sex, age, number, email, address);
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string userName = txbAccountName.Text;

            ResetPass(userName);
        }
        // Hiển thị Thống kê Doanh thu
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }
        
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string name = txbTableName.Text;
            string status = txbTBstatus.Text;
            if (status == "Empty")
            {
                if (TableDAO.Instance.InsertTable(name, status))
                {
                    MessageBox.Show("Add table success", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListTable();
                    if (insertTable != null)
                    {
                        insertTable(this, new EventArgs());

                    }
                    else
                    {
                        MessageBox.Show("There are errors when adding table", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("There are errors when adding table", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private void btnEditTable_Click(object sender, EventArgs e)
        {
            if (txbTableID.Text == "")
            {
                MessageBox.Show("Error", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = Convert.ToInt32(txbTableID.Text);
                string name = txbTableName.Text;
                string status = txbTBstatus.Text;
                if (TableDAO.Instance.UpdateTable(id, name, status))
                {

                    MessageBox.Show("Edit table success", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListTable();
                    if (updateTable != null)
                    {
                        updateTable(this, new EventArgs());

                    }
                }
                else
                {
                    MessageBox.Show("There are errors when editing table", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }
        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if(txbTableID.Text == "")
            {
                MessageBox.Show("Error", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int idTable = Convert.ToInt32(txbTableID.Text);
                string status = txbTBstatus.Text;
                if (MessageBox.Show("Are you sure you want to Delete ?", "Announcement", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
                {

                }
                else if (status == "Empty")
                {
                    if (TableDAO.Instance.DeleteTable(idTable))
                    {
                        MessageBox.Show("Delete table success", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadListTable();
                        if (deleteTable != null)
                        {
                            deleteTable(this, new EventArgs());
                            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There are errors when delete table", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }
        //tạo Event để thao tác với table
        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }
        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }
        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }

        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            
            string name = txbCategoryName.Text;
            if (CategoryDAO.Instance.InsertCategory(name))
            {

                MessageBox.Show("Add category food success", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategory();
                if (insertCategory != null)
                {
                    insertCategory(this, new EventArgs());


                }
            }
            else
            {
                MessageBox.Show("There are errors when adding category food", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbCategoryID.Text);
            string name = txbCategoryName.Text;
            if (CategoryDAO.Instance.UpdateCategory(id, name))
            {

                MessageBox.Show("Edit category food success", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategory();
                if (updateCategory != null)
                {
                    updateCategory(this, new EventArgs());

                }
            }
            else
            {
                MessageBox.Show("There are errors when editing category food", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbCategoryID.Text);

            if (MessageBox.Show("Are you sure you want to Delete ?", "Announcement", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {

            }
            else if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Delete category food success", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategory();
                if (deleteCategory != null)
                {
                    deleteCategory(this, new EventArgs());
                    LoadListIceCream();
                }
            }
            else
            {
                MessageBox.Show("There are errors when delete category food", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //tạo Event để thao tác với table
        private event EventHandler insertCategory;
        public event EventHandler InsertCategory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }
        private event EventHandler updateCategory;
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }
        private event EventHandler deleteCategory;
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
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

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadCategory();
        }
        List<Table> SearchTableByStatus(string status)
        {
            List<Table> listTable = TableDAO.Instance.SearchTableByStatus(status);

            return listTable;
        }
        private void btnSearchTableByStatus_Click(object sender, EventArgs e)
        {
            tableList.DataSource = SearchTableByStatus(txbSearchTableByStatus.Text);
        }
        List<Account> SearchUserByDisplayname(string displayname)
        {
            List<Account> listAccount = AccountDAO.Instance.SearchUserByDisplayName(displayname);
            return listAccount;
        }
        private void btnSearchUserByDisplay_Click(object sender, EventArgs e)
        {
            accountList.DataSource = SearchUserByDisplayname(txbSearchUserByDisplay.Text);
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Left = 0;
            this.Top = 0;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }


        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
        
        private void hideshowcol(int index, CheckBox cb)
        {
            if (cb.Checked == true)
            {
                dtgvAccount.Columns[index].Visible = false;
            }
            else
            {
                dtgvAccount.Columns[index].Visible = true;
            }
        }
        private void UnHideHideCol_CheckedChanged(object sender, EventArgs e)
        {
            hideshowcol(0, UnHideHideCol0);
        }

        private void UnHideHideCol1_CheckedChanged(object sender, EventArgs e)
        {
            hideshowcol(1, UnHideHideCol1);
        }

        private void UnHideHideCol2_CheckedChanged(object sender, EventArgs e)
        {
            hideshowcol(2, UnHideHideCol2);
        }

        private void UnHideHideCol3_CheckedChanged(object sender, EventArgs e)
        {
            hideshowcol(3, UnHideHideCol3);
        }

        private void UnHideHideCol4_CheckedChanged(object sender, EventArgs e)
        {
            hideshowcol(4, UnHideHideCol4);
        }
        private void UnHideHideCol5_CheckedChanged(object sender, EventArgs e)
        {
            hideshowcol(5, UnHideHideCol5);
        }
        private void UnHideHideCol6_CheckedChanged(object sender, EventArgs e)
        {
            hideshowcol(6, UnHideHideCol6);
        }

        private void UnHideHideCol7_CheckedChanged(object sender, EventArgs e)
        {
            hideshowcol(7, UnHideHideCol7);
        }

        private void pbRevExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbCateExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbFoodExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbTableExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbAccExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
