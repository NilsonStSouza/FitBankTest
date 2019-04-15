using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Web;

namespace UsuarioFBProjeto.Models
{
    public class UsuarioRepositorio: IUsuarioRepositorio
    {
        private readonly string XmlNameConstant = "";
        //private readonly XElement UsuarioElement;

        public UsuarioRepositorio()
        {
            
        }
        public IEnumerable<UsuarioModel> GetUsuario()
        {
            var UsuarioElement = XElement.Load(HttpContext.Current.Server.MapPath(@XmlNameConstant));
            IList<UsuarioModel> listaUsuario = new List<UsuarioModel>();
            var consulta = from query in UsuarioElement.Element("usuarios").Elements()
                           select query;            
            try
            {                
                foreach (XElement elemento in consulta)                    
                {
                    listaUsuario.Add(new UsuarioModel()
                    {
                        Id = (int)elemento.Attribute("id"),
                        Nome = (string)elemento.Element("nome"),
                        Telefone = (string)elemento.Element("telefone"),
                        Cep = (string)elemento.Element("cep"),
                        Logradouro = (string)elemento.Element("logradouro"),
                        Complemento = (string)elemento.Element("complemento"),
                        Bairro = (string)elemento.Element("bairro"),
                        Localidade = (string)elemento.Element("localidade"),
                        Uf = (string)elemento.Element("uf")
                    });
                }
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UsuarioModel GetUsuarioPorID(int usuarioID)
        {
            var UsuarioElement = XElement.Load(HttpContext.Current.Server.MapPath(@XmlNameConstant));
            var consulta = from query in UsuarioElement.Element("usuarios").Elements()
                           select query;
            try
            {
                var UsuarioConsulta = consulta.FirstOrDefault();
                var vUsuario = new UsuarioModel()
                {
                    Id = (int)UsuarioConsulta.Attribute("id"),
                    Nome = (string)UsuarioConsulta.Element("nome"),
                    Telefone = (string)UsuarioConsulta.Element("telefone"),
                    Cep = (string)UsuarioConsulta.Element("cep"),
                    Logradouro = (string)UsuarioConsulta.Element("logradouro"),
                    Complemento = (string)UsuarioConsulta.Element("complemento"),
                    Bairro = (string)UsuarioConsulta.Element("bairro"),
                    Localidade = (string)UsuarioConsulta.Element("localidade"),
                    Uf = (string)UsuarioConsulta.Element("uf")
                };
                return vUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InserirUsuario(UsuarioModel vUsuario)
        {
            try
            {
                XmlDocument xmlDocumentInsert = new XmlDocument();
                xmlDocumentInsert.Load(HttpContext.Current.Server.MapPath(@XmlNameConstant));

                XmlElement xmlElementoPai = xmlDocumentInsert.CreateElement("usuario");
                XmlAttribute xmlAttribute = xmlDocumentInsert.CreateAttribute("id");
                XmlElement xmlElementoNome = xmlDocumentInsert.CreateElement("nome");
                XmlElement xmlElementoTelefone = xmlDocumentInsert.CreateElement("telefone");
                XmlElement xmlElementoCep = xmlDocumentInsert.CreateElement("cep");
                XmlElement xmlElementoLogradouro = xmlDocumentInsert.CreateElement("logradouro");
                XmlElement xmlElementoComplemento = xmlDocumentInsert.CreateElement("complemento");
                XmlElement xmlElementoBairro = xmlDocumentInsert.CreateElement("bairro");
                XmlElement xmlElementoLocalidade = xmlDocumentInsert.CreateElement("localidade");
                XmlElement xmlElementoUF = xmlDocumentInsert.CreateElement("uf");

                xmlAttribute.InnerText = vUsuario.Id.ToString();
                xmlElementoNome.InnerText = vUsuario.Nome;
                xmlElementoTelefone.InnerText = vUsuario.Telefone;
                xmlElementoCep.InnerText = vUsuario.Cep;
                xmlElementoLogradouro.InnerText = vUsuario.Logradouro;
                xmlElementoComplemento.InnerText = vUsuario.Complemento;
                xmlElementoBairro.InnerText = vUsuario.Bairro;
                xmlElementoLocalidade.InnerText = vUsuario.Localidade;
                xmlElementoUF.InnerText = vUsuario.Uf;

                xmlElementoPai.AppendChild(xmlAttribute);
                xmlElementoPai.AppendChild(xmlElementoNome);
                xmlElementoPai.AppendChild(xmlElementoTelefone);
                xmlElementoPai.AppendChild(xmlElementoCep);
                xmlElementoPai.AppendChild(xmlElementoLogradouro);
                xmlElementoPai.AppendChild(xmlElementoComplemento);
                xmlElementoPai.AppendChild(xmlElementoBairro);
                xmlElementoPai.AppendChild(xmlElementoLocalidade);
                xmlElementoPai.AppendChild(xmlElementoUF);

                xmlDocumentInsert.DocumentElement.AppendChild(xmlElementoPai);
                xmlDocumentInsert.Save(HttpContext.Current.Server.MapPath(@XmlNameConstant)); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeletarUsuario(int usuarioID)
        {
            try
            {
                var UsuarioElement = XElement.Load(HttpContext.Current.Server.MapPath(@XmlNameConstant));                
                IEnumerable<XElement> vUsuarioDelete =  from query in
                                                        UsuarioElement.Element("usuario").Elements()
                                                        where (((string)query.Attribute("id")).Equals(usuarioID.ToString()))
                                                        select query;

                foreach (XElement elemento in vUsuarioDelete)
                {
                    elemento.Remove();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }       
        public void AtualizarUsuario(UsuarioModel usuarioModel)
        {
            try
            {
                var UsuarioElement = XElement.Load(HttpContext.Current.Server.MapPath(@XmlNameConstant));                
                IEnumerable<XElement> vUsuarioDelete = from query in
                                                       UsuarioElement.Element("usuario").Elements()
                                                       where (((string)query.Attribute("id")).Equals(usuarioModel.Id.ToString()))
                                                       select query;
                if( vUsuarioDelete != null)
                {
                    UsuarioElement.Element("nome").Value = usuarioModel.Nome;
                    UsuarioElement.Element("telefone").Value = usuarioModel.Telefone;
                    UsuarioElement.Element("cep").Value = usuarioModel.Cep;
                    UsuarioElement.Element("logradouro").Value = usuarioModel.Logradouro;
                    UsuarioElement.Element("complemento").Value = usuarioModel.Complemento;
                    UsuarioElement.Element("bairro").Value = usuarioModel.Bairro;
                    UsuarioElement.Element("localidade").Value = usuarioModel.Localidade;
                    UsuarioElement.Element("uf").Value = usuarioModel.Uf;

                    UsuarioElement.Save(HttpContext.Current.Server.MapPath(@XmlNameConstant));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}