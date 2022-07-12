using System.Collections;
using System.Collections.Generic;
using mprzekop.unityinspectorgraph;
using UnityEngine;

namespace mprzekop.unityinspectorgraph.graph
{
    public class LineFunction : MonoBehaviour
    {
        public static Vector3[] SampleLineFunction(LineFunctionData data, int samples = 100)
        {
            Vector3[] points = new Vector3[samples];
            for (int i = 0; i < samples; i++)
            {
                var curPos = ((float) i).Remap(0, samples-1, data.FunctionRangeStart,
                    data.FunctionRangeEnd);
                var val = data.Function.Invoke(curPos);
                points[i] = new Vector3(curPos, val);
            }

            return points;
        }
    }
}