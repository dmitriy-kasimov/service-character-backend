using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCharacter.Domain.Core.DTO.Appearance
{
    public class HeadBlendData
    {
        public uint ShapeFirstID = 0;
        public uint ShapeSecondID = 0;
        public uint ShapeThirdID = 0;
        public uint SkinFirstID = 0;
        public uint SkinSecondID = 0;
        public uint SkinThirdID = 0;
        public float ShapeMix = 0;
        public float SkinMix = 0;
        public float ThirdMix = 0;

        public HeadBlendData(uint ShapeFirstID, uint ShapeSecondID, uint ShapeThirdID, uint SkinFirstID, uint SkinSecondID, uint SkinThirdID, float ShapeMix, float SkinMix, float ThirdMix)
        {
            this.ShapeFirstID = ShapeFirstID;
            this.ShapeSecondID = ShapeSecondID;
            this.ShapeThirdID = ShapeThirdID;
            this.SkinFirstID = SkinFirstID;
            this.SkinSecondID = SkinSecondID;
            this.SkinThirdID = SkinThirdID;
            this.ShapeMix = ShapeMix;
            this.SkinMix = SkinMix;
            this.ThirdMix = ThirdMix;
        }
    }
}
