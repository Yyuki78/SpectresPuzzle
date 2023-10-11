using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSpectres : MonoBehaviour
{
    public int SpectresID = 0;

    private bool isPlus = false;
    private Color colorValue = new Color(0, 0, 0, 0.003f);
    private Color firstColor;

    private SpriteRenderer _spriteRenderer;
    private PolygonCollider2D _polygonCollider;

    private bool isHit = false;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;
        firstColor = _spriteRenderer.color;
        _polygonCollider = GetComponent<PolygonCollider2D>();
        _polygonCollider.enabled = false;
    }

    private void Update()
    {
        if (isHit) return;
        if (_spriteRenderer.color.a > 0.95f)
            isPlus = false;
        if (_spriteRenderer.color.a < 0.15f)
            isPlus = true;

        if (isPlus)
            _spriteRenderer.color += colorValue;
        else
            _spriteRenderer.color -= colorValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHit) return;
        if (collision.gameObject.tag == "Spectres")
        {
            isHit = true;
            gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (!_spriteRenderer.enabled) return;
        GetComponentInParent<SpectresManager>().GenerareSpectres(transform.position);
    }

    public void ShowNext()
    {
        if (isHit) return;
        _spriteRenderer.enabled = true;
        _polygonCollider.enabled = true;
    }

    public void HideSprite()
    {
        if (!_spriteRenderer.enabled) return;
        _spriteRenderer.enabled = false;
        _spriteRenderer.color = firstColor;
        _polygonCollider.enabled = false;
    }
}
