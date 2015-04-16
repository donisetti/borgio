using System;

namespace BorgioBase.Dominio1.Entidades
{

    public class Pessoa : Entidade
    {
        public int PessoaId { get; set; }

        public String Nome { get; set; }
        public string Tipo { get; set; }
        public string Email { get; set; }

        public string Site { get; set; }
        public string TelResidencial { get; set; }
        public string TelCelular { get; set; }

    }
}
