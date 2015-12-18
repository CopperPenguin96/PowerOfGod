using System;
using System.Collections.Generic;
using System.Linq;
using Power_of_God.Bible_Plans;

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
        public List<VerseObj> VerseList;
        public string VerseAuthor;

        public BibPlan(string name, string id, List<VerseObj> verses, string verseauthor)
        {
            Name = name;
            Id = id;
            if (!ValidateId())
            {
                throw new Exception("The Bible Plan ID could not validated. Possible duplicate?");
            }
            VerseList = verses;
            VerseAuthor = verseauthor;
        }
        
        private bool ValidateId()
        {
            return (from bp in BibPlanParser.BibPlanList()
                    let bpName = bp.Name
                    let bpAuthor = bp.VerseAuthor select bp.Id).All(bpId => bpId != Id);
        }
    }
}
