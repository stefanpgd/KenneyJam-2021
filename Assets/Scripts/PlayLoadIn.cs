using UnityEngine;

public class PlayLoadIn : MonoBehaviour
{
    [SerializeField] private Animator cameraAnim;

    private void Start()
    {
        cameraAnim.SetTrigger("LoadIn");
    }
}
