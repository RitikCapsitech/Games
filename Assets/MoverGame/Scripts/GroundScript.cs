using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private float speed = 24f;
  
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Gets input from left/right arrow or A/D keys
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        float clampedX = Mathf.Clamp(transform.position.x, -7.5f, 7.5f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

    }
}
