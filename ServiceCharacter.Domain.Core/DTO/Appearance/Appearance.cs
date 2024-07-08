using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCharacter.Domain.Core.DTO.Appearance
{
    public class Appearance
    {
        public HeadBlendData HeadBlendData { get; set; }
        public HeadBlendPaletteColor HeadBlendPaletteColor { get; set; }
        public FaceFeature FaceFeature { get; set; }
        public HeadOverlay HeadOverlay { get; set; }
        public HeadOverlayColor HeadOverlayColor { get; set; }
        public EyeColor EyeColor { get; set; }
        public HairColor HairColor { get; set; }

        public Appearance(
            HeadBlendData HeadBlendData,
            HeadBlendPaletteColor HeadBlendPaletteColor,
            FaceFeature FaceFeature,
            HeadOverlay HeadOverlay,
            HeadOverlayColor HeadOverlayColor,
            EyeColor EyeColor,
            HairColor HairColor
        )
        {
            this.HeadBlendData = HeadBlendData;
            this.HeadBlendPaletteColor = HeadBlendPaletteColor;
            this.FaceFeature = FaceFeature;
            this.HeadOverlay = HeadOverlay;
            this.HeadOverlayColor = HeadOverlayColor;
            this.EyeColor = EyeColor;
            this.HairColor = HairColor;
        }
    }
}
