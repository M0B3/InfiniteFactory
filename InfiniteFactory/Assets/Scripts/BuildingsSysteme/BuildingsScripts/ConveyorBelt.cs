using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public bool isPlaced = false;

    private Vector3 startPos;
    private Vector3 direction;
    private float distance = 1.0f;

    private void Update()
    {
        startPos = transform.position;
        direction = transform.up;

        Debug.DrawRay(startPos, direction * distance, Color.red);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb2d = collision.GetComponent<Rigidbody2D>();
        rb2d.AddForce(new Vector3(direction.x, direction.y, 0), ForceMode2D.Impulse);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = startPos;
    }
}
