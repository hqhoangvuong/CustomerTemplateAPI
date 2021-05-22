
namespace CustomerTemplateAPI.Models
{
    public class SystemTableConfig
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ExplicitName { get; set; }

        public string ModelName { get; set; }

        public bool IsHidden { get; set; }

        public string ActionGroup { get; set; }
    }
}
