using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleSystem
{
    public class BattleVisuals : MonoBehaviour
    {
        const string LVL_STRING = "Lv: ";
        
        [SerializeField] Slider healthBar;
        // [SerializeField] Slider EnergyBar;
        [SerializeField] TextMeshProUGUI levelText;
        [SerializeField] TextMeshProUGUI healthText;
        int _currentHealth;
        int _maxHealth;
        int _level;

        public void SetStartingValues(int currentHealth, int maxHealth, int level)
        {
            _currentHealth = currentHealth;
            _maxHealth = maxHealth;
            _level = level;
            levelText.text = LVL_STRING + _level;
            UpdateHealthBar();
        }

        public void ChangeHealth(int currentHealth)
        {
            _currentHealth = currentHealth;
            
            if (_currentHealth <= 0)
            {
                Destroy(gameObject, 1f);
            }
            
            UpdateHealthBar();
        }
        
        void UpdateHealthBar()
        {
            healthBar.maxValue = _maxHealth;
            healthBar.value = _currentHealth;
            //healthText.text = _currentHealth.ToString();
        }
    }
}
