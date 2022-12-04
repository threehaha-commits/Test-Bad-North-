using UnityEngine;
using UnityEngine.AI;

public class Death
{
    private readonly Animator _animator;
    private readonly Transform _transform;
    private const string _animationDeathName = "Death";
    private readonly TargetObserver _targetObserver;
    private readonly RoundViewer _roundViewer;
    private readonly NavMeshAgent _agent;
    private readonly Collider _collider;
    
    public Death(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
        _targetObserver = Object.FindObjectOfType<TargetObserver>();
        _roundViewer = Object.FindObjectOfType<RoundViewer>();
        _agent = _transform.GetComponent<NavMeshAgent>();
        _collider = _transform.GetComponent<Collider>();
    }

    public void Die()
    {
        VisualDestroyObject();
        _targetObserver.RemoveSubscriber(_transform);
        _roundViewer.RemoveEnemy(_transform);
        if(_agent != null)
            _agent.enabled = false;
        if(_collider != null)
            _collider.enabled = false;
    }

    private void VisualDestroyObject()
    {
        if (_animator != null)
            _animator.SetTrigger(_animationDeathName);
        else
            Object.Destroy(_transform.gameObject);
    }
}