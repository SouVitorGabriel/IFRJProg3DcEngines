using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MoonPatrolXNA
{
    class Obstacle : GameObject
    {
        private ObstacleType type;
        private bool sleeping;

        private ObstacleManager obstacleManager;

        private int inicialPosX;

        public Obstacle(ContentManager content, string texturePath, Point position, Point size, ObstacleManager obstacleManager, ObstacleType type)  : base (content, texturePath, position, size)
        {
            this.type = type;
            this.obstacleManager = obstacleManager;
            inicialPosX = position.X;
        }

        public override void Update(GameTime gameTime)
        {
            if (sleeping)
                return;
            
            base.Update(gameTime);

            this.SetPositionX(Position.X - gameTime.ElapsedGameTime.Milliseconds / 5);

            if (Position.X < 0 - this.Collider.Width)
            {
                sleeping = true;
                if (type == ObstacleType.Rock)
                    obstacleManager.AddRockToPool(this);
                else
                    obstacleManager.AddHoleToPool(this);
            }
        }

        public void Reset()
        {
            this.SetPositionX(inicialPosX);
            sleeping = false;
        }

        public override void Draw(SpriteBatch sb)
        {
            if(sleeping)
                return;

            base.Draw(sb);
        }
    }
}
