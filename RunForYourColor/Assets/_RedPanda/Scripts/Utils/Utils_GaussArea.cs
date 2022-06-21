using System;

namespace GaussAlan
{
    public static class Utils_GaussArea
    {
        public static double Calculation(double[,] coordinates)
        {
            double _sum = 0;
            int queue = 0;

            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                double X_after;
                double X_before;

                double Y = coordinates[i, 1];

                if (queue == 0)
                {
                    X_after = coordinates[i + 1, 0];

                    X_before = coordinates[coordinates.GetLength(0) - 1, 0];
                }
                else if (queue == coordinates.GetLength(0) - 1)
                {
                    X_after = coordinates[0, 0];

                    X_before = coordinates[i - 1, 0];
                }
                else
                {
                    X_after = coordinates[i + 1, 0];

                    X_before = coordinates[i - 1, 0];
                }

                _sum += Y * (X_after - X_before);

                queue++;
            }

            return Math.Abs(_sum / 2);
        }
    }
}