using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] private Color _baseColor;
    [SerializeField] private Color _offsetColor;
    [Header("Assignables")]
    [SerializeField] private GameObject _highlight;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void Init(bool isOffset)
    {
        //Change color
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
    