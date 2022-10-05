using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum ITEM_STAT_TYPE
{
    ATTACK,
    ATTACK_SPEED,
    CRITICAL,
    SPEED,
    MAX_HP
}

public class UIManager : MonoBehaviour
{
    public static UIManager i;

    [SerializeField] GameObject hpUI;
    [SerializeField] GameObject statUI;
    [SerializeField] Text infoT;

    // Start is called before the first frame update
    void Start()
    {
        i = this;
        statUI = GameObject.Find("StatUI");
        infoT = GameObject.Find("InfoText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitHpUI(int maxHp)
    {
        hpUI.GetComponent<Slider>().maxValue = maxHp;
        hpUI.GetComponent<Slider>().value = maxHp;
        hpUI.GetComponentInChildren<Text>().text = "HP" + maxHp.ToString();
    }

    public void SetHpUI(int hp)
    {
        hpUI.GetComponent<Slider>().value = hp;
        hpUI.GetComponentInChildren<Text>().text = "HP" + hp.ToString();
    }

    public void PrintHpText(string str, int _hp)
    {
        StartCoroutine(HpText(str,_hp));
    }

    IEnumerator HpText(string str, int _hp)
    {
        hpUI.GetComponentInChildren<Text>().text = str + _hp.ToString();
        yield return new WaitForSeconds(1);
        hpUI.GetComponentInChildren<Text>().text = "HP" + hpUI.GetComponent<Slider>().value.ToString();
    }

    public void SetStatUI(ITEM_STAT_TYPE type, string lv, int maxHp = 0)
    {
        string info = "";

        statUI.transform.GetChild((int)type).GetComponentInChildren<Text>().text = "LV." + lv;      //StatUI 갱신
        if (type == ITEM_STAT_TYPE.MAX_HP)
        {
            hpUI.GetComponent<Slider>().maxValue = maxHp;       //Hp바 갱신
            info = "MAX HP\nLEEVEL UP";
        }
        else if (type == ITEM_STAT_TYPE.ATTACK) info = "ATTACK\nLEVEL UP";
        else if (type == ITEM_STAT_TYPE.ATTACK_SPEED) info = "ASPEED\nLEVEL UP";
        else if (type == ITEM_STAT_TYPE.CRITICAL) info = "CRITICAL\nLEVEL UP";
        else info = "SPEED\nLEVEL UP";

        StartCoroutine(Info(info));
    }

    IEnumerator Info(string _str)
    {
        infoT.text = _str;
        infoT.enabled = true;
        yield return new WaitForSeconds(1);
        infoT.enabled = false;
    }
}
