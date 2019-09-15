using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public delegate void OnResetGameDelegate();
    public static event OnResetGameDelegate resetGameDelegate;
    public static GameManager Instance { get; private set; }

    [SerializeField] private Canvas MenuCanvas = null;
    [SerializeField] private Canvas GameCanvas = null;
    [SerializeField] private TextMeshProUGUI title = null;
    [SerializeField] private TextMeshProUGUI button = null;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    void Start()
    {
        BlockCollisionDetect.blockCollisionDelegate += GameOver;
        GameCanvas.enabled = false;
        Time.timeScale = 0;
    }

    public void PlayButtonPressed(GameObject btn)
    {
        if (btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Start")
            Resume();
        else
            Reset();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        MenuCanvas.enabled = true;
    }

    public void Resume()
    {
        MenuCanvas.enabled = false;
        GameCanvas.enabled = true;
        Time.timeScale = 1;
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        MenuCanvas.enabled = true;
        GameCanvas.enabled = false;
        title.text = Utils.TimeFormat.FormatTime(Stopwatch.Instance.Count);
        button.text = "Restart";
    }

    public void Reset()
    {
        resetGameDelegate?.Invoke();
        Resume();
    }
}
