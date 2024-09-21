using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreater : MonoBehaviour
{
    public  int NODE_GRID_ROW_COUNT = 4;
    public  int NODE_GRID_COLUMN_COUNT = 4;
    [SerializeField]
    private GameObject nodePrefab;
    // Start is called before the first frame update
    private void Start()
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

    
    }
    
}


