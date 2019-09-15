using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public delegate void OnResetGameDelegate();
    public static event OnResetGameDelegate resetGameDelegate;
    public static GameManager Instance { get; private set; }

    [SerializeField] private Canvas MenuCanvas;
    [SerializeField] private Canvas GameCanvas;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI button;

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
        Time.timeScale = 1;
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        MenuCanvas.enabled = true;
        title.text = Stopwatch.Instance.Count.ToString("F2");
        button.text = "Restart";
    }

    public void Reset()
    {
        resetGameDelegate?.Invoke();
        Resume();
    }
}
