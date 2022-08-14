using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexMapCommands
{
    public enum MapMarkup
    {
        FourQuadrants,
        Positive,
        NonNegative
    }

    public enum Direction
    {
        SE,
        SW,
        NW,
        NE
    }

    // maybe remake with flags
    public struct MapSettings
    {
        public float hexRadius;
        public uint width;
        public uint height;
        public MapMarkup markup;
        public Direction positiveDirection;
    }
}
