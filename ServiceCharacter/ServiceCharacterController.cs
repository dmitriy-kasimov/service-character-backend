using AltV.Net;
using Newtonsoft.Json;
using ServiceCharacter.Domain.Core;
using ServiceCharacter.Infrastructure.Data.Exceptions;
using System.Numerics;

namespace ServiceCharacter
{
    internal class ServiceCharacterController : IScript
    {
        private Infrastructure.Business.ServiceCharacter? _serviceCharacter;
        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void UserConnect(User user, string reason)
        {
            _serviceCharacter = new Infrastructure.Business.ServiceCharacter(user);
            _serviceCharacter.Create(user, user.Character);
            user.Spawn(new Vector3(0,5,71), 1000);
            user.Emit("s:c:createCharacter");
        }

        [ServerEvent("ServiceUSIA:s:ServiceCharacter:s:start")]
        public void Start(User user)
        {
            try 
            {
                _serviceCharacter?.Start(user);

                var characterString = JsonConvert.SerializeObject(user.Character) ?? throw new ServerException(Server.ErrorSerializeCharacter);
                user.Emit("ServiceCharacter:s:ServiceCharacter:c:start", characterString);
            }
            catch (ServerException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [ClientEvent("c:s:createCharacter")]
        public void CreateCharacter(User user, string jsonCharacter)
        {
            Console.WriteLine("jsonCharacter");
            Console.WriteLine(jsonCharacter);
            try
            {
                var Character = JsonConvert.DeserializeObject<Character>(jsonCharacter) ?? throw new ServerException(Server.ErrorDeserializeCharacter);
                _serviceCharacter?.Create(user, Character);
            }
            catch (ServerException ex) 
            {
                Console.WriteLine(ex.Message);
            } 
        }

        [ClientEvent("ServiceUSIA:s:ServiceCharacter:s:updateCharacter")]
        public void UpdateCharacter(User user)
        {
            Console.WriteLine("UpdateCharacter was called!");
            try
            {
                _serviceCharacter?.Update(user);
            }
            catch (ServerException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
