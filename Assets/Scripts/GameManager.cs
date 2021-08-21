using UnityEngine;
using UnityEngine.SceneManagement;
using SilverRogue.Tools;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeForNextLevelFinish;
    [SerializeField] private float timeForLevelRestartCrash;
    [SerializeField] private float LoadOutDuration = 1f;
    [SerializeField] private Animator cameraEffect;
    [SerializeField] private Animator outOfBoostAnimator;

    [SerializeField] private List<AudioClip> crashClips;
    [SerializeField] private AudioSource audioSource;

    private Timer nextLevelTimer;
    private Timer restartLevel;
    private Timer reloadLevel;
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
        cameraEffect.SetTrigger("LoadIn");
    }

    public void ShipReachedStation()
    {
        // TODO: Wait X time before loading next level
        nextLevelTimer = new Timer(timeForNextLevelFinish);
        nextLevelTimer.timerExpiredEvent += LoadNextLevel;
    }

    public void ShipCrashed()
    {
        int randomClip = Random.Range(0, crashClips.Count);
        audioSource.clip = crashClips[randomClip];
        audioSource.Play();

        restartLevel = new Timer(timeForLevelRestartCrash);
        restartLevel.timerExpiredEvent += Restart;
    }

    public void ShipLostInSpace() 
    {
        // TODO: replace with restart prompt, "Flew into nothingness of space" 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShipStranded() // out of boosts
    {
        outOfBoostAnimator.SetTrigger("NotifyPlayer");
    }

    private void LoadNextLevel()
    {
        cameraEffect.SetTrigger("LoadOut");
        nextLevelTimer = new Timer(LoadOutDuration);
        nextLevelTimer.timerExpiredEvent += LoadLevel;
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Restart()
    {
        cameraEffect.SetTrigger("LoadOut");
        reloadLevel = new Timer(LoadOutDuration);
        reloadLevel.timerExpiredEvent += RestartLevel;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
