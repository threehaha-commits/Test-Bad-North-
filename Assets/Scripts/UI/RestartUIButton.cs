using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartUIButton : MonoBehaviour
{
    public void Restart()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}