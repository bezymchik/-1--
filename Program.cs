using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int[,] result = new int[3, 7];
        static string data = File.ReadAllText(@"D:\ЛП\4 курс 1 семестр\Теорія прийняття рішень\ЛР 1\ConsoleApp1\data.txt");
        static IEnumerable<int> dataEnum = data
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(n => int.Parse(n));
        static int[] nums = dataEnum.ToArray();
        static int[] for_Gurvic_min;
        static int[] for_Gurvic_max;

        static void Main(string[] args)
        {
            Console.WriteLine("Критерiй Гурвiца = 0,5");
            Console.WriteLine("4-й стовпець - критерiй Вальда, 5-й - Максимальний, 6-й - Гурвiца, 7-й - Лапласа");
            int[] maximum = Maximum(nums);
            int[] laplassa = Laplassa(nums);
            int[] valda = Valda(nums);
            for_Gurvic_min = valda;
            for_Gurvic_max = maximum;
            int[] gurvic = Gurvic(nums);
            result[0, 0] = nums[0]; result[0, 1] = nums[1]; result[0, 2] = nums[2];
            result[1, 0] = nums[3]; result[1, 1] = nums[4]; result[1, 2] = nums[5];
            result[2, 0] = nums[6]; result[2, 1] = nums[7]; result[2, 2] = nums[8];
            result[0, 3] = valda[0]; result[1, 3] = valda[1]; result[2, 3] = valda[2];
            result[0, 4] = maximum[0]; result[1, 4] = maximum[1]; result[2, 4] = maximum[2];
            result[0, 5] = gurvic[0]; result[1, 5] = gurvic[1]; result[2, 5] = maximum[2];
            result[0, 6] = laplassa[0]; result[1, 6] = laplassa[1]; result[2, 6] = laplassa[2];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write("{0}\t", result[i, j]);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        static int[] Maximum(int[] nums)
        {
            int first = nums.Skip(-1).Take(2).Max();
            int second = nums.Skip(2).Take(5).Max();
            int third = nums.Skip(5).Take(8).Max();
            return new int[] { first, second, third };
        }

        static int[] Laplassa(int[] nums)
        {
            int first = (nums[0] / 3) + (nums[1] / 3) + (nums[2] / 3);
            int second = (nums[3] / 3) + (nums[4] / 3) + (nums[5] / 3);
            int third = (nums[6] / 3) + (nums[7] / 3) + (nums[8] / 3);
            return new int[] { first, second, third };
        }

        static int[] Valda(int[] nums)
        {
            int first = nums.Skip(-1).Take(2).Min();
            int second = nums.Skip(2).Take(5).Min();
            int third = nums.Skip(5).Take(8).Min();
            return new int[] { first, second, third };
        }

        static int[] Gurvic(int[] nums)
        {
            int first = (int)((0.5* for_Gurvic_min[0]) + ((1 - 0.5) * for_Gurvic_max[0]));
            int second = (int)((0.5 * for_Gurvic_min[1]) + ((1 - 0.5) * for_Gurvic_max[1]));
            int third = (int)((0.5 * for_Gurvic_min[2]) + ((1 - 0.5) * for_Gurvic_max[2]));
            return new int[] { first, second, third };
        }
    }
}
