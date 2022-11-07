using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilding : MonoBehaviour
{
    [SerializeField] private int minXSize;
    [SerializeField] private int maxXSize;
    [SerializeField] private int minZSize;
    [SerializeField] private int maxZsize;

    [SerializeField] private GameObject simpleCube;
    [SerializeField] private CubeCellCore moveCube;

    private bool standartGame = false;

    private int zSize;
    private int xSize;

    public bool StandartGame
    {
        set { standartGame = value; }
    }
    public Color[,] StartBuild()
    {
        Color[,] colorBlocks = null;
        if (!standartGame)
        {
            xSize = Random.Range(minXSize, maxXSize + 1);
            zSize = Random.Range(minZSize, maxZsize + 1);

            colorBlocks = LevelCalculations.StartCalculations(xSize, zSize, standartGame);
        }
        else
        {
            xSize = 5;
            zSize = 5;

            colorBlocks = LevelCalculations.StartCalculations(xSize, zSize, standartGame);
        }


        BuildLevel(colorBlocks);

        return colorBlocks;
    }

    private void BuildLevel(Color[,] colorBlocks)
    {
        for (int x = 0; x < xSize; x++)
        {
            if (x % 2 != 0)
            {
                continue;
            }

            GameObject TempObject = Instantiate(simpleCube, transform);

            TempObject.transform.position = new Vector3(x, 0, -1);

            TempObject.GetComponent<Renderer>().material.color = colorBlocks[x, 0];
        }

        for (int x = 0; x < xSize; x++)
        {
            if (x % 2 != 0)
            {
                for (int z = 1; z < zSize + 1; z += 2)
                {
                    GameObject TempObject = Instantiate(simpleCube, transform);

                    TempObject.transform.position = new Vector3(x, 0, z);
                }

                for (int z = 2; z < zSize + 1; z += 2)
                {
                    colorBlocks[x,z] = new Color(0, 0, 0, 0);
                }
            }
            else
            {
                for (int z = 1; z < zSize + 1; z++)
                {
                    CubeCellCore TempObject = Instantiate(moveCube, transform);

                    TempObject.transform.position = new Vector3(x, 0, z);

                    TempObject.GetComponent<Renderer>().material.color = colorBlocks[x, z];
                    TempObject.CanMove = true;
                }
            }
        }
    }
}
