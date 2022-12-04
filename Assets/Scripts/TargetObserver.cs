using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObserver : MonoBehaviour, IPause
{
    private readonly float _setTargetsTime = 0.8f;
    private readonly List<ITargetFinder> _iTargets = new();
    private readonly List<Transform> _tTargets = new();
    bool IPause.isPause { get; set; }
    private IPause pause => this;
    private PauseUIButton _pauseUIButton;
    
    public void AddSubscriber(Transform subscriber)
    {
        var subscriberInterface = subscriber.GetComponent<ITargetFinder>();
        _tTargets.Add(subscriber);
        _iTargets.Add(subscriberInterface);
    }

    public void RemoveSubscriber(Transform subscriber)
    {
        var subscriberInterface = subscriber.GetComponent<ITargetFinder>();
        _tTargets.Remove(subscriber);
        _iTargets.Remove(subscriberInterface);
    }
    
    private void Start()
    {
        _pauseUIButton = FindObjectOfType<PauseUIButton>();
        _pauseUIButton.AddPauseUnit(this);
        StartCoroutine(SetTargets());
    }

    private IEnumerator SetTargets()
    {
        while (true)
        {
            if(pause.isPause == false)
            {
                for (int i = 0; i < _iTargets.Count; i++)
                {
                    _iTargets[i]?.Find(_tTargets.ToArray());
                }
            }
            yield return new WaitForSeconds(_setTargetsTime);
        }
    }
}