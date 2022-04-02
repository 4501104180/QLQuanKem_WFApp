using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamManage.DTO
{
    public class Account
    {
        public Account(string userName, string displayName, string type, string sex, int age, string number,string email, string address, string password = null, string password2 = null)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Type = type;
            this.Sex = sex;
            this.Age = age;
            this.Number = number;
            this.Email = email;
            this.Address = address;
            this.Password = password;
            this.Password2 = password2;
        }

        public Account(DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.DisplayName = row["displayName"].ToString();
            this.Type = row["type"].ToString();
            this.Sex = row["sex"].ToString();
            this.Age = (int)row["age"];
            this.Number = row["number"].ToString();
            this.Email = row["Email"].ToString();
            this.Address = row["addresss"].ToString();
            this.Password = row["password"].ToString();
            this.Password2 = row["password2"].ToString();
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string displayName;

        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private string sex;
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private string number;
        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string password2;

        public string Password2
        {
            get { return password2; }
            set { password2 = value; }
        }
    }
}
