using UnityEngine;

public class Depot : MonoBehaviour
{
    private Spawner spawner;
    private BuildingsSpawnerHandler bsh;

    [Header("Win Condition")]
    [SerializeField] private int maxManufactureToWin = 5;
    private int currentManufacture = 0;
    private bool win = false;

    private void Awake()
    {
        bsh = FindAnyObjectByType<BuildingsSpawnerHandler>();
        spawner = FindAnyObjectByType<Spawner>();
        bsh.winMenu.SetActive(false);
    }
    private void Update()
    {
        if (currentManufacture >= maxManufactureToWin && !win)
        {
            bsh.winMenu.SetActive(true);
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
            Destroy(collision.gameObject);
            spawner.blocksList.Remove(collision.gameObject);
        }
    }

}
