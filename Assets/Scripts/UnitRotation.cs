using UnityEngine;
using UnityEngine.AI;

public class UnitRotation : MonoBehaviour
{
    private Vector3 _target;
    private NavMeshAgent _agent;
    private float distanceForAttack => _agent.stoppingDistance;
    private Transform _transform;
    
    private void Start()
    {
        _transform = transform;
        _agent = GetComponent<NavMeshAgent>();
        AddToAction();
    }

    private void AddToAction()
    {
        var characterState = GetComponent<CharacterState>();
        characterState.AddAction(RotateTo);
    }

    public void RotateTo(Transform target)
    {
        if (Helper.IsNull(target))
        {
            _target = Vector3.zero;
            return;
        }
        var distance = (target.position - _transform.position).sqrMagnitude;
        if (distance <= distanceForAttack)
            _target = target.position;
        else
            _target = Vector3.zero;
    }
    
    private void FixedUpdate()
    {
        if (TargetIsZero())
            return;

        RotateToTarget();
    }

    private void RotateToTarget()
    {
        var dir = _target - _transform.position;
        _transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }

    private bool TargetIsZero()
    {
        return _target == Vector3.zero;
    }
}