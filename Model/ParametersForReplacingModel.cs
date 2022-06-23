using Autodesk.Revit.DB;
using Newtonsoft.Json;

namespace AddSharedParametersToFamilies
{
    public class ParametersForReplacingModel
    {
        [JsonIgnore]
        public FamilyParameter FamilyParameter { get; set; }

        [JsonIgnore]
        public ExternalDefinition SharedParameter { get; set; }

        public string FamilyParameterName { get; set; }
        public string SharedParameterName { get; set; }

    }
}
