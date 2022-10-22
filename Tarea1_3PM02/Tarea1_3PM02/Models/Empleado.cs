using SQLite;
using System;

namespace Tarea1_3PM02.Models
{
    public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(100)]
        public String nombres { get; set; }

        [MaxLength(100)]
        public String apellidos { get; set; }
        public int edad { get; set; }
        public String correo { get; set; }

        [MaxLength(150)]
        public String direccion { get; set; }
    }
}
