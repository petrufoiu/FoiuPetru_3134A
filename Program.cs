using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace FoiuPetru{
    class EGC : GameWindow {

        public EGC() : base(800, 600) {
            KeyDown += Keyboard_KeyDown;
        }

        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e) {
            if (e.Key == Key.Escape)
                this.Exit();

        }

        protected override void OnLoad(EventArgs e) {
            GL.ClearColor(Color.MidnightBlue);
        }

        protected override void OnResize(EventArgs e) {
            GL.Viewport(10, 10, Width -20, Height -20);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        protected override void OnUpdateFrame(FrameEventArgs e) {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (keyboard[Key.A])
            {
                GL.Viewport(100, 5, Width -200, Height -200);
            }
            if (keyboard[Key.B])
            {
                GL.Viewport(5, 100, Width -200, Height -200);
            }
            if (keyboard[Key.C])
            {
                GL.Ortho(-2.0, 2.0, -2.0, 2.0, 0.0, 4.0); 
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e) {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-1.0f, 1.0f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, 0.0f);
            GL.Color3(Color.Ivory);
            GL.Vertex2(1.0f, 1.0f);

            GL.End();
            // Sfârșitul modului imediat!
            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Orange);
            GL.Vertex2(1.0f, 1.0f);
            GL.Color3(Color.LightYellow);
            GL.Vertex2(0.0f, 0.0f);
            GL.Color3(Color.Red);
            GL.Vertex2(1.0f, -1.0f);

            GL.End();

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.DarkViolet);
            GL.Vertex2(-1.0f, -1.0f);
            GL.Color3(Color.DarkBlue);
            GL.Vertex2(0.0f, 0.0f);
            GL.Color3(Color.Orchid);
            GL.Vertex2(-1.0f, 1.0f);

            GL.End();

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.DarkGreen);
            GL.Vertex2(1.0f, -1.0f);
            GL.Color3(Color.MediumVioletRed);
            GL.Vertex2(0.0f, 0.0f);
            GL.Color3(Color.Cyan);
            GL.Vertex2(-1.0f, -1.0f);

            GL.End();

            this.SwapBuffers();
        }

        [STAThread]
        static void Main(string[] args) {

            using (EGC example = new EGC()) {

                example.Run(30.0, 0.0);
            }
        }
    }
}
