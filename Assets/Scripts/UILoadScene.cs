using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SilverRogue.Tools;

public class UILoadScene : MonoBehaviour
{
    [SerializeField] private Animator cameraAnimator;
    [SerializeField] private Button button;

    private Timer glitchDelay;

    private void Start()
    {
        button.onClick.AddListener(StartGlitch);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(StartGlitch);
    }

    private void StartGlitch()
    {
        glitchDelay = new Timer(1f);
        cameraAnimator.SetTrigger("LoadOut");
        glitchDelay.timerExpiredEvent += LoadScene;
    }    

    private void LoadScene()
    {
        SceneManager.LoadScene("Level 1");
    }
}
