using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void QUIT()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void LoadTestLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
