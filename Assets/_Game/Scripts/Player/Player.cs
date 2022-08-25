using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TankController))]
public class Player : MonoExtended
{
    public static Player Instance;
    
    public int Health { get; private set; }
    
    [SerializeField]
    [Min(0)]
    int _maxHealth = 3;

    [Header("Events")]
    public UnityEvent OnHealthUpdate;
    public UnityEvent OnHeal;
    public UnityEvent OnHurt;
    public UnityEvent OnDeath;

    TankController _tank;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        _tank = GetComponent<TankController>();
        Health = _maxHealth;
    }

    public void Heal(int amount)
    {
        Health += amount;
        Health = Mathf.Clamp(Health, 0, _maxHealth);
        
        OnHealthUpdate?.Invoke();
        OnHeal?.Invoke();
    }

    public void Hurt(int amount)
    {
        Health -= amount;
        OnHealthUpdate?.Invoke();

        if (Health <= 0)
        {
           Kill();
           return;
        }
        
        OnHurt?.Invoke();
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        OnDeath?.Invoke();
    }
}