using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public static class LectureExtension
    {
        public static bool IsNull(this string a) => string.IsNullOrWhiteSpace(a);
        public static string IsNull(this string a, string b) => string.IsNullOrWhiteSpace(a) ? b : a;
        public static bool In(this string a, params string[] b) => b.Contains(a);

        public static int ToInt(this string a) => Convert.ToInt32(a.IsNull("0").Replace(",", ""));

        public static string ToString(this DateTime? date, string format)
        {
            if (date.HasValue)
                return date.Value.ToString(format, System.Globalization.CultureInfo.InvariantCulture);

            return null;
        }
    }
}
