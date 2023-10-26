using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class BuildingsSpawnerHandler : MonoBehaviour
{
    [Header("Buildings Prefabs")]
    [SerializeField] private GameObject prefabBuildingsTest;
    [SerializeField] private GameObject mousePosition;

    private Camera cam;
    private Vector3 mousePos;

    private Collider2D currentCollider;
    private GameObject currentTile;

    private void Awake()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        mousePosition.transform.position = mousePos;
    }

    public void SpawnBuilding()
    {
        GameObject buildingsClone = Instantiate(prefabBuildingsTest, mousePos, Quaternion.identity);
        buildingsClone.transform.parent = mousePosition.transform;

        //Dissable collider to avoid on mouse over glitch
        currentCollider = buildingsClone.GetComponent<Collider2D>();
        currentCollider.enabled = false;
    }

    //-INPUTS---//
    public void OnSelect(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && currentCollider != null)
        {
            // currentCollider.transform.parent = tile.transform.position
            currentCollider.enabled = true;
        }
    }
}
