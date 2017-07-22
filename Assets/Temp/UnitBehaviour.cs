using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour {

    public float moveSpeed = 5f;
    public int unitType = 0;    //0:近战  1：远程物理  2：远程法术  3：远程增益  4：近距离建造     5：远距离建造
    public MyWeapon selfWeapon;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Move(Vector3 targetPos, int targetType)
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, Time.deltaTime * moveSpeed);
        if ((unitType == 0 || unitType == 4) && targetType != 0)
        {
            if (Vector3.Distance(this.transform.position, targetPos) < 2f)
            {
                this.transform.GetComponent<Test>().allowMove = false;
                this.transform.GetComponent<Test>().ac.EndAnimation();
                if (targetType == 1)
                {
                    this.transform.GetComponent<Test>().ac.EndAnimation();
                }
                else if(targetType == 2)
                {
                    Attack();
                }
                else if(targetType == 3)
                {
                    Attack();
                }
            }
        }
        else if(targetType == 0)
        {
            if (Vector3.Distance(this.transform.position, targetPos) < 0.1f)
            {
                this.transform.GetComponent<Test>().allowMove = false;
                this.transform.GetComponent<Test>().ac.EndAnimation();
            }
        }

    }

    public void Attack()
    {
        this.transform.GetComponent<Test>().ac.Play("Melee Right Attack 01", 4);
    }

    IEnumerator TimeCount(float time)
    {
        yield return new WaitForSeconds(time);
        selfWeapon.SwitchIsCheck(false);
    }

    public void BeHit(Transform hiter)
    {
        this.transform.GetComponent<UnitAttributes>().HP = this.transform.GetComponent<UnitAttributes>().HP - hiter.GetComponent<UnitAttributes>().PAttack;
    }
}
