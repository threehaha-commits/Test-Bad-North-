using System.Collections.Generic;
using UnityEngine;

public class HomeLifeHandler : MonoBehaviour
{
    private readonly List<HomeLife> _homes = new();
    private EndGameViewer _endGameViewer;

    private void Start()
    {
        _endGameViewer = FindObjectOfType<EndGameViewer>();
    }

    public void AddHome(HomeLife home)
    {
        _homes.Add(home);
    }

    public void RemoveHome(HomeLife home)
    {
        _homes.Remove(home);
        CheckLife();
    }

    private void CheckLife()
    {
        if(AllHomesWasDestroy())
            _endGameViewer.End("Loss! (Restart)");
    }

    private bool AllHomesWasDestroy()
    {
        return _homes.Count == 0;
    }
}