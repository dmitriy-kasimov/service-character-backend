using ServiceCharacter.Domain.Core;

namespace ServiceCharacter.Services.Interfaces
{
    public interface IServiceCharacter
    {
        public void Start(User user);
        public void Create(User user, Character character);
        public void Update(User user);
    }
}
