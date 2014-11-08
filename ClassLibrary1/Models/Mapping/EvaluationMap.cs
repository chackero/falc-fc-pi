using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClassLibrary1.Models.Mapping
{
    public class EvaluationMap : EntityTypeConfiguration<Evaluation>
    {
        public EvaluationMap()
        {
            // Primary Key
            this.HasKey(t => t.idEval);

            // Properties
            this.Property(t => t.idEval)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.feedback)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Evaluation");
            this.Property(t => t.idEval).HasColumnName("idEval");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.feedback).HasColumnName("feedback");
            this.Property(t => t.score).HasColumnName("score");
        }
    }
}
