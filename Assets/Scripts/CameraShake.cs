using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 startPosition;

    #region Singleton
    public static CameraShake Instance;
    private void Awake() => Instance = this;
    #endregion

    private void Start()
    {
        startPosition = transform.localPosition;
    }

    public void ScreenShake(float duration, float magnitude)
    {
        StartCoroutine(ApplyScreenShake(duration, magnitude));
    }

    private IEnumerator ApplyScreenShake(float duration, float magnitude)
    {
        float m_Elapsed = 0f;

        while(m_Elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = startPosition + new Vector3(x, y, 0);

            m_Elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = startPosition;
    }
}
