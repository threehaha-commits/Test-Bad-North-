using UnityEngine;

public class BoatContainer : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    private int _countUnitInBoat = 0;
    public bool isFull => _countUnitInBoat == _points.Length;
    private EnemyInBoatHandler _enemyInBoatHandler;
    
    private void Start()
    {
        _enemyInBoatHandler = GetComponent<EnemyInBoatHandler>();
    }

    //Помещаем врагов в лодку и отправляем в общий массив
    public void ContainToBoat(Transform unit)
    {
        unit.parent = _points[_countUnitInBoat];
        unit.localPosition = Vector3.zero;
        _enemyInBoatHandler.AddToHandler(unit);
        _countUnitInBoat++;
    }
}