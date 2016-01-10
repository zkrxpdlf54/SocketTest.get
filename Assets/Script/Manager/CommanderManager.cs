using UnityEngine;
using System.Collections;

public class CommanderManager : Singleton<CommanderManager> {
    
    private UIManager uiManager;
    public UIManager UIManager
    {
        get
        {
            return this.uiManager;
        }
    }


    public override void Init()
    {
        uiManager = this.GetComponent<UIManager>();
    }

    public override void OnApplicationQuit()
    {
        uiManager = null;

        base.OnApplicationQuit();
    }

}
