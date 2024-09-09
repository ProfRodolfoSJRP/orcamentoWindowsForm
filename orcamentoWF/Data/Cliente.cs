using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Cliente
    {
        // Código 
        public int Id_Cliente { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        // Public : Publico
        // String : Texto -> Varchar do banco de dados
        // Int : Inteiro
        // GET - SET : Permite Ler e atribuir valores na 'variavel'
    }
}

