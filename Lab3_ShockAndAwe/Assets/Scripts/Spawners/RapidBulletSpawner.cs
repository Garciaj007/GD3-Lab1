using UnityEngine;

public class RapidBulletSpawner : AObjectSpawner
{
    public float rateOfFire;
    private Utils.Timer bulletTimer;

    private void Start()
    {
        bulletTimer = new Utils.Timer(rateOfFire);
        bulletTimer.TimerFinished += Spawn;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            bulletTimer.Start();

        if(Input.GetMouseButtonUp(1))
            bulletTimer.Stop();
    }

    protected override void Spawn()
    {
        throw new System.NotImplementedException();
    }
}
