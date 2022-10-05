using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    [SerializeField] int atk = 20;      //���ݷ�
    [SerializeField] int limitAtkLv = 6;
    int atkLv = 1;

    [SerializeField] float atkRate = 0.2f;  //���� ������
    [SerializeField] int limitAspdLv = 6;
    int aspdLv = 1;

    [SerializeField] float range = 100;      //���� ��Ÿ�
    float time = 0;        //���� ������ üũ�� ����

    [SerializeField] float critical = 60f;    //ũ��Ƽ�� Ȯ��
    [SerializeField] int limitCriLv = 6;
    int criLv = 1;

    Ray shootRay;           //�߻� ���� ��Ƶ� ����
    RaycastHit hit;         //���̿� �浹�� ������Ʈ�� ��Ƶ� ����
    int enemyLayerMask;     //���̾ enemy�� �༮�� �浹�ǵ��� ����ũ ���� �־�� ����    

    LineRenderer shootLine;
    float shootWidth;       //������ ũ��

    Light light;
    [SerializeField] float ligthInten = 10;       //����Ʈ ���

    private void Awake()
    {
        shootLine = GetComponent<LineRenderer>();
        shootWidth = shootLine.startWidth;
        light = GetComponent<Light>();       
        enemyLayerMask = LayerMask.GetMask("Enemy");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.i.GAMESTART || GameManager.i.GAMEOVER) return;

        time += Time.deltaTime;
        if (time > atkRate)
        {
            if(Input.GetMouseButtonDown(0)) Shoot();
        }

        if(shootLine.startWidth != 0) EffectScaleDown();
    }

    void Shoot()
    {
        light.intensity = ligthInten;                   //����Ʈ ��� �缳��

        shootLine.startWidth = shootWidth;                   //���� ũ�� �缳��
        shootLine.SetPosition(0, transform.position);   //���� �������� ����

        shootRay.origin = transform.position;           //���� �������� ����
        shootRay.direction = transform.forward;         //���̰� ���ư� ���� ����

        if(Physics.Raycast(shootRay, out hit, range,enemyLayerMask))
        {
            int cirAtk = atk;
            float num = Random.Range(0, 101);
            bool isCri = false;

            if(critical >= num)
            {
                isCri = true;
                cirAtk = atk * Random.Range(2, 5);
            }

            shootLine.SetPosition(1, hit.point);        //���̿� ���� ������Ʈ ��ġ�� �־���
            hit.transform.GetComponent<Enemycomponent>().TakeDamage(cirAtk,isCri);   //���� ������ �Դ� �Լ� ȣ��
        }
        else
        {
            shootLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            //��Ÿ���ŭ ���ؼ� ������ �׷���
        }

        time = 0;
    }

    void EffectScaleDown()
    {
        shootLine.startWidth = Mathf.Lerp(shootLine.startWidth, 0, 10 * Time.deltaTime);   //�������� ũ�⸦ �ٿ���.
        light.intensity = Mathf.Lerp(light.intensity, 0, 10 * Time.deltaTime);             //����Ʈ�� ��⸦ �ٿ���.

    }

    public void GetAttackItem(int val)
    {
        if (atkLv >= limitAtkLv) return;
        atkLv++;
        atk += val;

        UIManager.i.SetStatUI(ITEM_STAT_TYPE.ATTACK, atkLv.ToString());
    }

    public void GetItemAttackSpeed(float val)
    {
        if (aspdLv >= limitAspdLv) return;
        aspdLv++;
        atkRate -= val;

        UIManager.i.SetStatUI(ITEM_STAT_TYPE.ATTACK_SPEED, aspdLv.ToString());
    }

    public void GetItemCritical(float val)
    {
        if (aspdLv >= limitCriLv) return;
        criLv++;
        critical += val;

        UIManager.i.SetStatUI(ITEM_STAT_TYPE.CRITICAL, criLv.ToString());
    }
}
