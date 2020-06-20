using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    #region Manager References
    JobManager _jobManager; //Reference to the JobManager
    #endregion
    
    #region Workers
    public List<Worker> _workers; //List of all workers associated with this building, either for work or living
    #endregion

    #region Jobs
    public List<Job> _jobs; // List of all available Jobs. Is populated in Start()
    #endregion

    #region Methods
    // Start is called before the first frame update
    protected virtual void Start()
    {
    }

    // Update is called once per frame
    protected virtual void Update()
    {
    }
    public void WorkerAssignedToBuilding(Worker w)
    {
        _workers.Add(w);
    }

    public void WorkerRemovedFromBuilding(Worker w)
    {
        _workers.Remove(w);
    }
    #endregion
}
