using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class BlockManager : MonoBehaviour
{
    public static BlockManager Instance { get; private set; }

    [SerializeField] private float[] degrees = null;
    [SerializeField] private GameObject[] patterns = null;
    [SerializeField] private Vector2 delayRange = Vector2.zero;

    [SerializeField] private List<GameObject> blocks = new List<GameObject>();

    public List<GameObject> Blocks
    {
        get
        {
            return blocks;
        }
    }

    private float currentTime = 0;
    private float previousTime = 0;
    [SerializeField] private float delay = 2f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        previousTime = Time.time;

        GameManager.resetGameDelegate += Reset;
    }

    private void Update()
    {
        if(currentTime - previousTime > delay)
        {
            previousTime = currentTime;
            SpawnBlock();
        }
        currentTime = Time.time;
    }

    private void Reset()
    {
        currentTime = 0;
        previousTime = 0;
        delay = 2f;

        foreach(var block in blocks)
        {
            Destroy(block);
        }
    }

    private void SpawnBlock()
    {
        delay = GetNewDelay();
        var block = Instantiate(GetPrefabFromRange(), Vector3.zero, GetNewRotation());
        block.AddComponent<DestroyWithDelay>().DestroyDelay = 8f;
        blocks.Add(block);
    }

    private float GetNewDelay()
    {
        return Random.Range(delayRange.x / DifficultyManager.Instance.Difficulty, delayRange.y / DifficultyManager.Instance.Difficulty);
    }

    private Quaternion GetNewRotation()
    {
        int rotationIndex = Random.Range(0, degrees.Length);
        return Quaternion.Euler(0, 0, degrees[rotationIndex]);
    }

    private GameObject GetPrefabFromRange()
    {
        int patternIndex = Random.Range(0, patterns.Length);
        return patterns[patternIndex];
    }
}
