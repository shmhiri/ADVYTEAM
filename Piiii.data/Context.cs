namespace Piiii.data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Piiii.domain;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<accommodationexpenses> accommodationexpenses { get; set; }
        public virtual DbSet<activity> activity { get; set; }
        public virtual DbSet<answer> answer { get; set; }
        public virtual DbSet<catalog> catalog { get; set; }
        public virtual DbSet<conge> conge { get; set; }
        public virtual DbSet<conges> conges { get; set; }
        public virtual DbSet<employe> employe { get; set; }
        public virtual DbSet<employee> employee { get; set; }
        public virtual DbSet<evaluation360> evaluation360 { get; set; }
        public virtual DbSet<evaluation360done> evaluation360done { get; set; }
        public virtual DbSet<expensenote> expensenote { get; set; }
        public virtual DbSet<fichecompetence> fichecompetence { get; set; }
        public virtual DbSet<formation> formation { get; set; }
        public virtual DbSet<mission> mission { get; set; }
        public virtual DbSet<missionexpenses> missionexpenses { get; set; }
        public virtual DbSet<mon_video> mon_video { get; set; }
        public virtual DbSet<project> project { get; set; }
        public virtual DbSet<question> question { get; set; }
        public virtual DbSet<quiz> quiz { get; set; }
        public virtual DbSet<selfevaluation> selfevaluation { get; set; }
        public virtual DbSet<timesheet> timesheet { get; set; }
        public virtual DbSet<transportexpenses> transportexpenses { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<userskills> userskills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<accommodationexpenses>()
                .Property(e => e.accommodationBill)
                .IsUnicode(false);

            modelBuilder.Entity<accommodationexpenses>()
                .Property(e => e.acctype)
                .IsUnicode(false);

            modelBuilder.Entity<accommodationexpenses>()
                .HasMany(e => e.expensenote)
                .WithMany(e => e.accommodationexpenses)
                .Map(m => m.ToTable("expensenote_accommodationexpenses").MapLeftKey("accommodationExp_id").MapRightKey("ExpenseNote_refrence"));

            modelBuilder.Entity<activity>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<activity>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<activity>()
                .Property(e => e.otherdetai)
                .IsUnicode(false);

            modelBuilder.Entity<activity>()
                .HasMany(e => e.project1)
                .WithMany(e => e.activity1)
                .Map(m => m.ToTable("project_activity").MapRightKey("Project_id"));

            modelBuilder.Entity<activity>()
                .HasMany(e => e.timesheet1)
                .WithMany(e => e.activity1)
                .Map(m => m.ToTable("timesheet_activity").MapRightKey("Timesheet_id"));

            modelBuilder.Entity<answer>()
                .Property(e => e.answer_name)
                .IsUnicode(false);

            modelBuilder.Entity<catalog>()
                .Property(e => e.nom_cat)
                .IsUnicode(false);

            modelBuilder.Entity<catalog>()
                .HasMany(e => e.formation)
                .WithOptional(e => e.catalog)
                .HasForeignKey(e => e.cat_id_cat);

            modelBuilder.Entity<conge>()
                .Property(e => e.etat_demande)
                .IsUnicode(false);

            modelBuilder.Entity<conge>()
                .Property(e => e.raison)
                .IsUnicode(false);

            modelBuilder.Entity<conges>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<conges>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.codePostal)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.pays)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.rue)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.ville)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.poste)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.salaire)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.conge)
                .WithOptional(e => e.employe)
                .HasForeignKey(e => e.employe_Id_emp);

            modelBuilder.Entity<employee>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.evaluation360done)
                .WithOptional(e => e.employee)
                .HasForeignKey(e => e.Coworker_id);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.selfevaluation)
                .WithOptional(e => e.employee)
                .HasForeignKey(e => e.Employee_id);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.evaluation360)
                .WithOptional(e => e.employee)
                .HasForeignKey(e => e.Employee_id);

            modelBuilder.Entity<evaluation360>()
                .HasMany(e => e.evaluation360done)
                .WithOptional(e => e.evaluation360)
                .HasForeignKey(e => e.Evaluation360_id);

            modelBuilder.Entity<evaluation360done>()
                .Property(e => e.improvements)
                .IsUnicode(false);

            modelBuilder.Entity<evaluation360done>()
                .Property(e => e.qualities)
                .IsUnicode(false);

            modelBuilder.Entity<evaluation360done>()
                .Property(e => e.score)
                .IsUnicode(false);

            modelBuilder.Entity<expensenote>()
                .HasMany(e => e.transportexpenses)
                .WithMany(e => e.expensenote)
                .Map(m => m.ToTable("expensenote_transportexpenses").MapLeftKey("ExpenseNote_refrence").MapRightKey("tansportExp_id"));

            modelBuilder.Entity<fichecompetence>()
                .Property(e => e.maitrise)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.lieu)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.niveauobt)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.nom_anim)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.nom_for)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.prerequis)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .HasMany(e => e.quiz1)
                .WithOptional(e => e.formation1)
                .HasForeignKey(e => e.formation_id_for);

            modelBuilder.Entity<mission>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.estimation)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.place)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.secondSkill)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.skillsRequired)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.subject)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.thirdSkill)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .HasMany(e => e.expensenote)
                .WithOptional(e => e.mission)
                .HasForeignKey(e => e.mission_refrence);

            modelBuilder.Entity<mission>()
                .HasMany(e => e.missionexpenses)
                .WithOptional(e => e.mission)
                .HasForeignKey(e => e.mission_refrence);

            modelBuilder.Entity<missionexpenses>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<missionexpenses>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<missionexpenses>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<mon_video>()
                .Property(e => e.URI)
                .IsUnicode(false);

            modelBuilder.Entity<mon_video>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<mon_video>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.otherdetai)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .HasMany(e => e.activity)
                .WithOptional(e => e.project)
                .HasForeignKey(e => e.project_id_id);

            modelBuilder.Entity<project>()
                .HasMany(e => e.project1)
                .WithOptional(e => e.project2)
                .HasForeignKey(e => e.Project_code_id);

            modelBuilder.Entity<question>()
                .Property(e => e.question_name)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.question_description)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .HasMany(e => e.answer)
                .WithOptional(e => e.question)
                .HasForeignKey(e => e.question_id_Question);

            modelBuilder.Entity<quiz>()
                .Property(e => e.QuizName)
                .IsUnicode(false);

            modelBuilder.Entity<quiz>()
                .HasMany(e => e.formation)
                .WithOptional(e => e.quiz)
                .HasForeignKey(e => e.quiz_id_Quiz);

            modelBuilder.Entity<quiz>()
                .HasMany(e => e.question)
                .WithOptional(e => e.quiz)
                .HasForeignKey(e => e.quiz_id_Quiz);

            modelBuilder.Entity<selfevaluation>()
                .Property(e => e.improvements)
                .IsUnicode(false);

            modelBuilder.Entity<selfevaluation>()
                .Property(e => e.qualities)
                .IsUnicode(false);

            modelBuilder.Entity<timesheet>()
                .Property(e => e.poste)
                .IsUnicode(false);

            modelBuilder.Entity<timesheet>()
                .HasMany(e => e.activity)
                .WithOptional(e => e.timesheet)
                .HasForeignKey(e => e.timesheetid_id);

            modelBuilder.Entity<timesheet>()
                .HasMany(e => e.conges1)
                .WithOptional(e => e.timesheet)
                .HasForeignKey(e => e.timesheet_id);

            modelBuilder.Entity<transportexpenses>()
                .Property(e => e.boardingTicket)
                .IsUnicode(false);

            modelBuilder.Entity<transportexpenses>()
                .Property(e => e.trspType)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.secondSkill)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.skillsRequired)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.thirdSkill)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.DTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.activity)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.emploey_id_userId);

            modelBuilder.Entity<user>()
                .HasMany(e => e.conges)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.employer_id_userId);

            modelBuilder.Entity<user>()
                .HasMany(e => e.expensenote)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.officer_userId);

            modelBuilder.Entity<user>()
                .HasMany(e => e.expensenote1)
                .WithOptional(e => e.user1)
                .HasForeignKey(e => e.employee_userId);

            modelBuilder.Entity<user>()
                .HasMany(e => e.mission)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_userId);

            modelBuilder.Entity<user>()
                .HasMany(e => e.missionexpenses)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_userId);

            modelBuilder.Entity<user>()
                .HasMany(e => e.project)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.manager_id_userId);

            modelBuilder.Entity<user>()
                .HasMany(e => e.timesheet)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.employer_id_userId);

            modelBuilder.Entity<userskills>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<userskills>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<userskills>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<userskills>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<userskills>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<userskills>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<userskills>()
                .Property(e => e.secondSkill)
                .IsUnicode(false);

            modelBuilder.Entity<userskills>()
                .Property(e => e.skillsRequired)
                .IsUnicode(false);

            modelBuilder.Entity<userskills>()
                .Property(e => e.thirdSkill)
                .IsUnicode(false);
        }
    }
}
