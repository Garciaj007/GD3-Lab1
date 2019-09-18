using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public delegate void OnResetGameDelegate();
    public static event OnResetGameDelegate resetGameDelegate;
    public static GameManager Instance { get; private set; }

    [SerializeField] private Canvas MenuCanvas = null;
    [SerializeField] private Canvas GameCanvas = null;
    [SerializeField] private Text timer = null; 
    [SerializeField] private Text title = null;
    [SerializeField] private Text button = null;

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
        if (btn.transform.GetChild(0).GetComponent<Text>().text == "Start")
            Resume();
        else
            Reset();
    }

    public void Resume()
    {
        Cursor.visible = false;
        MenuCanvas.enabled = false;
        GameCanvas.enabled = true;
        Time.timeScale = 1;
    }

    private void GameOver()
    {
        Cursor.visible = true;
        Time.timeScale = 0;
        MenuCanvas.enabled = true;
        GameCanvas.enabled = false;
        title.text = timer.text;
        button.text = "Restart";
    }

    public void Reset()
    {
        resetGameDelegate?.Invoke();
        Resume();
    }
}
