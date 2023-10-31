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
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        
    }
}
