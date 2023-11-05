using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject redSquare;
    [SerializeField] private GameObject blueSquare;
    [SerializeField] private GameObject greenSquare;

    private float maxCounter = 5f;
    private float currentCounter = 0.0f;

    private BuildingsSpawnerHandler bsh;
    public List<GameObject> blocksList = new List<GameObject>();

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
                GameObject _blueSquare = Instantiate(blueSquare, new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity);
                GameObject _greenSquare = Instantiate(greenSquare, new Vector3(transform.position.x, transform.position.y - 1, 0), Quaternion.identity);
                currentCounter = 0.0f;
                blocksList.Add(_redSquare);
                blocksList.Add(_blueSquare);
                blocksList.Add(_greenSquare);
            }
        }

        if (bsh.stop)
        {
            foreach (GameObject _square in blocksList)
            {
                Destroy(_square);
                blocksList = new List<GameObject>();
            }
        }

    }
}
