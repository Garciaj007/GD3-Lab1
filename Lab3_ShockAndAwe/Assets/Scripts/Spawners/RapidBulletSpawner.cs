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
        if (Input.GetMouseButtonDown(0))
            bulletTimer.Start();

        if(Input.GetMouseButtonUp(0))
            bulletTimer.Stop();
        
        if(Input.GetMouseButton(0))
            bulletTimer.Update();
    }

    protected override void Spawn()
    {
        var pos = Input.mousePosition;
        pos.z = 0.5f;
        pos = Camera.main.ScreenToWorldPoint(pos);
        objectPool.SpawnFromPool("RapidBullet", pos, 
            Quaternion.LookRotation(MouseViewportRotator.Instance.MouseOrientationRay.direction, Vector3.up));
    }
}
