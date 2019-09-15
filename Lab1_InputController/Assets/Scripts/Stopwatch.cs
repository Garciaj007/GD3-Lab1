using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    public static Stopwatch Instance { get; private set; }
    public float Count { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this; 
    }

    private void Start()
    {
        Count = 0f;
        GameManager.resetGameDelegate += Reset;
    }

    // Update is called once per frame
    void Update()
    {
        Count += Time.deltaTime;
    }

    private void Reset()
    {
        Count = 0f;
    }
}
