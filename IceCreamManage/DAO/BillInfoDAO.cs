using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceCreamManage.DTO;

namespace IceCreamManage.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set => instance = value;
        }

        private BillInfoDAO() { }

        public List <BillInfo> GetListBillInfo(int idBill)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            string query = "USP_GetListBillInfo @idBill";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idBill });
            
            foreach(DataRow item in data.Rows)
            {
                BillInfo billInfo = new BillInfo(item);
                listBillInfo.Add(billInfo);
            }

            return listBillInfo;
        }
        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            string query = "USP_InsertBillInfo @idBill ,  @idFood , @count";
            DataProvider.Instance.ExecuteQuery(query, new object[] { idBill, idFood, count });
        }
        public void DeleteBillInfoByFoodID(int id)
        {
            DataProvider.Instance.ExecuteQuery("delete dbo.BillInfo WHERE idFood = " + id);

        }
        public void DeleteBillInfoByBillID(int id)
        {
            
            DataProvider.Instance.ExecuteQuery("Delete BillInfo FROM Bill , BillInfo WHERE  idBill = Bill.id");

        }
        public void DeleteFoodCategoryByBillInfoByFoodID()
        {
            DataProvider.Instance.ExecuteQuery("delete BillInfo From Food , BillInfo WHERE idFood = Food.id ");

        }
    }
}
