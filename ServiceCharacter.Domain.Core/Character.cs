using ServiceCharacter.Domain.Core.DTO.Appearance;
using ServiceCharacter.Domain.Core.DTO.Clothes;
using ServiceCharacter.Domain.Core.DTO.Prop;
using System.Drawing;

namespace ServiceCharacter.Domain.Core
{
    public class Character
    {
        public Appearance Appearance { get; set; }
        public Clothes Clothes { get; set; }
        public Props Props { get; set; }
        public Character(Appearance Appearance, Clothes Clothes, Props Props)
        {
            this.Appearance = Appearance;
            this.Clothes = Clothes;
            this.Props = Props;
        }
    }
}
