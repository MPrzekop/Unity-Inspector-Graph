using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mprzekop.unityinspectorgraph.demo
{
    public class GraphDemo : MonoBehaviour
    {
        public AnimationCurve curve;
        public Color curveColor;
        [Range(0, 10f)] public float width,yPadding;
    }
}