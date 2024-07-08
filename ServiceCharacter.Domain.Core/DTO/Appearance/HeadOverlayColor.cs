namespace ServiceCharacter.Domain.Core.DTO.Appearance
{
    public class HeadOverlayColor
    {
        public byte overlayID = 0;
        public byte colorType = 0;
        public byte colorIndex = 0;
        public byte secondColorIndex = 0;
        public HeadOverlayColor(byte overlayID, byte colorType, byte colorIndex, byte secondColorIndex)
        {
            this.overlayID = overlayID;
            this.colorType = colorType;
            this.colorIndex = colorIndex;
            this.secondColorIndex = secondColorIndex;
        }
    }
}
