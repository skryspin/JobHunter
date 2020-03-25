using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebakeCollider : MonoBehaviour
{
    public SkinnedMeshRenderer skin;
    public MeshCollider meshCollider;
    
    
    /* Bakes the skin (including rig deform) into the meshCollider.
     * This is resource intensive and should NOT be called often.
     **/ 
    public void Rebake() {
        Mesh newmesh = new Mesh(); 
        skin.BakeMesh(newmesh); //bakes current renderer into newmesh
        meshCollider.sharedMesh = newmesh; //updates collider based on position of skin
        fixScale();
    }
    
    private void fixScale() {
        GameObject g = new GameObject();
        g.transform.parent = skin.gameObject.transform; //parents new gameobject to skin's object
        g.AddComponent<MeshCollider>().sharedMesh = meshCollider.sharedMesh; //adds meshcollider to new gameobject
        Destroy(meshCollider); //destroys uneeded mesh
        
        
        //setting up new gameobject transform
        g.transform.localScale = new Vector3(0.13821680965f, 0.13821680965f, 0.13821680965f); //scale new gameobject
        g.transform.localRotation = new Quaternion();
        g.transform.localPosition = new Vector3(0,0,0);
        g.AddComponent<Rigidbody>().isKinematic = true; 
        
        
    }
}
