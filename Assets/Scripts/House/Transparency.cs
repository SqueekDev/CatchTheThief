using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            float hidingPercent = 50;
            ChangeVisibility(hidingPercent);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            float visibilityPercent = 100;
            ChangeVisibility(visibilityPercent);
        }
    }

    private void ChangeVisibility(float percent)
    {
        float maxPercent = 100;
        Color color = _renderer.color;
        color.a = percent / maxPercent;
        _renderer.color = color;
    }
}
