using UnityEngine;
public class TimedDestroyer : MonoBehaviour
{
    public float countDownLength = 100;
    private float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= countDownLength)
        {
            Destroy(gameObject);
        }
    }
}
