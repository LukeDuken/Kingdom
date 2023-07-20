using System; //allows us to work with any type of time intervals
using System.Collections;
using UnityEngine;

namespace WorldTime
{
    public class WorldTime
    : MonoBehaviour
    {
        //to notify another script that the time has changed
        public event EventHandler<TimeSpan> WorldTimeChanged;
        public int startTime = 0;

        [SerializeField]
        private float _dayLenght; //how long the day is in second

        private TimeSpan _currentTime;
        private float _minuteLenght => _dayLenght / WorldTimeConstant.MinutesInDay;

        private void Start()
        {
            //when the day night cycle start
            _currentTime += TimeSpan.FromMinutes(startTime);
            WorldTimeChanged?.Invoke(this, _currentTime);
            StartCoroutine(AddMinute()); //Start coroutine
        }

        private IEnumerator AddMinute()
        {
            _currentTime += TimeSpan.FromMinutes(1);
            WorldTimeChanged?.Invoke(this, _currentTime);
            yield return new WaitForSeconds(_minuteLenght);
            StartCoroutine(AddMinute());//infinite loop 
        }
    }
}
