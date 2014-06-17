﻿using Microsoft.Xna.Framework;

namespace Abimn
{
    /// <summary>
    /// Menu des options
    /// </summary>
    public class OptionsMenu : GameType
    {
        private Entity background;

        private Entity sonEnabled;
        private Entity sonDisabled;
        private Entity retour;
        private Entity volume;
        private Entity luminosite;
        private Entity cannaVol;
        private Entity cannaLum;

        public OptionsMenu() : base(false) { }

        public override void Initialize()
        {
            background = new Entity(new Pos(C.Screen.Width/2, C.Screen.Height/2));
            background.LoadContent("options menu", "1", Center.All);

            sonEnabled = new Entity(new Pos(background.Pos.X + background.Rect.Width / 2, background.Pos.Y + background.Rect.Height / 2));
            sonEnabled.LoadContent("options menu", "2", "3", "2", Center.All);

            sonDisabled = new Entity(sonEnabled.Pos, false);
            sonDisabled.LoadContent("options menu", "4", "5", "4");

            volume = new Entity(new Pos(background.Pos.X + background.Rect.Width / 2 - 130, background.Pos.Y + background.Rect.Height / 2 - 100));
            volume.LoadContent("options menu", "6", Center.All);

            luminosite = new Entity(new Pos(background.Pos.X + background.Rect.Width / 2 + 130, background.Pos.Y + background.Rect.Height / 2 - 100));
            luminosite.LoadContent("options menu", "7", Center.All);

            retour = new Entity(new Pos(background.Pos.X + background.Rect.Width / 2, background.Pos.Y + background.Rect.Height / 2 + 100));
            retour.LoadContent("pause menu", "2", "6", "2", Center.All);

            cannaVol = new Entity(new Pos(volume.Pos.X + 46, volume.Pos.Y + 38));
            cannaLum = new Entity(new Pos(luminosite.Pos.X + 46, luminosite.Pos.Y + 38));
            cannaVol.LoadContent("options menu", "8", "9", "10");
            cannaLum.LoadContent("options menu", "8", "9", "10");
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (sonEnabled.IsClicked())
            {
                sonEnabled.Visible = false;
                sonDisabled.Visible = true;
                Music.Allowed = false;
            }
            else if (sonDisabled.IsClicked())
            {
                sonEnabled.Visible = true;
                sonDisabled.Visible = false;
                Music.Allowed = true;
            }

            if (volume.MouseIsOver(new Pos(30, 0)) && E.LeftIsDown())
            {
                cannaVol.Pos.I = E.GetMousePosX() - 10;
                float lol = (cannaVol.Pos.X - volume.Pos.X - 30) / 100;
                Music.Volume = lol;
            }

            if (luminosite.MouseIsOver(new Pos(30, 0)) && E.LeftIsDown())
            {
                cannaLum.Pos.I = E.GetMousePosX() - 10;
            }

            if (retour.IsClicked() && E.LeftIsReleased())
                this.State = State.Exit;
        }

        public override void Draw()
        {
            background.Draw();
            sonEnabled.Draw();
            sonDisabled.Draw();
            retour.Draw();
            volume.Draw();
            luminosite.Draw();
            cannaLum.Draw();
            cannaVol.Draw();
        }
    }
}
