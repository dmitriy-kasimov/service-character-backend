using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCharacter.Domain.Core.DTO.Clothes
{
    public class Clothes
    {
        public byte Component;
        public ushort Drawable;
        public byte Texture;
        public byte Palette;

        public Clothes(byte Component, ushort Drawable, byte Texture, byte Palette) 
        {
            this.Component = Component;
            this.Drawable = Drawable;
            this.Texture = Texture;
            this.Palette = Palette;
        }
    }
}
