﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class DataInputKey : DataInput
{
    [SerializeField] private string name;
    public string Name { get { return name; } set { name = value; } }
    [SerializeField] private KeyCode positive = KeyCode.A;
    [SerializeField] private KeyCode negative = KeyCode.D;
    [Header("Data")]
    [SerializeField] private DataFloat dataNode;
    [Header("Events")]
    [SerializeField] private UnityEvent onPositiveKeyDown = null;
    [SerializeField] private UnityEvent onPositiveKey     = null;
    [SerializeField] private UnityEvent onPositiveKeyUp   = null;
    [SerializeField] private UnityEvent onNegativeKeyDown = null;
    [SerializeField] private UnityEvent onNegativeKey     = null;  
    [SerializeField] private UnityEvent onNegativeKeyUp   = null;

    private bool pressedPositive;
    private bool pressedNegative;

    public override void Start(Data data)
    {
        if (data.Has(dataNode))
            dataNode = data.GetFloat(dataNode.Name);
        else
            data.Add(dataNode);
    }

    public override void Update()
    {
        bool currentlyPressedPositive = Input.GetKey(positive);
        bool currentlyPressedNegative = Input.GetKey(negative);

        if (currentlyPressedPositive && !pressedPositive)
            onPositiveKeyDown.Invoke();
        else if (currentlyPressedPositive && pressedPositive)
            onPositiveKey.Invoke();
        else if (!currentlyPressedPositive && pressedPositive)
            onPositiveKeyUp.Invoke();
        else if (currentlyPressedNegative && !pressedNegative)
            onNegativeKeyDown.Invoke();
        else if (currentlyPressedNegative && pressedNegative)
            onNegativeKey.Invoke();
        else if (!currentlyPressedNegative && pressedNegative)
            onNegativeKeyUp.Invoke();

        dataNode.Value = 0;
        if (currentlyPressedPositive)
            dataNode += 1;
        if (currentlyPressedNegative)
            dataNode -= 1;

        pressedPositive = currentlyPressedPositive;
        pressedNegative = currentlyPressedNegative;
    }
}
