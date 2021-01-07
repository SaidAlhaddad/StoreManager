using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDAL.Models
{
    class Material
    {
        public int id;
        public string name;
        public string unit;
        public double price;
        public int quantity;

        public Material(int id, string name, string unit, double price, int quantity)
        {
            this.id = id;
            this.name = name;
            this.unit = unit;
            this.price = price;
            this.quantity = quantity;
        }

        public Material(string name, string unit, double price, int quantity)
        {
            this.name = name;
            this.unit = unit;
            this.price = price;
            this.quantity = quantity;
        }

        public bool isExist()
        {
            BL.Material.IMaterialBL bl = new BL.Material.MaterialSQLiteBL();
            return bl.isExist(this);
        }
    }
}
