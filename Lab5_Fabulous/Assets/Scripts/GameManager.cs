using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("Entities")]
    [SerializeField] private List<EntityScriptableObject> eso = new List<EntityScriptableObject>();
    [Header("UI Components")]
    [SerializeField] private Text tipsText = null;
    [SerializeField] private Text likesText = null;
    [Space]
    [Header("Values")]
    [SerializeField] private float baseFee = 10.0f;
    //[SerializeField] private float tipsOverTimeMultiplier = 0.0f;
    [SerializeField] private float likesOverTimeMultiplier = 0.0f;
    [SerializeField] private float likesAmountPerClick = 1.0f;
    [SerializeField] private float tipsAmountPerClick = 0.01f;
    
    private Utils.Timer secondsTimer = new Utils.Timer(1.0f);
    private float likesMultiplier = 1.0f;
    private float drunkMultiplier = 1.0f;
    private float highMultiplier = 1.0f;
    private float IncapacitatedMultiplier = 1.0f;
    private float tips = 0.0f;
    private int likes = 0;

    public static GameManager I { get; private set; }

    private void Awake()
    {
        if(I != null && I != this) Destroy(gameObject); I = this;
    }

    private void Start()
    {
        secondsTimer.TimerFinished += UpdateLikesPerSec;
        secondsTimer.TimerFinished += RefreshText;

        MouseEventHandlerManager.mouseDownEvent += UpdateTips; 
        MouseEventHandlerManager.mouseDownEvent += UpdateLikes;
        MouseEventHandlerManager.mouseDownEvent += RefreshText;

        secondsTimer.Start();
    }

    private void Update()
    {
        secondsTimer.Update();
    }

    private void RefreshText()
    {
        tipsText.text = $"Tips: ${tips.ToString("N2")}";
        likesText.text = likes > 1000000 ? $"Likes: {(likes/1000000.0f).ToString("N2")}m" : likes > 1000 ? $"Likes: {(likes/1000.0f).ToString("N2")}k" : $"Likes: {likes}";
    }

    private void UpdateLikes() => likes += Mathf.RoundToInt(likesAmountPerClick * likesMultiplier / IncapacitatedMultiplier);
    private void UpdateLikesPerSec() => likes *= Mathf.RoundToInt(likesMultiplier / IncapacitatedMultiplier);
    private void UpdateTips() => tips += tipsAmountPerClick * drunkMultiplier * highMultiplier;
    private void UpdateLikesMultiplier() => likesMultiplier += likesOverTimeMultiplier;

    private float Total() => tips + (likes / 1000) * baseFee / IncapacitatedMultiplier;

    public void Drink() { drunkMultiplier += 0.05f; IncapacitatedMultiplier += 0.01f; }
    public void Puff() { highMultiplier += 0.1f; IncapacitatedMultiplier += 0.05f; }

    public void DestroyEntity(EntityController e)
    {
        likes += e.Entity.likesAddedWhenDead;

        //Spawn Likes Animation

        Destroy(e.gameObject);
    }

    public void NightOver()
    {
        print($"Total: {Total()}");
    }
}
