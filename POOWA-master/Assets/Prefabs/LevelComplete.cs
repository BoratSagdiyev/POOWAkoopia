using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

    

    public void LoadNextLevel()
    {
        int lastLevel = 12;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex + 1 > lastLevel)
        {
            
            // Load the menu
            SceneManager.LoadScene(0);
        }
        else
        {
            
            SceneManager.LoadScene(currentSceneIndex + 1);
            
        }
    }

    

}
