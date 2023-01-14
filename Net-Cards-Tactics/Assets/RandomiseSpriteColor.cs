using UnityEngine;

public class RandomiseSpriteColor : MonoBehaviour
{
    private void Start()
    {
        GetComponentInParent<SpriteRenderer>().color = Random.ColorHSV();
    }
}
