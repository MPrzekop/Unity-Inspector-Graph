using System.Collections;
using System.Collections.Generic;
using System.Linq;
using mprzekop.unityinspectorgraph.graph;
using UnityEditor;
using UnityEngine;

namespace mprzekop.unityinspectorgraph.demo
{
    [CustomEditor(typeof(GraphDemo))]
    public class GraphDemoEditor : Editor
    {
        private bool orthoLast = false;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GraphDemo d = target as GraphDemo;
            EditorGUILayout.LabelField("interactive graph");
            if (d.curve != null && d.curve.keys.Length > 0)
            {
                GraphDrawer.DrawGraph(d.yPadding,new LineData()
                {
                    color = d.curveColor,
                    points = getPoints(d.curve),
                    width = d.width
                });
            }
            GUI.color=Color.white;
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("scripted graphs");


            GraphDrawer.DrawGraph(100, new LineFunctionData((x) => { return Mathf.Sin(x); }, Color.green, 2f, -Mathf.PI,
                Mathf.PI));

            GraphDrawer.DrawGraph(100, new LineFunctionData((x) => { return Mathf.Pow(x - Mathf.PI, 2f); }, Color.red,
                2f,
                Mathf.PI,
                2 * Mathf.PI), new LineFunctionData((x) => { return Mathf.Sin(x); }, Color.white, 2f, -Mathf.PI,
                Mathf.PI));
            GraphDrawer.DrawGraph(300, new LineFunctionData((x) => { return Mathf.Sin(x) + Mathf.Sin(x * 24) * 0.2f; },
                Color.white,
                3f, -Mathf.PI,
                Mathf.PI), new LineFunctionData((x) => { return Mathf.Sin(x); }, Color.green, 1.5f, -Mathf.PI,
                Mathf.PI));

            orthoLast = EditorGUILayout.Toggle("ortho graph", orthoLast);
            GraphDrawer.DrawGraph(300,20,20,orthoLast, new LineFunctionData((x) =>
            {
                return Mathf.Sqrt(1 - x * x + 2 * x * 0 - 0);
            }, Color.black, 3f,-1,1),new LineFunctionData((x) =>
            {
                return -Mathf.Sqrt(1 - x * x + 2 * x * 0 - 0);
            }, Color.black, 3f,-1,1));

        }

        Vector3[] getPoints(AnimationCurve curve, int samples = 200)
        {
            Vector3[] points = new Vector3[samples];
            float xMin = curve.keys.Min(x => x.time);
            float xMax = curve.keys.Max(x => x.time);
            float length = Mathf.Abs(xMax - xMin) / samples;
            for (int i = 0; i < samples; i++)
            {
                points[i] = new Vector3(xMin + i * length, curve.Evaluate(xMin + i * length));
            }

            return points;
        }
    }
}