
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 offset;
    private Vector3 spawnStartPos;

    private void Start()
    {
        spawnStartPos = transform.position;
    }

    public void OnMouseDown()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - mousePos;
        GetComponent<Collider2D>().enabled = false;
    }

    public void OnMouseDrag()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, 0);
    }

    public void OnMouseUp()
    {
        // ⚠️ KEEP COLLIDER DISABLED during raycast
        // Cast a ray from current shape position to find cell underneath
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0.1f);

        Debug.Log($"Raycast hit: {hit.collider?.name}");

        if (hit.collider != null && hit.collider.name.Contains("Cell"))
        {
            Cell cell = hit.collider.GetComponent<Cell>();

            Debug.Log($"Cell found: {cell != null}, IsFilled: {cell?.IsFilled}");

            if (cell != null && !cell.IsFilled)
            {
                Debug.Log("Creating clone!");

                // Create clone at cell position
                GameObject clone = Instantiate(gameObject, cell.transform.position, Quaternion.identity);

                // Disable drag on clone
                Destroy(clone.GetComponent<DragDrop>());

                // Place in cell
                cell.PlaceShape(clone);
            }
        }

        //  Re-enable collider AFTER raycast
        GetComponent<Collider2D>().enabled = true;

        // Always return original to spawn
        transform.position = spawnStartPos;
    }
}