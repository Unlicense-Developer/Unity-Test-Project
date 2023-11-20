using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champion : MonoBehaviour
{
    struct Stat
    {
        string name;
        int ad;
        int ap;
        int armor;
        int resist;
        float atkSpeed;
        float abilHaste;
        float criticalChance;
        int criticalDamage;

    }

    public Material outline;
    Renderer renderers;

    List<Material> materialList = new List<Material>();

    // Start is called before the first frame update
    void Start()
    {
        outline = new Material(Shader.Find("Custom/Outline Shader"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        renderers = this.GetComponent<Renderer>();

        materialList.Clear();
        materialList.AddRange(renderers.sharedMaterials);
        materialList.Add(outline);

        renderers.materials = materialList.ToArray();

        Debug.Log("마우스를 올림");
    }

    private void OnMouseDrag()
    {
        
    }

    private void OnMouseExit()
    {
        Renderer renderer = this.GetComponent<Renderer>();

        materialList.Clear();
        materialList.AddRange(renderer.sharedMaterials);
        materialList.Remove(outline);

        renderer.materials = materialList.ToArray();

        Debug.Log("마우스를 뗌");
    }
}
