using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamManage.DTO
{
    public class IceCream
    {
        public IceCream(int id, string name, int categoryID, float price, string desfood)
        {
            this.ID = id;
            this.Name = name;
            this.CategoryID = categoryID;
            this.Price = price;
            this.DescriptionFood = desfood;
        }
        public IceCream(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.CategoryID = (int)row["IDCategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.DescriptionFood = row["DescriptionFood"].ToString();
        }

        private float price;
        private int categoryID;
        private string name;
        private int iD;
        private string desFood;
        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public float Price { get => price; set => price = value; }
        public string DescriptionFood { get => desFood; set => desFood = value; }
    }
}
