using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using IceCreamManage.DTO;

namespace IceCreamManage.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        internal static AccountDAO Instance
        {
            get {if (instance == null) instance = new AccountDAO(); return instance; }
            private set => instance = value;
        }
        private AccountDAO() { }

        //truy vấn đăng nhập từ database
        public bool Login(string username, string password)
        {
            string query = "EXEC USP_Login @username , @password";

            DataTable result = DataProvider.Instance.ExecuteQuery(query,new object[] {username, password });

            return result.Rows.Count > 0;
        }
        
        
        // quen mk cap 1
        public bool ForgotPassword(string userName,string newPass, string password2)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_ForgotPassWord @userName , @newPassword , @password", new object[] { userName,newPass,password2 });

            return result > 0;
        }
        // doi mk cap 1 
        public bool ChangePassword(string userName, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_ChangePassWord @userName1 , @password1 , @newPassword1", new object[] { userName, pass, newPass });

            return result > 0;
        }
        // doi mk cap 2
        public bool ChangePassword2(string userName, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_ChangePassWord2 @userName2 , @password2 , @newPassword2", new object[] { userName, pass, newPass });

            return result > 0;
        }
        // edit tk
        public bool UpdateAccount2(string userName, string displayName,string sex,int age,string number,string email, string address, string pass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @sex , @age , @number , @email , @address , @password", new object[]{userName, displayName, sex, age, number, email, address, pass});

            return result > 0;
        }

        //Lấy danh sách account từ database
        public DataTable GetListAccount2()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT UserName as [Tên tài khoản], DisplayName as [Tên hiển thị], Type as [Loại], Sex as [Giới tính], Age as [Tuổi], Number as [Số điện thoại], Email, Addresss as [Địa chỉ] FROM dbo.Account");
        }
        public List<Account> GetListAccount()
        {
            List<Account> list = new List<Account>();

            string query = "select * from Account";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Account acc = new Account(item);
                list.Add(acc);
            }

            return list;
        }
        public List<Account> SearchUserByDisplayName(string displayName)
        {
            List<Account> accList = new List<Account>();

            string query = string.Format("SELECT * FROM dbo.Account WHERE dbo.fuConvertToUnsign1(displayname) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", displayName);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Account acc = new Account(item);
                accList.Add(acc);
            }

            return accList;
        }
        //trả về kiểu Account khi bằng tk
        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where userName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }
        // kiểm tra username có bị trùng
        public int Check(string name)
        {
            string check = string.Format("SELECT * FROM dbo.Account WHERE UserName = N'{0}'", name);
            var test = DataProvider.Instance.ExecuteScalar(check);
            if (test == null)
                return 1;
            else
                return 0;
        }
        // đăng ký tài khoản
        public bool SignUPAccount(string name, string displayName,string password,string password2, string sex, int age, string number, string email, string address)
        {
            if (Check(name) == 1)
            {
                string query = string.Format("INSERT dbo.Account ( UserName , DisplayName , Password , Password2 , Sex , Age , Number , Email , Addresss )VALUES  ( N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', {5} , N'{6}' , N'{7}' , N'{8}')", name, displayName, password,password2, sex, age, number, email, address);
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            else
            {
                return false;
            }

        }
        //thêm tk
        public bool InsertAccount(string name, string displayName, string type, string sex, int age, string number, string email, string address )
        {
            if (Check(name) == 1)
            {
                string query = string.Format("INSERT dbo.Account ( UserName , DisplayName , Type , Sex , Age , Number , Email , Addresss )VALUES  ( N'{0}', N'{1}', N'{2}' , N'{3}', {4} , N'{5}', N'{6}', N'{7}' )", name, displayName, type, sex, age, number, email, address);
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            else
            {
                return false;
            }
            
        }
        //sửa
        public bool UpdateAccount(string name, string displayName, string type, string sex, int age, string number, string email, string address)
        {
            string query = string.Format("UPDATE dbo.Account SET DisplayName = N'{1}' , Type = N'{2}' , Sex = N'{3}' , Age = {4} , Number = N'{5}' , Email = N'{6}' , Addresss = N'{7}' WHERE UserName = N'{0}'", name, displayName, type, sex, age, number, email, address);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        //xóa
        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete Account where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        //đặt lại mk

        public bool ResetPassword(string name)
        {
            string query = string.Format("update account set password = N'0', password2 = N'0' where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
