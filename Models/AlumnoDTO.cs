using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_CRUD_example_2.Models
{
    [Table("alumnos", Schema = "public")]
    public class AlumnoDTO
    {
        [Key]
        [Column("alumno_id")]
        [Display(Name = "alumno_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // el autoincrementable
        public int Alumno_id { get; set; }

        [Required]
        [Column("alumno_nombre")]
        [Display(Name = "alumno_nombre")]
        public string Alumno_nombre { get; set; }

        [Required]
        [Column("alumno_apellidos")]
        [Display(Name = "alumno_apellidos")]
        public string Alumno_apellidos { get; set; }

        [Required]
        [Column("alumno_email")]
        [Display(Name = "alumno_email")]
        public string Alumno_email { get; set; }

        /************************ campos para la relación entre alumnos y asignaturas ***************************/

        [InverseProperty("Alumno")]
        public virtual List<RelAlumAsigDTO>? ListaRelAlumAsig { get; set; } // collection navigation property

    }
}
