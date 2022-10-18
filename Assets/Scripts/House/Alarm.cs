using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _changeDegree;
    [SerializeField] private Home _home;

    private int _volumeModifier = -1;

    private void OnEnable()
    {
        _audio.volume = 0;
        _home.Invaded += OnAlarmActivation;
        _home.Left += OnAlarmActivation;
    }

    private void OnDisable()
    {
        _home.Invaded -= OnAlarmActivation;
        _home.Left -= OnAlarmActivation;
    }

    private void OnAlarmActivation()
    {
        ChangeVolumeModifier();
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        float changeStep = 0.1f;
        int maxVolume = 1;

        for (int i = 0; i < maxVolume/changeStep; i++)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, maxVolume, changeStep * _volumeModifier);
            yield return new WaitForSeconds(changeStep);
        }
    }

    private void ChangeVolumeModifier()
    {
        _volumeModifier *= -1;
    }
}
