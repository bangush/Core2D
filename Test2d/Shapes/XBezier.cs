﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Test2d
{
    /// <summary>
    /// 
    /// </summary>
    public class XBezier : BaseShape
    {
        private XPoint _point1;
        private XPoint _point2;
        private XPoint _point3;
        private XPoint _point4;
        private bool _isFilled;

        /// <summary>
        /// 
        /// </summary>
        public XPoint Point1
        {
            get { return _point1; }
            set
            {
                if (value != _point1)
                {
                    _point1 = value;
                    Notify("Point1");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public XPoint Point2
        {
            get { return _point2; }
            set
            {
                if (value != _point2)
                {
                    _point2 = value;
                    Notify("Point2");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public XPoint Point3
        {
            get { return _point3; }
            set
            {
                if (value != _point3)
                {
                    _point3 = value;
                    Notify("Point3");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public XPoint Point4
        {
            get { return _point4; }
            set
            {
                if (value != _point4)
                {
                    _point4 = value;
                    Notify("Point4");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsFilled
        {
            get { return _isFilled; }
            set
            {
                if (value != _isFilled)
                {
                    _isFilled = value;
                    Notify("IsFilled");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="renderer"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="db"></param>
        public override void Draw(object dc, IRenderer renderer, double dx, double dy, IList<ShapeProperty> db)
        {
            if (State.HasFlag(ShapeState.Visible))
            {
                renderer.Draw(dc, this, dx, dy, db);
            }

            if (renderer.SelectedShape != null)
            {
                if (this == renderer.SelectedShape)
                {
                    _point1.Draw(dc, renderer, dx, dy, db);
                    _point2.Draw(dc, renderer, dx, dy, db);
                    _point3.Draw(dc, renderer, dx, dy, db);
                    _point4.Draw(dc, renderer, dx, dy, db);
                }
                else if (_point1 == renderer.SelectedShape)
                {
                    _point1.Draw(dc, renderer, dx, dy, db);
                }
                else if (_point2 == renderer.SelectedShape)
                {
                    _point2.Draw(dc, renderer, dx, dy, db);
                }
                else if (_point3 == renderer.SelectedShape)
                {
                    _point3.Draw(dc, renderer, dx, dy, db);
                }
                else if (_point4 == renderer.SelectedShape)
                {
                    _point4.Draw(dc, renderer, dx, dy, db);
                }
            }
            
            if (renderer.SelectedShapes != null)
            {
                if (renderer.SelectedShapes.Contains(this))
                {
                    _point1.Draw(dc, renderer, dx, dy, db);
                    _point2.Draw(dc, renderer, dx, dy, db);
                    _point3.Draw(dc, renderer, dx, dy, db);
                    _point4.Draw(dc, renderer, dx, dy, db);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public override void Move(double dx, double dy)
        {
            Point1.Move(dx, dy);
            Point2.Move(dx, dy);
            Point3.Move(dx, dy);
            Point4.Move(dx, dy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="x4"></param>
        /// <param name="y4"></param>
        /// <param name="style"></param>
        /// <param name="point"></param>
        /// <param name="isFilled"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static XBezier Create(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double x4, double y4,
            ShapeStyle style,
            BaseShape point,
            bool isFilled = false,
            string name = "")
        {
            return new XBezier()
            {
                Name = name,
                Style = style,
                Properties = new ObservableCollection<ShapeProperty>(),
                Point1 = XPoint.Create(x1, y1, point),
                Point2 = XPoint.Create(x2, y2, point),
                Point3 = XPoint.Create(x3, y3, point),
                Point4 = XPoint.Create(x4, y4, point),
                IsFilled = isFilled
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="style"></param>
        /// <param name="point"></param>
        /// <param name="isFilled"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static XBezier Create(
            double x, double y,
            ShapeStyle style,
            BaseShape point,
            bool isFilled = false,
            string name = "")
        {
            return Create(x, y, x, y, x, y, x, y, style, point, isFilled, name);
        }
    }
}
