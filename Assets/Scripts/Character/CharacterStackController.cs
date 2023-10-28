using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStackController : MonoBehaviour
{
    public List<GameObject> blocks = new List<GameObject>();
    GameObject lastCube;

    void Start()
    {
        UpdateLastBlockObject();
    }

    public void LastAddedCubes(GameObject cube)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z);
        cube.transform.position = new Vector3(lastCube.transform.position.x, lastCube.transform.position.y - 2.0f, lastCube.transform.position.z);
        cube.transform.SetParent(transform);
        blocks.Add(cube);
        UpdateLastBlockObject();
    }

    public void DecreaseBlock(GameObject cube)
    {
        cube.transform.parent = null;
        blocks.Remove(cube);
        UpdateLastBlockObject();
    }



    /// <summary>
    /// En alttaki küpü belirmeye yarar.
    /// </summary>
    public void UpdateLastBlockObject()
    {
        lastCube = blocks[blocks.Count - 1];
    }


}
