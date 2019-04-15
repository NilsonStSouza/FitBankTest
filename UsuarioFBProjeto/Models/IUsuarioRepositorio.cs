using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioFBProjeto.Models
{
    public interface IUsuarioRepositorio
    {
        IEnumerable<UsuarioModel> GetUsuario();
        UsuarioModel GetUsuarioPorID(int usuarioID);
        void InserirUsuario(UsuarioModel usuarioModel);
        void DeletarUsuario(int usuarioID);
        void AtualizarUsuario(UsuarioModel usuarioModel);
    }
}
