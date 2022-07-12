
# Unity inspector graph visualiser

 Draw any graph in your custom editor.
 
 <p align="center">
  <img src="https://github.com/MPrzekop/Unity-Inspector-Graph/blob/images/Editor/GIT%20images/Main.png" width="700" title="header image of overlayed sines">
 </p>
 
## Instalation
### Package Manager

Go to `Window -> Package Manager` and add from git [URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html) using this URL:

`https://github.com/MPrzekop/unity-inspector-graph-drawer.git`


## How to Use
### Attribute
Create Dummy field and give it attribute [Graph("Method name")]

template:

```
 [Graph("F")] public float dummy;
       
        public float F(float x)
        {
            return Mathf.Sin(x) * Mathf.Sin(x);
        }
```

full parameters `(Method name, function x start, function x end, rect height, sample count)`:

```
 [Graph(MethodName: "F",start:-5,end: 5,rectHeight:200,samples:400)] public float dummyFull;
```

![](https://github.com/MPrzekop/Unity-Inspector-Graph/blob/images/Editor/GIT%20images/AttributeVis.png)

Visualised method has to be declared as public `float MethodName(float x)`

### Custom editor
In custom editor create a call to `GraphDrawer.DrawGraph()` there are overloads for:
* array of Vector3 points
* arbitrary points wraper with line color and width
* function container with line color and width

Graph values by default are stretched to a width of inspector window:
![](https://github.com/MPrzekop/Unity-Inspector-Graph/blob/images/Editor/GIT%20images/Stretched.png)

but can also be declared to have regular grid:
![](https://github.com/MPrzekop/Unity-Inspector-Graph/blob/images/Editor/GIT%20images/ortho.png)


## notes
There is demo component and custom editor for it.
<p align="center">
  <img src="https://github.com/MPrzekop/Unity-Inspector-Graph/blob/images/Editor/GIT%20images/Demo.png" width="500" title="component demo">
 </p>

