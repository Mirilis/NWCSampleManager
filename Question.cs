using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWCSampleManager
{
    public partial class Question
    {
        public string TeamName
        { get => ((Team)this.Team).ToString().SplitCamelCase(); }

        public string ResponseType
        { get => ((ResponseType)this.Type).ToString().SplitCamelCase(); }

        public int TeamSort { get => ProductFlow.Order.IndexOf(((Team)this.Team).ToString()); }

        public ResponseRepository GetMilestoneResponseForQuestion(Traveller m)
        {
            using (var sql = new SampleTravellersContext())
            {
                var p = this.ResponseRepositories.Where(x => x.Traveller == m);

                if (p.Any())
                {
                    return p.First();
                }
                else return null;
            }
        }

        public void AddPrerequisite(Question that)
        {
            if (!(this.Id == that.Id))
            {
                this.AddPreOrPostequisite(this, that);
            }

        }
            public void AddPostrequisite(Question that)
        {
            if (!(this.Id == that.Id))
            {
                this.AddPreOrPostequisite(that, this);
            }
            
        }

        public Question GetCompleteQuestion()
        {
            using (var sql = new SampleTravellersContext())
            {
                try
                {
                    return sql.Questions
                        .Include("Prerequisites")
                        .Include("Postrequisites")
                        .Include("Corequisites")
                        .Where(x => x.Id == this.Id).First();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public List<Question> RequisitesList()
        {
            var temp = this.GetCompleteQuestion();
            var btemp = temp.Prerequisites.ToList();
            btemp.AddRange(temp.Corequisites);
            btemp.AddRange(temp.Postrequisites);

            return btemp;
        }

        private void AddPreOrPostequisite(Question q1, Question q2)
        {
            if (!q1.Prerequisites.Any(x=>x.Id == q1.Id))
            {
                q1.Prerequisites.Add(q2);
            }
            if (!q2.Postrequisites.Any(x=>x.Id == q1.Id))
            {
                q2.Postrequisites.Add(q1);
            }
        }
            
    }
}
