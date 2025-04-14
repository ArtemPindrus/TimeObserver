using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeObserver.Extensions {
    public static class StringExtensions {
        public static string SeparateByUppercase(this string str) { 
            List<char> chars = new(str.ToCharArray());

            for(int i = 1; i < chars.Count; i++) {
                if (char.IsUpper(chars[i])) {
                    chars.Insert(i, ' ');
                    i++;
                }
            }

            return new string(chars.ToArray());
        }
    }
}
