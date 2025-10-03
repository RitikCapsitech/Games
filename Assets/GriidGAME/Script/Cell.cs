using UnityEngine;

public class Cell : MonoBehaviour
{
    private GameObject placedShape = null;

    // True if this cell already contains a placed shape
    public bool IsFilled => placedShape != null;

    // Place a shape GameObject into the cell (expects a cloned GameObject)
    public void PlaceShape(GameObject shape)
    {
        if (placedShape != null || shape == null) return;

        placedShape = shape;

        placedShape.transform.SetParent(transform);
        placedShape.transform.localPosition = Vector3.zero;
        placedShape.transform.localRotation = Quaternion.identity;

        // disable collider so it doesn't block future placement
        var col = placedShape.GetComponent<Collider2D>();
        if (col != null) col.enabled = false;
    }

    // Clear the placed shape (used by Reset)
    public void Clear()
    {
        if (placedShape != null)
        {
            Destroy(placedShape);
            placedShape = null;
        }
    }
}
