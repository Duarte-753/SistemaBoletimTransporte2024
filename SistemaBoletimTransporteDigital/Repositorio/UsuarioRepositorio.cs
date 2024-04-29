
using Microsoft.EntityFrameworkCore;
using SistemaBoletimTransporteDigital.Data;
using SistemaBoletimTransporteDigital.Models;


namespace SistemaBoletimTransporteDigital.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext) // construtor
        {
            this._bancoContext = bancoContext;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuario.First(x => x.Usuario == login);
        }

        public UsuarioModel BuscarPorEmailLogin(string email, string login)
        {
            return _bancoContext.Usuario.First(x => x.Usuario == login & x.Email == email);
        }


        public UsuarioModel ListarPorId(int id)
        {
          return _bancoContext.Usuario.First(x => x.Id == id);
        }

        public UsuarioModel BuscarPorToken(string token)
        {
            return _bancoContext.Usuario.First(x => x.Senha == token);
        }

        public List<UsuarioModel> BuscarUsuario() // buscar os dados do banco da tabela Usuario
        {
           return _bancoContext.Usuario.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            // gravar no banco de dados
            usuario.SetSenhaHash();
            usuario.CorridaStatus = Enums.PerfilEnum.Finalizada;
            usuario.EstaVinculadoAumaCorrida = Enums.PerfilEnum.VinculadoAcorridaNao;
            _bancoContext.Usuario.Add(usuario);
            _bancoContext.SaveChanges();

            return usuario;
            
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do usuário!");

            usuarioDB.CodigoFuncional = usuario.CodigoFuncional;
            usuarioDB.Nome= usuario.Nome;
            usuarioDB.Usuario = usuario.Usuario;
            usuarioDB.Senha = usuario.Senha;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Celular = usuario.Celular;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataUltimaAtualizacao = usuario.DataUltimaAtualizacao;
            
           

            _bancoContext.Usuario.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na exclusão do usuário!");

            _bancoContext.Usuario.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public UsuarioModel EditarUsuario(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do usuário!");

            usuarioDB.CodigoFuncional = usuario.CodigoFuncional;
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Usuario = usuario.Usuario;
            usuarioDB.Senha = usuario.Senha;
            usuarioDB.SetSenhaHash();
            usuarioDB.Email = usuario.Email;
            usuarioDB.Celular = usuario.Celular;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataUltimaAtualizacao = usuario.DataUltimaAtualizacao;



            _bancoContext.Usuario.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public UsuarioModel EditarNovaSenha(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do usuário!");

            
            usuarioDB.Senha = usuario.Senha;
            usuarioDB.SetSenhaHash();
            usuarioDB.DataUltimaAtualizacao = usuario.DataUltimaAtualizacao;



            _bancoContext.Usuario.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

       

        public void CorridaStatusUserI(CorridaModel buscaUsuario)
        {
            UsuarioModel usuarioDB = ListarPorId(buscaUsuario.UsuarioID);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do Usuario!");

            usuarioDB.CorridaStatus = Enums.PerfilEnum.Iniciada;


            _bancoContext.Usuario.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return;
        }

        public void CorridaStatusUserF(CorridaModel buscaUsuario)
        {
            UsuarioModel usuarioDB = ListarPorId(buscaUsuario.UsuarioID);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do Usuario!");

            usuarioDB.CorridaStatus = Enums.PerfilEnum.Finalizada;


            _bancoContext.Usuario.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return;
        }

        //public UsuarioModel BuscarPorCodigoFuncional(string codigoFuncional)
        //{
        //    return _bancoContext.Usuario.FirstOrDefault(u => u.CodigoFuncional == codigoFuncional);
        //}

        object IUsuarioRepositorio.BuscarPorCodigoFuncional(string codigoFuncional)
        {
            return _bancoContext.Usuario.FirstOrDefault(u => u.CodigoFuncional == codigoFuncional);
        }

        public UsuarioModel BuscarPorNomeUsuario(string nomeUsuario)
        {
            return _bancoContext.Usuario.FirstOrDefault(u => u.Usuario == nomeUsuario);
        }

        public object BuscarPorEmail(string email)
        {
            return _bancoContext.Usuario.FirstOrDefault(u => u.Email == email);
        }

        public void CorridaVinculadoSim(CorridaModel buscaUsuario)
        {
            UsuarioModel usuarioDB = ListarPorId(buscaUsuario.UsuarioID);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do Usuario!");

            usuarioDB.EstaVinculadoAumaCorrida = Enums.PerfilEnum.VinculadoAcorridaSim;


            _bancoContext.Usuario.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return;
        }

        public void CorridaVinculadoNao(CorridaModel buscaUsuario)
        {
            UsuarioModel usuarioDB = ListarPorId(buscaUsuario.UsuarioID);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do Usuario!");

            usuarioDB.EstaVinculadoAumaCorrida = Enums.PerfilEnum.VinculadoAcorridaNao;


            _bancoContext.Usuario.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return;
        }
    }
}
