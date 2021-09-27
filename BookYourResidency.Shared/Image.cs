using System;
using System.Collections.Generic;
using System.Text;

namespace BookYourResidency.Shared
{

        public class Image
        {
            public int ImageId { get; set; }
            public string ImageUrl { get; set; }
            public byte[] Filse { get; set; }
            public virtual Property Property { get; set; }
        }
}
