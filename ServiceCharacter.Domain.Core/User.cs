using AltV.Net;
using AltV.Net.Elements.Entities;
using ServiceCharacter.Domain.Core.DTO.Appearance;
using ServiceCharacter.Domain.Core.DTO.Clothes;
using ServiceCharacter.Domain.Core.DTO.Prop;

namespace ServiceCharacter.Domain.Core
{
    public class User : Player
    {
        private Character _character = Character.GetInitialValue();
        public Character Character { get => _character; 
            set
            {
                _character = value;

                SetHeadBlendData(
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

                SetHeadBlendPaletteColor(
                    value.Appearance.HeadBlendPaletteColor.id,
                    new AltV.Net.Data.Rgba(
                        value.Appearance.HeadBlendPaletteColor.r,
                        value.Appearance.HeadBlendPaletteColor.g,
                        value.Appearance.HeadBlendPaletteColor.b,
                        value.Appearance.HeadBlendPaletteColor.a
                    )
                    
                );

                SetFaceFeature(
                    value.Appearance.FaceFeature.index,
                    value.Appearance.FaceFeature.scale
                );

                SetHeadOverlay(
                    value.Appearance.HeadOverlay.overlayID,
                    value.Appearance.HeadOverlay.index,
                    value.Appearance.HeadOverlay.opacity
                );

                SetHeadOverlayColor(
                    value.Appearance.HeadOverlayColor.overlayID,
                    value.Appearance.HeadOverlayColor.colorType,
                    value.Appearance.HeadOverlayColor.colorIndex,
                    value.Appearance.HeadOverlayColor.secondColorIndex
                );

                SetEyeColor(Character.Appearance.EyeColor.index);

                HairColor = Character.Appearance.HairColor.colorID;

                HairHighlightColor = Character.Appearance.HairColor.highlightColorID;

                SetClothes(value.Clothes.Component, value.Clothes.Drawable, value.Clothes.Texture, value.Clothes.Palette);
                
                SetProps(value.Props.Component, value.Props.Drawable, value.Props.Texture);
            }
        }
        public User(ICore core, IntPtr nativePointer, uint id) : base(core, nativePointer, id)
        {

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
