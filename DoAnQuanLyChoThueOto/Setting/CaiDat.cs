using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQuanLyChoThueOto.Setting
{
     static class CaiDat
    {
        private static Font fonts=default;
        private static Color colors=default;

        public static Font Fonts { get => fonts; set => fonts = value; }
        public static Color Colors { get => colors; set => colors = value; }
    }
}
