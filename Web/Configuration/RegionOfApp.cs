using System.Globalization;

namespace Web.Configuration
{
    public class RegionOfApp
    {
        public static RegionInfo Current { get; } = new RegionInfo("en-US");
    }
}
