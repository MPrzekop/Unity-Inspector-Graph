using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using mprzekop.unityinspectorgraph.graph;
using UnityEditor;
using UnityEngine;


[System.AttributeUsage(System.AttributeTargets.Field)]
public class GraphAttribute : PropertyAttribute
{
    public readonly string MethodName;
    public float start, end;
    public float height = 200;

    public GraphAttribute(string MethodName, float start = 0, float end = 1, float rectHeight = 200)
    {
        this.MethodName = MethodName;
        this.end = end;
        this.start = start;
        this.height = rectHeight;
    }
}

[CustomPropertyDrawer(typeof(GraphAttribute))]
public class GraphAttributePropertyDrawer : PropertyDrawer
{
    private MethodInfo _eventMethodInfo = null;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return (attribute as GraphAttribute).height;
    }

    public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
    {
        var graphAttribute = attribute as GraphAttribute;
        EditorGUI.LabelField(position, graphAttribute.MethodName + "(x)");
        var ownerType = prop.serializedObject.targetObject.GetType();
        if (_eventMethodInfo == null)
        {
            _eventMethodInfo = ownerType.GetMethod(graphAttribute.MethodName, types: new[] {typeof(float)});
            if (_eventMethodInfo != null)
            {
                if (_eventMethodInfo.ReturnType == typeof(float))
                {
                    // var d= (Func<float,float>)_eventMethodInfo.CreateDelegate(typeof(Func<float, float>));
                    // Debug.Log();
//                    EditorGUILayout.LabelField(graphAttribute.MethodName);

                    GraphDrawer.DrawGraph(new LineFunctionData(
                        (x) =>
                        {
                            return (float) _eventMethodInfo.Invoke(prop.serializedObject.targetObject,
                                new[] {(object) x});
                        }, Color.white, 2f, graphAttribute.start, graphAttribute.end));
                }
                else
                {
                    EditorGUILayout.LabelField("Wrong return type - needs to be float");
                }
            }
            else
            {
                var cache = GUI.color;
                EditorGUILayout.LabelField("Wrong method name or method declaration - expected float F(float x)");
                GUI.color = cache;
            }
        }
        else
        {
            if (_eventMethodInfo.ReturnType == typeof(float))
            {
                // var d= (Func<float,float>)_eventMethodInfo.CreateDelegate(typeof(Func<float, float>));
                // Debug.Log();
//                    EditorGUILayout.LabelField(graphAttribute.MethodName);

                GraphDrawer.DrawGraphAttribute(position,
                    new LineFunctionData(
                        (x) =>
                        {
                            return (float) _eventMethodInfo.Invoke(prop.serializedObject.targetObject,
                                new[] {(object) x});
                        }, Color.white, 2f, graphAttribute.start, graphAttribute.end));
            }
            else
            {
                EditorGUILayout.LabelField("Wrong return type - needs to be float");
            }
        }
    }
}