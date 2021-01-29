using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInfoUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textStats;
    private GameObject panelHide;

    public void SetVisiblePanelStats(string strPaste)
    {
        this.textStats.text = strPaste;
        panelHide.SetActive(true);
    }
    public void DisablePanel()
    {
        panelHide.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        panelHide = transform.GetChild(0).gameObject;
        DisablePanel();
    }

}
