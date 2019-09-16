using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static class TimeFormat
    {
        public static string FormatTime(float time)
        {
            int seconds = (int)time;
            int millis = (int)(1000 * (time % 1));
            return string.Format("{0:00}:{1:00}", seconds, millis);
        }
    }
}
