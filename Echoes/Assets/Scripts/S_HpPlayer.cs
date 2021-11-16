using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_HpPlayer : MonoBehaviour
{
    [SerializeField] private int _maxHP;
    private int _hp;

    private void Start()
    {
        _hp = _maxHP;
        Debug.Log("HP:" + _hp); //DEBUG line
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))  // start of DEBUG Section
        {
            HurtPlayerCharacter();
        }  //end of DEBUG Section
    }

    public void HurtPlayerCharacter()
    {
        _hp--;
        if(_hp <= 0)
        {
            _hp = 0;
        }
        Debug.Log("HP:"+_hp); //DEBUG line
    }

    public void HealPlayerCharacter(int hpAmount)
    {
        _hp += hpAmount;
        if(_hp>_maxHP)
        {
            _hp = _maxHP;
        }
    }

    private void RecoverAllHP()
    {
        _hp = _maxHP;
    }
}
