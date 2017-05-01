﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWCSampleManager
{
    public class SeedData
    {
        public SeedData()
        {
            using (var sql = new SampleTravellersContext())
            {
                if (!sql.Questions.ToList().Any())
                {
                    sql.Questions.Add(new Question()
                    {
                        Name = "Full Basic Workup",
                        Request = "Note the type of machine used to produce the cores from Core Box #1",
                        RequiresResponse = true,
                        Team = (int)Team.Administrator,
                        Type = (int)ResponseType.TextInput,
                        HelpText = "N/A",
                        Template = true
                    });
                    sql.Questions.Add(new Question()
                    {
                        Name = "Core Box #1 Machine Type",
                        Request = "Note the type of machine used to produce the cores from Core Box #1",
                        RequiresResponse = true,
                        Team = (int)Team.CoreDepartment,
                        Type = (int)ResponseType.TextInput,
                        HelpText = "N/A",
                    });
                    sql.Questions.Add(new Question()
                    {
                        Name = "Produce 1A Cores",
                        Request = "Produce the required number of 1A cores from Core Box #1.  Note the number produced.",
                        RequiresResponse = true,
                        Team = (int)Team.CoreDepartment,
                        Type = (int)ResponseType.RealNumber,
                        HelpText = "N/A"
                    });
                    sql.Questions.Add(new Question()
                    {
                        Name = "1A Core Weight",
                        Request = "During production, weigh the 1A core and record that weight here.",
                        RequiresResponse = true,
                        Team = (int)Team.CoreDepartment,
                        Type = (int)ResponseType.RealNumber,
                        HelpText = "N/A"
                    });
                    sql.Questions.Add(new Question()
                    {
                        Name = "1A Core Photo Prep",
                        Request = "Set aside a 1A core and contact the quality department to get a photo of the core for the Process Card. Note if this was completed.",
                        RequiresResponse = true,
                        Team = (int)Team.CoreDepartment,
                        Type = (int)ResponseType.YesNo,
                        HelpText = "N/A"
                    });
                    sql.Questions.Add(new Question()
                    {
                        Name = "1A Core Photo",
                        Request = "Take a Photo of the 1A Core and upload that photo here.",
                        RequiresResponse = true,
                        Team = (int)Team.QualityEngineering,
                        Type = (int)ResponseType.FileUpload,
                        HelpText = "N/A"
                    });
                    sql.Questions.Add(new Question()
                    {
                        Name = "Cope Photo",
                        Request = "Take a Photo of the pattern Cope and upload that file here.",
                        RequiresResponse = true,
                        Team = (int)Team.MoldDepartment,
                        Type = (int)ResponseType.FileUpload,
                        HelpText = "N/A"
                    });
                    sql.Questions.Add(new Question()
                    {
                        Name = "Drag Photo",
                        Request = "Take a Photo of the pattern Drag and upload that file here.",
                        RequiresResponse = true,
                        Team = (int)Team.MoldDepartment,
                        Type = (int)ResponseType.FileUpload,
                        HelpText = "N/A"
                    });
                    sql.Questions.Add(new Question()
                    {
                        Name = "Pour Weight",
                        Request = "Blast a complete set of gating.  Weigh the gating and all casting impressions (unground castings). Record the weight.",
                        RequiresResponse = true,
                        Team = (int)Team.CleanDepartment,
                        Type = (int)ResponseType.RealNumber,
                        HelpText = "N/A"
                    });
                    sql.Questions.Add(new Question()
                    {
                        Name = "Pour Weight Photo",
                        Request = "Take a Photo of the gating system and castings weighed, and upload photo here.",
                        RequiresResponse = true,
                        Team = (int)Team.CleanDepartment,
                        Type = (int)ResponseType.FileUpload,
                        HelpText = "N/A"
                    });
                    sql.Questions.Add(new Question()
                    {
                        Name = "Cast Weight",
                        Request = "Grind 5 castings or one of each cavity, whichever is greater.  Weigh each of those castings on the small scale and average those weights and record here.",
                        RequiresResponse = true,
                        Team = (int)Team.CleanDepartment,
                        Type = (int)ResponseType.RealNumber,
                        HelpText = "N/A"
                    });
                }

                sql.SaveChanges();
                var q = sql.Questions.Where(x => x.Name == "Full Basic Workup").First();
                sql.Questions.Where(x => x.Id != q.Id).ToList().ForEach(x => q.Corequisites.Add(x));
                var r = sql.Questions.Where(x => x.Name == "Pour Weight").First();
                r.AddPrerequisite(sql.Questions.Where(x => x.Name == "Cope Photo").First());
                r.AddPrerequisite(sql.Questions.Where(x => x.Name == "Drag Photo").First());
                r.AddPostrequisite(sql.Questions.Where(x => x.Name == "Pour Weight Photo").First());
                var s = sql.Questions.Where(x => x.Name == "1A Core Photo Prep").First();
                s.AddPostrequisite(sql.Questions.Where(x => x.Name == "1A Core Photo").First());               
                var n = new User();
                n.TeamAffiliations.Add(new TeamAffiliation() { Team = (int)Team.IndustrialEngineering });
                n.First = "Adam";
                n.Last = "Hoover";
                n.Email = "ahoover@grede.com";
                n.WindowsName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                if (!sql.Users.Any(x=>x.Email == n.Email))
                {
                    sql.Users.Add(n);
                }
                sql.SaveChanges();
            }
        }
    }
}
