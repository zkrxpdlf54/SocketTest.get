using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum UI_PANEL
{
    NONE,
    LOGIN_PANEL,
    TAP_PANEL,
    FRENDLIST_PANEL,
    CHAT_PANEL,
}

public class UIManager : MonoBehaviour {

    GameObject _rootCanvas;
    public GameObject RootCanvas
    {
        get
        {
            if (_rootCanvas == null)
                _rootCanvas = GameObject.Find("Canvas");
            return _rootCanvas;
        }
    }

    private Dictionary<UI_PANEL, string> panelTable = new Dictionary<UI_PANEL, string>();
    Dictionary<UI_PANEL, GameObject> activePanel = new Dictionary<UI_PANEL, GameObject>();

    void InitPanelTable()
    {
        panelTable.Add(UI_PANEL.LOGIN_PANEL, "LoginPanel");
        panelTable.Add(UI_PANEL.TAP_PANEL, "TapPanel");
        panelTable.Add(UI_PANEL.FRENDLIST_PANEL, "FriendListPanel");
    }

    public GameObject ShowPanel(UI_PANEL panel, object data = null)
    {
        GameObject panelGO = LoadPanel(panel);

        switch (panelGO.GetComponent<BasePanel>().panel_type)
        {
            case PANEL_TYPE.TAP:
                if (GetPanel(UI_PANEL.TAP_PANEL) == null)
                    LoadPanel(UI_PANEL.TAP_PANEL);
                break;
        }
        return panelGO;
    }

    public GameObject GetPanel(UI_PANEL panel)
    {
        if (activePanel.ContainsKey(panel) && activePanel[panel] != null)
            return activePanel[panel];
        return null;
    }

    public GameObject LoadPanel(UI_PANEL panel)
    {
        GameObject panelGO = Resources.Load("Prefab/" + panelTable[panel]) as GameObject;
        if (panelGO == null)
            Debug.LogError("Panel Load Fail!! Name: [" + panelTable[panel] + "] NULL");
        return panelGO;
    }
}
