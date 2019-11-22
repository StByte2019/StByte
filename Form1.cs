using System;
using System.IO;
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
    public partial class Form1 : Form
    {
        List<PointLatLng> points = new List<PointLatLng>(); 
        GMapOverlay markersOverlay = new GMapOverlay("marker"); 

        int indicator = 0;
        static int port = 8005; // порт для приема входящих запросов
        public Form1()
        {
        
            InitializeComponent();

            /*
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            // создаем сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);

                // начинаем прослушивание
                listenSocket.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байтов
                    byte[] data = new byte[256]; // буфер для получаемых данных

                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);

                    Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());

                    // отправляем ответ
                    string message = "ваше сообщение доставлено";
                    data = Encoding.Unicode.GetBytes(message);
                    handler.Send(data);
                    // закрываем сокет
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            */
        }

        public void Form1_Load(object sender, EventArgs e)
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
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            Form3 newform3 = new Form3();
            newform3.Show();
            this.Hide();


           /* var coordinata2 = double.Parse(textBox2.Text);
            var coordinata1 = double.Parse(textBox1.Text);
            new PointLatLng(48.861017, 2.330030);
            //points.Add(new PointLatLng(coordinata1, coordinata2)); 
            GMarkerGoogle markerEnd1 = new GMarkerGoogle(points.LastOrDefault(), GMarkerGoogleType.green);
            markerEnd1.ToolTipText = textBox3.Text;
            markersOverlay.Markers.Add(markerEnd1);
            markersOverlay.Markers.Add(markerEnd1); 
            gMapControl1.Overlays.Add(markersOverlay);
            gMapControl1.Refresh();

            Form2 newForm = new Form2();
            newForm.Show();
            this.Hide();
            */
        }



        private void GMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            gMapControl1.Overlays[0].Markers.Add(new GMarkerGoogle(gMapControl1.FromLocalToLatLng(e.X, e.Y), GMarkerGoogleType.red));
            points.Add(new PointLatLng(e.X, e.Y));
        }

        private void GMapControl1_MouseClick(object sender, MouseEventArgs e)
        { }

        private void Button3_Click(object sender, EventArgs e)
        {
            /*
            int? mID = null;
            if (GMapMarker != null)
            {
                mID = Convert.ToInt32(currentMarker.Tag);
                markersOverlay.Markers.Remove(currentMarker);
                currentMarker = null;
            }
            m_dbMarkers.Delete(_table, String.Format("markers.ID = {0} ", mID));
            */
        }

        private void GMapControl1_OnMarkerClick(GMap.NET.WindowsForms.GMapMarker item, MouseEventArgs e)
        {
           // currentMarker = item;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            Form2 newForm1 = new Form2();
            newForm1.Show();
            this.Hide();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            /*
            var coordinata1 = textBox1.Text;
            coordinata1.Replace(',', '.');
            var x = double.Parse(coordinata1);
            var coordinata2 = textBox2.Text;
            coordinata2.Replace(',', '.');
            var y = double.Parse(coordinata2);
            */
            var coordinata1 = double.Parse(textBox1.Text);
            var coordinata2 = double.Parse(textBox2.Text);


            points.Add(new PointLatLng(coordinata1, coordinata2)); 
            GMarkerGoogle marker = new GMarkerGoogle(points.LastOrDefault(), GMarkerGoogleType.red);
            marker.ToolTipText = textBox3.Text;
            markersOverlay.Markers.Add(marker);
            
            gMapControl1.Overlays.Add(markersOverlay);
            gMapControl1.Refresh();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
        }
