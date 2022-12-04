using UnityEngine;

public class HpBar
{
    private readonly LineRenderer _lineRenderer;
    private readonly float _maxLength;
    private readonly float _maxHealth;
    
    public HpBar(LineRenderer lineRenderer, float maxHealth)
    {
        _lineRenderer = lineRenderer;
        _maxHealth = maxHealth;
        _maxLength = lineRenderer.GetPosition(1).z;
    }

    public void Change(float hp)
    {
        var value = hp * _maxLength / _maxHealth;
        var newLength = new Vector3(0, 0, value);
        _lineRenderer.SetPosition(1, newLength);
    }
}