using AltV.Net;
using AltV.Net.Elements.Entities;
using ServiceCharacter.Domain.Core.DTO.Appearance;
using ServiceCharacter.Domain.Core.DTO.Clothes;
using ServiceCharacter.Domain.Core.DTO.Prop;

namespace ServiceCharacter.Domain.Core
{
    public class User : Player
    {
        private Character _character;
        public Character Character { get { return _character; }
            set
            {
                _character = value;

                this.SetHeadBlendData(
                    value.Appearance.HeadBlendData.ShapeFirstID,
                    value.Appearance.HeadBlendData.ShapeSecondID,
                    value.Appearance.HeadBlendData.ShapeThirdID,
                    value.Appearance.HeadBlendData.SkinFirstID,
                    value.Appearance.HeadBlendData.SkinSecondID,
                    value.Appearance.HeadBlendData.SkinThirdID,
                    value.Appearance.HeadBlendData.ShapeMix,
                    value.Appearance.HeadBlendData.SkinMix,
                    value.Appearance.HeadBlendData.ThirdMix
                );

                this.SetHeadBlendPaletteColor(
                    value.Appearance.HeadBlendPaletteColor.id,
                    value.Appearance.HeadBlendPaletteColor.rgba
                );

                this.SetFaceFeature(
                    value.Appearance.FaceFeature.index,
                    value.Appearance.FaceFeature.scale
                );

                this.SetHeadOverlay(
                    value.Appearance.HeadOverlay.overlayID,
                    value.Appearance.HeadOverlay.index,
                    value.Appearance.HeadOverlay.opacity
                );

                this.SetHeadOverlayColor(
                    value.Appearance.HeadOverlayColor.overlayID,
                    value.Appearance.HeadOverlayColor.colorType,
                    value.Appearance.HeadOverlayColor.colorIndex,
                    value.Appearance.HeadOverlayColor.secondColorIndex
                );

                this.SetEyeColor(this.Character.Appearance.EyeColor.index);

                this.HairColor = this.Character.Appearance.HairColor.colorID;

                this.HairHighlightColor = this.Character.Appearance.HairColor.highlightColorID;



                this.SetClothes(value.Clothes.Component, value.Clothes.Drawable, value.Clothes.Texture, value.Clothes.Palette);



                this.SetProps(value.Props.Component, value.Props.Drawable, value.Props.Texture);

                
            }
        }
        public User(ICore core, IntPtr nativePointer, uint id) : base(core, nativePointer, id)
        {
            HeadBlendData HeadBlendData = new(0,0,0,0,0,0,0,0,0);
            HeadBlendPaletteColor HeadBlendPaletteColor = new(0, new AltV.Net.Data.Rgba(255, 0, 0, 255));
            FaceFeature FaceFeature = new(0, 0.5f);
            HeadOverlay HeadOverlay = new(0, 0, 0.5f);
            HeadOverlayColor HeadOverlayColor = new(0, 0, 0, 0);
            EyeColor EyeColor = new(0);
            HairColor HairColor = new(0, 0);
            Appearance Appearance = new(HeadBlendData, HeadBlendPaletteColor, FaceFeature, HeadOverlay, HeadOverlayColor, EyeColor, HairColor);

            Clothes Clothes = new(1, 14, 0, 0);

            Props Props = new(0, 13, 0);

            Character = new Character(Appearance, Clothes, Props);
        }
    }

    public class UserFactory : IEntityFactory<IPlayer>
    {
        public IPlayer Create(ICore core, IntPtr playerPointer, uint id)
        {
            return new User(core, playerPointer, id);
        }
    }
}
