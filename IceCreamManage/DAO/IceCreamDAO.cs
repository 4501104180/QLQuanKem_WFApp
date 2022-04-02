using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceCreamManage.DTO;

namespace IceCreamManage.DAO
{
    public class IceCreamDAO
    {
        private static IceCreamDAO instance;

        public static IceCreamDAO Instance
        {
            get { if (instance == null) instance = new IceCreamDAO(); return IceCreamDAO.instance; }
            private set => instance = value;
        }

        private IceCreamDAO() { }

        //truy vấn sql dùng trong việc tìm kiếm thức ăn

        public int getIDIceCreamByName(string iceCreamName)
        {
            string query = "SELECT id FROM Food WHERE Name = N'" + iceCreamName + "'";
            return Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
        }
        public List<IceCream> SearchIceCreamByName(string name)
        {
            List<IceCream> list = new List<IceCream>();

            string query = string.Format("SELECT * FROM dbo.Food WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                IceCream food = new IceCream(item);
                list.Add(food);
            }

            return list;
        }
        public List<IceCream> GetIceCreamByCategoryID(int id)
        {
            List<IceCream> list = new List<IceCream>();

            string query = "Select * from Food where idCategory = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                IceCream food = new IceCream(item);
                list.Add(food);
            }

            return list;
        }
        public List<IceCream> GetListIceCream()
        {
            List<IceCream> list = new List<IceCream>();

            string query = "select * from food";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                IceCream food = new IceCream(item);
                list.Add(food);
            }

            return list;
        }
        public bool InsertIceCream(string name, int id, float price ,string desfood)
        {
            string query = string.Format("INSERT dbo.Food ( name, idCategory , price , DescriptionFood )VALUES  ( N'{0}', {1}, {2}, N'{3}')", name, id, price,desfood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateIceCream(int idFood, string name, int id, float price, string desfood)
        {
            string query = string.Format("UPDATE dbo.Food SET name = N'{0}', idCategory = {1}, price = {2}, DescriptionFood = N'{4}' WHERE id = {3}", name, id, price, idFood,desfood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public void DeleteIceCreamByCategoryID(int id)
        {
            BillInfoDAO.Instance.DeleteFoodCategoryByBillInfoByFoodID();
            DataProvider.Instance.ExecuteQuery("delete Food where idCategory ="+ id);

        }
        public bool DeleteIceCream(int idFood)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(idFood);

            string query = string.Format("Delete Food where id = {0}", idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        
    }
}
