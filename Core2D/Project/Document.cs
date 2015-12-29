﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System.Collections.Immutable;

namespace Core2D
{
    /// <summary>
    /// 
    /// </summary>
    public class Document : ObservableObject
    {
        private string _name;
        private ImmutableArray<Page> _pages;

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { Update(ref _name, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public ImmutableArray<Page> Pages
        {
            get { return _pages; }
            set { Update(ref _pages, value); }
        }

        /// <summary>
        /// Creates a new <see cref="Document"/> instance.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Document Create(string name = "Document")
        {
            return new Document()
            {
                Name = name,
                Pages = ImmutableArray.Create<Page>()
            };
        }
    }
}
