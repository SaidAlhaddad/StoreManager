using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDAL.BL.Material
{
    interface IMaterialBL
    {
        bool add(Models.Material material);
        bool update(Models.Material material);
        bool delete(Models.Material material);
        bool isExist(Models.Material material);
        DataTable selectAllMaterials();
    }
}
