using UnityEngine;

public class TweenScale : MonoBehaviour
{
    public float targetScale; 
    public float timeToReachTarget;
    private float startScale; 
    private float percentScaled; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (percentScaled < 1f) // 1
        {
            percentScaled += Time.deltaTime / timeToReachTarget; // 2
            float scale = Mathf.Lerp(startScale, targetScale, percentScaled); // 3
            transform.localScale = new Vector3(scale, scale, scale); // 4
        }
    }
}
