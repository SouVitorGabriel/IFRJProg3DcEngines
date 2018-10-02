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

        _House house, house1;
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
            
            this.ground = new _Quad(GraphicsDevice, this, Color.SaddleBrown, new Vector3(0, 0, 0), new Vector2(70, 70), _WallOrientation.Up);
            //this.ground.CreateRotation("X", -90);

            this.house = new _House(GraphicsDevice, this);
            this.house1 = new _House(GraphicsDevice, this);

            this.helicopter = new _Helicopter(GraphicsDevice, this);
            this.helicopter.CreateTranslation(0, 0, 10f);
            

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
            
            angle += 5f;


            this.house.Update(gameTime);
            this.house.SetMatrixIndetity();
            this.house.CreateTranslation(0, 0, 10);

            this.house1.Update(gameTime);
            this.house1.SetMatrixIndetity();
            this.house1.CreateScale(1.5f, 1.5f, 1.5f);
            this.house1.CreateRotation("y", 45f);
            this.house1.CreateTranslation(-120, 0, -50);

            this.helicopter.Update();
            //this.helicopter.CreateTranslation(0, 10f, 0);

            //this.house.SetMatrixIndetity();
            //this.house.CreateTranslation(10f, 0, 0);
            //this.house.CreateScale(1f, 1f, 1f);
            //this.ground.SetMatrixIndetity();
            //this.ground.CreateRotation("y", angle);
            //this.ground.CreateTranslation(8f, 0, 0);

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
            //this.house.Draw(this.camera);
            this.house1.Draw(this.camera);
            this.helicopter.Draw(this.camera);

            base.Draw(gameTime);
        }
    }
}
