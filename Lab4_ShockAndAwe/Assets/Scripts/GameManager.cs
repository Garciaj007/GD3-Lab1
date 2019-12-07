using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
#pragma warning disable IDE0051 // Remove unused private members
    [SerializeField] private Vector2 cullAndDepth = Vector2.zero;
    [SerializeField] private float targetSpeed = 2.0f;
    [SerializeField] private float incrementSpeed = 0.001f;
#pragma warning restore IDE0051 // Remove unused private members

    private readonly Utils.Timer targetIncrementTimer = new Utils.Timer(1.0f);

    public static GameManager Instance {get; private set;}
    public float TargetSpeed { get { return targetSpeed; } }
    public Vector2 CullAndDepth { get { return cullAndDepth; } }

    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        Instance = this;
    }

    private void Start()
    {
        targetIncrementTimer.TimerFinished += IncrementTargetSpeed;
        targetIncrementTimer.Start();
    }

    private void Update()
    {
        targetIncrementTimer.Update();
    }

    private void IncrementTargetSpeed() => targetSpeed += incrementSpeed;
}
