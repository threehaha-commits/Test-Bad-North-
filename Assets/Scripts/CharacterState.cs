using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(TargetHandler))]
public class CharacterState : MonoBehaviour, IPause
{
    private UnityAction<Transform> _charapterAction;
    
    bool IPause.isPause { get; set; }
    private IPause pause => this;
    private PauseUIButton _pauseUIButton;
    
    private void Awake()
    {
        _pauseUIButton = FindObjectOfType<PauseUIButton>();
        _pauseUIButton.AddPauseUnit(this);
    }

    public void AddAction(UnityAction<Transform> action)
    {
        _charapterAction += action;
    }
    
    public void UpdateState(Transform target)
    {
        if (pause.isPause)
            return;
        _charapterAction.Invoke(target);
    }
}