
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public float Movespeedclouds = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * Movespeedclouds)*Time.deltaTime;
    }
}
