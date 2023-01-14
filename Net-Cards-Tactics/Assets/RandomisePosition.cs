using UnityEngine;

public class RandomisePosition : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
}
