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
//parametrised graph copying animation curve
            if (d.curve != null && d.curve.keys.Length > 0)
            {
                GraphDrawer.DrawGraph(d.yPadding, new LineData()
                {
                    color = d.curveColor,
                    points = getPoints(d.curve),
                    width = d.width
                });
            }

        
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("scripted graphs");

//simple sine graph
            GraphDrawer.DrawGraph(100, new LineFunctionData((x) => { return Mathf.Sin(x); }, Color.green, 2f, -Mathf.PI,
                Mathf.PI));


            DrawStitched();

            DrawOverlayed();


            DrawCircle();
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

        void DrawStitched()
        {
            //sine graph with exp stitched to the end
            GraphDrawer.DrawGraph(100, new LineFunctionData((x) => { return Mathf.Pow(x - Mathf.PI, 2f); }, Color.red,
                2f,
                Mathf.PI,
                2 * Mathf.PI), new LineFunctionData((x) => { return Mathf.Sin(x); }, Color.white, 2f, -Mathf.PI,
                Mathf.PI));
        }

        void DrawOverlayed()
        {
            //overlayed 2 functions
            GraphDrawer.DrawGraph(300, new LineFunctionData((x) => { return Mathf.Sin(x) + Mathf.Sin(x * 24) * 0.2f; },
                Color.white,
                3f, -Mathf.PI,
                Mathf.PI), new LineFunctionData((x) => { return Mathf.Sin(x); }, Color.green, 1.5f, -Mathf.PI,
                Mathf.PI));
        }

        void DrawCircle()
        {
            //circle graph with ortho toggle
            orthoLast = EditorGUILayout.Toggle("ortho graph", orthoLast);
            float radius = 1;
            var topCircle = new LineFunctionData((x) => { return Mathf.Sqrt(radius - x * x + 2 * x * 0 - 0); },
                Color.black, 3f, -1,
                1);
            var bottomCircle = new LineFunctionData((x) => { return -Mathf.Sqrt(radius - x * x + 2 * x * 0 - 0); },
                Color.black, 3f,
                -1,
                1);
            GraphDrawer.DrawGraph(samples: 300, windowPadding: 20, yRectPadding: 20, orthoLast, topCircle,
                bottomCircle
            );
        }
    }
}