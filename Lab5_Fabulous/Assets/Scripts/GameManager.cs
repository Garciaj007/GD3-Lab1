using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PostProcessProfile profile = null;
    [SerializeField] private ParticleSystem system;
    [Header("UI Components")]
    [SerializeField] private Text tipsText = null;
    [SerializeField] private Text likesText = null;
    [SerializeField] private Slider entityHealthSlider = null;
    [SerializeField] private Text entityNameText = null;
    [SerializeField] private GameObject resultsPanel = null;
    [SerializeField] private Text nightCountText = null;
    [SerializeField] private Text totalText = null;
    [SerializeField] private Text nLikesText = null;
    [Space]
    [Header("Values")]
    [SerializeField] private float baseFee = 10.0f;
    //[SerializeField] private float tipsOverTimeMultiplier = 0.0f;
    [SerializeField] private float likesOverTimeMultiplier = 0.0f;
    [SerializeField] private float likesAmountPerClick = 1.0f;
    [SerializeField] private float tipsAmountPerClick = 0.01f;
    [SerializeField] private float difficultyIncrementPerClick = 0.01f;
    [Header("Entities")]
    [SerializeField] private List<GameObject> entitiesList = new List<GameObject>();
    [SerializeField] private List<GameObject> powerUpsList = new List<GameObject>();

    private HighImageShader high = null;
    private DrunkImageShader drunk = null;

    private Utils.Timer secondsTimer = new Utils.Timer(1.0f);
    private Utils.Timer nightScreenTimer = new Utils.Timer(4.0f, false);

    private float likesMultiplier = 1.0f;
    private float drunkMultiplier = 1.0f;
    private float highMultiplier = 1.0f;
    private float IncapacitatedMultiplier = 1.0f;

    private float tips = 0.0f;
    private int likes = 0;
    private int entityIndex = 0;
    private int nightIndex = 0;

    private void ResetValues()
    {
        likesMultiplier = 1.0f;
        drunkMultiplier = 1.0f;
        highMultiplier = 1.0f;
        IncapacitatedMultiplier = 1.0f;

        tips = 0.0f;
        entityIndex = 0;

        high.power.value = 0;
        high.intensity.value = 0;
        drunk.power.value = 0;
    }

    public static GameManager I { get; private set; }
    public float Difficulty { get; private set; } = 1.0f;
    public float Damage { get; private set; } = 1.0f;

    private void Awake()
    {
        if (I != null && I != this) Destroy(gameObject); I = this;
    }

    private void Start()
    {
        secondsTimer.TimerFinished += UpdateLikesPerSec;
        secondsTimer.TimerFinished += RefreshInGameUIText;

        nightScreenTimer.TimerFinished += NewNight;

        MouseEventHandlerManager.mouseDownEvent += UpdateTips;
        MouseEventHandlerManager.mouseDownEvent += UpdateDifficulty;
        MouseEventHandlerManager.mouseDownEvent += UpdateLikes;
        MouseEventHandlerManager.mouseDownEvent += RefreshInGameUIText;

        secondsTimer.Start();

        profile.TryGetSettings(out high);
        profile.TryGetSettings(out drunk);

        ResetValues();
        SpawnEntity();
    }

    private void Update()
    {
        secondsTimer.Update();
        nightScreenTimer.Update();
    }

    private void RefreshInGameUIText()
    {
        tipsText.text = $"Tips: ${tips.ToString("N2")}";
        likesText.text = LikesToString();
    }

    public void RefreshEntityUI(EntityController e)
    {
        if (e == null) return;
        entityNameText.text = e.name;
        entityHealthSlider.value = e.HP;
    }

    private void RefreshResultsText()
    {
        nightCountText.text = $"Night {nightIndex}";
        totalText.text = $"Total {Total().ToString("C2")}";
        nLikesText.text = LikesToString();
    }

    public void ShowResultsScreen() => resultsPanel.SetActive(true);
    private void HideResultsScreen() => resultsPanel.SetActive(false);
    private void UpdateDifficulty() => Difficulty += difficultyIncrementPerClick;
    private void UpdateLikes() => likes += Mathf.RoundToInt(likesAmountPerClick * likesMultiplier / IncapacitatedMultiplier);
    private void UpdateLikesPerSec() => likes *= Mathf.RoundToInt(likesMultiplier / IncapacitatedMultiplier);
    private void UpdateTips() => tips += tipsAmountPerClick * drunkMultiplier * highMultiplier;
    private void UpdateLikesMultiplier() => likesMultiplier += likesOverTimeMultiplier;
    private float Total() => tips + (likes / 1000) * baseFee / IncapacitatedMultiplier;
    private string LikesToString() =>
        (likes > 1000000 ? $"Likes: {(likes / 1000000.0f).ToString("N2")}m" : likes > 1000 ? $"Likes: {(likes / 1000.0f).ToString("N2")}k" : $"Likes: {likes}") + " ♥";

    public void Drink(float amount)
    {
        drunkMultiplier += amount * 5;
        IncapacitatedMultiplier += amount;
        drunk.power.value += amount;
    }

    public void Puff(float amount)
    {
        highMultiplier += amount * 2;
        IncapacitatedMultiplier += amount;
        high.intensity.value += amount;
        high.power.value += amount;
    }

    public void DestroyEntity(EntityController e)
    {
        likes += e.LikesAddedWhenDead;

        if (system.IsAlive()) system.Clear();
        system.Play();

        RefreshInGameUIText();
        Destroy(e.gameObject);
        SpawnEntity();
    }

    public void SpawnEntity()
    {
        if (entityIndex >= entitiesList.Count) { NightOver(); return; }

        var rand = Random.Range(0, 3); GameObject entity;
        if (rand == 0)
            entity = powerUpsList[Random.Range(0, powerUpsList.Count)];
        else
            entity = entitiesList[entityIndex];

        Instantiate(entity, GameObject.Find("Entities").transform).name = entity.name;
        RefreshEntityUI(entity.GetComponent<EntityController>());
        entityIndex++;
    }

    public void NightOver()
    {
        ShowResultsScreen();
        RefreshResultsText();
        ResetValues();
        nightScreenTimer.Start();
    }

    public void NewNight()
    {
        entityIndex = 0;
        nightIndex++;
        HideResultsScreen();
        SpawnEntity();
    }
}
