using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class clsPersona
    {
        //Atributos
        public int Id { get; set; }
        [Required]
        [Display (Name = "Nombre")]
        public String Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public String Apellidos { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode =true)]
        public DateTime FechaNac { get; set; }
        [Display(Name = "Dirección")]
        public String Direccion { get; set; }
        [Display(Name = "Teléfono")]
        public String Telefono { get; set; }

        //Constructores
        public clsPersona()
        {
            Id = 1;
            Nombre = "";
            Apellidos = "";
            FechaNac = new DateTime();
            Direccion = "";
            Telefono = "";
        }

        public clsPersona(int id, String nombre, String apellidos, DateTime fechaNac, String direccion, String telefono)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            FechaNac = fechaNac;
            Direccion = direccion;
            Telefono = telefono;
        }
    }
}
