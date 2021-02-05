using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

namespace HuaweiAuthDemo
{
    internal class UnityMainThread : MonoBehaviour
    {
        internal static UnityMainThread instance;
        ConcurrentQueue<Action> jobs = new  ConcurrentQueue<Action>();

        void Awake() {
            instance = this;
        }

        void Update() {
            while (jobs.Count > 0)
            {
                Action currentJob;
                jobs.TryDequeue(out currentJob);
                if (currentJob != null)
                {
                    currentJob.Invoke();
                }
            }
        }

        internal void AddJob(Action newJob) {
            jobs.Enqueue(newJob);
        }
    }

}