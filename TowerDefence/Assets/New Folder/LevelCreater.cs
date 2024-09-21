using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public  int NODE_GRID_ROW_COUNT = 4;
    public  int NODE_GRID_COLUMN_COUNT = 4;
    [SerializeField]
    [Space(15)]
    [SerielizeField]
    private GameObject nodePrefab;
    [SerializeField]

     private GameObject planePrefab;
     [Space(15)]
     [SerializeField]

    // Start is called before the first frame update
   
    {
        CreateNodes();
    }

    // Update is called once per frame
    [ContextMenu("Create Nodes")]
    private void CreateNodes()
    {
       for (int x= 0; x < NODE_GRID_ROW_COUNT; x++)
         for (int z= 0; z < NODE_GRID_COLUMN_COUNT; z++)
        
        Instantiate(nodePrefab, new Vector3(x, 0, z), Quaternion.identity);
        GameObject plane = Instantiate(plane Prefab, new Vector3 ((NODE GRID ROW COUNT = offset)/2-1, 0,(NODE GRID_COLUMN COUNT * offset)/ 2-1), Quaternion. identity, nodeParent); 
        plane.transform.localScale = new Vector3(0.2f * NODE GRID ROW COUNT, plane.transform.localScale.y,0.2f * NODE GRID COLUMN_COUNT);
        for (int x; NODE GRIO_ROM COUNT; x++)
        for (int zB z NODE GRID COLUMN COUNT; z++)
        GameObject obj Instantiate(nodePrefab, new Vector3(x * offset, 8, z offset),Quaternion.identity, nodeParent);
        obj.name"Node: = + x + "  +z);
         
    }
    
}


