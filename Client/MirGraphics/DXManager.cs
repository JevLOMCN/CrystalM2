using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Client.MirControls;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Blend = Microsoft.DirectX.Direct3D.Blend;

namespace Client.MirGraphics
{
    class DXManager
    {
        public static List<MImage> TextureList = new List<MImage>();
        public static List<MirControl> ControlList = new List<MirControl>();


        public static Device Device;
        public static Sprite Sprite, TextSprite;
        public static Line Line;

        public static Surface CurrentSurface;
        public static Surface MainSurface;
        public static PresentParameters Parameters;
        public static bool DeviceLost;
        public static float Opacity = 1F;
        public static bool Blending;


        public static Texture RadarTexture;
        public static List<Texture> Lights = new List<Texture>();

        public static void Create()
        {
            Parameters = new PresentParameters
            {
                BackBufferFormat = Format.X8R8G8B8,
                PresentFlag = PresentFlag.LockableBackBuffer,
                BackBufferWidth = Settings.ScreenWidth,
                BackBufferHeight = Settings.ScreenHeight,
                SwapEffect = SwapEffect.Discard,
                PresentationInterval = Settings.FPSCap ? PresentInterval.One : PresentInterval.Immediate,
                Windowed = !Settings.FullScreen,
            };
            

            Caps devCaps = Manager.GetDeviceCaps(0, DeviceType.Hardware);
            DeviceType devType = DeviceType.Reference;
            CreateFlags devFlags = CreateFlags.HardwareVertexProcessing;

            if (devCaps.VertexShaderVersion.Major >= 2 && devCaps.PixelShaderVersion.Major >= 2)
                devType = DeviceType.Hardware;

            if (devCaps.DeviceCaps.SupportsHardwareTransformAndLight)
                devFlags = CreateFlags.HardwareVertexProcessing;


            if (devCaps.DeviceCaps.SupportsPureDevice)
                devFlags |= CreateFlags.PureDevice;


            Device = new Device(Manager.Adapters.Default.Adapter, devType, Program.Form, devFlags, Parameters);

            Device.DeviceLost += (o, e) => DeviceLost = true;
            Device.DeviceResizing += (o, e) => e.Cancel = true;
            Device.DeviceReset += (o, e) => LoadTextures();

            Device.SetDialogBoxesEnabled(true);
            LoadTextures();
        }

        private static unsafe void LoadTextures()
        {
            Sprite = new Sprite(Device);
            TextSprite = new Sprite(Device);
            Line = new Line(Device) { Width = 1F };

            MainSurface = Device.GetBackBuffer(0, 0, BackBufferType.Mono);
            CurrentSurface = MainSurface;
            Device.SetRenderTarget(0, MainSurface);


            if (RadarTexture == null || RadarTexture.Disposed)
            {
                RadarTexture = new Texture(Device, 2, 2, 1, Usage.None, Format.A8R8G8B8, Pool.Managed);

                using (GraphicsStream stream = RadarTexture.LockRectangle(0, LockFlags.Discard))
                using (Bitmap image = new Bitmap(2, 2, 8, PixelFormat.Format32bppArgb, (IntPtr) stream.InternalDataPointer))
                using (Graphics graphics = Graphics.FromImage(image))
                    graphics.Clear(Color.White);
            }

            CreateLights();
        }
        
        private unsafe static void CreateLights()
        {
            for (int i = Lights.Count - 1; i >= 0; i--)
                Lights[i].Dispose();

            Lights.Clear();

            for (int i = 1; i < 15; i++)
            {
                int width = 65*i;
                int height = 50*i;
                Texture light = new Texture(Device, width, height, 1, Usage.None, Format.A8R8G8B8, Pool.Managed);

                using (GraphicsStream stream = light.LockRectangle(0, LockFlags.Discard))
                using (Bitmap image = new Bitmap(width, height, width*4, PixelFormat.Format32bppArgb, (IntPtr) stream.InternalDataPointer))
                {
                    using (Graphics graphics = Graphics.FromImage(image))
                    {
                        using (GraphicsPath path = new GraphicsPath())
                        {
                            path.AddEllipse(new Rectangle(0, 0, width, height));
                            using (PathGradientBrush brush = new PathGradientBrush(path))
                            {
                                graphics.Clear(Color.FromArgb(0, 0, 0, 0));
                                brush.SurroundColors = new[] {Color.FromArgb(0, 0, 0, 0)};
                                brush.CenterColor = Color.White;
                                graphics.FillPath(brush, path);
                                graphics.Save();
                            }
                        }
                    }
                }
                light.Disposing += (o, e) => Lights.Remove(light);
                Lights.Add(light);
            }
        }

        public static void SetSurface(Surface surface)
        {
            if (CurrentSurface == surface)
                return;

            Sprite.Flush();
            CurrentSurface = surface;
            Device.SetRenderTarget(0, surface);
        }
        public static void AttemptReset()
        {
            try
            {
                int result;
                Device.CheckCooperativeLevel(out result);
                switch ((ResultCode)result)
                {
                    case ResultCode.DeviceNotReset:
                        Device.Reset(Parameters);
                        break;
                    case ResultCode.DeviceLost:
                        break;
                    case ResultCode.Success:
                        DeviceLost = false;
                        CurrentSurface = Device.GetBackBuffer(0, 0, BackBufferType.Mono);
                        Device.SetRenderTarget(0, CurrentSurface);
                        break;
                }
            }
            catch
            {
            }
        }
        public static void AttemptRecovery()
        {
            try
            {
                Sprite.End();
            }
            catch
            {
            }

            try
            {
                Device.EndScene();
            }
            catch
            {
            }
            try
            {
                MainSurface = Device.GetBackBuffer(0, 0, BackBufferType.Mono);
                CurrentSurface = MainSurface;
                Device.SetRenderTarget(0, MainSurface);
            }
            catch
            {
            }
        }
        public static void SetOpacity(float opacity)
        {
            if (Opacity == opacity)
                return;

            Sprite.Flush();
            Device.RenderState.AlphaBlendEnable = true;
            if (opacity >= 1 || opacity < 0)
            {
                Device.RenderState.SourceBlend = Blend.SourceAlpha;
                Device.RenderState.DestinationBlend = Blend.InvSourceAlpha;
                Device.RenderState.AlphaSourceBlend = Blend.One;
                Device.RenderState.BlendFactor = Color.FromArgb(255, 255, 255, 255);
            }
            else
            {
                Device.RenderState.SourceBlend = Blend.BlendFactor;
                Device.RenderState.DestinationBlend = Blend.InvBlendFactor;
                Device.RenderState.AlphaSourceBlend = Blend.SourceAlpha;
                Device.RenderState.BlendFactor = Color.FromArgb((byte)(255 * opacity), (byte)(255 * opacity),
                                                                (byte)(255 * opacity), (byte)(255 * opacity));
            }
            Opacity = opacity;
            Sprite.Flush();
        }
        public static void SetBlend(bool value, float rate = 1F)
        {
            if (value == Blending) return;
            Blending = value;
            Sprite.Flush();

            Sprite.End();
            if (Blending)
            {
                Sprite.Begin(SpriteFlags.DoNotSaveState);
                Device.RenderState.AlphaBlendEnable = true;
                Device.RenderState.SourceBlend = Blend.BlendFactor;
                Device.RenderState.DestinationBlend = Blend.One;
                Device.RenderState.BlendFactor = Color.FromArgb((byte)(255 * rate), (byte)(255 * rate),
                                                                (byte)(255 * rate), (byte)(255 * rate));
            }
            else
                Sprite.Begin(SpriteFlags.AlphaBlend);

            Device.SetRenderTarget(0, CurrentSurface);
        }

        public static void Clean()
        {
            for (int i = TextureList.Count - 1; i >= 0; i--)
            {
                MImage m = TextureList[i];

                if (m == null)
                {
                    TextureList.RemoveAt(i);
                    continue;
                }

                if (CMain.Time <= m.CleanTime) continue;


                TextureList.RemoveAt(i);
                if (m.Image != null && !m.Image.Disposed)
                    m.Image.Dispose();
            }

            for (int i = ControlList.Count - 1; i >= 0; i--)
            {
                MirControl c = ControlList[i];

                if (c == null)
                {
                    ControlList.RemoveAt(i);
                    continue;
                }

                if (CMain.Time <= c.CleanTime) continue;

                c.DisposeTexture();
            }
        }
    }
}
