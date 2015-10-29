using System;
using System.Collections.Generic;

namespace Core.Misc
{
    public partial class ImageSize : BaseEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsRemoved { get; set; }
    }
}
