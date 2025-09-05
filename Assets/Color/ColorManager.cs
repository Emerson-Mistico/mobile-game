using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Ebac.Core.Singleton;

public class ColorManager : Singleton<ColorManager>
{
    public List<Material> materials;
    public List<ColorSetup> colorSetups;

    public void ChangeColorBytype(ArtManager.ArtType artType)
    {
        Debug.Log("Cheguei aqui 2 -> " + artType);

        var setup = colorSetups.Find(i => i.artType == artType);

        for (int i = 0; i < materials.Count; i++)
        {
            Debug.Log("Cheguei aqui 3 -> " + i);

            materials[i].SetColor("_BaseColor", setup.colors[i]);
        }
    }
}

[System.Serializable]
public class ColorSetup
{
    public ArtManager.ArtType artType;
    public List <Color> colors;
}
