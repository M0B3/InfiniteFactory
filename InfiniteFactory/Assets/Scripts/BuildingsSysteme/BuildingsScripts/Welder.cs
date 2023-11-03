using UnityEngine;

public class Welder : MonoBehaviour
{
    [SerializeField] private GameObject firstManufacturedBlock;
    [SerializeField] private GameObject ManufacturedBlock;
    [SerializeField] private LayerMask blockLayer;
    [SerializeField] private LayerMask firstManufacturedLayer;
    [SerializeField] private Transform outPosition;

    private Spawner spawner;

    private void Awake()
    {
        spawner = FindAnyObjectByType<Spawner>();
    }

    private void Update()
    {
        //Raycast to get the current block
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, -transform.right, 0.25f, blockLayer);
        RaycastHit2D[] manufacturedHit = Physics2D.RaycastAll(transform.position, -transform.right, 0.25f, firstManufacturedLayer);

        //normal block
        if (hit.Length == 2)
        {
            foreach (RaycastHit2D ray in hit)
            {
                spawner.blocksList.Remove(ray.collider.gameObject);
                Destroy(ray.collider.gameObject);

            }
            GameObject first = Instantiate(firstManufacturedBlock, outPosition.position, Quaternion.identity);
            spawner.blocksList.Add(first);
        }
        //first manufactured block
        if (manufacturedHit.Length == 2)
        {
            foreach (RaycastHit2D ray in manufacturedHit)
            {
                spawner.blocksList.Remove(ray.collider.gameObject);
                Destroy(ray.collider.gameObject);

            }
            GameObject end = Instantiate(ManufacturedBlock, outPosition.position, Quaternion.identity);
            spawner.blocksList.Add(end);
        }
    }
}
