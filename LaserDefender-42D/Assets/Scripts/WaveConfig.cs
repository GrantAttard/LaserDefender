using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Normal scripts are of type MonoBehaviour since they are used to control objects in our scene/hierarchy
 * 
 * ScriptableObject scripts are used to solve the issue of Prefabs since every time
 * a prefab is cloned, a copy of all the data for the prefab is generated and using up
 * the memory. There are certain values which need to be repeated and copied
 * for every clone but there is certain values which remain the same fora ll prefabs.
 * A ScriptableObject ensures taht teh specified values are created only once (Regardless
 * of how many prefab clones there are) and the values can be shared by all of the clones.
 * 
 */

[CreateAssetMenu(menuName = "Enemy Wave Config")]

public class WaveConfig : ScriptableObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
