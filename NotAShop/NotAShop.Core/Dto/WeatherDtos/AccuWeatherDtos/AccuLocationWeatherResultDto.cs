using System;
using System.Collections.Generic;

namespace NotAShop.Core.Dto.WeatherDtos.AccuWeatherDtos
{
    public class AccuLocationWeatherResultDto
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public string PrimaryPostalCode { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public string EffectiveDate { get; set; }
        public Int64 EffectiveEpochDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public string EndDate { get; set; }
        public Int64 EndEpochDate { get; set; }


        public string DailyForecastsDate { get; set; }
        public int DailyForecastsEpochDate { get; set; }

        public double TempMinValue { get; set; }
        public string TempMinUnit { get; set; }
        public int TempMinUnitType { get; set; }

        public double TempMaxValue { get; set; }
        public string TempMaxUnit { get; set; }
        public int TempMaxUnitType { get; set; }

        public int DayIcon { get; set; }
        public string DayIconPhrase { get; set; }
        public bool DayHasPrecipitation { get; set; }
        public string DayPrecipitationType { get; set; }
        public string DayPrecipitationIntensity { get; set; }

        public int NightIcon { get; set; }
        public string NightIconPhrase { get; set; }
        public bool NightHasPrecipitation { get; set; }
        public string NightPrecipitationType { get; set; }
        public string NightPrecipitationIntensity { get; set; }

        public string MobileLink { get; set; }
        public string Link { get; set; }
    }

    public class RegionDto
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
    }

    public class CountryDto
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
    }

    public class AdministrativeAreaDto
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public int Level { get; set; }
        public string LocalizedType { get; set; }
        public string EnglishType { get; set; }
        public string CountryID { get; set; }
    }

    public class TimeZoneDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double GmtOffset { get; set; }
        public bool IsDaylightSaving { get; set; }
        public DateTime? NextOffsetChange { get; set; }
    }

    public class GeoPositionDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ElevationDto Elevation { get; set; }
    }

    public class ElevationDto
    {
        public MetricDto Metric { get; set; }
        public ImperialDto Imperial { get; set; }
    }

    public class MetricDto
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class ImperialDto
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class SupplementalAdminAreaDto
    {
        public int Level { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
    }
}
