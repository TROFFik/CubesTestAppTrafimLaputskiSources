using System.Collections.Generic;
using UnityEngine;

public class LevelCalculations
{
    private static bool standartColors = false;
    private static List<Vector2> freeCells = new List<Vector2>();
    public static Color[,] StartCalculations(int Xsize, int Zsize, bool StandartColors)
    {
        standartColors = StandartColors;
        return CreateArray(Xsize, Zsize);
    }
    private static Color[,] CreateArray(int Xsize, int Zsize)
    {
        Color[,] colorBlocks = new Color[Xsize, Zsize + 1];

        FillFreeCells(Xsize, Zsize);
        FillArray(colorBlocks);
        return colorBlocks;
    }

    private static void FillArray(Color[,] colorBlocks)
    {
        int Xsize = colorBlocks.GetLength(0);
        int Zsize = colorBlocks.GetLength(1);

        for (int x = 0; x < Xsize; x++)
        {
            if (x % 2 != 0)
            {
                for (int z = 1; z < Zsize; z+=2)
                {
                    colorBlocks[x, z] = Color.white;
                }

                continue;
            }

            Color TempMainColor = GetColor(x);

            for (int z = 0; z < Zsize; z++)
            {
                if (z == 0)
                {
                    colorBlocks[x, z] = TempMainColor;
                    continue;
                }

                Vector2 TempVector = freeCells[Random.Range(0, freeCells.Count)];
                freeCells.Remove(TempVector);
                colorBlocks[(int)TempVector.x, (int)TempVector.y] = TempMainColor;
            }
        }
    }

    private static void FillFreeCells(int Xsize, int Zsize)
    {
        for (int x = 0; x < Xsize; x++)
        {
            if (x % 2 != 0)
            {
                continue;
            }

            for (int z = 1; z <= Zsize; z++)
            {
                freeCells.Add(new Vector2(x, z));
            }
        }
    }

    private static Color GetColor(int X)
    {
        Color TempColor = Color.black;

        if (standartColors)
        {
            Color[] TempColorArray = new Color[]
            {
                Color.red,
                Color.yellow,
                Color.blue
            };

            TempColor = TempColorArray[X/2];
        }
        else
        {
            TempColor = new Color(Random.value, Random.value, Random.value, 1);
        }

        return TempColor;
    }
}
