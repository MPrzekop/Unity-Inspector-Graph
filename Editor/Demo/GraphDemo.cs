using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mprzekop.unityinspectorgraph.demo
{
    public class GraphDemo : MonoBehaviour
    {
        public AnimationCurve curve;
        public Color curveColor;
        [Range(0, 10f)] public float width, yPadding;

        [SerializeField, Graph(MethodName: "F",start:-5,end: 5,rectHeight:200,samples:400)] public float dummyFull;
        
        [SerializeField, Graph("F")] public float dummy;
       
        public float F(float x)
        {
            return Mathf.Sin(x) + Mathf.Sin(x*25)*0.2f;
        }
    }
}