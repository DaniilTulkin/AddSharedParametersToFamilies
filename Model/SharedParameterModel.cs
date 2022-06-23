using Autodesk.Revit.DB;
using Newtonsoft.Json;

namespace AddSharedParametersToFamilies
{
    public class SharedParameterModel
    {
        public string ParameterName { get; set; }
        public string ParameterGroup { get; set; }

        [JsonIgnore]
        public ExternalDefinition ExternalDefinition { get; set; }
        public BuiltInParameterGroup BuiltInParameterGroup { get; set; }
        public bool IsInstanse { get; set; }
    }
}
