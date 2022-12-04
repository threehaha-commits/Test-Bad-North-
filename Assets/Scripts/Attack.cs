using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{
    private const float _distanceForAttack = 0.5f;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _damage;
    [SerializeField] private AudioClip _attackSound;
    private AudioSource _audioSource;
    private Animator _animator;
    private const string _animationAttackName = "Attack_Sword";
    private Reload _reload;
    private Attacker _attacker;
    private Transform _target;
    
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _reload = new Reload(_reloadTime);
        _animator = GetComponent<Animator>();
        _attacker = new Attacker(_damage);
        AddToAction();
        SetStopDistanceForAttack();
    }

    private void AddToAction()
    {
        var characterState = GetComponent<CharacterState>();
        characterState.AddAction(AttackTo);
    }

    public void AttackTo(Transform target)
    {
        if (Helper.IsNull(target))
            return;
        
        var distance = Helper.GetDistance(transform, target);
        if (distance < _distanceForAttack)
        {
            if(_reload.isEnd)
            {
                _target = target;
                PlayAttackAnimation();
            }
        }
    }

    // Call from animation event
    private void SetDamage()
    {
        _audioSource.PlayOneShot(_attackSound);
        _attacker.AttackTo(_target);
        _reload.Start();
    }

    private void PlayAttackAnimation()
    {
        _animator.SetTrigger(_animationAttackName);
    }

    private void SetStopDistanceForAttack()
    {
        var navMesh = GetComponent<NavMeshAgent>();
        var offset = 0.1f;
        navMesh.stoppingDistance = _distanceForAttack - offset;
    }
}