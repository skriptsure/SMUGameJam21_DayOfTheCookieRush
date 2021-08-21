using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMeshPicker : MonoBehaviour
{
    [System.Serializable]
    public class Option
    {
        public Mesh mesh;
        public Material[] materials;
    }

    public Option[] optionsToChoose;
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter mesh = GetComponent<MeshFilter>();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (mesh && optionsToChoose.Length > 0)
        {
            int index = Random.Range(0, optionsToChoose.Length);
            mesh.mesh = optionsToChoose[index].mesh;


            meshRenderer.materials = optionsToChoose[index].materials;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
