using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnWave : MonoBehaviour, IPause
{
    [SerializeField] private Transform _spawnUnit;
    [SerializeField] private BoatContainer _boatContainer;
    [SerializeField] private Transform[] _spawnPoint;
    private float _timeBetweenSpawnBoat = 0.8f;
    private float _timeBetweenSpawnUnitInBoat = 0.15f;
    private RoundViewer _roundViewer;
    private int currentSpawnPoint => Random.Range(0, _spawnPoint.Length);
    private BoatContainer _spawnedBoatContainer;
    bool IPause.isPause { get; set; }
    private IPause pause => this;
    private PauseUIButton _pauseUIButton;
    
    private void Awake()
    {
        _pauseUIButton = FindObjectOfType<PauseUIButton>();
        _pauseUIButton.AddPauseUnit(this);
        _roundViewer = FindObjectOfType<RoundViewer>();
    }

    public IEnumerator Spawner(int countUnitInWave)
    {
        var currentCountEnemy = 0;
        while (currentCountEnemy < countUnitInWave)
        {
            if(pause.isPause == false)
            {
                if (_spawnedBoatContainer == null)
                    CreateBoat();
                else
                {
                    if (_spawnedBoatContainer.isFull)
                        _spawnedBoatContainer = null;
                    else
                    {
                        while (!_spawnedBoatContainer.isFull)
                        {
                            if(currentCountEnemy >= countUnitInWave)
                                yield break;
                            CreateEnemyUnit(out var newEnemy);
                            _spawnedBoatContainer.ContainToBoat(newEnemy);
                            _roundViewer.AddEnemy(newEnemy);
                            currentCountEnemy++;
                            yield return new WaitForSeconds(_timeBetweenSpawnUnitInBoat);
                        }
                    }
                }
            }
            yield return new WaitForSeconds(_timeBetweenSpawnBoat);
        }
    }

    private void CreateBoat()
    {
        _spawnedBoatContainer = Instantiate(_boatContainer, _spawnPoint[currentSpawnPoint].position,
            _boatContainer.transform.rotation);
    }

    private void CreateEnemyUnit(out Transform enemy)
    {
        enemy = Instantiate(_spawnUnit);
    }
}