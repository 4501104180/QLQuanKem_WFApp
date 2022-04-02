﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceCreamManage.DTO;

namespace IceCreamManage.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set => instance = value;
        }

        private BillDAO() { }
        /// <summary>
        /// Thành công: bill ID
        /// Thất bại: -1
        /// </summary>
        /// <param name="idTable"></param>
        /// <returns></returns>

        public int GetUnCheckBillIDByTableID(int idTable)
        {
            string query = "USP_GetUnCheckBillIDByTableID @idTable";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idTable });

            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }

        public void CheckOut(int id, int discount, float totalPrice)
        {
            string query = "UPDATE dbo.Bill SET dateCheckOut = GETDATE(), status = 1, " + "discount = " + discount + ", totalPrice = " + totalPrice + " WHERE id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }



        public void InsertBill(int id)
        {
            string query = "exec USP_InsertBill @idTable";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
        }

        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }

        public void DeleteBillByTableFoodID(int id)
        {
            BillInfoDAO.Instance.DeleteBillInfoByBillID(id);
            string query = string.Format("Delete Bill where idTable = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
        }
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM Bill");
            }
            catch
            {
                return 1;
            }
        }
    }
}
