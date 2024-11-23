using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private Color hoverColor;
    [SerializeField]
    private Color defaultColor;

    [SerializeField]
    private GameObject turretPrefab;

    private GameObject selectedNode;

    private bool canBuild;
    private int turretIndex, cost;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.tag == "Node" && canBuild)
            {
                var node = hit.collider.GetComponent<BuildSettings>();
                if (node.structure == null)
                {
                    selectedNode = hit.collider.gameObject;
                    selectedNode.GetComponent<MeshRenderer>().material.color = hoverColor;
                }                
            }
            else
            {
                if(selectedNode != null)
                {
                    selectedNode.GetComponent<MeshRenderer>().material.color = defaultColor;
                    selectedNode = null;
                }                
            }
        }

        if (Input.GetMouseButtonDown(0) && selectedNode != null)
        {
            selectedNode.GetComponent<BuildSettings>().StartBuild(turretPrefab, 0.35f, cost, turretIndex);
            canBuild = false;
            InterstitialAd.Instance.TowerWasBuild();
        }
    }

    public void SetBuildTurret(int cost, int buildIndex)
    {
        canBuild = true;
        turretIndex = buildIndex;
        this.cost = cost;
    }
}
