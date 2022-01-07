using ApiFlockIT.Models;
using ApiFlockIT.Models.DTO;
using ApiFlockIT.Services;
using System.Linq;

namespace NetCoreApi.Services
{
    public interface IUserValidate
    {
        UserDTO Login(string username, string password);
    }
    public class UserValidate: IUserValidate
    {
        private readonly Ilog4netManager _log;

        private static User[] usuarios = new User[]
        {
            new User {Id=1,Realname="Test Dummy",Username="Test",Password="123" }
        };

        public UserValidate(Ilog4netManager log) { _log = log; }

        public UserDTO Login(string username, string password)
        {
            var userDTO = new UserDTO();
            _log.LogInfo("Inicio busqueda de usuario");
            _log.LogDebug($"username={username} password={password}");
            var user = usuarios.FirstOrDefault(a => a.Username == username && a.Password == password);

            if (user != null)
            {
                userDTO.IDResultado = 0;
                userDTO.Resultado = "Ok. Usuario validado";
                userDTO.Id= user.Id;
                userDTO.Realname = user.Realname;
                userDTO.Username = user.Username;
                _log.LogInfo($"Resultado={userDTO.IDResultado} Mensaje={userDTO.Resultado}");
                return userDTO;
            }
            else 
            {
                userDTO.IDResultado = -1;
                userDTO.Resultado = "Error. Usuario Invalido";
                _log.LogWarn($"Resultado={userDTO.IDResultado} Mensaje={userDTO.Resultado}");
                return userDTO;
            }

        }
    }
}
