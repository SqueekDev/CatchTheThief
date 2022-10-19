using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _changeDegree;
    [SerializeField] private Home _home;

    private Coroutine _volumeChange;

    private void OnEnable()
    {
        _audio.volume = 0;
        _home.Invaded += OnHomeInvaded;
    }

    private void OnDisable()
    {
        _home.Invaded -= OnHomeInvaded;
    }

    private void OnHomeInvaded(bool invaded)
    {
        if (_volumeChange != null)
        {
            StopCoroutine(_volumeChange);
        }

        int minVolumeLevel = 0;
        int maxVolumeLevel = 1;

        if (invaded)
        {
            _volumeChange = StartCoroutine(ChangeVolumeLevel(maxVolumeLevel));
        }
        else
        {
            _volumeChange = StartCoroutine(ChangeVolumeLevel(minVolumeLevel));
        }
    }

    private IEnumerator ChangeVolumeLevel(float target)
    {
        float changeStep = 0.1f;
        WaitForSeconds delay = new WaitForSeconds(changeStep);

        while (_audio.volume != target)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, target, changeStep);
            yield return delay;
        }
    }
}
