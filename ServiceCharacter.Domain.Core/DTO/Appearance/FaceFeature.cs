using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCharacter.Domain.Core.DTO.Appearance
{
    public class FaceFeature
    {
        public byte index = 0;
        public float scale = 0.5f;
        public FaceFeature(byte index, float scale)
        {
            this.index = index;
            this.scale = scale;
        }
    }
}
