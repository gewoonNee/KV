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
    public class StairsRight
    {
        private KV game;
        private Vector2 position;
        private int amountOfSteps;
        private List<StepRight> stairs;

        public StairsRight(KV game, Vector2 position, int amountOfSteps)
        {
            this.game = game;
            this.position = position + new Vector2(-amountOfSteps * 16, amountOfSteps * 16);
            this.amountOfSteps = amountOfSteps;
            this.stairs = new List<StepRight>();
            this.LoadContent();
        }

        private void LoadContent()
        {
            for (int i = 0; i < this.amountOfSteps; i++ )
            {
                this.stairs.Add(new StepRight(this.game, new Vector2(this.position.X + i * 16, this.position.Y - i * 16),
                                                @"trapRight01", '€'));

                this.stairs.Add(new StepRight(this.game, new Vector2(this.position.X + (i+1) * 16, this.position.Y - i * 16),
                                                @"trapRight02", '€'));
            }
            this.stairs.Add(new StepRight(this.game, new Vector2((this.position.X + (this.amountOfSteps + 1) * 16),(this.position.Y - this.amountOfSteps * 16)), @"trapTopRight02", '€'));
        }

        public void Draw(GameTime gameTime)
        {
            foreach (StepRight step in this.stairs)
            {
                step.Draw(gameTime);
            }
        }
    }
}
