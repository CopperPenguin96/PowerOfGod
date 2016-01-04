using Newtonsoft.Json;

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
