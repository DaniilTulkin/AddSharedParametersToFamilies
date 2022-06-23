
using Autodesk.Revit.DB;

namespace AddSharedParametersToFamilies
{
    public class UnitGroupRus
    {
        public static string ToRus(UnitGroup unitGroup)
        {
            switch (unitGroup)
            {
                case UnitGroup.Common:
                    return "Общие";
                case UnitGroup.Structural:
                    return "Несущие конструкции";
                case UnitGroup.HVAC:
                    return "ОВК";
                case UnitGroup.Electrical:
                    return "Электросети";
                case UnitGroup.Piping:
                    return "Трубопроводы";
                case UnitGroup.Energy:
                    return "Энергия";
                default:
                    return null;
            }
        }
    }
}
