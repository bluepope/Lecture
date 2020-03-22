using Lecture.Lib.Database;
using System;
using System.Linq;

namespace Lecture.ConsoleExtensionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = "123,123";

            #region IsNull string null 확인
            /*
            //case 1
            if (inputString == null || inputString == "")
            {
                Console.WriteLine("inputstring은 비어있을 수 없습니다");
                inputString = "default";
            }

            //case 2
            if (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("inputstring은 비어있을 수 없습니다");
                inputString = "default";
            }

            //case 3
            inputString = CommonCls.IsNull(inputString, "default");

            //case 4
            inputString = inputString.IsNull("default");
            */
            #endregion

            #region string 다중 비교
            /*
            //case 1
            if (inputString == "홍길동"
                || inputString == "둘리"
                || inputString == "마이콜")
            {
                Console.WriteLine("호이!");
            }

            //case 2
            if (new string[] { "홍길동", "둘리", "마이콜" }.Contains(inputString))
            {
                Console.WriteLine("호이!");
            }

            //case 3 확장메서드
            if (inputString.In("홍길동", "둘리", "마이콜"))
            {
                Console.WriteLine("호이!");
            }
            */
            #endregion

            //object 사용에 대한 주의
            // DataRow x["col1"] --> object
            //int x = inputString.ToInt();
            //Console.WriteLine(x);

            //nullable 사용에 대한 안내
            //DateTime 과 DateTime? 은 다름!!
            //작업 Table  UpdateTime, CompleteTime
            DateTime? date = DateTime.Now;

            Console.WriteLine(date.ToString("yyyy/MM/dd"));
        }
    }

    public class CommonCls
    {
        public static bool IsNull(string a) => string.IsNullOrWhiteSpace(a);
        public static string IsNull(string a, string b) => string.IsNullOrWhiteSpace(a) ? b : a;
    }
}
