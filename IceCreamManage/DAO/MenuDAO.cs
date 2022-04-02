using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IceCreamManage.DTO;

namespace IceCreamManage.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set => instance = value;
        }

        private MenuDAO() { }

        public List<IceCreamManage.DTO.Menu> GetListMenuByTable(int id)
        {
            List<IceCreamManage.DTO.Menu> listMenu = new List<IceCreamManage.DTO.Menu>();

            string query = "USP_GetListMenuByTable @id";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });

            foreach (DataRow item in data.Rows)
            {
                IceCreamManage.DTO.Menu menu = new DTO.Menu(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
