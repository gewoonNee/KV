using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace KV
{
    public class Brick : Image, IBuildingBlock
    {

        private char character;
        private string imageName;

        public char Character
        {
            get { return this.character; }
        }

        public string ImageName
        {
            get { return this.imageName; }
            set { this.imageName = value; }
        }


        public Brick(KV game, Vector2 position, string imageName, char character) : base(game, position, @"Bricks\" + imageName)
        {
            this.character = character;
            this.imageName = imageName;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
