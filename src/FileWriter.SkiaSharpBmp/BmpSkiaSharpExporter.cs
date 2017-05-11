﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using System.IO;
using Core2D.Interfaces;
using Core2D.Project;
using Core2D.Renderer;
using SkiaSharp;

namespace FileWriter.SkiaSharpBmp
{
    /// <summary>
    /// SkiaSharp bmp <see cref="IProjectExporter"/> implementation.
    /// </summary>
    public sealed class BmpSkiaSharpExporter : IProjectExporter
    {
        private readonly ShapeRenderer _renderer;
        private readonly ContainerPresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="BmpSkiaSharpExporter"/> class.
        /// </summary>
        /// <param name="renderer">The shape renderer.</param>
        /// <param name="presenter">The container presenter.</param>
        public BmpSkiaSharpExporter(ShapeRenderer renderer, ContainerPresenter presenter)
        {
            _renderer = renderer;
            _presenter = presenter;
        }

        /// <inheritdoc/>
        void IProjectExporter.Save(string path, XContainer container)
        {
            Save(path, container);
        }

        /// <inheritdoc/>
        void IProjectExporter.Save(string path, XDocument document)
        {
            throw new NotSupportedException("Saving documents as bmp drawing is not supported.");
        }

        /// <inheritdoc/>
        void IProjectExporter.Save(string path, XProject project)
        {
            throw new NotSupportedException("Saving projects as bmp drawing is not supported.");
        }

        void Save(string path, XContainer container)
        {
            var info = new SKImageInfo((int)container.Width, (int)container.Height);
            using (var bitmap = new SKBitmap(info))
            {
                using (var canvas = new SKCanvas(bitmap))
                {
                    _presenter.Render(canvas, _renderer, container, 0, 0);
                }
                using (var image = SKImage.FromBitmap(bitmap))
                using (var data = image.Encode(SKEncodedImageFormat.Bmp, 100))
                using (var stream = File.OpenWrite(path))
                {
                    data.SaveTo(stream);
                }
            }
        }
    }
}
