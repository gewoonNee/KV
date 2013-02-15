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
    public class Image
    {
        //Fields
        protected KV game;
        protected Texture2D texture;
        protected Rectangle rectangle;
        protected Vector2 position;
        protected string imagePath;


        public Image(KV game, Vector2 position, string imagePath)
        {
            this.game = game;
            this.position = position;
            this.imagePath = imagePath;
            this.texture = this.game.Content.Load<Texture2D>(this.imagePath);
            this.rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.texture.Width, this.texture.Height);
        }

        public virtual void Draw(GameTime gameTime)
        {
            this.game.SpriteBatch.Draw(this.texture, this.rectangle, Color.DeepSkyBlue);
        }
    }
}
