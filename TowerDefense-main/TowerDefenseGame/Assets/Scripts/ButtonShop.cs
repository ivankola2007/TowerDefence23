using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShop : MonoBehaviour
{
    [SerializeField]
    private Text costText;
    [SerializeField]
    private int cost;
    [SerializeField]
    private int buildIndex;

    [SerializeField]
    private Button button;
    public void Awake ()
    cosText.text = cost.ToString();
    private void Start()
    {
        costText.text = cost.ToString();
        //button.onClick.AddListener();
    }

    private void SetBuildTurret(int cost, int buildIndex)
    {
      costText.text = cost.ToString();
      var buildManager = BuildManager.Instance;
    buton.onCliock.AddListenner(() => buildManager.SetBuildTurret(cost, buildIndex));
    }
}
