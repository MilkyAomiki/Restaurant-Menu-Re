using System.Globalization;

namespace Web.Configuration
{
    public sealed class RegionOfApp
    {
        public static readonly RegionOfApp Instance = new RegionOfApp();
        public RegionInfo Current { get; } = new RegionInfo("en-US");

        static RegionOfApp()
        {
            
        }
    }
}
