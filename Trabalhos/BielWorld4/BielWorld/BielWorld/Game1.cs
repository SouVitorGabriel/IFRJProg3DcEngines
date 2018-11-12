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

namespace BielWorld
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Matrix world;

        _Screen screen;
        _Camera camera;
        _Quad ground;
        
        float angle;
        bool wireframe, culling, pressed, pressed1;

        _House house;
        _Helicopter helicopter;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }
        
        protected override void Initialize()
        {
            this.world = Matrix.Identity;
            this.screen = _Screen.GetInstance();
            this.screen.SetWidth(graphics.PreferredBackBufferWidth);
            this.screen.SetHeight(graphics.PreferredBackBufferHeight);

            this.camera = new _Camera();

            this.ground = new _Quad(GraphicsDevice, this, @"Textures\chao", new Vector3(0, 0, 0), new Vector2(500, 500), _WallOrientation.Up);

            this.house = new _House(GraphicsDevice, this);

            this.helicopter = new _Helicopter(GraphicsDevice, this);

            base.Initialize();
        }
        

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
        }

        protected override void UnloadContent()
        {

        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.D1) && !pressed)
            {
                pressed = true;
                wireframe = !wireframe;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.D1))
                pressed = false;


            if (Keyboard.GetState().IsKeyDown(Keys.D2) && !pressed1)
            {
                pressed1 = true;
                culling = !culling;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.D2))
                pressed1 = false;

            

            this.ground.Update(gameTime);
            
            angle += 0.5f;


            this.house.SetMatrixIndetity();
            this.house.Update(gameTime);
            this.house.CreateScale(1.5f, 1.5f, 1.5f);

            this.helicopter.SetMatrixIndetity();
            this.helicopter.Update(gameTime);
            this.helicopter.CreateTranslation(0, 12.5f, 0);

            this.camera.Update(gameTime, this.helicopter);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            RasterizerState rs = new RasterizerState();
            if(culling)
            rs.CullMode = CullMode.None;

            rs.FillMode = FillMode.Solid;

            if(wireframe)
            rs.FillMode = FillMode.WireFrame;
            this.GraphicsDevice.RasterizerState = rs;

            this.ground.Draw(this.camera);
            this.house.Draw(this.camera);
            this.helicopter.Draw(this.camera);

            base.Draw(gameTime);
        }
    }
}
