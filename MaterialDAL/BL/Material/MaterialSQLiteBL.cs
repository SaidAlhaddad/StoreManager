using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDAL.BL.Material
{
    class MaterialSQLiteBL : IMaterialBL
    {
        
        static string TBL_MATERIAL = "TBL_MATERIAL";
        static string id_column = "id";
        static string name_column = "name";
        static string unit_column = "unit";
        static string price_column = "price";
        static string quantity_column = "quantity";
        public bool add(Models.Material material)
        {
            //Insert query
            //Ex : Insert into TBL_MATERIAL (name,unit,price,quantity) values('shminto','kies',2000.0,5)
            string query = String.Format("Insert into {0} ({1},{2},{3},{4}) values('{5}','{6}',{7},{8})"
                , TBL_MATERIAL, name_column, unit_column, price_column, quantity_column,
                material.name, material.unit, material.price,material.quantity);

            DAL.SQLiteDataAccessLayer dal = DAL.SQLiteDataAccessLayer.getInstance();

            //Return false if there is a problem in add operation ,else return true
            try
            {
                dal.executeCommand(query);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool delete(Models.Material material)
        {
            //Delete query
            //Ex : Delete from TBL_MATERIAL where id = 1
            string query = String.Format("Delete from {0} where {1} = {2}"
                , TBL_MATERIAL, id_column , material.id);

            DAL.SQLiteDataAccessLayer dal = DAL.SQLiteDataAccessLayer.getInstance();


            if (material.isExist())//Delete the material if exists
            {
                //Return false if there is a problem in delete operation ,else return true
                try
                {
                    dal.executeCommand(query);
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;//return false if the material not exists
            }
            return true;
        }
        public bool update(Models.Material material)
        {
            //Delete query
            //Ex : Update TBL_MATERIAL set name = 'theen' , unit = 'shwal', price = 12000 , quantity = 8 where id = 1
            string query = String.Format("Update {0} set {1} = '{2}' , {3} = '{4}' , {5} = {6} , {7} = {8} where {9} = {10}"
                , TBL_MATERIAL,name_column,material.name,unit_column,material.unit,price_column,
                material.price,quantity_column,material.quantity, id_column, material.id);

            DAL.SQLiteDataAccessLayer dal = DAL.SQLiteDataAccessLayer.getInstance();


            if (material.isExist())//Delete the material if exists
            {
                //Return false if there is a problem in delete operation ,else return true
                /*try
                {*/
                    dal.executeCommand(query);
                /*}
                catch
                {
                    return false;
                }*/
            }
            else
            {
                return false;//return false if the material not exists
            }
            return true;
        }
        public bool isExist(Models.Material material)
        {
            //
            string query = String.Format("SELECT EXISTS(SELECT 1 FROM {0} WHERE {1}={2} LIMIT 1)"
                , TBL_MATERIAL, id_column, material.id);

            DAL.SQLiteDataAccessLayer dal = DAL.SQLiteDataAccessLayer.getInstance();
            List<string> result= dal.executeReturnValue(query);

            if (result[0] == "1")//if returned 1 => it exists , if returned 0 => it not exists
                return true;
            else
                return false;
        }
        public DataTable selectAllMaterials()
        {
            string query = String.Format("SELECT * from {0}", TBL_MATERIAL);

            DAL.SQLiteDataAccessLayer dal = DAL.SQLiteDataAccessLayer.getInstance();
            DataTable dt = dal.selectData(query);

            return dt;
        }
    }
}
