using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject redSquare;

    private float maxCounter = 5.0f;
    private float currentCounter = 0.0f;

    private BuildingsSpawnerHandler bsh;

    private void Awake()
    {
        bsh = FindAnyObjectByType<BuildingsSpawnerHandler>();
    }

    private void Update()
    {
        if (bsh.play)
        {
            currentCounter += Time.deltaTime * 5f;
            if (currentCounter > maxCounter)
            {
                GameObject _redSquare = Instantiate(redSquare, new Vector3(transform.position.x, transform.position.y + 1, 0), Quaternion.identity);
                currentCounter = 0.0f;
            }
        }

    }
}
