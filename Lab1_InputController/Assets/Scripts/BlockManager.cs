using UnityEngine;
using UnityEngine.Events;

public class BlockManager : MonoBehaviour
{
    private UnityEvent spawnBlockEvent;

    [SerializeField] private float[] degrees;
    [SerializeField] private GameObject[] patterns;
    [SerializeField] private Vector2 delayRange;
    [SerializeField] private float perlinIncrementAmnt = 10.0f;

    private float currentTime = 0;
    private float previousTime = 0;
    private float perlinIncr = 0;
    private float delay = 2.0f;

    private void Start()
    {
        Debug.Assert(patterns.Length > 0 || degrees.Length > 0);

        previousTime = Time.time;

        if (spawnBlockEvent == null)
            spawnBlockEvent = new UnityEvent();

        spawnBlockEvent.AddListener(SpawnBlock);

        perlinIncr = Random.Range(0.0f, 10.0f);
    }

    // Update is called once per frame
    private void Update()
    {
        if(currentTime - previousTime > delay)
        {
            previousTime = currentTime;
            spawnBlockEvent.Invoke();
        }

        currentTime = Time.time;
    }

    private void SpawnBlock()
    {
        perlinIncr += perlinIncrementAmnt;
        delay = GetNewDelay();
        Instantiate(GetPrefabFromRange(), Vector3.zero, GetNewRotation());
    }

    private float GetNewDelay()
    {
         return Random.Range(delayRange.x, delayRange.y);
    }

    private Quaternion GetNewRotation()
    {
        //int rotationIndex = Mathf.Clamp(Mathf.RoundToInt(Mathf.PerlinNoise(perlinIncr, perlinIncr) * degrees.Length), 0, degrees.Length - 1);
        int rotationIndex = Random.Range(0, degrees.Length);
        return Quaternion.Euler(0, 0, degrees[rotationIndex]);
    }

    private GameObject GetPrefabFromRange()
    {
        //int patternIndex = Mathf.Clamp(Mathf.RoundToInt(Mathf.PerlinNoise(perlinIncr, perlinIncr) * patterns.Length), 0, patterns.Length - 1);
        int patternIndex = Random.Range(0, degrees.Length);
        return patterns[patternIndex];
    }
}
