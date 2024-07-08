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
        public Rgba rgba = new(100, 150, 200, 255);

        public HeadBlendPaletteColor(byte id, Rgba rgba)
        {
            this.id = id;
            this.rgba = rgba;
        }
    }
}
