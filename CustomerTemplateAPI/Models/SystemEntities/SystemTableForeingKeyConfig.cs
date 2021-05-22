
namespace CustomerTemplateAPI.Models
{
    public class SystemTableForeingKeyConfig 
    { 
        public int Id { get; set; }
        public string FkName { get; set; }

        public string SourceTableName { get; set; }

        public string SourceColumnName { get; set; }

        public int SourceColumnOrdinalPos { get; set; }

        public string RefrencedTableName { get; set; }

        public string RefrencedColumnName { get; set; }

        public int RefrencedColumnOrdinalPos { get; set; }

        public string MappedRefrencedColumnName { get; set; }

        public int MappedRefrencedColumnOrdinalPos { get; set; }
    }
}
