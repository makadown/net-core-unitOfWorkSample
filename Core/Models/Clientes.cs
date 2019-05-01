using System;
using System.Collections.Generic;

namespace unitOfWorkSample.Core.Models
{
     public class Clientes
    {
        public long Id { get; set; }
        public string Apellido { get; set; }
        public DateTime CreateAt { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public string Nombre { get; set; }
    }
}