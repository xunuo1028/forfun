using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public UnitBehaviour model;
    public en_state curState;
    public ForFunAC ac;
    public float runSpeed = 5;
    [SerializeField]
    private Vector3 runTarget;
    public float distance = 10.0f;
    public float damping = 0.1f;
    public bool allowRotate = false;
    public bool allowMove = false;
    

    private Vector3 wantedPosition;
    private int targetType;

    public UnitAttributes ua;
    public MyWeapon mw;

    public Camera camera;

    public bool isDebug = true;

    private Vector3 pPos;

    public bool isNPC;
    public int battleSide;  //0：地面     1：我方    2：敌方    3：中立    4：中立物品（可破坏）      5：中立物品（不可破坏）

    private struct ActionBase
    {
        public int targetType;  //0：地面     1：我方    2：敌方    3：中立    4：中立物品（可破坏）      5：中立物品（不可破坏）
        public Vector3 targetPos;

    }

    public enum en_state
    {
        en_state_none,
        en_state_idel,
        en_state_walk,
        en_state_run,
        en_state_attack,
        en_state_hurt,
        en_state_skill,
        en_state_die
    };

	// Use this for initialization
	void Start () {
        curState = en_state.en_state_none;
        ua.HP = 10;
        ua.MP = 10;
        ua.PAgainst = 1;
        ua.MAgainst = 2;
        ua.PAttack = 1;
        ua.MAttack = 0.7f;

        pPos = model.transform.position;

        UIBattleControl.Instance().InitHUD(this);
	}
	
	// Update is called once per frame
    void Update()
    {
        //switch (curState)
        //{
        //    case en_state.en_state_none:
        //        break;
        //    case en_state.en_state_idel:
        //        curAnim.SetBool("Relax", true);
        //        transform.Translate(Vector3.zero);
        //        break;
        //    case en_state.en_state_walk:
        //        break;
        //    case en_state.en_state_run:
        //        curAnim.SetBool("Run", true);
        //        
        //        

        //        //model.Move(forward * runSpeed); 

        //        break;
        //    case en_state.en_state_skill:

        //        break;
        //    case en_state.en_state_attack:
        //        break;
        //    case en_state.en_state_die:
        //        transform.Translate(Vector3.zero);
        //        curState = en_state.en_state_none;
        //        break;
        //}

        //runByMouse();
        if (!isDebug)
        {
            if (Input.GetMouseButtonUp(0))
            {
                allowRotate = true;
                ActionBase click = new ActionBase();
                click = GetMousePosition(Input.mousePosition);
                wantedPosition = click.targetPos;
                targetType = click.targetType;
            }

            if (allowRotate)
            {
                allowMove = false;
                smoothRotate(wantedPosition, model.transform);
            }

            if (allowMove)
            {
                ac.Play("Run", 3);
                model.Move(wantedPosition, targetType);
            }
        }   
    }

    void LateUpdate()
    {
        if (!isNPC)
        {
            CameraControl(1, pPos, model.transform);
            pPos = model.transform.position;
        }

    }

    private ActionBase GetMousePosition(Vector3 input)
    {
        Ray ray = Camera.main.ScreenPointToRay(input);
        RaycastHit hit;
        ActionBase ab = new ActionBase();
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Terrain")
            {
                ab.targetType = 0;
                ab.targetPos = hit.point;
            }
            else if(hit.collider.tag == "Self")
            {
                ab.targetType = 1;
                ab.targetPos = hit.transform.position;
            }
            else if(hit.collider.tag == "Enemy")
            {
                ab.targetType = 2;
                ab.targetPos = hit.transform.position;
            }
            else if(hit.collider.tag == "M")
            {
                ab.targetType = 3;
            }
            else if(hit.collider.tag == "MItem")
            {
                ab.targetType = 4;
            }
            else if(hit.collider.tag == "MItemD")
            {
                ab.targetType = 5;
            }
            
        }
        return ab;
    }

    private void smoothRotate(Vector3 lookAtTarget, Transform frameTarget)
	{
        if (!frameTarget)
            return;

        Quaternion rotate = Quaternion.LookRotation(lookAtTarget - transform.position);
        transform.rotation = Quaternion.SlerpUnclamped(transform.rotation, rotate, Time.deltaTime * damping);
        double result = System.Math.Round(rotate.eulerAngles.y, 2) - System.Math.Round(transform.rotation.eulerAngles.y, 2);
        if (result < 0)
        {
            result = -result;
        }
        if(result < 30f)
        {
            transform.rotation = rotate;
            allowRotate = false;
            allowMove = true;
        }
	}

    public void CameraControl(int actionType, Vector3 lastPFramePosition, Transform moveOwner)
    {
        if(moveOwner.position == lastPFramePosition)
        {
            return;
        }

        Vector3 moveOffset = moveOwner.position - lastPFramePosition;
        Vector3 targetPos = camera.transform.position + moveOffset;
        camera.transform.position = Vector3.Lerp(targetPos, camera.transform.position, Time.deltaTime);

    }

}
