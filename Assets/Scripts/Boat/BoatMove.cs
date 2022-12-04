using UnityEngine;

public class BoatMove : MonoBehaviour, IPause
{
    [SerializeField] private float _moveSpeed;
    public Transform _island { private get; set; }
    private Transform _transform;
    public bool _canMove { private get; set; } = true;
    bool IPause.isPause { get; set; }
    private IPause pause => this;
    private PauseUIButton _pauseUIButton;
    
    private void Start()
    {
        _pauseUIButton = FindObjectOfType<PauseUIButton>();
        _pauseUIButton.AddPauseUnit(this);
        _transform = transform;
        SetDirectionToIsland();
    }

    private void SetDirectionToIsland()
    {
        var dir = _island.position - _transform.position;
        _transform.rotation = Quaternion.LookRotation(dir, _transform.position);
    }

    private void FixedUpdate()
    {
        if (_canMove == false || pause.isPause)
            return;
        var delta = _moveSpeed * Time.fixedDeltaTime;
        _transform.position += _transform.forward * delta;
    }
}