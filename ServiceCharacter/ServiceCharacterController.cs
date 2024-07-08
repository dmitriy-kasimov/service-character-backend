using AltV.Net;
using Newtonsoft.Json;
using ServiceCharacter.Domain.Core;
using ServiceCharacter.Infrastructure.Data.Exceptions;
using System.Numerics;

namespace ServiceCharacter
{
    internal class ServiceCharacterController : IScript
    {
        public Infrastructure.Business.ServiceCharacter ServiceCharacter;
        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void UserConnect(User user, string reason)
        {
            ServiceCharacter = new Infrastructure.Business.ServiceCharacter(user);
            ServiceCharacter.Create(user, user.Character);
            user.Spawn(new Vector3(0,0,10), 1000);
            user.Emit("ServiceCharacter:s:ServiceCharacter:c:createCharacter");
        }

        [ServerEvent("ServiceUSIA:s:ServiceCharacter:s:start")]
        public void Start(User user)
        {
            try 
            {
                ServiceCharacter.Start(user);

                string characterString = JsonConvert.SerializeObject(user.Character) ?? throw new ServerException(Server.ErrorSerializeCharacter);
                user.Emit("ServiceCharacter:s:ServiceCharacter:c:start", characterString);
            }
            catch (ServerException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [ClientEvent("ServiceCharacter:c:ServiceCharacter:s:createCharacter")]
        public void CreateCharacter(User user, string jsonCharacter)
        {
            try
            {
                Character Character = JsonConvert.DeserializeObject<Character>(jsonCharacter) ?? throw new ServerException(Server.ErrorDeserializeCharacter);
                ServiceCharacter.Create(user, Character);
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
                ServiceCharacter.Update(user);
            }
            catch (ServerException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
