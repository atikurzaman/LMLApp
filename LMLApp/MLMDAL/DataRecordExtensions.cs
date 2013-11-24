using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace LMLApp
{
    public static class DataRecordExtensions
    {
        public static bool HasColumn(this IDataReader dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                //string s = dr.GetName(i);
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }

        public static bool IsNull(this IDataReader dr, string columnName)
        {
            // dr[columnName]
            if (Convert.IsDBNull(dr[columnName]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}