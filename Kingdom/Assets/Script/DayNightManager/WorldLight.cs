using UnityEngine.Rendering.Universal;
using UnityEngine;
using WorldTime;
using System;

namespace WorldTime
{
    [RequireComponent(typeof (Light2D))]
    public class WorldLight : MonoBehaviour
    {
        private Light2D _light;

        [SerializeField]
        private WorldTime _worldTime;

        [SerializeField]
        private Gradient _gradient;

        private void Awake()
        {
            _light = GetComponent<Light2D>();

            _worldTime.WorldTimeChanged += OnWorldTimeChanged;
        }

        //because we subscribe to the event we need to unsubscribe once is done
        private void OnDestroy()
        {
            _worldTime.WorldTimeChanged -= OnWorldTimeChanged;
        }

        //Update light color according to the point of the day
        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            _light.color = _gradient.Evaluate(PercentOfDay(newTime));
        }

        //Convert the time of the day in a % from 0 to 1
        private float PercentOfDay(TimeSpan timeSpan)
        {
            return (float)timeSpan.TotalMinutes % WorldTimeConstant.MinutesInDay / WorldTimeConstant.MinutesInDay;
        }

    }
}
