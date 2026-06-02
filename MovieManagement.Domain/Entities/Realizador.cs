using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Domain.Entities
{
    public class Realizador
    {
        public int Id { get; set; }
        public string Nome { get; set; } // Nome do realizador

        public string Pais { get; set; } // País de origem
    }
}