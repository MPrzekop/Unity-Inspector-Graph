using UnityEngine;


[System.AttributeUsage(System.AttributeTargets.Field)]
public class GraphAttribute : PropertyAttribute
{
    public readonly string MethodName;
    public float start, end;
    public float height = 200;
    public int samples=300;
    public GraphAttribute(string MethodName, float start = 0, float end = 1, float rectHeight = 200,int samples=300)
    {
        this.MethodName = MethodName;
        this.end = end;
        this.start = start;
        this.height = rectHeight;
        this.samples = samples;
    }
}