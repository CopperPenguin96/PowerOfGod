using System;
using System.Collections.Generic;
using System.Linq;

namespace BibPlans
{
    public class VerseObj
    {
        public string Book;
        public int Chapter;
        public int Verse;
    }
    public class BibPlan
    {
        public string Name;
        public string Id;
        public List<List<VerseObj>> VerseList;
        public string VerseAuthor;

        public BibPlan(string name, string id, List<List<VerseObj>> verses, string verseauthor, bool isCreator)
        {
            Name = name;
            Id = id;
            if (!isCreator)
            {
                if (!ValidateId()) throw new Exception("The Bible Plan ID could not be validated. Possible duplicate?");
            }
            VerseList = verses;
            VerseAuthor = verseauthor;
        }
        
        private bool ValidateId()
        {
           /* try
            {
                return (from bp in BibPlanParser.BibPlanList()
                        let bpName = bp.Name
                        let bpAuthor = bp.VerseAuthor
                        select bp.Id).All(bpId => bpId != Id);
            }
            catch (Exception)
            {
                // Ignore if possible
                return true;
            }*/

            return true; 
        }
    }
}
