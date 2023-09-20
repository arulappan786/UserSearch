using Microsoft.AspNetCore.Mvc.Rendering;

namespace UserSearch.Data
{
    public class SearchParameter
    {
        public string UserName { get; set; } = string.Empty;
        public required SelectList UserList { get; set; }
        public string FieldName { get; set; } = string.Empty;
        public required SelectList UserFieldList { get; set; }
        public DataType FieldDataType { get; set; }
        public ControlType FieldControlType { get; set; }
       public bool Constraint { get; set; }
    }

    public enum DataType
    {
        String=1,
        Numeric=2,
        Float=3,
        DateTime=4
    }

    public enum ControlType
    {
        TextBox=1,
        NumericTextBox=2,
        DropdownList=3,
        DateTime=4
    }

    public enum Constraint
    {
        Mandatory=1,
        Optional=2
    }
}
