using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class EnemyInBoatHandler : MonoBehaviour
{
    private Transform _island;
    private BoatMove _boatMove;
    private List<CharacterState> _enemies = new();
    private const int _timeBeetwernOutBoat = 125;
    
    private void Awake()
    {
        _boatMove = GetComponent<BoatMove>();
        _island = GameObject.FindWithTag("Island").transform;
        _boatMove._island = _island;
    }

    //Дабовляем врагов в общий массив
    public void AddToHandler(Transform enemy)
    {
        var characterStateFromEnemy = enemy.GetComponent<CharacterState>();
        _enemies.Add(characterStateFromEnemy);
    }
    
    public async void CollisionWasDetected(Vector3 point)
    {
        BoatStop();
        foreach (var enemy in _enemies)
        {
            DropToIsland(point, enemy);
            NavMeshActivate(enemy);
            enemy.transform.localScale = Vector3.one;
            await Task.Delay(_timeBeetwernOutBoat);
        }
        BoatDestroy();
        _enemies.Clear();
    }

    private void BoatStop()
    {
        _boatMove._canMove = false;
    }

    private void BoatDestroy()
    {
        var destroyTime = 1.5f;
        Destroy(_boatMove.gameObject, destroyTime);
    }

    private void NavMeshActivate(CharacterState enemy)
    {
        enemy.GetComponent<NavMeshAgent>().enabled = true;
    }

    private void DropToIsland(Vector3 point, CharacterState enemy)
    {
        enemy.transform.parent = transform.parent;
        enemy.transform.position = point;
    }
}