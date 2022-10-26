using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_CRUD_example_2.Models
{
    [Table("relalumasig", Schema = "public")]
    public class RelAlumAsigDTO
    {
        [Key]
        [Column("relAlumAsig_id")]
        [Display(Name = "relAlumAsig_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RelAlumAsig_id { get; set; }

        /************************ campos para la relación entre alumnos y asignaturas ***************************/

        [Required]
        [Column("alumno_id")]
        [Display(Name = "alumno_id")]
        public int Alumno_id { get; set; }

        [ForeignKey("Alumno_id")]
        public virtual AlumnoDTO? Alumno { get; set; } // reference navigation property

        [Required]
        [Column("asignatura_id")]
        [Display(Name = "asignatura_id")]
        public int Asignatura_id { get; set; }

        [ForeignKey("Asignatura_id")]
        public virtual AsignaturaDTO? Asignatura { get; set; } // reference navigation property

    }
}
