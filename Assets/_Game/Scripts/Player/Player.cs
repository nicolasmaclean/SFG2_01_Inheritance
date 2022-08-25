using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TankController))]
public class Player : MonoExtended
{
    public static Player Instance;
    
    public int Health { get; private set; }
    public bool Invincible
    {
        get => _invincible;
        set
        {
            _invincible = value;
            UpdateColor();
        }
    }
    
    [SerializeField]
    [Min(0)]
    int _maxHealth = 3;

    [SerializeField]
    Color _invincibleColor = Color.cyan;

    [Header("Events")]
    public UnityEvent OnHealthUpdate;
    public UnityEvent OnHeal;
    public UnityEvent OnHurt;
    public UnityEvent OnDeath;

    bool _invincible = false;
    TankController _tank;
    Dictionary<Renderer, Color> _colors;

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        Health = _maxHealth;
        _tank = GetComponent<TankController>();
        CacheColors();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
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
        if (Invincible) return;
        
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

    void CacheColors()
    {
        _colors = new Dictionary<Renderer, Color>();
        foreach (var rend in GetComponentsInChildren<Renderer>())
        {
            _colors.Add(rend, rend.material.color);
        }
    }

    void UpdateColor()
    {
        Color? col = Invincible ? _invincibleColor : null;
        foreach (var kvp in _colors)
        {
            Renderer rend = kvp.Key;
            Color c = kvp.Value;
            rend.material.color = col ?? c;
        }
    }
}