using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundViewer : MonoBehaviour
{
    [SerializeField] private int[] _unitCountInWave;
    [SerializeField] private int _roundCount = 3;
    [SerializeField] private TMP_Text _roundCountTMPText;
    private const float _periodicalCheckingTime = 0.8f;
    private List<Transform> _enemies = new();
    private SpawnWave _spawner;
    private EndGameViewer _endGameViewer;
    
    public void AddEnemy(Transform enemy)
    {
        _enemies.Add(enemy);
    }

    public void RemoveEnemy(Transform enemy)
    {
        _enemies.Remove(enemy);
    }
    
    public void StartGame()
    {
        _endGameViewer = FindObjectOfType<EndGameViewer>();
        _spawner = FindObjectOfType<SpawnWave>();
        StartCoroutine(RoundChecker());
    }

    private IEnumerator RoundChecker()
    {
        var currentRound = 0;
        while (currentRound  < _roundCount)
        {
            if (_enemies.Count == 0)
            {
                currentRound++;
                var spawnRoutine = _spawner.Spawner(_unitCountInWave[currentRound - 1]);
                _roundCountTMPText.text = $"Current round: {currentRound}";
                yield return _spawner.StartCoroutine(spawnRoutine);
            }
            yield return new WaitForSeconds(_periodicalCheckingTime);
        }

        yield return new WaitWhile(() => _enemies.Count > 0);
        _endGameViewer.End("Win! (Restart)");
    }
}