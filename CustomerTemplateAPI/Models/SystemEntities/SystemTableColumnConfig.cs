using CustomerTemplateAPI.Consts;
using System.ComponentModel.DataAnnotations;

namespace CustomerTemplateAPI.Models
{
    public class SystemTableColumnConfig
    {
        public int Id { get; set; }

        public int TableId { get; set; }

        public string Name { get; set; }

        public string ExplicitName { get; set; }

        public string PropertyName { get; set; }

        public string DataType { get; set; }

        public string ExplicitDataType { get; set; }

        public int OrdinalPosition { get; set; }

        public UIComponents DisplayComponent { get; set; }

        public string IsNullable { get; set; }

        public bool IsPrimaryKey { get; set; }

        public bool IsForeignKey { get; set; }

        public bool IsHidden { get; set; }
    }
}
