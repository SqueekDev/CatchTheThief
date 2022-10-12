using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _changeDegree;
    
    private int _volumeModifier = -1;

    private void Awake()
    {
        _audio.volume = 0;
    }

    private void Update()
    {
        float maxVolumeLevel = 1;
        _audio.volume = Mathf.MoveTowards(_audio.volume, maxVolumeLevel, _changeDegree * _volumeModifier * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief> (out Thief thief))
        {
            ChangeVolumeModifier();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            ChangeVolumeModifier();
        }
    }

    private void ChangeVolumeModifier()
    {
        _volumeModifier *= -1;
    }
}
