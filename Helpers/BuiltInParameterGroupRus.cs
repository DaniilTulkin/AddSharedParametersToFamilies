
using Autodesk.Revit.DB;

namespace AddSharedParametersToFamilies
{
    public class BuiltInParameterGroupRus
    {
        public static string ToRus(BuiltInParameterGroup builtInParameterGroup)
        {
            switch (builtInParameterGroup)
            {
                case BuiltInParameterGroup.INVALID:
                    return "Прочее";
                case BuiltInParameterGroup.PG_IDENTITY_DATA:
                    return "Идентификация";
                case BuiltInParameterGroup.PG_GEOMETRY:
                    return "Размеры";
                case BuiltInParameterGroup.PG_CONSTRUCTION:
                    return "Строительство";
                case BuiltInParameterGroup.PG_GRAPHICS:
                    return "Графика";
                case BuiltInParameterGroup.PG_MATERIALS:
                    return "Материалы и отделка";
                case BuiltInParameterGroup.PG_ELECTRICAL:
                    return "Электросети";
                case BuiltInParameterGroup.PG_PLUMBING:
                    return "Сантехника";
                case BuiltInParameterGroup.PG_STRUCTURAL:
                    return "Несущие конструкции";
                case BuiltInParameterGroup.PG_MECHANICAL:
                    return "Механизмы";
                case BuiltInParameterGroup.PG_PHASING:
                    return "Стадии";
                case BuiltInParameterGroup.PG_CONSTRAINTS:
                    return "Зависимости";
                case BuiltInParameterGroup.PG_TEXT:
                    return "Текст";
                case BuiltInParameterGroup.PG_ELECTRICAL_LIGHTING:
                    return "Электросети - освещение";
                case BuiltInParameterGroup.PG_ELECTRICAL_LOADS:
                    return "Электросети - Нагрузки";
                case BuiltInParameterGroup.PG_MECHANICAL_LOADS:
                    return "Механизмы - Нагрузки";
                case BuiltInParameterGroup.PG_MECHANICAL_AIRFLOW:
                    return "Механизмы - Расход";
                case BuiltInParameterGroup.PG_STRUCTURAL_ANALYSIS:
                    return "Расчёт несущих конструкций";
                case BuiltInParameterGroup.PG_ENERGY_ANALYSIS:
                    return "Расчёт энергопотребления";
                case BuiltInParameterGroup.PG_IFC:
                    return "Параметры IFC";
                case BuiltInParameterGroup.PG_REBAR_SYSTEM_LAYERS:
                    return "Слои";
                case BuiltInParameterGroup.PG_REBAR_ARRAY:
                    return "Набор арматурных стержней";
                case BuiltInParameterGroup.PG_ANALYTICAL_MODEL:
                    return "Аналитическая модель";
                case BuiltInParameterGroup.PG_FIRE_PROTECTION:
                    return "Система пожаротушения";
                case BuiltInParameterGroup.PG_TITLE:
                    return "Шрифты заголовков";
                case BuiltInParameterGroup.PG_GREEN_BUILDING:
                    return "Свойства экологически чистого здания";
                case BuiltInParameterGroup.PG_LIGHT_PHOTOMETRICS:
                    return "Фотометрические";
                case BuiltInParameterGroup.PG_SLAB_SHAPE_EDIT:
                    return "Редактирование формы перекрытия";
                case BuiltInParameterGroup.PG_ANALYSIS_RESULTS:
                    return "Результаты анализа";
                case BuiltInParameterGroup.PG_ADSK_MODEL_PROPERTIES:
                    return "Свойства модели";
                case BuiltInParameterGroup.PG_GENERAL:
                    return "Общие";
                case BuiltInParameterGroup.PG_ELECTRICAL_CIRCUITING:
                    return "Электросети - Создание цепей";
                case BuiltInParameterGroup.PG_DATA:
                    return "Данные";
                case BuiltInParameterGroup.PG_VISIBILITY:
                    return "Видимость";
                case BuiltInParameterGroup.PG_OVERALL_LEGEND:
                    return "Общая легенда";
                case BuiltInParameterGroup.PG_ANALYTICAL_ALIGNMENT:
                    return "Выравнивание аналитической модели";
                case BuiltInParameterGroup.PG_SEGMENTS_FITTINGS:
                    return "Сегменты и соединительные детали";
                case BuiltInParameterGroup.PG_FORCES:
                    return "Силы";
                case BuiltInParameterGroup.PG_MOMENTS:
                    return "Моменты";
                case BuiltInParameterGroup.PG_PRIMARY_END:
                    return "Основной конец";
                case BuiltInParameterGroup.PG_SECONDARY_END:
                    return "Второстепенный конец";
                case BuiltInParameterGroup.PG_RELEASES_MEMBER_FORCES:
                    return "Снятие связей/усилия для элемента";
                case BuiltInParameterGroup.PG_COUPLER_ARRAY:
                    return "Набор";
                default:
                    return null;
            }
        }

        public static BuiltInParameterGroup ToEng(string rus)
        {
            switch (rus)
            {
                case "Прочее":
                    return BuiltInParameterGroup.INVALID;
                case "Идентификация":
                    return BuiltInParameterGroup.PG_IDENTITY_DATA;
                case "Размеры":
                    return BuiltInParameterGroup.PG_GEOMETRY;
                case "Строительство":
                    return BuiltInParameterGroup.PG_CONSTRUCTION;
                case "Графика":
                    return BuiltInParameterGroup.PG_GRAPHICS;
                case "Материалы и отделка":
                    return BuiltInParameterGroup.PG_MATERIALS;
                case "Электросети":
                    return BuiltInParameterGroup.PG_ELECTRICAL;
                case "Сантехника":
                    return BuiltInParameterGroup.PG_PLUMBING;
                case "Несущие конструкции":
                    return BuiltInParameterGroup.PG_STRUCTURAL;
                case "Механизмы":
                    return BuiltInParameterGroup.PG_MECHANICAL;
                case "Стадии":
                    return BuiltInParameterGroup.PG_PHASING;
                case "Зависимости":
                    return BuiltInParameterGroup.PG_CONSTRAINTS;
                case "Текст":
                    return BuiltInParameterGroup.PG_TEXT;
                case "Электросети - освещение":
                    return BuiltInParameterGroup.PG_ELECTRICAL_LIGHTING;
                case "Электросети - Нагрузки":
                    return BuiltInParameterGroup.PG_ELECTRICAL_LOADS;
                case "Механизмы - Нагрузки":
                    return BuiltInParameterGroup.PG_MECHANICAL_LOADS;
                case "Механизмы - Расход":
                    return BuiltInParameterGroup.PG_MECHANICAL_AIRFLOW;
                case "Расчёт несущих конструкций":
                    return BuiltInParameterGroup.PG_STRUCTURAL_ANALYSIS;
                case "Расчёт энергопотребления":
                    return BuiltInParameterGroup.PG_ENERGY_ANALYSIS;
                case "Параметры IFC":
                    return BuiltInParameterGroup.PG_IFC;
                case "Слои":
                    return BuiltInParameterGroup.PG_REBAR_SYSTEM_LAYERS;
                case "Набор арматурных стержней":
                    return BuiltInParameterGroup.PG_REBAR_ARRAY;
                case "Аналитическая модель":
                    return BuiltInParameterGroup.PG_ANALYTICAL_MODEL;
                case "Система пожаротушения":
                    return BuiltInParameterGroup.PG_FIRE_PROTECTION;
                case "Шрифты заголовков":
                    return BuiltInParameterGroup.PG_TITLE;
                case "Свойства экологически чистого здания":
                    return BuiltInParameterGroup.PG_GREEN_BUILDING;
                case "Фотометрические":
                    return BuiltInParameterGroup.PG_LIGHT_PHOTOMETRICS;
                case "Редактирование формы перекрытия":
                    return BuiltInParameterGroup.PG_SLAB_SHAPE_EDIT;
                case "Результаты анализа":
                    return BuiltInParameterGroup.PG_ANALYSIS_RESULTS;
                case "Свойства модели":
                    return BuiltInParameterGroup.PG_ADSK_MODEL_PROPERTIES;
                case "Общие":
                    return BuiltInParameterGroup.PG_GENERAL;
                case "Электросети - Создание цепей":
                    return BuiltInParameterGroup.PG_ELECTRICAL_CIRCUITING;
                case "Данные":
                    return BuiltInParameterGroup.PG_DATA;
                case "Видимость":
                    return BuiltInParameterGroup.PG_VISIBILITY;
                case "Общая легенда":
                    return BuiltInParameterGroup.PG_OVERALL_LEGEND;
                case "Выравнивание аналитической модели":
                    return BuiltInParameterGroup.PG_ANALYTICAL_ALIGNMENT;
                case "Сегменты и соединительные детали":
                    return BuiltInParameterGroup.PG_SEGMENTS_FITTINGS;
                case "Силы":
                    return BuiltInParameterGroup.PG_FORCES;
                case "Моменты":
                    return BuiltInParameterGroup.PG_MOMENTS;
                case "Основной конец":
                    return BuiltInParameterGroup.PG_PRIMARY_END;
                case "Второстепенный конец":
                    return BuiltInParameterGroup.PG_SECONDARY_END;
                case "Снятие связей/усилия для элемента":
                    return BuiltInParameterGroup.PG_RELEASES_MEMBER_FORCES;
                case "Набор":
                    return BuiltInParameterGroup.PG_COUPLER_ARRAY;
                default:
                    return BuiltInParameterGroup.INVALID;
            }
        }
    }
}
