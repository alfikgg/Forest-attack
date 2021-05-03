using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _startMoney;

    private Weapon _currentWeapon;
    private int _currentWeponNumber = 0;
    private int _currentHealth;
    private Animator _animator;
    private float _timeAfterLasShoot;


    public int Money => _startMoney;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction<Weapon> WeaponChanged;

    private void Start()
    {
        ChangeWeapon(_weapons[_currentWeponNumber]);
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            _timeAfterLasShoot += Time.deltaTime;

            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {               
                if (_timeAfterLasShoot >= _currentWeapon.ShootDelay)
                {
                    _timeAfterLasShoot = 0;
                    _currentWeapon.Shoot(_shootPoint);
                }
            }
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void AddMoney(int money)
    {
        _startMoney += money;
        MoneyChanged?.Invoke(Money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        _startMoney -= weapon.Price;
        MoneyChanged?.Invoke(Money);
        _weapons.Add(weapon);
    }

    public void NextWeapon()
    {
        if (_currentWeponNumber == _weapons.Count - 1)
            _currentWeponNumber = 0;
        else
            _currentWeponNumber++;

        ChangeWeapon(_weapons[_currentWeponNumber]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeponNumber == 0)
            _currentWeponNumber = _weapons.Count - 1;
        else
            _currentWeponNumber--;

        ChangeWeapon(_weapons[_currentWeponNumber]);
    }

    public void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
        WeaponChanged?.Invoke(_currentWeapon);
    }
}
