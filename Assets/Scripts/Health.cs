using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;

    private float health
    {
        get
        {
            if (_health < 0)
                _health = 0;
            return _health;
        }
        set => _health = value;
    }
    private Death _death;
    private HpBar _hpBar;
    private LineRenderer _bar;
    
    private void Start()
    {
        _death = new Death(transform);
        _bar = GetComponentInChildren<LineRenderer>();
        _hpBar = new HpBar(_bar, _health);
    }

    public float GetCurrentHealth()
    {
        return health;
    }
    
    void IDamageable.ApplyDamage(float damage)
    {
        health -= damage;
        ChangeHpBar();
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (health <= 0)
            _death.Die();
    }

    private void ChangeHpBar()
    {
        _hpBar.Change(health);
    }
}