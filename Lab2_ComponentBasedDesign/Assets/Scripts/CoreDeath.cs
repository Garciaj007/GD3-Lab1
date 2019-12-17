using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreDeath : MonoBehaviour
{
    [SerializeField] GameObject blackOverlay = null;

    private Utils.Timer gameoverTimer = new Utils.Timer(4.0f, false);
    public void Start() => GetComponent<HealthComponent>().DeathDelegate += OnCoreDeath;
    public void Update() => gameoverTimer.Update();
    public void ShowBlack() => blackOverlay.SetActive(true);
    public void ResetScene() => SceneManager.LoadScene(0);
    public void OnCoreDeath()
    {
        gameoverTimer.TimerFinished += ResetScene;
        gameoverTimer.Start();
        ShowBlack();
    }
}
