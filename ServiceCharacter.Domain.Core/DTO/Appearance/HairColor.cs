using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCharacter.Domain.Core.DTO.Appearance
{
    public class HairColor
    {
        public byte colorID = 0;
        public byte highlightColorID = 0;

        public HairColor(byte colorID, byte highlightColorID)
        {
            this.colorID = colorID;
            this.highlightColorID = highlightColorID;
        }
    }
}
