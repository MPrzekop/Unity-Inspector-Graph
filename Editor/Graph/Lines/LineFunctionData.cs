using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mprzekop.unityinspectorgraph.graph
{
    /// <summary>
    /// container for line function with additional used for drawing. 
    /// </summary>
    public class LineFunctionData
    {
        #region fields
        private Func<float,float> _function;
        private Color _lineColor;
        private float _lineWidth;
        private float _functionRangeStart = 0, _functionRangeEnd = 1;

        #endregion


        #region constructors

        public LineFunctionData(Func<float,float> function, Color lineColor, float lineWidth)
        {
            Function = function;
            LineColor = lineColor;
            LineWidth = lineWidth;
        }

        public LineFunctionData(Func<float,float> function, Color lineColor, float lineWidth, float functionRangeStart,
            float functionRangeEnd)
        {
            _function = function;
            _lineColor = lineColor;
            _lineWidth = lineWidth;
            FunctionRangeStart = functionRangeStart;
            FunctionRangeEnd = functionRangeEnd;
        }

        #endregion

        #region properties

        public Func<float,float> Function
        {
            get => _function;
            set => _function = value;
        }

        public Color LineColor
        {
            get => _lineColor;
            set => _lineColor = value;
        }

        public float LineWidth
        {
            get => _lineWidth;
            set => _lineWidth = value;
        }

        public float FunctionRangeStart
        {
            get => _functionRangeStart;
            set => _functionRangeStart = value;
        }

        public float FunctionRangeEnd
        {
            get => _functionRangeEnd;
            set => _functionRangeEnd = value;
        }

        #endregion
    }
}