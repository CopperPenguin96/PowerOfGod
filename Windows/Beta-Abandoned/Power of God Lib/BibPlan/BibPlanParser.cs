using Newtonsoft.Json;
using Power_of_God_Lib.BibPlan;

namespace BibPlans
{
    public class BibPlanParser
    {
        /// <summary>
        /// Bible Plan object
        /// </summary>
        /// <param name="content">JSON Conent of BibPlan File</param>
        /// <returns>BibPlan object based on JSON string</returns>
        public static BibPlan BiblicalPlan(string content)
        {
            return JsonConvert.DeserializeObject<BibPlan>(content);
        }
    }
}
