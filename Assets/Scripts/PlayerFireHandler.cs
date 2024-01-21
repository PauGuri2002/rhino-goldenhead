using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireHandler : MonoBehaviour
{
    public ArmatosteSystem armatoste;

    void OnFire(){
        armatoste.Fire();
    }
}
