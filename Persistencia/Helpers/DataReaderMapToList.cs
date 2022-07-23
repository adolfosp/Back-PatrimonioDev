using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace Persistencia.Helpers
{
    public class DataReaderMapToList
    {

        [Obsolete(message: "Utilizar Dapper ao invés desse método")]
        public static List<Tdto> DataReaderToList<Tdto>(DbDataReader dr)
        {
            List<Tdto> list = new List<Tdto>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    var dto = Activator.CreateInstance<Tdto>();
                    foreach (PropertyInfo prop in dto.GetType().GetProperties())
                    {
                        if (dr.GetColumnSchema().Any(x => x.ColumnName.ToUpper() == prop.Name.ToUpper()))
                        {
                            if (!Equals(dr[prop.Name], DBNull.Value))
                            {
                                prop.SetValue(dto, dr[prop.Name], null);
                            }
                        }
                    }
                    list.Add(dto);
                }
                return list;
            }
            return new List<Tdto>();
        }

        [Obsolete(message: "Utilizar Dapper ao invés desse método")]
        public static Tdto DataReader<Tdto>(DbDataReader dr)
        {
            var dto = Activator.CreateInstance<Tdto>();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    foreach (PropertyInfo prop in dto.GetType().GetProperties())
                    {
                        if (dr.GetColumnSchema().Any(x => x.ColumnName.ToUpper() == prop.Name.ToUpper()))
                        {
                            if (!Equals(dr[prop.Name], DBNull.Value))
                            {
                                prop.SetValue(dto, dr[prop.Name], null);
                            }
                        }
                    }
                }
                return dto;
            }
            return dto;
        }
    }
}
