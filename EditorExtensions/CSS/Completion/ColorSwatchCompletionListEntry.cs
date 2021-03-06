﻿using System;
using System.Windows;
using System.Windows.Media;
using Microsoft.CSS.Editor;
using Microsoft.VisualStudio.Text;
using Microsoft.CSS.Editor.Completion;
using Microsoft.CSS.Editor.Schemas.Browsers;
using Microsoft.Web.Editor.Completion;

namespace MadsKristensen.EditorExtensions.Css
{
    /// <summary>
    /// This represents a color swatch intellisense
    /// </summary>
    internal class ColorSwatchCompletionListEntry : ICssCompletionListEntry
    {
        private string _name;

        public ColorSwatchCompletionListEntry(string name = null, string value = null)
        {
            _name = name ?? string.Empty;
            ColorValue = value;
        }

        public string DisplayText
        {
            get { return _name; }
        }

        public string Description
        {
            get { return string.Empty; }
        }

        public string GetSyntax(Version version)
        {
            return string.Empty;
        }

        public string GetAttribute(string name)
        {
            return string.Empty;
        }

        public string GetVersionedAttribute(string name, System.Version version)
        {
            return string.Empty;
        }

        private string ColorValue { get; set; }

        public string GetInsertionText(CssTextSource textSource, ITrackingSpan typingSpan)
        {
            return DisplayText;
        }

        public bool AllowQuotedString
        {
            get { return true; }
        }

        public bool IsBuilder
        {
            get { return false; }
        }

        public int SortingPriority
        {
            get { return 0; }
        }


        public bool IsSupported(BrowserVersion browser)
        {
            return true;
        }

        public bool IsSupported(Version cssVersion)
        {
            return true;
        }

        public ITrackingSpan ApplicableTo
        {
            get { return null; }
        }

        public CompletionEntryFilterTypes FilterType
        {
            get { return CompletionEntryFilterTypes.MatchTyping; }
        }

        private ImageSource GetColorIcon()
        {
            Color color;

            try
            {
                color = (Color)ColorConverter.ConvertFromString(ColorValue);
            }
            catch
            {
                return null;
            }

            GeometryGroup group = new GeometryGroup();

            group.Children.Add(new RectangleGeometry(new Rect(new Size(50, 50))));

            GeometryDrawing drawing = new GeometryDrawing()
            {
                Geometry = group,
                Brush = new SolidColorBrush(color),
                Pen = new Pen(Brushes.Transparent, 10)
            };
            DrawingImage image = new DrawingImage(drawing);

            image.Freeze();

            return image;
        }

        public ImageSource Icon
        {
            get { return GetColorIcon(); }
        }

        public bool IsCommitChar(char typedCharacter)
        {
            return false;
        }

        public bool IsMuteCharacter(char typedCharacter)
        {
            return false;
        }

        public bool RetriggerIntellisense
        {
            get { return false; }
        }
    }
}
