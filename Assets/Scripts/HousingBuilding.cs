using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousingBuilding : Building
{
    public float _avHappiness; // The average happiness of workers
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Worker worker_1 = new Worker();
        Worker worker_2 = new Worker();
        worker_1._age = 15;
        worker_2._age = 15;
        _workers.Add(worker_1);
        _workers.Add(worker_2);
       //New instructions can be called after the base's.
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
       //New instructions can be called after the base's.

    }

    public float calcHapiness() {
        float happySum = 0;
        foreach (Worker worker in _workers)
        {
            happySum += worker._happiness;
        }
        return happySum / _workers.Count;
    }

        public void birth()
    {
        if (_workers.Count < 11) {
        WorkerAssignedToBuilding(new Worker());
        }
    }

}
