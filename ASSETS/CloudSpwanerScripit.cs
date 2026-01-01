using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    public GameObject clouds;
    public float spawncloudrate;
    private float timer1 = 0;

    void Start()
    {
        // ✔️ You can call it here
        Spawntheclouds();
    }

    void Update()
    {
        if (timer1 < spawncloudrate)
        {
            timer1 += Time.deltaTime;
        }
        else
        {
            // ✔️ And you can call it here too
            Spawntheclouds();
            timer1 = 0;
        }
    }

    // ❗ Defined once, outside Start/Update
    void Spawntheclouds()
    {
        Instantiate(clouds, transform.position, transform.rotation);
    }
}
