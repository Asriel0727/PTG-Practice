using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnergyBarUI : MonoBehaviour
{
    private Image _energyBarFill;
    private TextMeshProUGUI _energyBarText;
    private Character _character;

    private void Awake()
    {
        _energyBarFill = GetComponentInChildren<Image>();
        _energyBarText = GetComponentInChildren<TextMeshProUGUI>();
        _character = GetComponentInParent<Character>();
    }

    private void Start()
    {
        OnEnergyChange();
    }

    private void OnEnable()
    {
        Character.OnEnergyChange += OnEnergyChange;
    }

    private void OnDisable()
    {
        Character.OnEnergyChange -= OnEnergyChange;
    }

    private void OnEnergyChange()
    {

    }
}
