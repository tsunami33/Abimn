﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abimn
{
    public static class Tile
    {
        /// <summary>
        /// Dessine une tile
        /// </summary>
        /// <param name="path">Chemin de l'image à afficher</param>
        /// <param name="pos">Position à laquelle dessiner la tile</param>
        /// <param name="rotation">Rotation à appliquer à la Tile en radians</param>
        /// <param name="scale">Zoom à effectuer sur la Tile. 1 Par défaut.</param>
        public static void Draw(string path, Pos pos, float rotation = 0, float scale = 1, float opacity = 1, bool flip = false)
        {
            if (path != "" && path != null)
                G.spriteBatch.Draw(Ressources.GetImage(path == "fireball2" ? "fireball" : path), pos.ToVector2(), null, path == "fight/fireball2" ? Color.Blue : Color.White * opacity, rotation, new Vector2(), scale, flip ? SpriteEffects.FlipVertically : SpriteEffects.None, 0);
        }
    }
}
