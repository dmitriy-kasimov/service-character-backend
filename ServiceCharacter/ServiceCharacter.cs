using AltV.Net;
using AltV.Net.Elements.Entities;
using ServiceCharacter.Domain.Core;

namespace ServiceCharacter
{
    public class ServiceCharacter : Resource
    {
        public override IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return new UserFactory();
        }
        public override void OnStart()
        {

        }

        public override void OnStop()
        {

        }
    }
}