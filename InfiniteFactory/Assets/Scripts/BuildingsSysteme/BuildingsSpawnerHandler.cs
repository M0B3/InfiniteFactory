using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingsSpawnerHandler : MonoBehaviour
{
    public static BuildingsSpawnerHandler Instance;

    [Header("Buildings Prefabs")]
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject conveyorBeltPrefab;
    [SerializeField] private GameObject welderPrefab;
    [Header("Assignables")]
    [SerializeField] private GameObject mousePosition;
    [SerializeField] private Vector2 spawnerPos;

    private Camera cam;
    private Vector3 mousePos;

    //Current Object
    private Collider2D currentCollider;
    private ConveyorBelt conveyorBelt;
    private Welder welder;
    public GameObject currentTile;

    private GridGenerator gridGenerator;

    public bool play = false;
    public bool stop = false;

    private void Awake()
    {
        Instance = this;
        cam = Camera.main;

        gridGenerator = FindAnyObjectByType<GridGenerator>();
    }
    private void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        //Have a empty gameObject child of the mouse position
        mousePosition.transform.position = mousePos;

    }

    public void SpawnConvoyerBelt()
    {
        if (currentCollider == null && !play)
        {
            GameObject buildingsClone = Instantiate(conveyorBeltPrefab, mousePos, Quaternion.identity);
            buildingsClone.transform.parent = mousePosition.transform;

            //Dissable collider to avoid on mouse over glitch
            currentCollider = buildingsClone.GetComponent<Collider2D>();
            currentCollider.enabled = false;

            conveyorBelt = buildingsClone.GetComponent<ConveyorBelt>();
        }
    }
    public void SpawnWelder()
    {
        if (currentCollider == null && play)
        {
            GameObject buildingsClone = Instantiate(welderPrefab, mousePos, Quaternion.identity);
            buildingsClone.transform.parent = mousePosition.transform;

            //Disable collider to avoid on mouse over glitch
            currentCollider = buildingsClone.GetComponent<Collider2D>();
            currentCollider.enabled = false;

            welder = buildingsClone.GetComponent<Welder>();
        }
    }

    //-INPUTS---//
    public void OnSelect(InputAction.CallbackContext ctx)
    {
        //Select a building that are already placed
        if (ctx.performed && currentCollider == null && !play)
        {
            var rayHit = Physics2D.GetRayIntersection(cam.ScreenPointToRay(Mouse.current.position.ReadValue()));
            if (!rayHit.collider) return;

            if (rayHit.collider.CompareTag("Buildings"))
            {
                rayHit.collider.transform.parent = mousePosition.transform;
                rayHit.collider.enabled = false;
                currentCollider = rayHit.collider;

                conveyorBelt = rayHit.collider.GetComponent<ConveyorBelt>();
                welder = rayHit.collider.GetComponent<Welder>();
            }
        }

        //Place ConveyorBelt
        if (ctx.performed && currentCollider != null && currentTile != null && conveyorBelt != null)
        {
            currentCollider.transform.parent = currentTile.transform;

            Vector3 realPos = currentTile.transform.localPosition;
            currentCollider.transform.position = new Vector3(realPos.x, realPos.y, -0.1f);

            //Unselect current building
            currentCollider.enabled = true;
            currentCollider = null;

            conveyorBelt = null;
        }
        //Place Welder
        if (ctx.performed && currentCollider != null && currentTile != null && welder != null)
        {
            currentCollider.transform.parent = currentTile.transform;

            Vector3 realPos = currentTile.transform.localPosition;
            currentCollider.transform.position = realPos;

            //Unselect current building
            currentCollider.enabled = true;
            currentCollider = null;

            welder = null;
        }


    }

    public void OnDestroySelectedBuilding(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && currentCollider == null && !play)
        {
            var rayHit = Physics2D.GetRayIntersection(cam.ScreenPointToRay(Mouse.current.position.ReadValue()));
            if (!rayHit.collider) return;

            if (rayHit.collider.CompareTag("Buildings"))
            {
                Destroy(rayHit.collider.gameObject);

            }
        }
    }

    public void RotateCurrentBuilding(InputAction.CallbackContext ctx)
    {
        if (currentCollider != null && ctx.performed)
        {
            currentCollider.transform.Rotate(0, 0, -90);
        }
    }
    public void Play()
    {
        play = true;
        stop = false;
    }
    public void Stop()
    {
        stop = true;
        play = false;
    }
    //---------//

    public void SpawnSpawner()
    {
        var _getTile = gridGenerator.GetTileAtPosition(spawnerPos);
        var spawnSpawner = Instantiate(spawner, spawnerPos, Quaternion.identity);

        spawnSpawner.transform.parent = _getTile.transform;
    }
}
