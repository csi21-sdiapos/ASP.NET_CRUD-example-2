using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_CRUD_example_2.Models
{
    [Table("asignaturas", Schema = "public")]
    public class AsignaturaDTO
    {
        [Key]
        [Column("asignatura_id")]
        [Display(Name = "asignatura_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Asignatura_id { get; set; }

        [Required]
        [Column("asignatura_nombre")]
        [Display(Name = "asignatura_nombre")]
        public string Asignatura_nombre { get; set; }

        /************************ campos para la relación entre alumnos y asignaturas ***************************/

        [InverseProperty("Asignatura")]
        public virtual List<RelAlumAsigDTO>? ListaRelAlumAsig { get; set; } // // collection navigation property

    }
}
