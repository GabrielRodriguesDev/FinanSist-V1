using FinanSist.Domain.Commands.Autentica;
using FinanSist.Domain.Commands.Email;
using FinanSist.Domain.Commands.Usuario;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Interfaces.Services;

namespace FinanSist.Domain.Services
{
    public class AutenticaService : IAutenticaService
    {
        #region  Property
        private IUsuarioRepository _usuarioRepository;
        private IEmailService _emailService;
        private IUnitOfWork _uow;
        #endregion

        #region  Constructor
        public AutenticaService(IUsuarioRepository usuarioRepository, IUnitOfWork uow, IEmailService emailService)
        {
            _usuarioRepository = usuarioRepository;
            _uow = uow;
            _emailService = emailService;
        }


        #endregion

        #region Method
        public LoginCommandResult Login(LoginCommand cmd)
        {
            cmd.Validate();
            if (cmd.Invalid)
                return new LoginCommandResult(false, "Email ou senha inválidos", cmd.Notifications);

            var usuario = _usuarioRepository.PorEmail(cmd.Email);
            if (usuario == null)
                return new LoginCommandResult(false, "Email ou senha inválidos", cmd.Notifications);

            if (usuario.VerificarSenha(cmd.Senha))
            {
                var resultData = new Autenticado(usuario);
                return new LoginCommandResult(true, "Login efetuado com sucesso", resultData);
            }
            else
            {
                return new LoginCommandResult(false, "Email ou senha inválidos");
            }
        }
        public GenericCommandResult EsqueceuSenha(EsqueceuSenhaCommand cmd)
        {
            cmd.Validate();
            if (cmd.Invalid)
                return new GenericCommandResult(false, "Ops, Algo deu errado!", cmd.Notifications);

            var usuario = _usuarioRepository.PorEmail(cmd.Email);
            if (usuario == null)
                return new GenericCommandResult(false, "Email não Cadastrado");

            usuario.NovoTokenSenha();
            var result = new EsqueceuSenhaCommandResult(usuario);
            //var msg = CreatePostEsqueceuSenhaCommand.Create(usuario);
            //_emailService.Enviar(msg);
            _uow.BeginTransaction();
            try
            {
                _usuarioRepository.Update(usuario);
                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }

            return new GenericCommandResult(true, "Token para alteração de senha", result);
        }

        public GenericCommandResult AlterarSenha(AlterarSenhaCommand cmd)
        {
            cmd.Validate();
            if (cmd.Invalid)
                return new GenericCommandResult(false, "Ops, Algo deu errado!", cmd.Notifications);

            var usuario = _usuarioRepository.PorTokenSenha(cmd.Token);

            if (usuario == null)
                return new GenericCommandResult(false, "Desculpe, não foi possivel alterar senha");

            if (usuario.TokenSenhaValidade < DateTime.Now)
                return new GenericCommandResult(false, "Desculpe, não foi possivel alterar senha");

            usuario.AlterarSenha(cmd.NovaSenha);
            _uow.BeginTransaction();
            try
            {
                _usuarioRepository.Update(usuario);
                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }
            return new GenericCommandResult(true, "Senha alterada com sucesso");
        }
        #endregion
    }

}
