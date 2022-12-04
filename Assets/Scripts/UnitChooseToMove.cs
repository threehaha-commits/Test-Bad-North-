using UnityEngine;

public class UnitChooseToMove : MonoBehaviour, IPause
{
    private Move _pickUnit;
    private bool _inputLMB => Input.GetMouseButtonDown(0);
    bool IPause.isPause { get; set; }
    private IPause pause => this;
    private PauseUIButton _pauseUIButton;
    
    private void Start()
    {
        _pauseUIButton = FindObjectOfType<PauseUIButton>();
        _pauseUIButton.AddPauseUnit(this);
    }

    private void Update()
    {
        if (_inputLMB && pause.isPause == false)
        {
            if (RayHelper.GetRay(out var hit))
                ClickHandler(hit);
        }
    }
    
    private void ClickHandler(RaycastHit hit)
    {
        switch (_pickUnit)
        {
            case null:
                ChooseUnit(hit);
                break;
            default:
                MoveToPoint(hit);
                break;
        }
    }

    private void ChooseUnit(RaycastHit hit)
    {
        var unitTransform = hit.transform;
        if(unitTransform.TryGetComponent<Move>(out var move))
        {
            _pickUnit = move;
            Coloroid.ActiveChooseEffect(unitTransform);
        }
    }

    private void MoveToPoint(RaycastHit hit)
    {
        _pickUnit.MoveTo(hit.point);
        Coloroid.Clear();
        _pickUnit = null;
    }
}