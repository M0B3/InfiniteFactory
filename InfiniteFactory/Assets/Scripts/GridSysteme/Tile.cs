using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] private Color _baseColor;
    [SerializeField] private Color _offsetColor;
    [Header("Assignables")]
    [SerializeField] private GameObject _highlight;
    private SpriteRenderer _renderer;
    private BuildingsSpawnerHandler _spawnerHandler;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _spawnerHandler = FindAnyObjectByType<BuildingsSpawnerHandler>();
    }

    public void Init(bool isOffset)
    {
        //Change color
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);

        _spawnerHandler.currentTile = this.gameObject;
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);

        _spawnerHandler.currentTile = null;
    }
}
    