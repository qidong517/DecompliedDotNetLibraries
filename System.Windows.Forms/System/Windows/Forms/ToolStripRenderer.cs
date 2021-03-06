﻿namespace System.Windows.Forms
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.Security.Permissions;
    using System.Windows.Forms.Layout;

    public abstract class ToolStripRenderer
    {
        private static Rectangle[] baseSizeGripRectangles = new Rectangle[] { new Rectangle(8, 0, 2, 2), new Rectangle(8, 4, 2, 2), new Rectangle(8, 8, 2, 2), new Rectangle(4, 4, 2, 2), new Rectangle(4, 8, 2, 2), new Rectangle(0, 8, 2, 2) };
        private static ColorMatrix disabledImageColorMatrix;
        private static readonly object EventRenderArrow = new object();
        private static readonly object EventRenderBorder = new object();
        private static readonly object EventRenderButtonBackground = new object();
        private static readonly object EventRenderDropDownButtonBackground = new object();
        private static readonly object EventRenderGrip = new object();
        private static readonly object EventRenderImageMargin = new object();
        private static readonly object EventRenderItemBackground = new object();
        private static readonly object EventRenderItemCheck = new object();
        private static readonly object EventRenderItemImage = new object();
        private static readonly object EventRenderItemText = new object();
        private static readonly object EventRenderLabelBackground = new object();
        private static readonly object EventRenderMenuItemBackground = new object();
        private static readonly object EventRenderOverflowButtonBackground = new object();
        private static readonly object EventRenderSeparator = new object();
        private static readonly object EventRenderSplitButtonBackground = new object();
        private static readonly object EventRenderStatusStripPanelBackground = new object();
        private static readonly object EventRenderStatusStripSizingGrip = new object();
        private static readonly object EventRenderToolStripBackground = new object();
        private static readonly object EventRenderToolStripContentPanelBackground = new object();
        private static readonly object EventRenderToolStripPanelBackground = new object();
        private static readonly object EventRenderToolStripStatusLabelBackground = new object();
        private EventHandlerList events;
        private bool isAutoGenerated;

        public event ToolStripArrowRenderEventHandler RenderArrow
        {
            add
            {
                this.AddHandler(EventRenderArrow, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderArrow, value);
            }
        }

        public event ToolStripItemRenderEventHandler RenderButtonBackground
        {
            add
            {
                this.AddHandler(EventRenderButtonBackground, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderButtonBackground, value);
            }
        }

        public event ToolStripItemRenderEventHandler RenderDropDownButtonBackground
        {
            add
            {
                this.AddHandler(EventRenderDropDownButtonBackground, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderDropDownButtonBackground, value);
            }
        }

        public event ToolStripGripRenderEventHandler RenderGrip
        {
            add
            {
                this.AddHandler(EventRenderGrip, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderGrip, value);
            }
        }

        public event ToolStripRenderEventHandler RenderImageMargin
        {
            add
            {
                this.AddHandler(EventRenderImageMargin, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderImageMargin, value);
            }
        }

        public event ToolStripItemRenderEventHandler RenderItemBackground
        {
            add
            {
                this.AddHandler(EventRenderItemBackground, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderItemBackground, value);
            }
        }

        public event ToolStripItemImageRenderEventHandler RenderItemCheck
        {
            add
            {
                this.AddHandler(EventRenderItemCheck, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderItemCheck, value);
            }
        }

        public event ToolStripItemImageRenderEventHandler RenderItemImage
        {
            add
            {
                this.AddHandler(EventRenderItemImage, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderItemImage, value);
            }
        }

        public event ToolStripItemTextRenderEventHandler RenderItemText
        {
            add
            {
                this.AddHandler(EventRenderItemText, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderItemText, value);
            }
        }

        public event ToolStripItemRenderEventHandler RenderLabelBackground
        {
            add
            {
                this.AddHandler(EventRenderLabelBackground, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderLabelBackground, value);
            }
        }

        public event ToolStripItemRenderEventHandler RenderMenuItemBackground
        {
            add
            {
                this.AddHandler(EventRenderMenuItemBackground, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderMenuItemBackground, value);
            }
        }

        public event ToolStripItemRenderEventHandler RenderOverflowButtonBackground
        {
            add
            {
                this.AddHandler(EventRenderOverflowButtonBackground, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderOverflowButtonBackground, value);
            }
        }

        public event ToolStripSeparatorRenderEventHandler RenderSeparator
        {
            add
            {
                this.AddHandler(EventRenderSeparator, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderSeparator, value);
            }
        }

        public event ToolStripItemRenderEventHandler RenderSplitButtonBackground
        {
            add
            {
                this.AddHandler(EventRenderSplitButtonBackground, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderSplitButtonBackground, value);
            }
        }

        public event ToolStripRenderEventHandler RenderStatusStripSizingGrip
        {
            add
            {
                this.AddHandler(EventRenderStatusStripSizingGrip, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderStatusStripSizingGrip, value);
            }
        }

        public event ToolStripRenderEventHandler RenderToolStripBackground
        {
            add
            {
                this.AddHandler(EventRenderToolStripBackground, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderToolStripBackground, value);
            }
        }

        public event ToolStripRenderEventHandler RenderToolStripBorder
        {
            add
            {
                this.AddHandler(EventRenderBorder, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderBorder, value);
            }
        }

        public event ToolStripContentPanelRenderEventHandler RenderToolStripContentPanelBackground
        {
            add
            {
                this.AddHandler(EventRenderToolStripContentPanelBackground, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderToolStripContentPanelBackground, value);
            }
        }

        public event ToolStripPanelRenderEventHandler RenderToolStripPanelBackground
        {
            add
            {
                this.AddHandler(EventRenderToolStripPanelBackground, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderToolStripPanelBackground, value);
            }
        }

        public event ToolStripItemRenderEventHandler RenderToolStripStatusLabelBackground
        {
            add
            {
                this.AddHandler(EventRenderToolStripStatusLabelBackground, value);
            }
            remove
            {
                this.RemoveHandler(EventRenderToolStripStatusLabelBackground, value);
            }
        }

        protected ToolStripRenderer()
        {
        }

        internal ToolStripRenderer(bool isAutoGenerated)
        {
            this.isAutoGenerated = isAutoGenerated;
        }

        [UIPermission(SecurityAction.Demand, Window=UIPermissionWindow.AllWindows)]
        private void AddHandler(object key, Delegate value)
        {
            this.Events.AddHandler(key, value);
        }

        public static Image CreateDisabledImage(Image normalImage)
        {
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.ClearColorKey();
            imageAttr.SetColorMatrix(DisabledImageColorMatrix);
            Size size = normalImage.Size;
            Bitmap image = new Bitmap(size.Width, size.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawImage(normalImage, new Rectangle(0, 0, size.Width, size.Height), 0, 0, size.Width, size.Height, GraphicsUnit.Pixel, imageAttr);
            graphics.Dispose();
            return image;
        }

        public void DrawArrow(ToolStripArrowRenderEventArgs e)
        {
            this.OnRenderArrow(e);
            ToolStripArrowRenderEventHandler handler = this.Events[EventRenderArrow] as ToolStripArrowRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawButtonBackground(ToolStripItemRenderEventArgs e)
        {
            this.OnRenderButtonBackground(e);
            ToolStripItemRenderEventHandler handler = this.Events[EventRenderButtonBackground] as ToolStripItemRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            this.OnRenderDropDownButtonBackground(e);
            ToolStripItemRenderEventHandler handler = this.Events[EventRenderDropDownButtonBackground] as ToolStripItemRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawGrip(ToolStripGripRenderEventArgs e)
        {
            this.OnRenderGrip(e);
            ToolStripGripRenderEventHandler handler = this.Events[EventRenderGrip] as ToolStripGripRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawImageMargin(ToolStripRenderEventArgs e)
        {
            this.OnRenderImageMargin(e);
            ToolStripRenderEventHandler handler = this.Events[EventRenderImageMargin] as ToolStripRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawItemBackground(ToolStripItemRenderEventArgs e)
        {
            this.OnRenderItemBackground(e);
            ToolStripItemRenderEventHandler handler = this.Events[EventRenderItemBackground] as ToolStripItemRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            this.OnRenderItemCheck(e);
            ToolStripItemImageRenderEventHandler handler = this.Events[EventRenderItemCheck] as ToolStripItemImageRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawItemImage(ToolStripItemImageRenderEventArgs e)
        {
            this.OnRenderItemImage(e);
            ToolStripItemImageRenderEventHandler handler = this.Events[EventRenderItemImage] as ToolStripItemImageRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawItemText(ToolStripItemTextRenderEventArgs e)
        {
            this.OnRenderItemText(e);
            ToolStripItemTextRenderEventHandler handler = this.Events[EventRenderItemText] as ToolStripItemTextRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawLabelBackground(ToolStripItemRenderEventArgs e)
        {
            this.OnRenderLabelBackground(e);
            ToolStripItemRenderEventHandler handler = this.Events[EventRenderLabelBackground] as ToolStripItemRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            this.OnRenderMenuItemBackground(e);
            ToolStripItemRenderEventHandler handler = this.Events[EventRenderMenuItemBackground] as ToolStripItemRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
            this.OnRenderOverflowButtonBackground(e);
            ToolStripItemRenderEventHandler handler = this.Events[EventRenderOverflowButtonBackground] as ToolStripItemRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            this.OnRenderSeparator(e);
            ToolStripSeparatorRenderEventHandler handler = this.Events[EventRenderSeparator] as ToolStripSeparatorRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawSplitButton(ToolStripItemRenderEventArgs e)
        {
            this.OnRenderSplitButtonBackground(e);
            ToolStripItemRenderEventHandler handler = this.Events[EventRenderSplitButtonBackground] as ToolStripItemRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawStatusStripSizingGrip(ToolStripRenderEventArgs e)
        {
            this.OnRenderStatusStripSizingGrip(e);
            ToolStripRenderEventHandler handler = this.Events[EventRenderStatusStripSizingGrip] as ToolStripRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawToolStripBackground(ToolStripRenderEventArgs e)
        {
            this.OnRenderToolStripBackground(e);
            ToolStripRenderEventHandler handler = this.Events[EventRenderToolStripBackground] as ToolStripRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawToolStripBorder(ToolStripRenderEventArgs e)
        {
            this.OnRenderToolStripBorder(e);
            ToolStripRenderEventHandler handler = this.Events[EventRenderBorder] as ToolStripRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
        {
            this.OnRenderToolStripContentPanelBackground(e);
            ToolStripContentPanelRenderEventHandler handler = this.Events[EventRenderToolStripContentPanelBackground] as ToolStripContentPanelRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawToolStripPanelBackground(ToolStripPanelRenderEventArgs e)
        {
            this.OnRenderToolStripPanelBackground(e);
            ToolStripPanelRenderEventHandler handler = this.Events[EventRenderToolStripPanelBackground] as ToolStripPanelRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void DrawToolStripStatusLabelBackground(ToolStripItemRenderEventArgs e)
        {
            this.OnRenderToolStripStatusLabelBackground(e);
            ToolStripItemRenderEventHandler handler = this.Events[EventRenderToolStripStatusLabelBackground] as ToolStripItemRenderEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        internal virtual Region GetTransparentRegion(ToolStrip toolStrip)
        {
            return null;
        }

        protected internal virtual void Initialize(ToolStrip toolStrip)
        {
        }

        protected internal virtual void InitializeContentPanel(ToolStripContentPanel contentPanel)
        {
        }

        protected internal virtual void InitializeItem(ToolStripItem item)
        {
        }

        protected internal virtual void InitializePanel(ToolStripPanel toolStripPanel)
        {
        }

        protected virtual void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderArrow(e);
            }
            else
            {
                Graphics graphics = e.Graphics;
                Rectangle arrowRectangle = e.ArrowRectangle;
                using (Brush brush = new SolidBrush(e.ArrowColor))
                {
                    Point point = new Point(arrowRectangle.Left + (arrowRectangle.Width / 2), arrowRectangle.Top + (arrowRectangle.Height / 2));
                    Point[] points = null;
                    switch (e.Direction)
                    {
                        case ArrowDirection.Left:
                            points = new Point[] { new Point(point.X + 2, point.Y - 4), new Point(point.X + 2, point.Y + 4), new Point(point.X - 2, point.Y) };
                            break;

                        case ArrowDirection.Up:
                            points = new Point[] { new Point(point.X - 2, point.Y + 1), new Point(point.X + 3, point.Y + 1), new Point(point.X, point.Y - 2) };
                            break;

                        case ArrowDirection.Right:
                            points = new Point[] { new Point(point.X - 2, point.Y - 4), new Point(point.X - 2, point.Y + 4), new Point(point.X + 2, point.Y) };
                            break;

                        default:
                            points = new Point[] { new Point(point.X - 2, point.Y - 1), new Point(point.X + 3, point.Y - 1), new Point(point.X, point.Y + 2) };
                            break;
                    }
                    graphics.FillPolygon(brush, points);
                }
            }
        }

        protected virtual void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderButtonBackground(e);
            }
        }

        protected virtual void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderDropDownButtonBackground(e);
            }
        }

        protected virtual void OnRenderGrip(ToolStripGripRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderGrip(e);
            }
        }

        protected virtual void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderImageMargin(e);
            }
        }

        protected virtual void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderItemBackground(e);
            }
        }

        protected virtual void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderItemCheck(e);
            }
            else
            {
                Rectangle imageRectangle = e.ImageRectangle;
                Image normalImage = e.Image;
                if ((imageRectangle != Rectangle.Empty) && (normalImage != null))
                {
                    if (!e.Item.Enabled)
                    {
                        normalImage = CreateDisabledImage(normalImage);
                    }
                    e.Graphics.DrawImage(normalImage, imageRectangle, new Rectangle(Point.Empty, imageRectangle.Size), GraphicsUnit.Pixel);
                }
            }
        }

        protected virtual void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderItemImage(e);
            }
            else
            {
                Rectangle imageRectangle = e.ImageRectangle;
                Image normalImage = e.Image;
                if ((imageRectangle != Rectangle.Empty) && (normalImage != null))
                {
                    bool flag = false;
                    if (e.ShiftOnPress && e.Item.Pressed)
                    {
                        imageRectangle.X++;
                    }
                    if (!e.Item.Enabled)
                    {
                        normalImage = CreateDisabledImage(normalImage);
                        flag = true;
                    }
                    if (e.Item.ImageScaling == ToolStripItemImageScaling.None)
                    {
                        e.Graphics.DrawImage(normalImage, imageRectangle, new Rectangle(Point.Empty, imageRectangle.Size), GraphicsUnit.Pixel);
                    }
                    else
                    {
                        e.Graphics.DrawImage(normalImage, imageRectangle);
                    }
                    if (flag)
                    {
                        normalImage.Dispose();
                    }
                }
            }
        }

        protected virtual void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderItemText(e);
            }
            else
            {
                ToolStripItem item = e.Item;
                Graphics dc = e.Graphics;
                Color textColor = e.TextColor;
                Font textFont = e.TextFont;
                string text = e.Text;
                Rectangle textRectangle = e.TextRectangle;
                TextFormatFlags textFormat = e.TextFormat;
                textColor = item.Enabled ? textColor : SystemColors.GrayText;
                if (((e.TextDirection != ToolStripTextDirection.Horizontal) && (textRectangle.Width > 0)) && (textRectangle.Height > 0))
                {
                    Size size = LayoutUtils.FlipSize(textRectangle.Size);
                    using (Bitmap bitmap = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppPArgb))
                    {
                        using (Graphics graphics2 = Graphics.FromImage(bitmap))
                        {
                            graphics2.TextRenderingHint = TextRenderingHint.AntiAlias;
                            TextRenderer.DrawText(graphics2, text, textFont, new Rectangle(Point.Empty, size), textColor, textFormat);
                            bitmap.RotateFlip((e.TextDirection == ToolStripTextDirection.Vertical90) ? RotateFlipType.Rotate90FlipNone : RotateFlipType.Rotate270FlipNone);
                            dc.DrawImage(bitmap, textRectangle);
                        }
                        return;
                    }
                }
                TextRenderer.DrawText(dc, text, textFont, textRectangle, textColor, textFormat);
            }
        }

        protected virtual void OnRenderLabelBackground(ToolStripItemRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderLabelBackground(e);
            }
        }

        protected virtual void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderMenuItemBackground(e);
            }
        }

        protected virtual void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderOverflowButtonBackground(e);
            }
        }

        protected virtual void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderSeparator(e);
            }
        }

        protected virtual void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderSplitButtonBackground(e);
            }
        }

        protected virtual void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderStatusStripSizingGrip(e);
            }
            else
            {
                Graphics graphics = e.Graphics;
                StatusStrip toolStrip = e.ToolStrip as StatusStrip;
                if (toolStrip != null)
                {
                    Rectangle sizeGripBounds = toolStrip.SizeGripBounds;
                    if (!LayoutUtils.IsZeroWidthOrHeight(sizeGripBounds))
                    {
                        Rectangle[] rects = new Rectangle[baseSizeGripRectangles.Length];
                        Rectangle[] rectangleArray2 = new Rectangle[baseSizeGripRectangles.Length];
                        for (int i = 0; i < baseSizeGripRectangles.Length; i++)
                        {
                            Rectangle rectangle2 = baseSizeGripRectangles[i];
                            if (toolStrip.RightToLeft == RightToLeft.Yes)
                            {
                                rectangle2.X = (sizeGripBounds.Width - rectangle2.X) - rectangle2.Width;
                            }
                            rectangle2.Offset(sizeGripBounds.X, sizeGripBounds.Bottom - 12);
                            rects[i] = rectangle2;
                            if (toolStrip.RightToLeft == RightToLeft.Yes)
                            {
                                rectangle2.Offset(1, -1);
                            }
                            else
                            {
                                rectangle2.Offset(-1, -1);
                            }
                            rectangleArray2[i] = rectangle2;
                        }
                        graphics.FillRectangles(SystemBrushes.ButtonHighlight, rects);
                        graphics.FillRectangles(SystemBrushes.ButtonShadow, rectangleArray2);
                    }
                }
            }
        }

        protected virtual void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderToolStripBackground(e);
            }
        }

        protected virtual void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderToolStripBorder(e);
            }
        }

        protected virtual void OnRenderToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderToolStripContentPanelBackground(e);
            }
        }

        protected virtual void OnRenderToolStripPanelBackground(ToolStripPanelRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderToolStripPanelBackground(e);
            }
        }

        protected virtual void OnRenderToolStripStatusLabelBackground(ToolStripItemRenderEventArgs e)
        {
            if (this.RendererOverride != null)
            {
                this.RendererOverride.OnRenderToolStripStatusLabelBackground(e);
            }
        }

        [UIPermission(SecurityAction.Demand, Window=UIPermissionWindow.AllWindows)]
        private void RemoveHandler(object key, Delegate value)
        {
            this.Events.RemoveHandler(key, value);
        }

        internal bool ShouldPaintBackground(Control control)
        {
            return ((control.RawBackColor == Color.Empty) && (control.BackgroundImage == null));
        }

        private static ColorMatrix DisabledImageColorMatrix
        {
            get
            {
                if (disabledImageColorMatrix == null)
                {
                    float[][] numArray = new float[5][];
                    numArray[0] = new float[] { 0.2125f, 0.2125f, 0.2125f, 0f, 0f };
                    numArray[1] = new float[] { 0.2577f, 0.2577f, 0.2577f, 0f, 0f };
                    numArray[2] = new float[] { 0.0361f, 0.0361f, 0.0361f, 0f, 0f };
                    float[] numArray3 = new float[5];
                    numArray3[3] = 1f;
                    numArray[3] = numArray3;
                    numArray[4] = new float[] { 0.38f, 0.38f, 0.38f, 0f, 1f };
                    float[][] numArray2 = new float[5][];
                    float[] numArray4 = new float[5];
                    numArray4[0] = 1f;
                    numArray2[0] = numArray4;
                    float[] numArray5 = new float[5];
                    numArray5[1] = 1f;
                    numArray2[1] = numArray5;
                    float[] numArray6 = new float[5];
                    numArray6[2] = 1f;
                    numArray2[2] = numArray6;
                    float[] numArray7 = new float[5];
                    numArray7[3] = 0.7f;
                    numArray2[3] = numArray7;
                    numArray2[4] = new float[5];
                    disabledImageColorMatrix = ControlPaint.MultiplyColorMatrix(numArray2, numArray);
                }
                return disabledImageColorMatrix;
            }
        }

        private EventHandlerList Events
        {
            get
            {
                if (this.events == null)
                {
                    this.events = new EventHandlerList();
                }
                return this.events;
            }
        }

        internal bool IsAutoGenerated
        {
            get
            {
                return this.isAutoGenerated;
            }
        }

        internal virtual ToolStripRenderer RendererOverride
        {
            get
            {
                return null;
            }
        }
    }
}

