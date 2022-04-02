using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceCreamManage.DTO;

namespace IceCreamManage.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set => instance = value;
        }

        private CategoryDAO() { }
        public DataTable GetListCategoryByDataTable()
        {
            return DataProvider.Instance.ExecuteQuery("Select id as [ID loại] , name as [Tên loại] From FoodCategory");
        }

        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();

            string query = "Select * From FoodCategory";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }
            return list;
        }
        public Category GetCategoryByID(int id)
        {
            
            Category category = null;

            string query = "select * from FoodCategory where id = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }

            return category;
        }
        public int Check(string name)
        {
            string check = string.Format("SELECT * FROM dbo.FoodCategory WHERE Name = N'{0}'", name);
            var test = DataProvider.Instance.ExecuteScalar(check);
            if (test == null)
                return 1;
            else
                return 0;
        }
        public bool InsertCategory(string name)
        {
            if(Check(name) ==1)
            {
                string query = string.Format("INSERT dbo.FoodCategory ( Name ) VALUES ( N'{0}' )", name);
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            else
            {
                return false;
            }
            
        }
        public bool UpdateCategory(int idCategory, string name)
        {
            if (Check(name) == 1)
            {
                string query = string.Format("UPDATE dbo.FoodCategory SET Name = N'{1}' WHERE id = {0} ", idCategory, name);
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            else
            {
                return false;
            }
            
        }

        public bool DeleteCategory(int idCategory)
        {
           
            IceCreamDAO.Instance.DeleteIceCreamByCategoryID(idCategory);
            
            string query = string.Format("Delete FoodCategory where id = {0}", idCategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
