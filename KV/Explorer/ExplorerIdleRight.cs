using System;
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
    public class ExplorerIdleRight : AnimatedSprite
    {
        //Fields
        private Explorer explorer;

        public ExplorerIdleRight(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.i = 7;
        }

        public override void Update(GameTime gameTime)
        {
            if (Input.DetectKeyDown(Keys.Right))
            {
                this.explorer.State = this.explorer.WalkRight;
            }
            if (Input.DetectKeyDown(Keys.Left))
            {
                this.explorer.State = this.explorer.WalkLeft;
            }

            if (Input.DetectKeyDown(Keys.Space))
            {
                this.explorer.State = this.explorer.JumpIdleRight;
                this.explorer.JumpIdleRight.Initialize();
            }

            //base.Update(gameTime);
            
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
