using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void ChangePotition(int X, int Z)
    {
        transform.position = new Vector3(X/2, 13, Z/2);
    }

}
