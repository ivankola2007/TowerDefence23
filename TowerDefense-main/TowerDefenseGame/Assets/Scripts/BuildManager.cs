using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
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

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.tag == "Node")
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
            selectedNode.GetComponent<BuildSettings>().StartBuild(turretPrefab, 0.35f);
        }
    }
}
