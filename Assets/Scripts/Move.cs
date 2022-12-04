using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour, IPause
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private const string _animationRunName = "Run";
    private Vector3 _movePosition;
    private bool _isPause;
    bool IPause.isPause
    {
        get => _isPause;
        set
        {
            _isPause = value;
            if (_isPause)
            {
                if (AgentIsEnabled())
                {
                    _agent.destination = transform.position;
                    _animator.SetBool(_animationRunName, false);
                }
            }
        }
    }
    private IPause pause => this;
    private PauseUIButton _pauseUIButton;
    private Vector3 _lastPosition;
    private bool _isRuning;
    
    private void Awake()
    {
        _pauseUIButton = FindObjectOfType<PauseUIButton>();
        _pauseUIButton.AddPauseUnit(this);
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        AddToAction();
    }

    private void AddToAction()
    {
        var characterState = GetComponent<CharacterState>();
        characterState.AddAction(MoveTo);
    }
    
    //From TargetObserver
    public void MoveTo(Transform target)
    {
        if (!pause.isPause && CanMove(target))
        {
            _movePosition = target.position;
        }
        PlayAnimation(_movePosition);
    }

    private bool CanMove(Transform target)
    {
        return Helper.IsNotNull(target) && AgentIsEnabled();
    }

    private bool AgentIsEnabled()
    {
        return _agent.enabled;
    }

    //From UnitChooser
    public void MoveTo(Vector3 point)
    {
        if (pause.isPause)
            return;
        
        if(AgentIsEnabled())
            _movePosition = point;

        PlayAnimation(_movePosition);
    }

    private void PlayAnimation(Vector3 point)
    {
        if (point != Vector3.zero)
            _agent.destination = point;
    }
    
    private void FixedUpdate()
    {
        _animator.SetBool(_animationRunName, _isRuning);
        if (!AgentIsEnabled())
            return;
        _isRuning = _agent.remainingDistance > 0.5f;
    }
}