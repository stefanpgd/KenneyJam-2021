using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float scaleModifier;
    [SerializeField] private float randomRotationSpeed;
    [SerializeField] private float offsetRotationSpeed;

    private float rotationSpeed;
    private float angle;
    private bool turnLeft;

    private void Start()
    {
        if(scaleModifier != 0)
        {
            float scaleOffset = Random.Range(-scaleModifier, scaleModifier);
            transform.localScale = transform.localScale * (1 + scaleOffset);
        }
       
        rotationSpeed = Random.Range(randomRotationSpeed - offsetRotationSpeed, randomRotationSpeed + offsetRotationSpeed);
        angle = Random.Range(-180f, 180f);

        int roll = Random.Range(0, 10);
        if(roll > 5)
        {
            turnLeft = true;
        }
    }

    private void Update()
    {
        if(turnLeft)
        {
            angle -= rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
        else
        {
            angle += rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
