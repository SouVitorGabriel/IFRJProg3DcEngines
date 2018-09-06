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

namespace WindowsGame1
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        VertexPositionColor[] verts;
        VertexBuffer vertexBuffer;

        Matrix world;
        Matrix view;
        Matrix projection;

        float angle;
        Random random;

        BasicEffect effect;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


        }
        
        protected override void Initialize()
        {
            world = Matrix.Identity;
            view = Matrix.CreateLookAt(new Vector3(0,0,5), Vector3.Zero, Vector3.Up);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Window.ClientBounds.Width / (float)Window.ClientBounds.Height, 1, 100);

            random = new Random();

            verts = new VertexPositionColor[3];
            verts[0] = new VertexPositionColor(new Vector3(0, 1, 0), Color.Red);
            verts[1] = new VertexPositionColor(new Vector3(1, -1, 0), Color.Green);
            verts[2] = new VertexPositionColor(new Vector3(-1, -1, 0), Color.Blue);

            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), verts.Length, BufferUsage.None);
            vertexBuffer.SetData<VertexPositionColor>(verts);


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            effect = new BasicEffect(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //world *= Matrix.CreateRotationY(0.01f);
            //world *= Matrix.CreateRotationX(0.01f);
            //world *= Matrix.CreateRotationZ(0.01f);
            //world *= Matrix.CreateTranslation(0.02f, 0, 0);
            world = Matrix.Identity;

            world *= Matrix.CreateRotationY(angle);
            
            world *= Matrix.CreateTranslation(2, 0, 0);
            world *= Matrix.CreateScale(1, 2, 1);
            angle += 0.05f;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            GraphicsDevice.SetVertexBuffer(vertexBuffer);

            effect.World = this.world;
            effect.View = this.view;
            effect.Projection = this.projection;
            effect.VertexColorEnabled = true;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleStrip, verts, 0, 1);
            }
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
