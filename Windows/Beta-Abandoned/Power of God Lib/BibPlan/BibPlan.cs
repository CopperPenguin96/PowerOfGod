using System;
using System.Collections.Generic;
using BibPlans;
using Power_of_God_Lib.NetBible;

namespace Power_of_God_Lib.BibPlan
{
    /// <summary>
    /// BibPlan files are used to read Bible Plans
    /// </summary>
    public class BibPlan
    {
        /// <summary>
        /// Bible Plan Name
        /// </summary>
        public string Name;
        /// <summary>
        /// The Identification of the Bible Plan
        /// </summary>
        public string Id;
        /// <summary>
        /// The Passages
        /// </summary>
        public List<List<VerseObj>> VerseList;
        /// <summary>
        /// Which user made this plan?
        /// </summary>
        public string VerseAuthor;
        /// <summary>
        /// Constructor for Bible Plan
        /// </summary>
        /// <param name="name">Plan Name</param>
        /// <param name="id">Identification</param>
        /// <param name="verses">The Passages</param>
        /// <param name="verseauthor">Username of author</param>
        /// <param name="isCreator">True if in BibPlan maker</param>
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
        /// <summary>
        /// Validates ID. Obsolete
        /// </summary>
        /// <returns></returns>
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
