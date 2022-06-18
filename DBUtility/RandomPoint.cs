using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBUtility
{
    public class RandomPoint
    {
        public static int[] Point
        {
            get 
            { 
                int[] A = new int[40];
                for (int i = 100; i < 140; i++) 
                {
                    A[i-100] = i;
                }
                return A;
            }
        }



        public static int[] Defend
        {
            get
            {
                int[] A = new int[40];
                for (int i = 0; i < 40; i++)
                {
                    A[i] = i + 1;
                }
                return A;
            }
        }

        public static int[] Tactics 
        {
            get
            {
                int[] A = new int[40];
                for (int i = 0; i < 40; i++)
                {
                    A[i] = (i - 16) + 1;
                }
                return A;
            }
        }

        public static int[] Assist
        {
            get
            {
                int[] A = new int[20];
                for (int i = 12; i < 32; i++)
                {
                    A[i - 12] = i;
                }
                return A;
            }
        }
        public static float[] GailvAssist
        {
            get
            {
                float[] A = new float[20];
                A[0] = 0.900f;
                A[1] = 0.890f;
                A[2] = 0.880f;
                A[3] = 0.870f;
                A[4] = 0.860f;

                A[5] = 0.510f;
                A[6] = 0.520f;
                A[7] = 0.530f;
                A[8] = 0.540f;
                A[9] = 0.550f;
                A[10] = 0.560f;
                A[11] = 0.390f;
                A[12] = 0.380f;
                A[13] = 0.370f;
                A[14] = 0.360f;

                A[15] = 0.190f;
                A[16] = 0.180f;
                A[17] = 0.170f;
                A[18] = 0.160f;
                A[19] = 0.160f;
                return A;
            }
        }
        public static float[] TrueGailvAssist(int B)
        {
            float[] A = new float[20];
            A = GailvAssist;
            if (B <= 60) { return A; }

            for (int i = 0; i < A.Length; i++)
            {
                if (i < 5)
                {
                    A[i] = A[i] - 0.020f * (B - 60);
                }
                else if (i > 4 && i < 15)
                {
                    A[i] = A[i] + 0.005f * (B - 60);
                }
                else
                {
                    A[i] = A[i] + 0.010f * (B - 60);
                }
            }
            return A;
        }


        public static int[] Steal
        {
            get
            {
                int[] A = new int[15];
                for (int i = 5; i < 20; i++)
                {
                    A[i - 5] = i;
                }
                return A;
            }
        }
        public static float[] GailvSteal
        {
            get
            {
                float[] A = new float[15];
                A[0] = 0.500f;
                A[1] = 0.490f;
                A[2] = 0.480f;
                A[3] = 0.470f;
                A[4] = 0.460f;

                A[5] = 0.550f;
                A[6] = 0.540f;
                A[7] = 0.530f;
                A[8] = 0.520f;
                A[9] = 0.510f;
                A[10] = 0.500f;

                A[11] = 0.390f;
                A[12] = 0.380f;
                A[13] = 0.370f;
                A[14] = 0.360f;

                return A;
            }
        }
        public static float[] TrueGailvSteal(int B)
        {
            float[] A = new float[15];
            A = GailvSteal;
            if (B <= 70) { return A; }
            else if (B > 70 && B < 89)
            {
                for (int i = 0; i < A.Length; i++)
                {
                    if (i < 6)
                    {
                        A[i] = A[i] - 0.020f * (B - 70);
                    }
                    else if (i > 5 && i < 11)
                    {
                        A[i] = A[i] + 0.020f * (B - 70);
                    }
                    else
                    {
                        A[i] = A[i] + 0.005f * (B - 70);
                    }
                }
            }
            else
            {
                A[0] = 0.100f;
                A[1] = 0.110f;
                A[2] = 0.120f;
                A[3] = 0.130f;
                A[4] = 0.140f;

                A[5] = 0.950f;
                A[6] = 0.940f;
                A[7] = 0.930f;
                A[8] = 0.920f;
                A[9] = 0.910f;
                A[10] = 0.900f;

                A[11] = 0.450f;
                A[12] = 0.440f;
                A[13] = 0.430f;
                A[14] = 0.420f;
            }
            return A;
        }

        public static int[] Block
        {
            get
            {
                int[] A = new int[15];
                for (int i = 0; i < 15; i++)
                {
                    A[i] = i;
                }
                return A;
            }
        }
        public static float[] GailvBlock
        {
            get
            {
                float[] A = new float[15];
                A[0] = 0.500f;
                A[1] = 0.490f;
                A[2] = 0.480f;
                A[3] = 0.470f;
                A[4] = 0.460f;

                A[5] = 0.550f;
                A[6] = 0.540f;
                A[7] = 0.530f;
                A[8] = 0.520f;
                A[9] = 0.510f;
                A[10] = 0.500f;

                A[11] = 0.390f;
                A[12] = 0.380f;
                A[13] = 0.370f;
                A[14] = 0.360f;

                return A;
            }
        }
        public static float[] TrueGailvBlock(int B)
        {
            float[] A = new float[15];
            A = GailvBlock;
            if (B <= 55) { return A; }
            else if (B > 55 && B < 70)
            {
                for (int i = 0; i < A.Length; i++)
                {
                    if (i < 6)
                    {
                        A[i] = A[i] - 0.020f * (B - 55);
                    }
                    else if (i > 5 && i < 11)
                    {
                        A[i] = A[i] + 0.020f * (B - 55);
                    }
                    else
                    {
                        A[i] = A[i] + 0.005f * (B - 55);
                    }
                }
            }
            else
            {
                A[0] = 0.100f;
                A[1] = 0.110f;
                A[2] = 0.120f;
                A[3] = 0.130f;
                A[4] = 0.140f;

                A[5] = 0.950f;
                A[6] = 0.940f;
                A[7] = 0.930f;
                A[8] = 0.920f;
                A[9] = 0.910f;
                A[10] = 0.900f;

                A[11] = 0.450f;
                A[12] = 0.440f;
                A[13] = 0.430f;
                A[14] = 0.420f;
            }
            return A;
        }
        
        public static int[] Backboard
        {
            get
            {
                int[] A = new int[40];
                for (int i = 35; i < 55; i++)
                {
                    A[i - 35] = i;
                }
                return A;
            }
        }
        public static float[] GailvBackboard
        {
            get
            {
                float[] A = new float[20];
                A[0] = 0.400f;
                A[1] = 0.410f;
                A[2] = 0.420f;
                A[3] = 0.430f;
                A[4] = 0.440f;
                A[5] = 0.450f;

                A[6] = 0.460f;
                A[7] = 0.470f;
                A[8] = 0.480f;
                A[9] = 0.490f;
                A[10] = 0.500f;
                A[11] = 0.510f;
                A[12] = 0.520f;
                A[13] = 0.530f;
                A[14] = 0.540f;

                A[15] = 0.300f;
                A[16] = 0.290f;
                A[17] = 0.280f;
                A[18] = 0.270f;
                A[19] = 0.260f;
                return A;
            }
        }
        public static float[] TrueGailvBackboard(int B)
        {
            float[] A = new float[20];
            A = GailvBackboard;
            if (B <= 70) { return A; }
            
            for (int i = 0; i < 20; i++)
            {
                if (i < 6)
                {
                    A[i] = A[i] - 0.010f * (B - 70);
                }
                else if (i > 5 && i < 15)
                {
                    A[i] = A[i] + 0.010f * (B - 70);
                }
                else
                {
                    A[i] = A[i] + 0.005f * (B - 70);
                }
            }
            return A;
        }

        public static float[] Gailv
        {
            get
            {
                float[] A = new float[40];
                A[0] = 0.010f;
                A[1] = 0.020f;
                A[2] = 0.030f;
                A[3] = 0.040f;
                A[4] = 0.050f;
                A[5] = 0.060f;
                A[6] = 0.070f;
                A[7] = 0.080f;
                A[8] = 0.090f;
                A[9] = 0.100f;
                A[10] = 0.660f;
                A[11] = 0.650f;
                A[12] = 0.640f;
                A[13] = 0.630f;
                A[14] = 0.620f;
                A[15] = 0.610f;
                A[16] = 0.600f;

                A[17] = 0.790f;
                A[18] = 0.780f;
                A[19] = 0.770f;
                A[20] = 0.760f;
                A[21] = 0.750f;
                A[22] = 0.740f;
                A[23] = 0.730f;

                A[24] = 0.600f;
                A[25] = 0.550f;
                A[26] = 0.500f;

                A[27] = 0.400f;
                A[28] = 0.300f;
                A[29] = 0.200f;
                A[30] = 0.100f;

                A[31] = 0.090f;
                A[32] = 0.080f;
                A[33] = 0.070f;
                A[34] = 0.060f;
                A[35] = 0.050f;
                A[36] = 0.040f;
                A[37] = 0.030f;
                A[38] = 0.020f;
                A[39] = 0.010f;
                return A;
            }
        }

        public static float[] TrueGailv(int B)
        {
            float[] A = new float[40];
            A = Gailv;
            for (int i = 0; i < 40; i++)
            {
                if (i < 10)
                {
                    A[i] = A[i] + 0.020f * (100 - B);
                    if (A[i] > 1)
                    {
                        A[i] = 0.990f;
                    }
                }
                else if (i > 9 && i < 17)
                {
                    A[i] = A[i] + 0.005f * (100 - B);
                }
                else if (i > 16 && i < 24)
                {
                    A[i] = A[i] - 0.010f * (100 - B);
                }
                else if (i > 23 && i < 27)
                {
                    A[i] = A[i] - 0.015f * (100 - B);
                }
                else if (i > 26 && i < 29)
                {
                    A[i] = A[i] - 0.005f * (100 - B);
                }
                else if (i > 27 && i < 31)
                {
                    A[i] = A[i] - 0.002f * (100 - B);
                }
                else
                {
                    A[i] = A[i] - 0.001f * (100 - B);

                    if (A[i] <= 0)
                    {
                        A[i] = 0.001f;
                    }

                }
            }
            return A;
        }
        /**
        public static float[] TrueGailv(int B)
        {
                float[] A = new float[40];
                A = Gailv;
                for (int i = 0; i < 40; i++) 
                {
                    if (i < 10)
                    {
                        A[i] = A[i] + 0.010f*(100-B);
                        if (A[i] > 1)
                        {
                            A[i] = 0.990f;
                        }
                    }
                    else if (i > 9 && i < 16)
                    {
                        A[i] = A[i] - 0.010f * (100 - B);
                    }
                    else if (i > 15 && i < 27)
                    {
                        A[i] = A[i] - 0.010f * (100 - B);
                    }
                    else if (i > 26 && i < 30)
                    {
                        A[i] = A[i] - 0.001f * (100 - B);
                    }
                    else 
                    {
                        A[i] = A[i] - 0.001f * (100 - B);
                        
                        if (A[i] <= 0) 
                        {
                            A[i] = 0.001f;
                        }

                    }
                }
                return A;
        }
        **/
        public static float[] ZhanShuGailv
        {
            get
            {
                float[] A = new float[40];
                A[0] = 0.001f;
                A[1] = 0.002f;
                A[2] = 0.003f;
                A[3] = 0.004f;
                A[4] = 0.005f;
                A[5] = 0.006f;
                A[6] = 0.007f;
                A[7] = 0.008f;
                A[8] = 0.009f;
                A[9] = 0.010f;

                A[10] = 0.500f;
                A[11] = 0.510f;
                A[12] = 0.520f;
                A[13] = 0.530f;
                A[14] = 0.540f;
                A[15] = 0.550f;

                A[16] = 0.700f;
                A[17] = 0.690f;
                A[18] = 0.680f;
                A[19] = 0.670f;
                A[20] = 0.660f;
                A[21] = 0.650f;

                A[22] = 0.500f;
                A[23] = 0.450f;
                A[24] = 0.400f;
                A[25] = 0.350f;
                A[26] = 0.300f;
                A[27] = 0.250f;
                A[28] = 0.200f;
                A[29] = 0.150f;

                A[30] = 0.100f;
                A[31] = 0.090f;
                A[32] = 0.080f;
                A[33] = 0.070f;
                A[34] = 0.060f;
                A[35] = 0.050f;
                A[36] = 0.040f;
                A[37] = 0.030f;
                A[38] = 0.020f;
                A[39] = 0.010f;
                return A;
            }
        }

        public static float[] TrueZhanShuGailv(int B)
        {
            float[] A = new float[40];
            A = ZhanShuGailv;
            for (int i = 0; i < 40; i++)
            {
                if (i < 10)
                {
                    A[i] = A[i] + 0.010f * (100 - B);
                }
                else if (i > 9 && i < 16) 
                {
                    A[i] = A[i] + 0.005f * (100 - B);
                }
                else if (i > 15 && i < 22)
                {
                    A[i] = A[i] - 0.005f * (100 - B);
                }
                else if (i > 21 && i < 30)
                {
                    A[i] = A[i] - 0.002f * (100 - B);
                }
                else
                {
                    A[i] = A[i] - 0.001f * (100 - B);

                    if (A[i] <= 0)
                    {
                        A[i] = 0.001f;
                    }

                }
            }
            return A;
        }
    }
}
