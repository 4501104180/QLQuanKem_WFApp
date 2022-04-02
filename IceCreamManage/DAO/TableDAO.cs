using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceCreamManage.DTO;
using IceCreamManage.DAO;

namespace IceCreamManage.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            set => instance = value;
        }

        public static int TableWidth = 104;
        public static int TableHeight = 104;
        private TableDAO() { }
        public DataTable GetTableByDataTable()
        {
            return DataProvider.Instance.ExecuteQuery("Select id as [ID bàn] , Name as [Tên bàn] , Status as [Trạng thái] from TableFood");
        }
        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idTable1 , @idTabel2", new object[] { id1, id2 });
        }

        public List<Table> SearchTableByStatus(string status)
        {
            List<Table> tableList = new List<Table>();

            string query = string.Format("SELECT * FROM dbo.TableFood WHERE dbo.fuConvertToUnsign1(status) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", status);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }
        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }
        public int Check(string name)
        {
            string check = string.Format("SELECT * FROM dbo.TableFood WHERE Name = N'{0}'", name);
            var test = DataProvider.Instance.ExecuteScalar(check);
            if (test == null)
                return 1;
            else
                return 0;
        }
        public bool InsertTable(string name, string status = "Empty")
        {
            if (Check(name) == 1)
            {
                string query = string.Format("INSERT dbo.TableFood (Name , Status )VALUES  ( N'{0}' , N'{1}' )", name, status);
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            else
            {
                return false;
            }
            
        }

        public bool UpdateTable(int idTable, string name, string status)
        {
            if (Check(name) == 1)
            {
                string query = string.Format("UPDATE dbo.TableFood SET Name = N'{1}', Status = N'{2}' WHERE id = {0}", idTable, name, status);
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            else
            {
                return false;
            }
            
        }

        public bool DeleteTable(int idTable)
        {
            BillDAO.Instance.DeleteBillByTableFoodID(idTable);
            string query = string.Format("Delete TableFood where id = {0}", idTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public List<Table> GetListTable()
        {
            List<Table> list = new List<Table>();

            string query = "select * from TableFood";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                list.Add(table);
            }

            return list;
        }
    }
}
