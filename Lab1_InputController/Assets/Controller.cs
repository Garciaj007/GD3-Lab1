using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputComponent : MonoBehaviour
{
    public abstract void Gather(Data data);
    public abstract void Input();
}

public abstract class ControlComponent : MonoBehaviour
{
    public abstract void Gather(Data data);

    public abstract void Execute();
}

public class Controller : MonoBehaviour
{
    private Data data = new Data();

    [Header("Inputs")]
    [SerializeField] private List<InputComponent> inputs = new List<InputComponent>();
    [Header("Controls")]
    [SerializeField] private List<ControlComponent> controls = new List<ControlComponent>();

    // Start is called before the first frame update
    void Start()
    {
        InputComponent[] inputComponents = GetComponents<InputComponent>();
        foreach (InputComponent component in inputComponents)
        {
            if (!inputs.Contains(component))
                inputs.Add(component);
        }

        ControlComponent[] controlComponents = GetComponents<ControlComponent>();
        foreach (ControlComponent component in controlComponents)
        {
            if (!controls.Contains(component))
                controls.Add(component);
        }

        foreach (InputComponent component in inputs)
            component.Gather(data);

        foreach (ControlComponent component in controls)
            component.Gather(data);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (InputComponent component in inputs)
            component.Input();

        foreach (ControlComponent component in controls)
            component.Execute();
    }
}
