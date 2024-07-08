using ServiceCharacter.Domain.Core;

namespace ServiceCharacter.Domain.Interfaces
{
    public interface ICharacterRepository
    {
        public void Create(User user, Character character);
        public Character GetCharacter(User user);
    }
}
