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
    class ObstacleManager
    {
        private List<Obstacle> rocks;
        private List<Obstacle> poolRocks;

        private List<Obstacle> holes;
        private List<Obstacle> poolHoles;

        private ContentManager content;

        private int rockPosY, holePosY, size, windowSizeX;

        private float timer;

        public ObstacleManager (ContentManager content, int rockPosY, int holePosY, int size, int windowSizeX)
        {
            this.rockPosY = rockPosY;
            this.holePosY = holePosY;
            this.size = size;
            this.content = content;
            this.windowSizeX = windowSizeX;

            poolRocks = new List<Obstacle>();
            rocks = new List<Obstacle>();
        }

        public  void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void CreateRock()
        {
            if (poolRocks.Count > 0)
            {
                poolRocks[0].Reset();
                poolRocks.RemoveAt(0);
            }
            else
            {
                rocks.Add(new Obstacle(this.content, @"blank", new Point(this.windowSizeX + size, this.rockPosY), new Point(size, size), this, ObstacleType.Rock));
            }
        }

        public void CreateHole()
        {

        }

        public void AddRockToPool(Obstacle rock)
        {
            rocks.Add(rock);
        }
        public void AddHoleToPool(Obstacle hole)
        {
            holes.Add(hole);
        }
    }
}
