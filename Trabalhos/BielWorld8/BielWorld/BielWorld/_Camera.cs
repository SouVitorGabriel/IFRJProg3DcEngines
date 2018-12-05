using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BielWorld
{
    public class _Camera
    {
        private Matrix view;
        private Matrix projection;

        private Vector3 position;
        private Vector3 target;
        private Vector3 up;
        private Vector3 rotation;

        private float translationSpeed = 50;
        private float rotationSpeed = 80;

        private BoundingBox boundingBox;
        private bool cameraMove = true;

        public _Camera()
        {
            this.position = new Vector3(0, 30, 55);
            this.target = new Vector3(0, 0, 0); //Vector3.Zero;
            this.rotation = new Vector3(-15, 0, 0);
            this.up = Vector3.Up;
            this.SetupView(this.position, this.target, this.up);

            this.boundingBox = new BoundingBox();
            this.boundingBox.Min = this.position - Vector3.One;
            this.boundingBox.Max = this.position + Vector3.One;

            this.SetupProjection();
        }

        public void Update(GameTime gameTime, _Helicopter heli)
        {
            BoundingBox bBox = heli.GetBoundingBox();
            _MachineState state = heli.GetMachineState();
            Vector3 heliPos = heli.Position;

            this.SetupView(this.position, this.target, this.up);
            this.SetupProjection();

            this.CameraRotation(gameTime);
            if (cameraMove == true)
            {
                
                this.CameraTranslation(gameTime);
            }

            this.view = Matrix.Identity;
            this.view *= Matrix.CreateRotationX(MathHelper.ToRadians(rotation.X));
            this.view *= Matrix.CreateRotationY(MathHelper.ToRadians(rotation.Y));

            this.view *= Matrix.CreateTranslation(this.position);
            this.view = Matrix.Invert(this.view);

            this.TranslateBoundingBox();

            if (this.boundingBox.Intersects(bBox))
            {
                if (state == _MachineState.On)
                {
                    cameraMove = false;
                    
                    this.view *= Matrix.CreateRotationY(MathHelper.ToRadians(-180));
                    //this.view *= Matrix.CreateRotationX(MathHelper.ToRadians(10));
                }

                this.view *= Matrix.CreateTranslation(-heliPos);

                if (state == _MachineState.Off && cameraMove == false)
                {
                    Console.WriteLine("Saiu");
                    this.position = this.position + new Vector3(0, 30, 55);
                    this.view *= Matrix.CreateRotationY(MathHelper.ToRadians(-180));
                    this.view *= Matrix.CreateRotationX(MathHelper.ToRadians(10));
                    cameraMove = true;
                }
            }
            
            //Console.WriteLine("BoxC: " + this.boundingBox.ToString());
            //Console.WriteLine("BoxH: " + bBox.ToString());
            //Console.WriteLine("State: " + state.ToString());
        }

        private void SetupView(Vector3 position, Vector3 target, Vector3 up)
        {
            this.view = Matrix.CreateLookAt(position, target, up);
        }

        private void SetupProjection()
        {
            _Screen screen = _Screen.GetInstance();

            this.projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                                  screen.GetWidth() / (float)screen.GetHeight(),
                                                                  0.001f,
                                                                  1000);
        }

        public Matrix GetView()
        {
            return this.view;
        }

        public Matrix GetProjection()
        {
            return this.projection;
        }

        private void CameraRotation(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                this.rotation.Y += this.rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                this.rotation.Y -= this.rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                this.rotation.X += this.rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                this.rotation.X -= this.rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            }
        }

        private void CameraTranslation(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                this.position.Y += (float)Math.Sin(MathHelper.ToRadians(90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                this.position.Y -= (float)Math.Sin(MathHelper.ToRadians(90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                this.position.X -= (float)Math.Sin(MathHelper.ToRadians(this.rotation.Y)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
                this.position.Z -= (float)Math.Cos(MathHelper.ToRadians(this.rotation.Y)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                this.position.X += (float)Math.Sin(MathHelper.ToRadians(this.rotation.Y)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
                this.position.Z += (float)Math.Cos(MathHelper.ToRadians(this.rotation.Y)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                this.position.X += (float)Math.Sin(MathHelper.ToRadians(this.rotation.Y + 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
                this.position.Z += (float)Math.Cos(MathHelper.ToRadians(this.rotation.Y + 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                this.position.X += (float)Math.Sin(MathHelper.ToRadians(this.rotation.Y - 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
                this.position.Z += (float)Math.Cos(MathHelper.ToRadians(this.rotation.Y - 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.translationSpeed;
            }
        }
        private void TranslateBoundingBox()
        {
            this.boundingBox.Min = this.position - Vector3.One;
            this.boundingBox.Max = this.position + Vector3.One;
        }

        public BoundingBox GetBoundingBox()
        {
            return this.boundingBox;
        }

        public Vector3 getPosition()
        {
            return this.position;
        }

        public Vector3 getRotation()
        {
            return this.rotation;
        }
    }
}
