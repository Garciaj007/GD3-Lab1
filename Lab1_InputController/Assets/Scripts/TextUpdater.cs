using UnityEngine;
using UnityEngine.UI;
public class TextUpdater : MonoBehaviour
{
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = Utils.TimeFormat.FormatTime(Stopwatch.Instance.Count);
    }
}
