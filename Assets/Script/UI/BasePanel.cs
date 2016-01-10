using UnityEngine;
using System.Collections;

public enum PANEL_TYPE
{
    NONE,
    TAP,
    POPUP,
}

public class BasePanel : MonoBehaviour {

    public PANEL_TYPE panel_type = PANEL_TYPE.NONE;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
