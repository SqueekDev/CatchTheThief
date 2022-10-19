using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Home _home;

    private void OnEnable()
    {
        _home.Invaded += OnHomeInvaded;
    }

    private void OnDisable()
    {
        _home.Invaded -= OnHomeInvaded;
    }

    private void OnHomeInvaded(bool invided)
    {
        float hidingPercent = 50;
        float visibilityPercent = 100;

        if (invided)
        {
            ChangeVisibility(hidingPercent);
        }
        else
        {
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
