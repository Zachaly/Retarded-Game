using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retarded_Game.Models.Location
{
    public struct LocationSize
    {   
        private readonly int _maxHorizontalSize;
        private readonly int _maxVerticalSize;
        private readonly int _minHorizontalSize;
        private readonly int _minVerticalSize;
        private int _verticalSize = 0, _horizontalSize = 0;

        public int VerticalSize => _verticalSize;
        public int HorizontalSize => _horizontalSize;

        public LocationSize(int minHorizontalSize, int maxHorizontalSize, int minVerticalSize, int maxVerticalSize)
        {
            _maxHorizontalSize = maxHorizontalSize;
            _minHorizontalSize = minHorizontalSize;
            _maxVerticalSize = maxVerticalSize;
            _minVerticalSize = minVerticalSize;
        }
        
        public void SetSize()
        {
            Random random = new Random();

            _horizontalSize = random.Next(_minHorizontalSize, _maxHorizontalSize);
            _verticalSize = random.Next(_minVerticalSize, _maxVerticalSize);
        }
    }
}
