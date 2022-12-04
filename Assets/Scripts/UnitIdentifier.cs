using UnityEngine;

public class UnitIdentifier : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    private TargetObserver _targetObserver;
    private LineRenderer _renderer;
    
    public Unit Get()
    {
        return _unit;
    }

    private void Awake()
    {
        _targetObserver = FindObjectOfType<TargetObserver>();
        _targetObserver.AddSubscriber(transform);
        SetColorToBar();
    }

    private void SetColorToBar()
    {
        _renderer = GetComponentInChildren<LineRenderer>();
        if (_unit == Unit.Player)
            SetColorValue(Color.green);
        else
            SetColorValue(Color.red);
    }

    private void SetColorValue(Color color)
    {
        var alpha = 1f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new(color, 0.0f), new(color, 1.0f) },
            new GradientAlphaKey[] { new(alpha, 0.0f), new(alpha, 1.0f) });
        _renderer.colorGradient = gradient;
    }
    
    private void OnDestroy()
    {
        _targetObserver.RemoveSubscriber(transform);
    }
}