using UnityEngine;

public class Depot : MonoBehaviour
{
    private Spawner spawner;

    [Header("Win Condition")]
    [SerializeField] private int maxManufactureToWin = 5;
    private int currentManufacture = 0;
    private bool win = false;

    private void Awake()
    {
        spawner = FindAnyObjectByType<Spawner>();
    }
    private void Update()
    {
        if (currentManufacture >= maxManufactureToWin && !win)
        {
            print("Win");
            win = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Manufactured"))
        {
            spawner.blocksList.Remove(collision.gameObject);
            Destroy(collision.gameObject);

            currentManufacture++;
        }
        else
        {
            print("not the good sort of box");
            Destroy(collision.gameObject);
            spawner.blocksList.Remove(collision.gameObject);
        }
    }
}
