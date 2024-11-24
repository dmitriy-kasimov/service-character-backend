using ServiceCharacter.Domain.Core.DTO.Appearance;
using ServiceCharacter.Domain.Core.DTO.Clothes;
using ServiceCharacter.Domain.Core.DTO.Prop;

namespace ServiceCharacter.Domain.Core
{
    public class Character
    {
        public Appearance Appearance { get; set; }
        public Clothes Clothes { get; set; }
        public Props Props { get; set; }
        
        private Character(Appearance appearance, Clothes clothes, Props props)
        {
            Appearance = appearance;
            Clothes = clothes;
            Props = props;
        }

        public static Character GetInitialValue()
        {
            HeadBlendData HeadBlendData = new(0,0,0,0,0,0,0,0,0);
            HeadBlendPaletteColor HeadBlendPaletteColor = new(0, 255, 255, 255, 255);
            FaceFeature FaceFeature = new(0, 0.5f);
            HeadOverlay HeadOverlay = new(0, 0, 0.5f);
            HeadOverlayColor HeadOverlayColor = new(0, 0, 0, 0);
            EyeColor EyeColor = new(0);
            HairColor HairColor = new(0, 0);
            
            
            Appearance appearance = new(HeadBlendData, HeadBlendPaletteColor, FaceFeature, HeadOverlay, HeadOverlayColor, EyeColor, HairColor);
            Clothes clothes = new(0, 0, 0, 0);
            Props props = new(0, 0, 0);

            return new Character(appearance, clothes, props);
        }
    }
}
