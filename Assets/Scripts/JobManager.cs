using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobManager : MonoBehaviour
{

    private List<Job> _availableJobs = new List<Job>();
    public List<Worker> _unoccupiedWorkers = new List<Worker>();

    private List<Job> _unavailableJobs = new List<Job>();



    #region MonoBehaviour
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleUnoccupiedWorkers();
    }
    #endregion


    #region Methods

    private void HandleUnoccupiedWorkers()
    {
        while ((_unoccupiedWorkers.Count > 0) && (_availableJobs.Count > 0))
        {
            _availableJobs[0].AssignWorker(_unoccupiedWorkers[0]);
            _unavailableJobs.Add(_availableJobs[0]);
            _availableJobs.RemoveAt(0);
            _unoccupiedWorkers.RemoveAt(0);
        }
    }

    public void RegisterWorker(Worker w)
    {
        _unoccupiedWorkers.Add(w);
    }



    public void RemoveWorker(Worker w)
    {
        _unoccupiedWorkers.Remove(w);

        for (int i = 0; i < _unavailableJobs.Count; i++)
        {
            if (Equals(_unavailableJobs[i]._worker,w))
            {
                _unavailableJobs[i].RemoveWorker(w);
                _availableJobs.Add(_unavailableJobs[i]);
                break;
            }
        }
    }

    public void addAvailableJob(Job job)
    {
        _availableJobs.Add(job);
    }

    #endregion
}
