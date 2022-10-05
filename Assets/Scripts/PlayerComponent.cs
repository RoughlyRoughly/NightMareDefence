using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PlayerComponent : MonoBehaviour
{
    [SerializeField] int hp = 100;
    [SerializeField] int maxHp = 100;
    [SerializeField] int limitMaxHpLv = 6;
    int maxHpLv = 1;

    bool isDead = false;
    public bool DEAD { get { return isDead; } }

    Animator anit;
    SkinnedMeshRenderer smr;
    [SerializeField] Material[] materials;


    // Start is called before the first frame update
    void Start()
    {
        anit = GetComponent<Animator>();
        smr = GetComponentInChildren<SkinnedMeshRenderer>();
        UIManager.i.InitHpUI(maxHp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int dmg)
    {
        if (isDead) return;

        hp -= dmg;
        UIManager.i.SetHpUI(hp);
        StartCoroutine(HitColorChange());

        if (hp <= 0) Death();
    }

    void Death()
    {
        isDead = true;
        anit.SetTrigger("Death");
        GameManager.i.GameOver();
        //���� �ִϸ��̼� ����
    }

    IEnumerator HitColorChange()
    {
        smr.material = materials[1];
        yield return new WaitForSeconds(0.1f);
        smr.material = materials[0];
    }

    public void GetItemHp(int _hp)
    {
        hp += _hp;                      //hp����
        if (hp > maxHp) hp = maxHp;     //hp�� maxHp���� ������ hp�� maxHp�� ����

        UIManager.i.SetHpUI(hp);                //hpUI ����
        UIManager.i.PrintHpText("HP+", _hp);    //hpText ���
    }

    public void GetItemMaxHp(int _val)
    {
        if (maxHpLv >= limitMaxHpLv) return;
        maxHpLv++;  //�ƽ� Hp ���� ����
        maxHp += _val;  //�ƽ� Hp ����

        UIManager.i.SetStatUI(ITEM_STAT_TYPE.MAX_HP, maxHpLv.ToString(),maxHp);   //UI ����
    }
}
