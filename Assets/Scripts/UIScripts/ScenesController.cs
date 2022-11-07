using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesController : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
