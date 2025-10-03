using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GridManager gridManager;
    public GameObject[] shapePrefabs; // Assign 3 different prefabs in inspector

    // Predefined spawn positions for the shapes
    private Vector3[] spawnPositions = new Vector3[]
    {
        new Vector3(-6.8f, -2f, 0f),
        new Vector3(-6.8f, 0f, 0f),
        new Vector3(-6.8f, 2f, 0f)
    };

    void Start()
    {
        gridManager.GenerateGrid();

        // Safety check
        int count = Mathf.Min(shapePrefabs.Length, spawnPositions.Length);

        for (int i = 0; i < count; i++)
        {
            if (shapePrefabs[i] != null)
            {
                Instantiate(shapePrefabs[i], spawnPositions[i], Quaternion.identity);
            }
        }
    }

}
