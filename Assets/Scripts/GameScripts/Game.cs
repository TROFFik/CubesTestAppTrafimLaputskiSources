using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Singletone { get; private set; }

    [SerializeField] private GameObject WinMenu;
    [SerializeField] private LevelBuilding levelBuilding;
    [SerializeField] private CameraController cameraController;

    private Color[,] colorBlocks;
    private Color zeroColor = new Color(0, 0, 0, 0);
    private GameObject cube;


    int currentX;
    int currentZ;
    private void Awake()
    {
        if (!Singletone)
        {
            Singletone = this;
        }
        else
        {
            Destroy(gameObject);
        }


    }
    public void StartGame()
    {
        colorBlocks = levelBuilding.StartBuild();
        cameraController.ChangePotition(colorBlocks.GetLength(0), colorBlocks.GetLength(1));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && currentX > 0 && colorBlocks[currentX - 1, currentZ] == zeroColor)
        {
            NewPlace(new Vector3(-1, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.A) && currentX < colorBlocks.GetLength(0) - 1 && colorBlocks[currentX + 1, currentZ] == zeroColor)
        {
            NewPlace(new Vector3(1, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.W) && currentZ > 1 && colorBlocks[currentX, currentZ - 1] == zeroColor)
        {
            NewPlace(new Vector3(0, 0, -1));
        }

        if (Input.GetKeyDown(KeyCode.S) && currentZ < colorBlocks.GetLength(1) - 1 && colorBlocks[currentX, currentZ + 1] == zeroColor)
        {
            NewPlace(new Vector3(0, 0, 1));
        }
    }

    private void NewPlace(Vector3 Direction)
    {
        cube.transform.position = new Vector3(currentX, 0, currentZ) + Direction;

        colorBlocks[currentX + (int)Direction.x, currentZ + (int)Direction.z] = cube.GetComponent<Renderer>().material.color;
        colorBlocks[currentX, currentZ] = zeroColor;

        currentX = (int)cube.transform.position.x;
        currentZ = (int)cube.transform.position.z;

        CheckWin();
    }

    public void CubeForMove(GameObject TempGameObject)
    {
        cube = TempGameObject;

        currentX = (int)cube.transform.position.x;
        currentZ = (int)cube.transform.position.z;
    }

    private void CheckWin()
    {
        bool IsWin = true;
        for (int x = 0; x < colorBlocks.GetLength(0); x++)
        {
            if (x % 2 != 0)
            {
                continue;
            }

            Color MainColor = Color.black;

            for (int z = 0; z < colorBlocks.GetLength(1); z++)
            {
                if (z == 0)
                {
                    MainColor = colorBlocks[x, z];
                    continue;
                }

                if (colorBlocks[x, z] != MainColor)
                {
                    IsWin = false;
                    break;
                }

            }

            if (!IsWin)
            {
                break;
            }
        }

        if (IsWin)
        {
            WinMenu.SetActive(true);
        }
    }
}