#region File Description
//-----------------------------------------------------------------------------
// TiledMap
//
// Copyright � 2016 Wave Engine S.L. All rights reserved.
// Use is subject to license terms.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System.IO;
using System.Xml.Linq;
using TiledSharp;
using WaveEngine.Framework.Services;
#endregion

namespace WaveEngine.TiledMap
{
    /// <summary>
    /// Loader for wpk textures
    /// </summary>
    internal class WaveDocumentLoader : IDocumentLoader
    {
        #region Public Methods
        /// <summary>
        /// Loads the specified document.
        /// </summary>
        /// <param name="path">The path.</param>
        public XDocument Load(string path)
        {
            XDocument xDoc = null;

            using (Stream xmlStream = WaveServices.Storage.OpenContentFile(path))
            {
                xDoc = XDocument.Load(xmlStream);
            }

            return xDoc;
        }
        #endregion
    }
}
