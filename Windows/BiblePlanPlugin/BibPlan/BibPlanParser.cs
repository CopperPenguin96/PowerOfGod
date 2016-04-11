using Newtonsoft.Json;

namespace BiblePlanPlugin.BibPlan
{
    public class BibPlanParser
    {
        public static BibPlan BiblicalPlan(string content)
        {
            return JsonConvert.DeserializeObject<BibPlan>(content);
        }
    }
}
