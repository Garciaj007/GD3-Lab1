using UnityEngine;

public class BeatSequencer : MonoBehaviour
{
    [SerializeField] private float bpm = 120f;
    public static BeatSequencer Instance { get; private set; }
    public bool BeatFull { get; private set; }
    public bool BeatHalf { get; private set; }
    public bool Active { get; set; }

    private float beatInterval, beatTimer, beatIntervalHalf, beatTimerHalf;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        Active = true;
    }

    // Update is called once per frame
    void Update()
    {
        BeatFull = false;
        BeatHalf = false;
        beatInterval = 60 / bpm;
        beatIntervalHalf = beatInterval / 2;
        beatTimer += Time.unscaledDeltaTime;
        beatTimerHalf += Time.unscaledDeltaTime;

        if(beatTimer >= beatInterval && Active)
        {
            beatTimer -= beatInterval;
            BeatFull = true;
        }

        if(beatTimerHalf >= beatIntervalHalf && Active)
        {
            beatTimerHalf -= beatIntervalHalf;
            BeatHalf = true;
        }
    }

    private void Reset()
    {
        beatTimer = 0f;
        beatTimerHalf = 0f;
    }
}
