using UnityEngine;

namespace Utils
{
    public static class TimeFormat
    {
        public static string FormatTime(float time)
        {
            var minutes = (int)time / 60;
            var seconds = (int)time - 60 * minutes;
            var millis = (int)(1000 * (time - minutes * 60 - seconds));
            return $"{minutes:00}:{seconds:00}:{millis:00}";
        }
    }

    public static class Rigidbody2D
    {
        public static float Heading(Vector3 velocity)
        {
            return Vector3.Dot(Vector3.forward, velocity);
        }
    }

    public static class Mathf
    {
        public static float Map(float value, float inMin, float inMax, float outMin, float outMax)
        {
            return (value - inMin) / (inMax - inMin) * (outMax - outMin) + outMin;
        }
    }

    public class Timer
    {
        public delegate void OnTimerFinishedDelegate();
        public event OnTimerFinishedDelegate TimerFinished;

        private float startTime;
        private readonly float duration;
        private bool hasStarted = false;
        private bool isActive = false;
        private bool isRepeatitive;

        public Timer(float duration, bool isRepeatitive = true)
        {
            this.duration = duration;
            this.isRepeatitive = isRepeatitive;
        }

        public void Update()
        {
            if (!isActive) return;

            if (Time.time >= startTime + duration)
            {
                TimerFinished?.Invoke();
                if (!isRepeatitive) Stop();
                Reset();
            }
        }

        public void Start() { isActive = true; if (!hasStarted) { Reset(); hasStarted = true; } }
        public void Stop() { isActive = false; hasStarted = false; }
        public void Reset() => startTime = Time.time;
    }

    public class ScreenSize
    {
        /// <summary>
        /// Returns Dimesions of Sprite to fit Orthographic Camera Size
        /// </summary>
        /// <param name="width">Sprite Bounds X / 1/2 Sprite Width</param>
        /// <param name="height">Sprite Bounds Y / 1/2 Sprite Height</param>
        /// <param name="cam">OrthoGraphic Camera</param>
        /// <returns></returns>
        public static Vector2 GetScreenToWorld(float width, float height, Camera cam)
        {
            var worldScreenHeight = cam.orthographicSize;
            var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
            return new Vector2(worldScreenWidth / width, worldScreenHeight / height);
        }
    }
}
public static class VectorExtensions
{
    public static Vector2 XY(this Vector3 v)
    { return new Vector2(v.x, v.y); }
}
