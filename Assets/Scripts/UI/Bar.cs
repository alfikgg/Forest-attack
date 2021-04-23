using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    [SerializeField] private float _fillingSpeed = 0.5f;

    private float _targetValue;

    protected void OnValueChanged(int value, int maxValue)
    {    
        
        _targetValue = (float)value / maxValue;

        StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        while (Slider.value != _targetValue)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, _targetValue, _fillingSpeed);

            yield return null;
        }
    }
}
