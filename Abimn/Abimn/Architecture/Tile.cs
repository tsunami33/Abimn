﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Abimn
{
    public class Tile
    {
        /// <summary>
        /// Récupère ou définit l'image de la tile
        /// </summary>
        public Texture2D Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }
        private Texture2D _texture;

        public Tile() { }
        public Tile(ContentManager content, string assetName) { this.LoadContent(content, assetName); }

        /// <summary>
        /// Charge l'image voulue grâce au ContentManager donné
        /// </summary>
        /// <param name="content">Le ContentManager qui chargera l'image</param>
        /// <param name="assetName">L'asset name de l'image à charger pour ce Sprite</param>
        public virtual void LoadContent(ContentManager content, string assetName)
        {
            _texture = content.Load<Texture2D>(assetName);
        }

        /// <summary>
        /// Dessine la tile 
        /// </summary>
        /// <param name="key">Clé de l'image déclarée dans le TilesManager</param>
        /// <param name="pos">Position à laquelle dessiner la tile</param>
        /// <param name="rotation">Rotation à appliquer à la Tile en radians</param>
        /// <param name="scale">Zoom à effectuer sur la Tile. 1 Par défaut.</param>
        public static void Draw(string key, Pos pos, float rotation = 0, float scale = 1)
        {
            if (key != "" && key != null)
            {
                if (G.tiles.ContainsKey(key))
                    ((Tile)G.tiles[key]).Draw(pos, rotation, scale);
            }
        }

        /// <summary>
        /// Dessine la tile en utilisant ses attributs et le spritebatch donné
        /// </summary>
        /// <param name="pos">Position à laquelle dessiner la tile</param>
        /// <param name="rotation">Rotation à appliquer à la Tile en radians</param>
        /// <param name="scale">Zoom à effectuer sur la Tile. 1 Par défaut.</param>
        public virtual void Draw(Pos pos, float rotation = 0, float scale = 1)
        {
            G.spriteBatch.Draw(_texture, pos.ToVector2(), null, Color.White, rotation, new Vector2(), scale, SpriteEffects.None, 0);
        }
    }
}
