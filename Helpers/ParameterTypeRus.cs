using Autodesk.Revit.DB;

namespace AddSharedParametersToFamilies
{
    public class ParameterTypeRus
    {
        public static string ToRus(ParameterType parameterType)
        {
            switch (parameterType)
            {
                case ParameterType.Invalid:
                    return null;
                case ParameterType.Text:
                    return "Текст";
                case ParameterType.Integer:
                    return "Целое";
                case ParameterType.Number:
                    return "Число";
                case ParameterType.Length:
                    return "Длина";
                case ParameterType.Area:
                    return "Площадь";
                case ParameterType.Volume:
                    return "";
                case ParameterType.Angle:
                    return "Угол";
                case ParameterType.URL:
                    return "URL";
                case ParameterType.Material:
                    return "Материал";
                case ParameterType.YesNo:
                    return "Да/Нет";
                case ParameterType.Force:
                    return "Усилие";
                case ParameterType.LinearForce:
                    return "Распределенная нагрузка по линии";
                case ParameterType.AreaForce:
                    return "Распределённая нагрузка";
                case ParameterType.Moment:
                    return "Момент";
                case ParameterType.NumberOfPoles:
                    return "Количество полюсов";
                case ParameterType.FixtureUnit:
                    return "Расход приборов";
                case ParameterType.FamilyType:
                    return null;
                case ParameterType.LoadClassification:
                    return "Классификация нагрузок";
                case ParameterType.Image:
                    return "Изображение";
                case ParameterType.MultilineText:
                    return "Многостроничный текст";
                case ParameterType.HVACDensity:
                    return "Плотность";
                case ParameterType.HVACEnergy:
                    return "Энергия";
                case ParameterType.HVACFriction:
                    return "Трение";
                case ParameterType.HVACPower:
                    return "Мощность";
                case ParameterType.HVACPowerDensity:
                    return "Удельная мощность";
                case ParameterType.HVACPressure:
                    return "Давление";
                case ParameterType.HVACTemperature:
                    return "Температура";
                case ParameterType.HVACVelocity:
                    return "Скорость";
                case ParameterType.HVACAirflow:
                    return "Воздушный поток";
                case ParameterType.HVACDuctSize:
                    return "Размер воздуховода";
                case ParameterType.HVACCrossSection:
                    return "Поперечный разрез";
                case ParameterType.HVACHeatGain:
                    return "Теплоприток";
                case ParameterType.ElectricalCurrent:
                    return "Ток";
                case ParameterType.ElectricalPotential:
                    return "Электрический потенциал";
                case ParameterType.ElectricalFrequency:
                    return "Частота";
                case ParameterType.ElectricalIlluminance:
                    return "Освещённость";
                case ParameterType.ElectricalLuminousFlux:
                    return "Световой поток";
                case ParameterType.ElectricalPower:
                    return "Мощность";
                case ParameterType.HVACRoughness:
                    return "Шероховатость";
                case ParameterType.ElectricalApparentPower:
                    return "Полная установленная мощность";
                case ParameterType.ElectricalPowerDensity:
                    return "Удельная мощность";
                case ParameterType.PipingDensity:
                    return "Плотность";
                case ParameterType.PipingFlow:
                    return "Расход";
                case ParameterType.PipingFriction:
                    return "Трение";
                case ParameterType.PipingPressure:
                    return "Давление";
                case ParameterType.PipingTemperature:
                    return "Температура";
                case ParameterType.PipingVelocity:
                    return "Скорость";
                case ParameterType.PipingViscosity:
                    return "Динамическая вязкость";
                case ParameterType.PipeSize:
                    return "Размер трубы";
                case ParameterType.PipingRoughness:
                    return "Шероховатость";
                case ParameterType.Stress:
                    return "Напряжение";
                case ParameterType.UnitWeight:
                    return "Удельный вес";
                case ParameterType.ThermalExpansion:
                    return "Коэффициент теплового раширения";
                case ParameterType.LinearMoment:
                    return "Линейный момент";
                case ParameterType.ForcePerLength:
                    return "Сосредоточееный коэффициент упругости";
                case ParameterType.ForceLengthPerAngle:
                    return null;
                case ParameterType.LinearForcePerLength:
                    return null;
                case ParameterType.LinearForceLengthPerAngle:
                    return "Линейный угловой коэффициент упругости";
                case ParameterType.AreaForcePerLength:
                    return null;
                case ParameterType.PipingVolume:
                    return "Объём";
                case ParameterType.HVACViscosity:
                    return "Динамическая вязкость";
                case ParameterType.HVACCoefficientOfHeatTransfer:
                    return "Коэффициент теплопередачи";
                case ParameterType.HVACAirflowDensity:
                    return "Плотность воздушного потока";
                case ParameterType.Slope:
                    return "Уклон";
                case ParameterType.HVACCoolingLoad:
                    return "Холодильная нагрузка";
                case ParameterType.HVACCoolingLoadDividedByArea:
                    return "Холодильная нагрузка на единицу площади";
                case ParameterType.HVACCoolingLoadDividedByVolume:
                    return "Холодильная нагрузка на единицу объёма";
                case ParameterType.HVACHeatingLoad:
                    return "Отопительная нагрузка";
                case ParameterType.HVACHeatingLoadDividedByArea:
                    return "Отопительная нагрузка на единицу площади";
                case ParameterType.HVACHeatingLoadDividedByVolume:
                    return "Отопительная нагрузка на единицу объёма";
                case ParameterType.HVACAirflowDividedByVolume:
                    return "Воздушный поток на единицу объёма";
                case ParameterType.HVACAirflowDividedByCoolingLoad:
                    return "Воздушный поток, отнесённый к холодильной нагрузке"; 
                case ParameterType.HVACAreaDividedByCoolingLoad:
                    return "Площадь, отнесённая к холодильной нагрузке";
                case ParameterType.WireSize:
                    return "Диаметр провода";
                case ParameterType.HVACSlope:
                    return "Уклон";
                case ParameterType.PipingSlope:
                    return "Уклон";
                case ParameterType.Currency:
                    return "Денежная единица";
                case ParameterType.ElectricalEfficacy:
                    return "Эффективность";
                case ParameterType.ElectricalWattage:
                    return "Мощность";
                case ParameterType.ColorTemperature:
                    return "Цветовая температура";
                case ParameterType.ElectricalLuminousIntensity:
                    return "Сила света";
                case ParameterType.ElectricalLuminance:
                    return "Яркость";
                case ParameterType.HVACAreaDividedByHeatingLoad:
                    return "Площадь на единицу отопительной нагрузки";
                case ParameterType.HVACFactor:
                    return "Коэффициент";
                case ParameterType.ElectricalTemperature:
                    return "Темепратура";
                case ParameterType.ElectricalCableTraySize:
                    return "Размер кабельного лотка";
                case ParameterType.ElectricalConduitSize:
                    return "Размер короба";
                case ParameterType.ReinforcementVolume:
                    return "Объём арматуры";
                case ParameterType.ReinforcementLength:
                    return "Длина армирования";
                case ParameterType.ElectricalDemandFactor:
                    return "Коэффициент спроса нагрузки";
                case ParameterType.HVACDuctInsulationThickness:
                    return "Толщина изоляции воздуховода";
                case ParameterType.HVACDuctLiningThickness:
                    return "Толщина внутренней изоляции воздуховода";
                case ParameterType.PipeInsulationThickness:
                    return "Толщина изоляции трубы";
                case ParameterType.HVACThermalResistance:
                    return "Термостойкость";
                case ParameterType.HVACThermalMass:
                    return "Тепловая нагрузка";
                case ParameterType.Acceleration:
                    return "Ускорение";
                case ParameterType.BarDiameter:
                    return "Диаметр стержня";
                case ParameterType.CrackWidth:
                    return "Ширина трещины";
                case ParameterType.DisplacementDeflection:
                    return "Смещение/прогиб";
                case ParameterType.Energy:
                    return "Энергия";
                case ParameterType.StructuralFrequency:
                    return "Частота";
                case ParameterType.Mass:
                    return "Масса";
                case ParameterType.MassPerUnitLength:
                    return "Масса на единицу длины";
                case ParameterType.MomentOfInertia:
                    return "Момент инерции";
                case ParameterType.SurfaceArea:
                    return "Площадь поверхности на единицу длины";
                case ParameterType.Period:
                    return "Период";
                case ParameterType.Pulsation:
                    return "Пульсация";
                case ParameterType.ReinforcementArea:
                    return "Армирование по площади";
                case ParameterType.ReinforcementAreaPerUnitLength:
                    return "Армирование по площади на единицу длины";
                case ParameterType.ReinforcementCover:
                    return "Защитный слой армирвоания";
                case ParameterType.ReinforcementSpacing:
                    return "Интервал армирвоания";
                case ParameterType.Rotation:
                    return "Вращение";
                case ParameterType.SectionArea:
                    return "Площадь сечения";
                case ParameterType.SectionDimension:
                    return "Размеры сечения";
                case ParameterType.SectionModulus:
                    return "Момент сопротивления сечения";
                case ParameterType.SectionProperty:
                    return "Свойства сечения";
                case ParameterType.StructuralVelocity:
                    return "Скорость";
                case ParameterType.WarpingConstant:
                    return "Постоянная перкоса";
                case ParameterType.Weight:
                    return "Вес";
                case ParameterType.WeightPerUnitLength:
                    return "Вес на единицу длины";
                case ParameterType.HVACThermalConductivity:
                    return "Тепловроводность";
                case ParameterType.HVACSpecificHeat:
                    return "Удельная теплоёмкость";
                case ParameterType.HVACSpecificHeatOfVaporization:
                    return "Удельная теплоёмкость парообразования";
                case ParameterType.HVACPermeability:
                    return "Проницаемость";
                case ParameterType.ElectricalResistivity:
                    return "Электрическое удельное сопротивление";
                case ParameterType.MassDensity:
                    return "Массовая плотность";
                case ParameterType.MassPerUnitArea:
                    return "Масса на единицу площади";
                case ParameterType.PipeDimension:
                    return "Размер трубы";
                case ParameterType.PipeMass:
                    return "Масса";
                case ParameterType.PipeMassPerUnitLength:
                    return "Масса на единицу длины";
                case ParameterType.HVACTemperatureDifference:
                    return "Разность температур";
                case ParameterType.PipingTemperatureDifference:
                    return "Разность температур";
                case ParameterType.ElectricalTemperatureDifference:
                    return "Разность температур";
                case ParameterType.TimeInterval:
                    return "Время";
                case ParameterType.Speed:
                    return "Скорость";
                default:
                    return null;
            }
        }
    }
}
