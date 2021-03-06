﻿#region File Description
//-----------------------------------------------------------------------------
// TiledMapUtils
//
// Copyright © 2016 Wave Engine S.L. All rights reserved.
// Use is subject to license terms.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
#endregion

namespace WaveEngine.TiledMap
{
    public static class TiledMapUtils
    {
        public static Entity CollisionEntityFromObject(string entityName, TiledMapObject mapObject)
        {
            Entity entity = null;
            if (mapObject.ObjectType == TiledMapObjectType.Basic)
            {
                if (mapObject.Width > 0 && mapObject.Height > 0)
                {
                    entity = new Entity(entityName)
                    .AddComponent(new Transform2D()
                    {
                        LocalPosition = new Vector2(mapObject.X, mapObject.Y),
                        Rectangle = new RectangleF(0, 0, mapObject.Width, mapObject.Height),
                        LocalRotation = MathHelper.ToRadians(mapObject.Rotation),
                        Origin = Vector2.Zero
                    })
                    .AddComponent(new RectangleCollider2D())
                    ;
                }
            }
            else
            {
                // Only Basic object types are supported
            }

            return entity;
        }

        /// <summary>
        /// Gets the tile rectangle by tile identifier.
        /// </summary>
        /// <param name="tileset">The tileset.</param>
        /// <param name="tileId">The tile identifier.</param>
        /// <returns>Tile rectangle</returns>
        public static Rectangle GetRectangleTileByID(Tileset tileset, int tileId)
        {
            int rectangleX = (tileId % tileset.XTilesCount);
            int rectangleY = ((tileId - rectangleX) / tileset.XTilesCount);

            int x = tileset.Margin + (tileset.TileWidth + tileset.Spacing) * rectangleX;
            int y = tileset.Margin + (tileset.TileHeight + tileset.Spacing) * rectangleY;

            return new Rectangle(x, y, tileset.TileWidth, tileset.TileHeight);
        }
    }
}
