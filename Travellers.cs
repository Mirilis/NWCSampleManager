using System;
using System.Collections.Generic;
using System.Linq;

[assembly: CLSCompliant(true)]

namespace NWCSampleManager
{
    public partial class Traveler
    {
        #region Public Methods

        public static List<Question> GetAllRequisites(Question q)
        {
            return ProcessQuestion(q);
        }

        public static string GetUID(User u)
        {
            return u.First.Substring(0, 1) + u.Last.Substring(0, 1) + (DateTime.Now.Ticks).ToString();
        }

        public static List<Question> SortByRequisites(List<Question> input)
        {
            var output = new List<Question>();
            var tmp = new List<Question>();
            foreach (var item in input)
            {
                tmp.Add(item.GetCompleteQuestion());
            }
            tmp = tmp.OrderBy(x => x.TeamSort).ToList();
            output = new List<Question>(tmp);
            do
            {
                tmp = new List<Question>(output);

                foreach (var tmpQ in tmp)
                {
                    foreach (var TmpQPre in tmpQ.Prerequisites)
                    {
                        if (output.IndexOf(tmpQ) < output.IndexOf(output.Where(x => x.Id == TmpQPre.Id).First()))
                        {
                            output.Remove(tmpQ);
                            output.Insert(output.IndexOf(output.Where(x => x.Id == TmpQPre.Id).First()) + 1, tmpQ);
                        }
                    }
                    foreach (var TmpQPre in tmpQ.Postrequisites)
                    {
                        if (output.IndexOf(tmpQ) > output.IndexOf(output.Where(x => x.Id == TmpQPre.Id).First()))
                        {
                            output.Remove(tmpQ);
                            output.Insert(output.IndexOf(output.Where(x => x.Id == TmpQPre.Id).First()), tmpQ);
                        }
                    }
                }
                var s = "Input" + Environment.NewLine;
                foreach (var item in tmp)
                {
                    s += item.Name + Environment.NewLine;
                }
                s += "output" + Environment.NewLine;
                foreach (var item in output)
                {
                    s += item.Name + Environment.NewLine;
                }
                s.Any();
            } while (!tmp.Select(y => y.Id).SequenceEqual(output.Select(x => x.Id)));
            return output;
        }

        public Response GetLatestResponse(Question q)
        {
            using (var sql = new SampleTravelersContext())
            {
                var p = this.Questions.Where(x => x.Id == q.Id);
                if (p.Any())
                {
                    if (p.First().GetMilestoneResponseForQuestion(this).Responses.Any())
                    {
                        p.First().GetMilestoneResponseForQuestion(this).Responses.First();
                    }
                    else return null;
                }
                else return null;
            }
            return null;
        }

        #endregion Public Methods

        #region Private Methods

        private static List<Question> ProcessQuestion(Question question)
        {
            //get all questions attached to the question being processed, and add them to a list.
            var tempList = question.RequisitesList();
            tempList.Add(question);
            var results = new List<Question>();
            var resultsID = new List<int>();
            //get all questions attached to each of the questions on the list.
            var processedQuestions = new List<int>();
            do
            {
                foreach (var additionalQuestion in tempList)
                {
                    if (!results.Any(x => x.Id == additionalQuestion.Id))
                    {
                        results.Add(additionalQuestion);
                        resultsID.Add(additionalQuestion.Id);
                    }

                    var tempList2 = additionalQuestion.RequisitesList();
                    foreach (var addQ in tempList2)
                    {
                        if (!tempList.Any(x => x.Id == addQ.Id))
                        {
                            if (!results.Any(x => x.Id == addQ.Id))
                            {
                                results.Add(addQ);
                                resultsID.Add(addQ.Id);
                            }
                        }
                    }
                    if (!processedQuestions.Any(x => x == additionalQuestion.Id))
                    {
                        processedQuestions.Add(additionalQuestion.Id);
                    }
                }
                if (results.Count != tempList.Count)
                {
                    tempList = results;
                    results = new List<Question>();
                    resultsID = new List<int>();
                }
            }
            while (!Enumerable.SequenceEqual(processedQuestions.OrderBy(x => x), resultsID.OrderBy(x => x)));

            return results;
        }

        #endregion Private Methods
    }
}