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
    public class Level
    {
        //Fields
        private KV game;
        private string levelPath;
        private List<string> lines;
        private int width, height;
        private IBuildingBlock[,] bricks;
        private Explorer explorer;
        private StairsRight stairs;
        private List<StairsRight> stairsRight;


        //Constructor
        public Level(KV game, int levelIndex)
        {
            this.game = game;
            this.levelPath = String.Format(@"Content\Levels\{0}.txt", levelIndex);
            this.LoadAssets();
            //this.stairs = new StairsRight(this.game, new Vector2(400, 300), 5);
            this.stairsRight = new List<StairsRight>();
            this.DetectStairsRight();
        }

        public void Update(GameTime gameTime)
        {
            this.explorer.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            for (int i = 0; i < this.bricks.GetLength(0); i++ )
            {
                for (int j = 0; j < this.bricks.GetLength(1); j++ )
                {
                    this.bricks[i, j].Draw(gameTime);
                }
            }
            if (this.explorer != null)
            {
                this.explorer.Draw(gameTime);
            }
            

            foreach(StairsRight stair in this.stairsRight)
            {
                stair.Draw(gameTime);
            }

        }

        private void LoadAssets()
        {
            this.lines = new List<string>();
            StreamReader reader = new StreamReader(this.levelPath);
            string line = reader.ReadLine();
            this.width = line.Length;

            while (line != null)
            {
                lines.Add(line);
                line = reader.ReadLine();
            }
            this.height = lines.Count;
            this.bricks = new IBuildingBlock[this.width, this.height];

            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    char brickElement = lines[i][j];
                    this.bricks[j, i] = this.LoadObject(brickElement, j * 16, i * 16);
                }
            }
            
        }

        private IBuildingBlock LoadObject(char brickElement, int x, int y)
        {
            switch (brickElement)
            {
                case '.':
                    return new Brick(this.game, new Vector2(x, y), @"Brick_transparant", '.');
                case '1':
                    return new Brick(this.game, new Vector2(x, y), @"Brick", '.');
                case '2':
                    return new Brick(this.game, new Vector2(x, y), @"fundament", '.');
                case '+':
                    this.explorer = new Explorer(this.game, new Vector2(x,y));
                    return new Brick(this.game, new Vector2(x, y), @"Brick_transparant", '+');
                case 's':
                    return new StepRight(this.game, new Vector2(x, y), @"trapTopRight01", 's');

                default:
                    return new Brick(this.game, new Vector2(x, y), @"Brick_transparent", '.');
                    
            }
        }

        private void DetectStairsRight()
        {
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++ )
                {
                    if (this.bricks[j, i].ImageName == @"trapTopRight01")
                    {
                        int amountOfStairs = 0;
                        int horizontal = j + 1;
                        for (int k = (i + 1); k < this.height; k++)
                        {
                            horizontal--;
                            if (this.bricks[horizontal, k].ImageName == @"Brick")
                            {
                                amountOfStairs = k - i - 1;
                                break;
                            }
                        }

                        this.stairsRight.Add(new StairsRight(this.game, new Vector2(j * 16, i * 16), amountOfStairs));
                    }
                    }
            }
        }

    }
}
