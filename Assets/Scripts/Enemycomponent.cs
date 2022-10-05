using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemycomponent : MonoBehaviour
{
    [SerializeField] int hp = 100;
    Animator anit;

    bool isDead = false;
    bool isSinking = false;
    float sinkSpeed = 0.5f;     // 죽었을때 바닥아래로 사라지는 속도

    SkinnedMeshRenderer smr;    //3D 모델을 담아둘 변수
    [SerializeField] Material[] materials;      //원래 재질의 매터리얼과 히트 시 변경해 줄 매터리얼을 담아둘 배열

    [SerializeField] GameObject dmgText;        //데미지 텍스트를 담아둘 변수
    [SerializeField] float dmgTextYPos = 1.5f;  //데미지 텍스트 Y축 위치

    // Start is called before the first frame update
    void Start()
    {
        anit = GetComponent<Animator>();
        smr = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Sinking();
    }

    public void TakeDamage(int dmg, bool isCri = false)
    {
        if (isDead) return;

        hp -= dmg;
        StartCoroutine(HitColorChange());
        GameObject dText = Instantiate(dmgText, new Vector3(transform.position.x, transform.position.y + dmgTextYPos, transform.position.z),
            Quaternion.identity, transform);    //데미지 텍스트를 생성

        if (!isCri)
        {
            dText.GetComponentInChildren<TextMesh>().text = "-" + dmg.ToString();
        }
        else
        {
            dText.GetComponentInChildren<TextMesh>().fontSize = 70;
            dText.GetComponentInChildren<TextMesh>().color = Color.yellow;
            dText.GetComponentInChildren<TextMesh>().text = "CRITICAL\n-" + dmg.ToString();
        }

        

        Destroy(dText, 0.2f);                   //데미지 텍스트 삭제

        if (hp <= 0) Death();
    }

    void Death()
    {
        isDead = true;
        anit.SetBool("isDead", isDead);
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }

    public void StartSinking()
    {
        isSinking = true;
        Destroy(gameObject, 2);
    }

    void Sinking()
    {
        if(isSinking)
        {
            transform.Translate(Vector3.down * sinkSpeed * Time.deltaTime);
        }
    }

    IEnumerator HitColorChange()
    {
        smr.material = materials[1];
        yield return new WaitForSeconds(0.1f);
        smr.material = materials[0];
    }
}
