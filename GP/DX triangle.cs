using Microsoft.DirectX.Direct3D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prac2
{
    public partial class Form1 : Form
    {
        Microsoft.DirectX.Direct3D.Device device;
        public Form1()
        {
            InitializeComponent();
            InitDevice();
        }
        private void InitDevice()
        {
            PresentParameters pp = new PresentParameters();

            pp.Windowed = true;
            pp.SwapEffect = SwapEffect.Discard;
            device = new Microsoft.DirectX.Direct3D.Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, pp);
        }
        private void Render()
        {
            CustomVertex.TransformedColored[] v = new CustomVertex.TransformedColored[3];

            //triangle
            v[0].Position = new Microsoft.DirectX.Vector4(240, 110, 0, 1);
            v[0].Color = System.Drawing.Color.FromArgb(255, 0, 0).ToArgb();

            v[1].Position = new Microsoft.DirectX.Vector4(380, 420, 0, 1);
            v[1].Color = System.Drawing.Color.FromArgb(0, 255, 0).ToArgb();

            v[2].Position = new Microsoft.DirectX.Vector4(110, 420, 0, 1);
            v[2].Color = System.Drawing.Color.FromArgb(0, 0, 255).ToArgb();

            device.Clear(ClearFlags.Target, Color.Cyan, 0, 1);

            device.BeginScene();
            device.VertexFormat = CustomVertex.TransformedColored.Format;
            device.DrawUserPrimitives(PrimitiveType.TriangleList, 1, v);
            device.EndScene();
            device.Present();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }
    }
}


