using UnityEngine;

public class TargetHandler : MonoBehaviour, ITargetFinder
{
    [Tooltip("The distance which unit will be search target. 0 = Infinity")]
    [SerializeField] private float _findDistance = 0;

    private float findDistance
    {
        get
        {
            if (_findDistance <= 0)
                _findDistance = Mathf.Infinity;
            return _findDistance;
        }
    }
    private CharacterState _characterState;
    private Transform _target;
    private UnitIdentifier ID;
    
    private void Awake()
    {
        ID = GetComponent<UnitIdentifier>();
        _characterState = GetComponent<CharacterState>();
    }

    void ITargetFinder.Find(Transform[] targets)
    {
        var distance = findDistance;
        _target = null;
        for (int i = 0; i < targets.Length; i++)
        {
            var target = targets[i];
            if(TargetIsNotMe(target) || TargetIsEnemyUnit(target))
                continue;
            distance = FindNearTarget(target, distance);
        }
        _characterState?.UpdateState(_target);
    }

    private float FindNearTarget(Transform target, float distance)
    {
        var dist = GetDistance(target);
        if (dist < distance)
        {
            _target = target;
            distance = dist;
        }

        return distance;
    }

    private float GetDistance(Transform target)
    {
        return (target.position - transform.position).sqrMagnitude;
    }

    private bool TargetIsEnemyUnit(Transform target)
    {
        target.TryGetComponent<UnitIdentifier>(out var targetID);
        return ID.Get() == targetID.Get();
    }
    
    private bool TargetIsNotMe(Transform target)
    {
        return target == transform;
    }
}