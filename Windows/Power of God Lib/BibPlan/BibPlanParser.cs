using Newtonsoft.Json;
using Power_of_God_Lib.BibPlan;

namespace BibPlans
{
    public class BibPlanParser
    {
        public static BibPlan BiblicalPlan(string content)
        {
            return JsonConvert.DeserializeObject<BibPlan>(content);
        }
    }
}
