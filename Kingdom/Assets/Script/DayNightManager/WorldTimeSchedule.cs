using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace WorldTime
{
    public class WorldTimeSchedule : MonoBehaviour
    {
        [SerializeField]
        private WorldTime _worldTime;

        [SerializeField] 
        private List<Schedule> _schedule;

        private void Start()
        {
            _worldTime.WorldTimeChanged += CheckSchedule;
        }

        private void OnDestroy() //because we subscribe to the event we need to unsubscribe once is done
        {
            _worldTime.WorldTimeChanged -= CheckSchedule;
        }
        private void CheckSchedule(object sender, TimeSpan newTime)
        {
            var schedule = 
                _schedule.FirstOrDefault(Schedule =>
                    Schedule.Hour == newTime.Hours &&
                    Schedule.Minute == newTime.Minutes);

            schedule?._action?.Invoke();
        }

        [Serializable]
        private class Schedule
        {
            public int Hour;
            public int Minute;
            public UnityEvent _action;
        }
      
    }
}
