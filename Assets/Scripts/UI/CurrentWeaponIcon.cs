using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWeaponIcon : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _image;

    private void OnEnable()
    {
        _player.WeaponChanged += ChangeIcon;
    }

    private void OnDisable()
    {
        _player.WeaponChanged -= ChangeIcon;
    }

    private void ChangeIcon(Weapon weapon)
    {
        if (weapon != null)
            _image.sprite = weapon.Icon;
    }
}
