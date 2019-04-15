using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UsuarioFBProjeto.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Informe o Nome")]
        [StringLength(50, ErrorMessage = "O campo Nome permite no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Informe um Telefone para contato")]
        [StringLength(11, ErrorMessage = "O campo Telefone permite no máximo 11 caracteres")]
        public string Telefone { get; set; }

        [DisplayName("Informe um CEP")]
        [StringLength(8, ErrorMessage = "O campo CEP permite no máximo 8 caracteres")]
        public string Cep { get; set; }        
        public string Logradouro { get; set; }   
        public string Complemento { get; set; }            
        public string Bairro { get; set; }        
        public string Localidade { get; set; }        
        public string Uf { get; set; }
    }
}