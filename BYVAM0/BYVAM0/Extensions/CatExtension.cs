using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BYVAM0.Model;

namespace BYVAM0.Extensions
{
    internal static class CatExtension
    {
        public static string LowerCat(this Cat cat) {
            return cat.ToString().ToLower();
        }

        public static string GetCatImgPath(this Cat cat)
        {
            return Path.Join(AppContext.BaseDirectory, "Assets", $"{cat.LowerCat()}.png");
        }
    }
}
