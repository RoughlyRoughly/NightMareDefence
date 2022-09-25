using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    [SerializeField] int atk = 20;      //공격력
    [SerializeField] float atkRate = 0.2f;  //공격 딜레이
    [SerializeField] float range = 100;      //공격 사거리
    float time = 0;        //공격 딜레이 체크할 변수

    Ray shootRay;           //발사 레이 담아둘 변수
    RaycastHit hit;         //레이에 충돌된 오브젝트를 담아둘 변수
    int enemyLayerMask;     //레이어가 enemy인 녀석만 충돌되도록 마스크 값을 넣어둘 변수    

    LineRenderer shootLine;
    float shootWidth;       //라인의 크기

    Light light;
    [SerializeField] float ligthInten = 10;       //라이트 밝기

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
        light.intensity = ligthInten;                   //라이트 밝기 재설정

        shootLine.startWidth = shootWidth;                   //라인 크기 재설정
        shootLine.SetPosition(0, transform.position);   //라인 시작지점 셋팅

        shootRay.origin = transform.position;           //레이 시작지점 셋팅
        shootRay.direction = transform.forward;         //레이가 나아갈 방향 셋팅

        if(Physics.Raycast(shootRay, out hit, range,enemyLayerMask))
        {
            shootLine.SetPosition(1, hit.point);        //레이에 맞은 오브젝트 위치를 넣어줌
            hit.transform.GetComponent<Enemycomponent>().TakeDamage(atk);   //적의 데미지 입는 함수 호출
        }
        else
        {
            shootLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            //사거리만큼 더해서 라인을 그려줌
        }

        time = 0;
    }

    void EffectScaleDown()
    {
        shootLine.startWidth = Mathf.Lerp(shootLine.startWidth, 0, 10 * Time.deltaTime);   //슛라인의 크기를 줄여줌.
        light.intensity = Mathf.Lerp(light.intensity, 0, 10 * Time.deltaTime);             //라이트의 밝기를 줄여줌.

    }
}
