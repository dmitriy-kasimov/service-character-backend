using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCharacter.Domain.Core.DTO.Appearance
{
    public class HeadOverlay
    {
        public byte overlayID = 0;
        public byte index = 0;
        public float opacity = 0.5f;
        public HeadOverlay(byte overlayID, byte index, float opacity)
        {
            this.overlayID = overlayID;
            this.index = index;
            this.opacity = opacity;
        }
    }
}
