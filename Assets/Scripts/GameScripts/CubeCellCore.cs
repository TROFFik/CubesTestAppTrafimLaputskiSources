using UnityEngine;

public class CubeCellCore : MonoBehaviour
{
    private Game game;
    private bool canMove;

    private void Start()
    {
        game = Game.Singletone; 
    }
    public bool CanMove
    {
        get{ return canMove; }
        set
        {
            canMove = value;
        }
    }
    public void OnClick()
    {
        if (canMove)
        {
            game.CubeForMove(gameObject);
        }
    }
}
