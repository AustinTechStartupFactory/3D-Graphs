using UnityEngine;
using System.Collections;

public abstract class Grapher : MonoBehaviour {
    public abstract int resolution { get; set; }
    public abstract float threshold { get; set; }
    public abstract bool absolute { get; set; }
    public abstract void SetFunction(int ID);
    //public abstract void SetResolution();
   // public abstract void SetThreshold();
   // public abstract void ToggleAbsolute();

}
