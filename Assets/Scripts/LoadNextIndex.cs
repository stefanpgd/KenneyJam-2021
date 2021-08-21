using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextIndex : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
