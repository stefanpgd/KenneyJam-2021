using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    public void ShipCrashed()
    {
        // TODO: replace with restart prompt, "Crashed" 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShipLostInSpace() 
    {
        // TODO: replace with restart prompt, "Flew into nothingness of space" 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShipStranded() // out of boosts
    {
        // TODO: replace with restart prompt "cant travel, out of boosts" with timer for delay
        Debug.LogError("OUT OF BOOSTS");    
    }

    public void LoadNextLevel()
    {

    }
}
