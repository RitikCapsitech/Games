using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject triangle;
    [SerializeField] private GameObject circle;
    [SerializeField] private GameObject capsule;

    [SerializeField] private float spawnInterval = 1.5f; // spawn every 1 second
    [SerializeField] private float spawnY = 6f;        // height to spawn from
    [SerializeField] private float minX = -6f, maxX = 6f; // random X range
   
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRandomShape();
            timer = 0f;
        }


    }
    public void DecreaseSpawnInterval()
    {
        spawnInterval = Mathf.Max(0.3f, spawnInterval - 0.3f);
        // minimum 0.3 seconds so it doesn’t get too fast
    }
    void SpawnRandomShape()
    {
        int choice = Random.Range(0, 3); // pick 0,1,2
        GameObject prefab = null;
        switch (choice)
        {
            case 0: prefab = triangle; break;
            case 1: prefab = circle; break;
            case 2: prefab = capsule; break;
        }

        Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), spawnY, 0);
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }

    
}
