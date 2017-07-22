using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyWeapon : MonoBehaviour {

    public int weaponType;  //0:近战武器    1:远程武器      2:远程魔法      3:近距离维修     4:远距离维修

    [SerializeField]
    public SubWeapon[] subWeapon;

    public Ray ray;
    public RaycastHit rh;
    public bool isCheck = true;
    public List<Transform> targets;
    public Test owner;
    public Transform debugCube;

	// Use this for initialization
	void Start () {
        targets = new List<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void SwitchIsCheck(bool value)
    {
        isCheck = value;
        if (isCheck)
        {
            targets.Clear();
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other == null)
        {
            Debug.Log("other == null");
            return;
        }

        if (other.tag == "Enemy")
        {
            other.transform.GetComponent<UnitBehaviour>().BeHit(owner.transform);
        }
    }

    

}
