using System;
using System.Collections.Generic;
using System.Linq;

namespace NWCSampleManager
{
    public partial class Question
    {
        #region Public Properties

        public string ResponseType
        { get => ((ResponseType)this.Type).ToString().SplitCamelCase(); }

        public string TeamName
        { get => ((Team)this.Team).ToString().SplitCamelCase(); }

        public int TeamSort { get => ProductFlow.Order.IndexOf(((Team)this.Team).ToString()); }

        #endregion Public Properties

        #region Public Methods

        public void AddPostrequisite(Question that, bool unilateral = false)
        {
            if (!(this.Id == that.Id))
            {
                this.AddPreOrPostequisite(that, this);
            }
        }

        public void AddPrerequisite(Question that, bool unilateral = false)
        {
            if (!(this.Id == that.Id))
            {
                this.AddPreOrPostequisite(this, that);
            }
        }

        public Question GetCompleteQuestion()
        {
            using (var sql = new SampleTravelersContext())
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

        public ResponseRepository GetMilestoneResponseForQuestion(Traveler m)
        {
            using (var sql = new SampleTravelersContext())
            {
                var p = this.ResponseRepositories.Where(x => x.Traveler == m);

                if (p.Any())
                {
                    return p.First();
                }
                else return null;
            }
        }

        public QuestionComment GetQuestionCommentForTraveler(Traveler m)
        {
            using (var sql = new SampleTravelersContext())
            {
                var p = this.QuestionComments.Where(x => x.Traveler == m);

                if (p.Any())
                {
                    return p.First();
                }
                else return null;
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

        #endregion Public Methods

        #region Private Methods

        private void AddPreOrPostequisite(Question q1, Question q2)
        {
            if (!q1.Prerequisites.Any(x => x.Id == q1.Id))
            {
                q1.Prerequisites.Add(q2);
            }
            if (!q2.Postrequisites.Any(x => x.Id == q1.Id))
            {
                q2.Postrequisites.Add(q1);
            }
        }

        #endregion Private Methods
    }
}