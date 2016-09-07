using System;

namespace LotterySpinner
{
    using System.Linq;

    static class LottrySpinner
    {
        static readonly Random randomNumber = new Random();

        /// <summary>
        /// Random 1 to 49
        /// </summary>
        /// <returns></returns>
        public static int GetLottoNumber(int[] exclusions)
        {
            while (true)
            {
                var number = randomNumber.Next(1, 59);

                if (!exclusions.Any(i => i == number))
                {
                    return number;
                }
            }
        }

        /// <summary>
        /// Random 1 to 50
        /// </summary>
        /// <param name="euroNumbers"></param>
        /// <returns></returns>
        public static int GetEuroNumber(int[] exclusions)
        {
            while (true)
            {
                var number = randomNumber.Next(1, 50);

                if (!exclusions.Any(i => i == number))
                {
                    return number;
                }
            }
        }

        /// <summary>
        /// Random 1 to 11
        /// </summary>
        /// <returns></returns>
        public static int GetEuroLuckStar(int[] exclusions)
        {
            while (true)
            {
                var number = randomNumber.Next(1, 11);

                if (!exclusions.Any(i => i == number))
                {
                    return number;
                }
            }
        }
    }
}
