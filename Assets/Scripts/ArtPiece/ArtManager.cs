using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Ebac.Core.Singleton;

public class ArtManager : Singleton<ArtManager>
{
    public enum ArtType
    {
        TYPE_01,
        TYPE_02,
        TYPE_03,
        TYPE_04
    }    

    public List<ArtSetup> artSetups;   
    public ArtSetup GetSetupByType(ArtType artType)
    {
        return artSetups.Find(i=>i.artType == artType);
    }
    

}

[System.Serializable]
public class ArtSetup
{
    public ArtManager.ArtType artType;
    public GameObject gameObject;
}
