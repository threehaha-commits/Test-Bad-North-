using UnityEngine;

public class HomeLife : MonoBehaviour, IDamageable
{
    private Health _health;
    private HomeLifeHandler _homeLifeHanlder;
    
    private void Start()
    {
        _health = GetComponent<Health>();
        _homeLifeHanlder = FindObjectOfType<HomeLifeHandler>();
        _homeLifeHanlder.AddHome(this);
    }

    void IDamageable.ApplyDamage(float damage)
    {
        var currentHealth = _health.GetCurrentHealth();
        if (currentHealth <= 0)
            _homeLifeHanlder.RemoveHome(this);
    }
}