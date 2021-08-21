using UnityEngine;
using UnityEngine.SceneManagement;
using SilverRogue.Tools;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeForNextLevelLoad;

    private Timer nextLevelTimer;
    private ShipMovement shipMovement;

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

    private void Start()
    {
        shipMovement = ShipMovement.Instance;
    }

    public void ShipReachedStation()
    {
        // TODO: Wait X time before loading next level
        nextLevelTimer = new Timer(timeForNextLevelLoad);
        nextLevelTimer.timerExpiredEvent += LoadNextLevel;
    }

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
