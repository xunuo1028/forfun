using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIBattleControl : MonoBehaviour {

    public Transform UIPool;
    public Transform battleSide;
    public Camera camera;
    private List<Transform> roles;
    private List<Transform> huds;

    private static UIBattleControl instance;

    public static UIBattleControl Instance()
    {
        if (instance == null)
        {
            instance = new UIBattleControl();
        }
        return instance;
    }

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
        roles = new List<Transform>();
        huds = new List<Transform>();
	}

	// Update is called once per frame
	void Update () {
        UpdateHUDPerFrame();
	}

    public void InitHUD(Test role)
    {

        Transform hud_Clone = GameObject.Instantiate(UIPool.Find("HUD"));
        hud_Clone.name = "HUD_" + role.transform.name;
        hud_Clone.SetParent(battleSide.Find(role.battleSide.ToString()));
        hud_Clone.localPosition = Vector3.zero;
        hud_Clone.localScale = Vector3.one;
        Vector3 roleScreenPos = Camera.main.WorldToScreenPoint(role.transform.position);
        hud_Clone.localPosition = new Vector3(roleScreenPos.x - Screen.width / 2, roleScreenPos.y - Screen.height / 2 + 200f, 0);
        roles.Add(role.transform);
        huds.Add(hud_Clone);
    }

    private void UpdateHUDPerFrame()
    {
        Vector3 roleScreenPos;
        for(int i = 0; i < roles.Count; i++)
        {
            roleScreenPos = Camera.main.WorldToScreenPoint(roles[i].position);
            float xOffset = (roleScreenPos.x - Screen.width / 2) / (Screen.width / 2);
            float yOffset = (roleScreenPos.y - Screen.height / 2) / (Screen.height / 2);
            Vector2 size = huds[i].GetComponent<RectTransform>().sizeDelta;
            huds[i].localPosition = new Vector3(roleScreenPos.x - Screen.width / 2 + size.x * xOffset , roleScreenPos.y - Screen.height / 2 + 200f - size.y * yOffset, 0);

        }
    }
}
