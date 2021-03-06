﻿

// ------------------------------------------------------------------------------------------------
// This code was generated by EntityFramework Reverse POCO Generator (http://www.reversepoco.com/).
// Created by Simon Hughes (https://about.me/simon.hughes).
//
// Do not make changes directly to this file - edit the template instead.
//
// The following connection settings were used to generate this file:
//     Configuration file:     "NWCSampleManager\App.config"
//     Connection String Name: "SampleTravelers"
//     Connection String:      "Data Source=(localdb)\mssqllocaldb;Initial Catalog=SampleTravelers;Integrated Security=True;"
// ------------------------------------------------------------------------------------------------
// Database Edition       : Express Edition (64-bit)
// Database Engine Edition: Express

// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.5
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Interception;

namespace NWCSampleManager
{
    using System.Linq;
    using System.Collections.Generic;
    using System;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.SqlClient;
    using System.Data.Entity.Validation;
    using System.Text;

    #region Unit of work

    public interface ISampleTravelersContext : System.IDisposable
    {
        System.Data.Entity.DbSet<Question> Questions { get; set; } // Questions
        System.Data.Entity.DbSet<Response> Responses { get; set; } // Responses
        System.Data.Entity.DbSet<ResponseRepository> ResponseRepositories { get; set; } // ResponseRepository
        System.Data.Entity.DbSet<TeamAffiliation> TeamAffiliations { get; set; } // TeamAffiliations
        System.Data.Entity.DbSet<Traveler> travelers { get; set; } // travelers
        System.Data.Entity.DbSet<User> Users { get; set; } // Users

        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);
        System.Data.Entity.Infrastructure.DbChangeTracker ChangeTracker { get; }
        System.Data.Entity.Infrastructure.DbContextConfiguration Configuration { get; }
        System.Data.Entity.Database Database { get; }
        System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity);
        System.Collections.Generic.IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> GetValidationErrors();
        System.Data.Entity.DbSet Set(System.Type entityType);
        System.Data.Entity.DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();
    }

    #endregion

    #region Database context

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.30.0.0")]
    public partial class SampleTravelersContext : System.Data.Entity.DbContext, ISampleTravelersContext
    {
        public System.Data.Entity.DbSet<Question> Questions { get; set; } // Questions
        public System.Data.Entity.DbSet<Response> Responses { get; set; } // Responses
        public System.Data.Entity.DbSet<ResponseRepository> ResponseRepositories { get; set; } // ResponseRepository
        public System.Data.Entity.DbSet<TeamAffiliation> TeamAffiliations { get; set; } // TeamAffiliations
        public System.Data.Entity.DbSet<Traveler> travelers { get; set; } // travelers
        public System.Data.Entity.DbSet<User> Users { get; set; } // Users

        public static string AlertUserErrors(DbEntityValidationException e)
        {
            var s = new StringBuilder();
            s.Append("The following issues are preventing the saving of this document:" + Environment.NewLine);
            foreach (var eve in e.EntityValidationErrors)
            {
                foreach (var ve in eve.ValidationErrors)
                {
                    s.AppendFormat("Property: \"{0}\", Current Value: \"{1}\", Error: \"{2}\"",
                        ve.PropertyName,
                        eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                        ve.ErrorMessage);
                    s.Append(Environment.NewLine);
                }
            }
            return s.ToString();
        }

        static SampleTravelersContext()
        {
            System.Data.Entity.Database.SetInitializer<SampleTravelersContext>(null);
           
        }

        public SampleTravelersContext()
            : base("Name=SampleTravelers")
        {
            InitializePartial();
            this.Configuration.LazyLoadingEnabled = true;
        }

        public SampleTravelersContext(string connectionString)
            : base(connectionString)
        {
            InitializePartial();
        }

        public SampleTravelersContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
            InitializePartial();
        }

        public SampleTravelersContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            InitializePartial();
        }

        public SampleTravelersContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
            InitializePartial();
        }

            public override int SaveChanges()
            {
                foreach (var entry in ChangeTracker.Entries()
                          .Where(p => p.State == EntityState.Deleted))
                    SoftDelete(entry);

                return base.SaveChanges();
            }

        private static Dictionary<Type, EntitySetBase> _mappingCache =
        new Dictionary<Type, EntitySetBase>();

        private string GetTableName(Type type)
        {
            EntitySetBase es = GetEntitySet(type);

            return string.Format("[{0}].[{1}]",
                es.MetadataProperties["Schema"].Value,
                es.MetadataProperties["Table"].Value);
        }

        private string GetPrimaryKeyName(Type type)
        {
            EntitySetBase es = GetEntitySet(type);

            return es.ElementType.KeyMembers[0].Name;
        }

        private EntitySetBase GetEntitySet(Type type)
        {
            if (!_mappingCache.ContainsKey(type))
            {
                ObjectContext octx = ((IObjectContextAdapter)this).ObjectContext;

                string typeName = ObjectContext.GetObjectType(type).Name;

                var es = octx.MetadataWorkspace
                                .GetItemCollection(DataSpace.SSpace)
                                .GetItems<EntityContainer>()
                                .SelectMany(c => c.BaseEntitySets
                                                .Where(e => e.Name == typeName))
                                .FirstOrDefault();

                if (es == null)
                    throw new ArgumentException("Entity type not found in GetTableName", typeName);

                _mappingCache.Add(type, es);
            }

            return _mappingCache[type];
        }

        private void SoftDelete(DbEntityEntry entry)
        {
            Type entryEntityType = entry.Entity.GetType();

            if (entryEntityType == typeof(Traveler) || entryEntityType == typeof(Traveler))
            {

            

            string tableName = GetTableName(entryEntityType);
            string primaryKeyName = GetPrimaryKeyName(entryEntityType);

            string sql =
                string.Format(
                    "UPDATE {0} SET STATUS = 1 WHERE {1} = @id",
                        tableName, primaryKeyName);

            Database.ExecuteSqlCommand(
                sql,
                new SqlParameter("@id", entry.OriginalValues[primaryKeyName]));

            // prevent hard delete            
            entry.State = EntityState.Detached;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new ResponseConfiguration());
            modelBuilder.Configurations.Add(new ResponseRepositoryConfiguration());
            modelBuilder.Configurations.Add(new TeamAffiliationConfiguration());
            modelBuilder.Configurations.Add(new TravelerConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());

           

            OnModelCreatingPartial(modelBuilder);
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new QuestionConfiguration(schema));
            modelBuilder.Configurations.Add(new ResponseConfiguration(schema));
            modelBuilder.Configurations.Add(new ResponseRepositoryConfiguration(schema));
            modelBuilder.Configurations.Add(new TeamAffiliationConfiguration(schema));
            modelBuilder.Configurations.Add(new TravelerConfiguration(schema));
            modelBuilder.Configurations.Add(new UserConfiguration(schema));
            return modelBuilder;
        }

        partial void InitializePartial();
        partial void OnModelCreatingPartial(System.Data.Entity.DbModelBuilder modelBuilder);
    }
    #endregion

    #region POCO classes

    public partial class QuestionComment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Column(@"MilestoneId", Order = 2, TypeName = "int")]
        [Index(@"IX_FK_MilestoneResponseRepository", 1, IsUnique = false, IsClustered = false)]
        [Required]
        [Display(Name = "Milestone ID")]
        public int MilestoneId { get; set; } // MilestoneId

        [Column(@"QuestionId", Order = 3, TypeName = "int")]
        [Index(@"IX_FK_QuestionResponseRepository", 1, IsUnique = false, IsClustered = false)]
        [Required]
        [Display(Name = "Question ID")]
        public int QuestionId { get; set; } // QuestionId

        [ForeignKey("MilestoneId")] public virtual Traveler Traveler { get; set; } // FK_dbo.ResponseRepository_dbo.travelers_MilestoneId
        /// <summary>
        /// Parent Question pointed by [ResponseRepository].([QuestionId]) (FK_dbo.ResponseRepository_dbo.Questions_QuestionId)
        /// </summary>
        [ForeignKey("QuestionId")] public virtual Question Question { get; set; } // FK_dbo.ResponseRepository_dbo.Questions_QuestionId
    }

    public partial class HelpImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)
        
        [Required]
        [Column(@"QuestionId", Order = 2, TypeName = "int")]
        public virtual Question Question { get; set; }

        [Required]
        [Column(@"Image", Order = 3, TypeName = "varbinary(max)")]
        public byte[] Image { get; set; }
    }

    // Questions
    [Table("Questions", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.30.0.0")]
    public partial class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Column(@"Name", Order = 2, TypeName = "nvarchar(max)")]
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } // Name

        [Column(@"Team", Order = 3, TypeName = "int")]
        [Required]
        [Display(Name = "Team")]
        public int Team { get; set; } // Team

        [Column(@"RequiresResponse", Order = 4, TypeName = "bit")]
        [Required]
        [Display(Name = "Requires response")]
        public bool RequiresResponse { get; set; } // RequiresResponse

        [Column(@"Request", Order = 5, TypeName = "nvarchar(max)")]
        [Required]
        [Display(Name = "Request")]
        public string Request { get; set; } // Request

        [Column(@"Type", Order = 6, TypeName = "int")]
        [Required]
        [Display(Name = "Type")]
        public int Type { get; set; } // Type

        [Column(@"HelpText", Order = 7, TypeName = "nvarchar(max)")]
        [Required]
        [Display(Name = "Help text")]
        public string HelpText { get; set; } // HelpText
        
        [Display(Name = "Help Image")]
        public virtual HelpImage HelpImage { get; set; }

        [Column(@"Template", Order = 9, TypeName = "bit")]
        [Required]
        [Display(Name = "Template")]
        public bool Template { get; set; } // Template

        [Column(@"Status", Order = 10, TypeName = "bit")]
        [Display(Name="Status")]
        public bool Status { get; set; } // Status
        
        // Reverse navigation

        /// <summary>
        /// Child Questions (Many-to-Many) mapped by table [Corequisistes]
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Question> Corequisites { get; set; } // Many to many mapping
        /// <summary>
        /// Child Questions (Many-to-Many) mapped by table [Postrequisistes]
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Question> Postrequisites { get; set; } // Many to many mapping
        /// <summary>
        /// Child Questions (Many-to-Many) mapped by table [Prerequisistes]
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Question> Prerequisites { get; set; } // Many to many mapping
        /// <summary>
        /// Child Questions (Many-to-Many) mapped by table [Corequisistes]
        /// </summary>

        /// <summary>
        /// Child ResponseRepositories where [ResponseRepository].[QuestionId] point to this entity (FK_dbo.ResponseRepository_dbo.Questions_QuestionId)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ResponseRepository> ResponseRepositories { get; set; } // ResponseRepository.FK_dbo.ResponseRepository_dbo.Questions_QuestionId
        /// <summary>
        /// Child travelers (Many-to-Many) mapped by table [travelerActionList]
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Traveler> Travelers { get; set; } // Many to many mapping

        public virtual System.Collections.Generic.ICollection<QuestionComment> QuestionComments { get; set; } // ResponseRepository.FK_dbo.ResponseRepository_dbo.Questions_QuestionId

        public Question()
        {
            ResponseRepositories = new System.Collections.Generic.List<ResponseRepository>();
            Corequisites = new System.Collections.Generic.List<Question>();
            Postrequisites = new System.Collections.Generic.List<Question>();
            Prerequisites = new System.Collections.Generic.List<Question>();
            Travelers = new System.Collections.Generic.List<Traveler>();
            QuestionComments = new List<QuestionComment>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Responses
    [Table("Responses", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.30.0.0")]
    public partial class Response
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Column(@"String", Order = 2, TypeName = "nvarchar(max)")]
        [Display(Name = "String")]
        public string String { get; set; } // String

        [Column(@"Integer", Order = 3, TypeName = "int")]
        [Display(Name = "Integer")]
        public int? Integer { get; set; } // Integer

        [Column(@"Double", Order = 4, TypeName = "float")]
        [Display(Name = "Double")]
        public double? Double { get; set; } // Double

        [Column(@"File", Order = 5, TypeName = "varbinary(max)")]
        [Display(Name = "File")]
        public byte[] File { get; set; } // File

        [Column(@"Boolean", Order = 6, TypeName = "bit")]
        [Display(Name = "Boolean")]
        public bool? Boolean { get; set; } // Boolean

        [Column(@"EndDate", Order = 7, TypeName = "datetime")]
        [Required]
        [Display(Name = "End date")]
        public System.DateTime EndDate { get; set; } // EndDate

        [Column(@"User_Id", Order = 8, TypeName = "int")]
        [Index(@"IX_FK_ResponseUser", 1, IsUnique = false, IsClustered = false)]
        [Display(Name = "User ID")]
        public int? UserId { get; set; } // User_Id

        [Column(@"Completed", Order = 9, TypeName = "bit")]
        [Required]
        [Display(Name = "Completed")]
        public bool Completed { get; set; } // Completed

        [Column(@"Successful", Order = 10, TypeName = "bit")]
        [Required]
        [Display(Name = "Successful")]
        public bool Successful { get; set; } // Successful

        [Column(@"ResponseRepositoryId", Order = 11, TypeName = "int")]
        [Index(@"IX_FK_ResponseRepositoryResponse", 1, IsUnique = false, IsClustered = false)]
        [Required]
        [Display(Name = "Response repository ID")]
        public int ResponseRepositoryId { get; set; } // ResponseRepositoryId

        [Column(@"Query", Order = 12, TypeName = "nvarchar(max)")]
        [Display(Name = "Query")]
        public string Query { get; set; } // Query

        [Column(@"QueryResult", Order = 13, TypeName = "nvarchar(max)")]
        [Display(Name = "QueryResult")]
        public string QueryResult { get; set; } // QueryResult

        [Column(@"Comment", Order = 14, TypeName = "nvarchar(max)")]
        [Display(Name = "Comment")]
        public string Comment { get; set; } // Comment

        // Foreign keys

        /// <summary>
        /// Parent ResponseRepository pointed by [Responses].([ResponseRepositoryId]) (FK_dbo.Responses_dbo.ResponseRepository_ResponseRepositoryId)
        /// </summary>
        [ForeignKey("ResponseRepositoryId")] public virtual ResponseRepository ResponseRepository { get; set; } // FK_dbo.Responses_dbo.ResponseRepository_ResponseRepositoryId
        /// <summary>
        /// Parent User pointed by [Responses].([UserId]) (FK_dbo.Responses_dbo.Users_User_Id)
        /// </summary>
        [ForeignKey("UserId")] public virtual User User { get; set; } // FK_dbo.Responses_dbo.Users_User_Id

        public Response()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // ResponseRepository
    [Table("ResponseRepository", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.30.0.0")]
    public partial class ResponseRepository
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Column(@"MilestoneId", Order = 2, TypeName = "int")]
        [Index(@"IX_FK_MilestoneResponseRepository", 1, IsUnique = false, IsClustered = false)]
        [Required]
        [Display(Name = "Milestone ID")]
        public int MilestoneId { get; set; } // MilestoneId

        [Column(@"QuestionId", Order = 3, TypeName = "int")]
        [Index(@"IX_FK_QuestionResponseRepository", 1, IsUnique = false, IsClustered = false)]
        [Required]
        [Display(Name = "Question ID")]
        public int QuestionId { get; set; } // QuestionId

        // Reverse navigation

        /// <summary>
        /// Child Responses where [Responses].[ResponseRepositoryId] point to this entity (FK_dbo.Responses_dbo.ResponseRepository_ResponseRepositoryId)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Response> Responses { get; set; } // Responses.FK_dbo.Responses_dbo.ResponseRepository_ResponseRepositoryId

        // Foreign keys

        /// <summary>
        /// Parent traveler pointed by [ResponseRepository].([MilestoneId]) (FK_dbo.ResponseRepository_dbo.travelers_MilestoneId)
        /// </summary>
        [ForeignKey("MilestoneId")] public virtual Traveler Traveler { get; set; } // FK_dbo.ResponseRepository_dbo.travelers_MilestoneId
        /// <summary>
        /// Parent Question pointed by [ResponseRepository].([QuestionId]) (FK_dbo.ResponseRepository_dbo.Questions_QuestionId)
        /// </summary>
        [ForeignKey("QuestionId")] public virtual Question Question { get; set; } // FK_dbo.ResponseRepository_dbo.Questions_QuestionId

        public ResponseRepository()
        {
            Responses = new System.Collections.Generic.List<Response>();

            InitializePartial();
        }

        partial void InitializePartial();
    }

    // TeamAffiliations
    [Table("TeamAffiliations", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.30.0.0")]
    public partial class TeamAffiliation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Column(@"Team", Order = 2, TypeName = "int")]
        [Required]
        [Display(Name = "Team")]
        public int Team { get; set; } // Team

        // Reverse navigation

        /// <summary>
        /// Child Users (Many-to-Many) mapped by table [UserTeamAffiliation]
        /// </summary>
        public virtual System.Collections.Generic.ICollection<User> Users { get; set; } // Many to many mapping

        public TeamAffiliation()
        {
            Users = new System.Collections.Generic.List<User>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // travelers
    [Table("Travelers", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.30.0.0")]
    public partial class Traveler
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Column(@"Product", Order = 2, TypeName = "nvarchar(max)")]
        [Required]
        [Display(Name = "Product")]
        public string Product { get; set; } // Product

        [Column(@"StartDate", Order = 3, TypeName = "datetime")]
        [Required]
        [Display(Name = "Start date")]
        public System.DateTime StartDate { get; set; } // StartDate

        [Column(@"Owner_Id", Order = 4, TypeName = "int")]
        [Index(@"IX_FK_Owner", 1, IsUnique = false, IsClustered = false)]
        [Required]
        [Display(Name = "Owner ID")]
        public int OwnerId { get; set; } // Owner_Id

        [Column(@"Completed", Order = 5, TypeName = "bit")]
        [Required]
        [Display(Name = "Completed")]
        public bool Completed { get; set; } // Completed

        [Column(@"Successful", Order = 6, TypeName = "bit")]
        [Required]
        [Display(Name = "Successful")]
        public bool Successful { get; set; } // Successful

        [Column(@"Description", Order = 7, TypeName = "nvarchar(max)")]
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } // Description

        [Column(@"Name", Order = 8, TypeName = "nvarchar(max)")]
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } // Name

        [Column(@"Status", Order = 10, TypeName = "bit")]
        [Display(Name = "Status")]
        public bool Status { get; set; } // Status

        // Reverse navigation

        /// <summary>
        /// Child Questions (Many-to-Many) mapped by table [travelerActionList]
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Question> Questions { get; set; } // Many to many mapping
        /// <summary>
        /// Child ResponseRepositories where [ResponseRepository].[MilestoneId] point to this entity (FK_dbo.ResponseRepository_dbo.travelers_MilestoneId)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ResponseRepository> ResponseRepositories { get; set; } // ResponseRepository.FK_dbo.ResponseRepository_dbo.travelers_MilestoneId

        public virtual System.Collections.Generic.ICollection<QuestionComment> QuestionComments { get; set; } // ResponseRepository.FK_dbo.ResponseRepository_dbo.Questions_QuestionId

        // Foreign keys

        /// <summary>
        /// Parent User pointed by [travelers].([OwnerId]) (FK_dbo.travelers_dbo.Users_Owner_Id)
        /// </summary>
        [ForeignKey("OwnerId")] public virtual User User { get; set; } // FK_dbo.travelers_dbo.Users_Owner_Id

        public Traveler()
        {
            ResponseRepositories = new System.Collections.Generic.List<ResponseRepository>();
            Questions = new System.Collections.Generic.List<Question>();
            QuestionComments = new System.Collections.Generic.List<QuestionComment>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    // Users
    [Table("Users", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.30.0.0")]
    public partial class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Column(@"First", Order = 2, TypeName = "nvarchar(max)")]
        [Required]
        [Display(Name = "First")]
        public string First { get; set; } // First

        [Column(@"Last", Order = 3, TypeName = "nvarchar(max)")]
        [Required]
        [Display(Name = "Last")]
        public string Last { get; set; } // Last

        [Column(@"Email", Order = 4, TypeName = "nvarchar(max)")]
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } // Email

        [Column(@"WindowsName", Order = 5, TypeName = "nvarchar(max)")]
        [Required]
        [Display(Name = "Windows name")]
        public string WindowsName { get; set; } // WindowsName

        // Reverse navigation

        /// <summary>
        /// Child Responses where [Responses].[User_Id] point to this entity (FK_dbo.Responses_dbo.Users_User_Id)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Response> Responses { get; set; } // Responses.FK_dbo.Responses_dbo.Users_User_Id
        /// <summary>
        /// Child TeamAffiliations (Many-to-Many) mapped by table [UserTeamAffiliation]
        /// </summary>
        public virtual System.Collections.Generic.ICollection<TeamAffiliation> TeamAffiliations { get; set; } // Many to many mapping
        /// <summary>
        /// Child travelers where [travelers].[Owner_Id] point to this entity (FK_dbo.travelers_dbo.Users_Owner_Id)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Traveler> travelers { get; set; } // travelers.FK_dbo.travelers_dbo.Users_Owner_Id

        public User()
        {
            Responses = new System.Collections.Generic.List<Response>();
            travelers = new System.Collections.Generic.List<Traveler>();
            TeamAffiliations = new System.Collections.Generic.List<TeamAffiliation>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

    #endregion

    #region POCO Configuration

    public partial class HelpImageConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<HelpImage>
    {
        public HelpImageConfiguration()
            : this("dbo")
        {
        }

        public HelpImageConfiguration(string schema)
        {
            this.HasRequired(x => x.Question);
        }
    }
        // Questions
        [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.30.0.0")]
    public partial class QuestionConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
            : this("dbo")
        {
        }

        

        public QuestionConfiguration(string schema)
        {

            this.Map(x => x.Requires("Status").HasValue(false)).Ignore(x => x.Status);
            this.HasOptional(x => x.HelpImage);
            HasMany(t => t.Corequisites).WithMany().Map(m =>
            {
                m.ToTable("Corequisistes", "dbo");
                m.MapLeftKey("CorequisiteID");
                m.MapRightKey("QuestionID");
            });
            HasMany(t => t.Postrequisites).WithMany().Map(m =>
            {
                m.ToTable("Postrequisistes", "dbo");
                m.MapLeftKey("PostrequisiteID");
                m.MapRightKey("QuestionID");
            });
            HasMany(t => t.Prerequisites).WithMany().Map(m =>
            {
                m.ToTable("Prerequisistes", "dbo");
                m.MapLeftKey("PrerequisiteID");
                m.MapRightKey("QuestionID");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Responses
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.30.0.0")]
    public partial class ResponseConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Response>
    {
        public ResponseConfiguration()
            : this("dbo")
        {
        }

        public ResponseConfiguration(string schema)
        {
            Property(x => x.String).IsOptional();
            Property(x => x.Integer).IsOptional();
            Property(x => x.Double).IsOptional();
            Property(x => x.File).IsOptional();
            Property(x => x.Boolean).IsOptional();
            Property(x => x.UserId).IsOptional();
            Property(x => x.Query).IsOptional();
            Property(x => x.QueryResult).IsOptional();

            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ResponseRepository
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.30.0.0")]
    public partial class ResponseRepositoryConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ResponseRepository>
    {
        public ResponseRepositoryConfiguration()
            : this("dbo")
        {
        }

        public ResponseRepositoryConfiguration(string schema)
        {

            InitializePartial();
        }
        partial void InitializePartial();
    }

    public partial class QuestionCommentConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ResponseRepository>
    {
        public QuestionCommentConfiguration()
            : this("dbo")
        {
        }

        public QuestionCommentConfiguration(string schema)
        {

            InitializePartial();
        }
        partial void InitializePartial();
    }

    // TeamAffiliations
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.30.0.0")]
    public partial class TeamAffiliationConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<TeamAffiliation>
    {
        public TeamAffiliationConfiguration()
            : this("dbo")
        {
        }

        public TeamAffiliationConfiguration(string schema)
        {
            HasMany(t => t.Users).WithMany(t => t.TeamAffiliations).Map(m =>
            {
                m.ToTable("UserTeamAffiliation", "dbo");
                m.MapLeftKey("TeamAffiliations_Id");
                m.MapRightKey("Users_Id");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // travelers
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.30.0.0")]
    public partial class TravelerConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Traveler>
    {
        public TravelerConfiguration()
            : this("dbo")
        {
        }

        public TravelerConfiguration(string schema)
        {
            this.Map(x => x.Requires("Status").HasValue(false)).Ignore(x=>x.Status);
            HasMany(t => t.Questions).WithMany(t => t.Travelers).Map(m =>
            {
                m.ToTable("TravelerActionList", "dbo");
                m.MapLeftKey("Milestones_Id");
                m.MapRightKey("Questions_Id");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Users
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.30.0.0")]
    public partial class UserConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<User>
    {
        public UserConfiguration()
            : this("dbo")
        {
        }

        public UserConfiguration(string schema)
        {
            InitializePartial();
        }
        partial void InitializePartial();
    }

    #endregion

}
// </auto-generated>

