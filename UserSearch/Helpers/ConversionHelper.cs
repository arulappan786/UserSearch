using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Text;

namespace UserSearch.Helpers
{
    public static class ConversionHelper
    {
        
        #region Public Functions

        public static SelectList BindDropDown(DataTable dt)
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lst.Add(new SelectListItem()
                    {
                        Text = Convert.ToString(item[1]),
                        Value = Convert.ToString(item[0])
                    });
                }
            }

            return new SelectList(lst, "Value", "Text");
        }

        public static SelectList BindDropDownFromEnum(Array enumValues, Type objType)
        {

            List<SelectListItem> lst = new List<SelectListItem>();

            foreach (var val in enumValues)
            {
                lst.Add(new SelectListItem
                {
                    Text = Enum.GetName(objType, val),
                    Value = val.ToString()
                });
            }

            return new SelectList(lst, "Value", "Text");
        }

        public static string ConvertIntoJson(DataTable dt)
        {
            var jsonString = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                jsonString.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jsonString.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                        jsonString.Append("\"" + dt.Columns[j].ColumnName + "\":\""
                            + dt.Rows[i][j].ToString().Replace('"', '\"') + (j < dt.Columns.Count - 1 ? "\"," : "\""));

                    jsonString.Append(i < dt.Rows.Count - 1 ? "}," : "}");
                }
                return jsonString.Append("]").ToString();
            }
            else
            {
                return "[]";
            }
        }


        #endregion
    }
}
