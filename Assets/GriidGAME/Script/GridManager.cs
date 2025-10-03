using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Grid Settings")]
    public GameObject cellPrefab;   // assign your Cell prefab here
    public int gridSize = 2;        // starting size (2x2)
    public float cellSpacing = 2f;  // distance between cells

    private GameObject[,] gridCells;

    public void GenerateGrid()
    {
        // 🔹 Clear old grid first
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        gridCells = new GameObject[gridSize, gridSize];

        // 🔹 Calculate offset so grid is centered at (0,0)
        float offset = (gridSize - 1) * cellSpacing / 2f;

        // 🔹 Generate grid
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector2 pos = new Vector2(x * cellSpacing - offset, y * cellSpacing - offset);
                GameObject cell = Instantiate(cellPrefab, pos, Quaternion.identity, transform);
                cell.name = $"Cell_{x}_{y}";

                gridCells[x, y] = cell;
            }
        }
    }

    // 🔹 Check if all cells are filled
    public bool IsGridFull()
    {
        foreach (GameObject cellObj in gridCells)
        {
            Cell cell = cellObj.GetComponent<Cell>();
            if (cell != null && !cell.IsFilled)
                return false;
        }
        return true;
    }
}
