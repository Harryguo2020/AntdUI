﻿// COPYRIGHT (C) Tom. ALL RIGHTS RESERVED.
// THE AntdUI PROJECT IS AN WINFORM LIBRARY LICENSED UNDER THE Apache-2.0 License.
// LICENSED UNDER THE Apache License, VERSION 2.0 (THE "License")
// YOU MAY NOT USE THIS FILE EXCEPT IN COMPLIANCE WITH THE License.
// YOU MAY OBTAIN A COPY OF THE LICENSE AT
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// UNLESS REQUIRED BY APPLICABLE LAW OR AGREED TO IN WRITING, SOFTWARE
// DISTRIBUTED UNDER THE LICENSE IS DISTRIBUTED ON AN "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED.
// SEE THE LICENSE FOR THE SPECIFIC LANGUAGE GOVERNING PERMISSIONS AND
// LIMITATIONS UNDER THE License.
// GITEE: https://gitee.com/antdui/AntdUI
// GITHUB: https://github.com/AntdUI/AntdUI
// CSDN: https://blog.csdn.net/v_132
// QQ: 17379620

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace AntdUI.Icon
{
    /// <summary>
    /// 失败图标
    /// </summary>
    [Description("Icon 失败图标")]
    [ToolboxItem(false)]
    [System.Obsolete("use IconState")]
    public class IconError : IControl
    {
        #region 属性

        Color? back;
        [Description("背景颜色"), Category("外观"), DefaultValue(null)]
        [Editor(typeof(Design.ColorEditor), typeof(UITypeEditor))]
        public Color? Back
        {
            get => back;
            set
            {
                if (back == value) return;
                back = value;
                Invalidate();
                OnPropertyChanged("Back");
            }
        }

        Color? color;
        [Description("颜色"), Category("外观"), DefaultValue(null)]
        [Editor(typeof(Design.ColorEditor), typeof(UITypeEditor))]
        public Color? Color
        {
            get => color;
            set
            {
                if (color == value) return;
                color = value;
                Invalidate();
                OnPropertyChanged("Color");
            }
        }

        #endregion

        #region 渲染

        protected override void OnPaint(PaintEventArgs e)
        {
            var rect = ClientRectangle;
            var g = e.Graphics.High();
            float dot_size = rect.Width > rect.Height ? rect.Height : rect.Width;
            var rect_dot = new RectangleF((rect.Width - dot_size) / 2, (rect.Height - dot_size) / 2, dot_size, dot_size);

            if (color.HasValue)
            {
                using (var brush = new SolidBrush(color.Value))
                {
                    g.FillEllipse(brush, new RectangleF(rect_dot.X + 1, rect_dot.Y + 1, rect_dot.Width - 2, rect_dot.Height - 2));
                }
            }
            g.GetImgExtend(SvgDb.IcoError, rect, back ?? Colour.Error.Get("IconError"));
            this.PaintBadge(g);
            base.OnPaint(e);
        }

        #endregion
    }
}