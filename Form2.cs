using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using System.Net;
using System.Net.Sockets;
using GMap.NET.CacheProviders;
using GMap.NET.Internals;
using GMap.NET.ObjectModel;
using GMap.NET.Projections;
using GMap.NET.WindowsPresentation;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.WindowsForms.Markers;

namespace nordhack
{
    public partial class Form2 : Form
    {
        List<PointLatLng> points = new List<PointLatLng>();
        GMapOverlay markersOverlay = new GMapOverlay("marker");
        public Form2()
        {
            InitializeComponent();
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            gMapControl1.CanDragMap = true;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.GrayScaleMode = true;
            gMapControl1.MaxZoom = 18;
            gMapControl1.MinZoom = 2;
            gMapControl1.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;

            gMapControl1.PolygonsEnabled = true;
            gMapControl1.MarkersEnabled = true;
            gMapControl1.NegativeMode = false;
            gMapControl1.ShowTileGridLines = false;
            gMapControl1.Dock = DockStyle.Fill;
            gMapControl1.MapProvider = GMapProviders.OpenStreetMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            //gMapControl1.SetPositionByKeywords("Кировск, Россия");
            gMapControl1.Zoom = 15;
            gMapControl1.Position = new GMap.NET.PointLatLng(67.6369373, 33.7067296);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form1 newform1 = new Form1();
            newform1.Show();
            this.Close();
        }

        private void GMapControl1_Load(object sender, EventArgs e)
        {
            
            gMapControl1.CanDragMap = true;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.GrayScaleMode = true;
            gMapControl1.MaxZoom = 18;
            gMapControl1.MinZoom = 2;
            gMapControl1.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;

            gMapControl1.PolygonsEnabled = true;
            gMapControl1.MarkersEnabled = true;
            gMapControl1.NegativeMode = false;
            gMapControl1.ShowTileGridLines = false;
            gMapControl1.Dock = DockStyle.Fill;
            gMapControl1.MapProvider = GMapProviders.OpenStreetMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            //gMapControl1.SetPositionByKeywords("Кировск, Россия");
            gMapControl1.Zoom = 15;
            gMapControl1.Position = new GMap.NET.PointLatLng(67.6369373, 33.7067296);
            points.Add(new PointLatLng(67.6369373, 33.7067296));

            //-------------------
            GMarkerGoogle szfk = new GMarkerGoogle(points.FirstOrDefault(), GMarkerGoogleType.green);
            szfk.ToolTipText = textBox3.Text;
            markersOverlay.Markers.Add(szfk);
            markersOverlay.Markers.Add(szfk);
            gMapControl1.Overlays.Add(markersOverlay);
            //------------------------



            gMapControl1.Overlays.Add(markersOverlay);
            points.Add(new PointLatLng(67.63555, 33.7059463));
            GMarkerGoogle marker = new GMarkerGoogle(points.LastOrDefault(), GMarkerGoogleType.red);
            marker.ToolTipText = "Точка";
             markersOverlay.Markers.Add(marker);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
