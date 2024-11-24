using AltV.Net.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCharacter.Domain.Core.DTO.Appearance
{
    public class HeadBlendPaletteColor
    {
        public byte id = 0;
        public byte r = 255;
        public byte g = 255;
        public byte b = 255;
        public byte a = 255;

        public HeadBlendPaletteColor(byte id, byte r, byte g, byte b, byte a)
        {
            this.id = id;
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }
}
