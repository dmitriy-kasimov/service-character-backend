using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCharacter.Domain.Core.DTO.Appearance
{
    public class EyeColor
    {
        public ushort index = 0;
        public EyeColor(ushort index)
        {
            this.index = index;
        }
    }
}
