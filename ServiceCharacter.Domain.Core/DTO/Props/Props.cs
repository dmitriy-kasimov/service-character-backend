using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCharacter.Domain.Core.DTO.Prop
{
    public class Props
    {
        public byte Component;
        public ushort Drawable;
        public byte Texture;

        public Props(byte Component, ushort Drawable, byte Texture) 
        {
            this.Component = Component;
            this.Drawable = Drawable;
            this.Texture = Texture;
        }
    }
}
