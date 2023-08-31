using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private int _maxHP = 100;
    private int _hp;

    public int MaxHP => _maxHP;
    public int HP
    {
        get => _hp;
        private set {
            bool isDamage = value < _hp;
            _hp = Mathf.Clamp(value, 0, _maxHP);

            if(isDamage)
            {
                Damaged?.Invoke(_hp);
            }
            else
            {
                Healed?.Invoke(_hp);
            }
            if (_hp <= 0)
            {
                Died?.Invoke(_hp);
            }
        }
    }

    public UnityEvent<int> Healed;
    public UnityEvent<int> Damaged;
    public UnityEvent<int> Died;

    public void Awake() => Reset();

    public void Reset() => _hp = MaxHP;

    public void Damage(int amount) => HP -= amount;


    public void Heal(int amount) => HP += amount;

}
