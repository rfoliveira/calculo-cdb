using System.Net.Http.Formatting;

namespace CalculoCDB.API.App_Start
{
    public static class FormattersConfig
    {
        public static void Configure(this MediaTypeFormatterCollection formatters)
        {
            var json = formatters.JsonFormatter;
            json.UseDataContractJsonSerializer = true;

            formatters.Remove(formatters.XmlFormatter);
        }
    }
}