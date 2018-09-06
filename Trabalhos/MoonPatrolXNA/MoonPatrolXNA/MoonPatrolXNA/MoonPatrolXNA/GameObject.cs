using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MoonPatrolXNA
{
    class GameObject
    {
        protected Point position;
        public Point Position { get => position; set { position = value; collider.X = position.X - collider.Width / 2; collider.Y = position.Y - collider.Height / 2; } }
        
        protected Rectangle collider;
        public Rectangle Collider { get => collider; }

        protected Texture2D texture;

      
        public GameObject(ContentManager content, string texturePath, Point position, Point size)
        {
            texture = content.Load<Texture2D>(texturePath);
            this.position = position;
            collider = new Rectangle(position.X - size.X / 2, position.Y - size.Y / 2, size.X, size.Y);
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, collider, Color.White);
        }
        
        
        

        public virtual void OnColision()
        {

        }
    }
}
