using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Image = System.Drawing.Image;

namespace ChuongChat
{
    public partial class Server : Form
    {

        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            ketnoi();
            chenicon();
            listView1.Visible = false;
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            foreach (Socket item in clientList)
            {
                Send(item);
            }
            if (txbMessage.Text != string.Empty)
            {
                lsvMessage.Items.Add(txbMessage.Text);
                lsvMessage.Items.Add(DateTime.Now.ToString("HH:mm"));
                txbMessage.Clear();
            }
            treeView1.Invoke(new Action(() =>
            {
                treeView1.Nodes.Clear();
                foreach (Socket k in clientList)
                {
                    treeView1.Nodes.Add(k.RemoteEndPoint.ToString());
                }
            }));

        }
        IPEndPoint IP;
        Socket server;
       
        List<Socket> clientList;
        int port = 2021;


        
        void ketnoi()
        {
            clientList = new List<Socket>();
           
            IP = new IPEndPoint(IPAddress.Any, port);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
          
            server.Bind(IP);

          
            Thread Listen = new Thread(chapnhan);
            Listen.IsBackground = true;
            Listen.Start();
        }
        public void chapnhan()
        {
            try
            {
                while (true)
                {
                    server.Listen(100);
                    Socket client = server.Accept();
                    clientList.Add(client);
                    treeView1.Invoke(new Action(() =>
                    {
                        treeView1.Nodes.Add(client.RemoteEndPoint.ToString());

                    }));

                    Thread receive = new Thread(Receive);
                    receive.IsBackground = true;
                    receive.Start(client);
                }
            }
           
            catch
            {
                IP = new IPEndPoint(IPAddress.Any, 1997);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            }

        }
        public bool mychek(Socket s)
        {
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if (part1 & part2)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
       
        void thoat()
        {
            server.Close();
        }

       
        void Send(Socket client)
        {
            
            if (client != null && txbMessage.Text != string.Empty)
            {
                byte[] data = new byte[1024 * 5000];
                data = Giaima(txbMessage.Text);
                client.Send(data);
            }
        }

       
        void Receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                   
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                  
                    foreach (Socket item in clientList)
                    {
                        if (item != null && item != client)
                        {
                            item.Send(data);
                        }
                    }
                    obj = Gomma(data);
                    if (obj.GetType().ToString() == "System.String")
                    {
                        lsvMessage.Items.Add((String)Gomma(data));
                        lsvMessage.Items.Add(DateTime.Now.ToString("HH:mm"));
                    }

                    if (obj.GetType().ToString() == "System.Drawing.Bitmap")
                    {
                        id++;
                        Image image = (Image)obj;
                        image1.Images.Add(id + "", image);
                        lsvMessage.Items.Add("", id);

                    }

                   
                }
            }
            catch
            {
                clientList.Remove(client);
                treeView1.Nodes.Clear();
                foreach (Socket item in clientList)
                {
                    treeView1.Invoke(new Action(() =>
                    {
                        treeView1.Nodes.Add(client.RemoteEndPoint.ToString());

                    }));
                }
                client.Close();
            }
        }

      
        byte[] Giaima(object obj)
        {
           
            MemoryStream stream = new MemoryStream();
            
            BinaryFormatter formatter = new BinaryFormatter();
            
            formatter.Serialize(stream, obj);
           
            return stream.ToArray();
        }

       
        object Gomma(byte[] data)
        {
            
            MemoryStream stream = new MemoryStream(data);
            
            BinaryFormatter formatter = new BinaryFormatter();
           
            return formatter.Deserialize(stream);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            thoat();
        }
        int id = -1;
        private void btnanh_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.Filter = "Image|*.bmp;*.jpg;*.gif;*.png";
            DialogResult Result = openImage.ShowDialog();
            
            if (Result == DialogResult.OK) 
            {
                try
                {
                    if (openImage.FileName != "")
                    {
                        id++;
                        Image image = Image.FromFile(openImage.FileName);
                        foreach (Socket item in clientList)
                        {
                            item.Send(Giaima(image));
                        }
                        image1.Images.Add(id + "", image);
                        lsvMessage.Items.Add("", id);
                        lsvMessage.Items.Add(DateTime.Now.ToString("HH:mm"));
                    }
                    else 
                    {
                        MessageBox.Show("Không thể chèn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            else 
            {
                return; 
            }

        }
        private bool check = true;
        private void btnIcon_Click(object sender, EventArgs e)
        {
            if (server == null) return;
            if (check)
            {
                listView1.Visible = check;
                check = false;
            }
            else
            {
                listView1.Visible = check;
                check = true;
            }
        }
        private void chenicon()
        {
            string duongDan = Environment.CurrentDirectory.ToString(); 
            var url = Directory.GetParent(Directory.GetParent(duongDan).ToString()); 
            string path = url + @"\icon";
            string[] file = Directory.GetFiles(path);
            foreach (string f in file)
            {
                Image icon = Image.FromFile(f);
                imageList1.Images.Add(icon);
            }
            listView1.LargeImageList = imageList1;
            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                listView1.Items.Add("", i);
            }
        }
        int id2 = 0;
        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedIndices.Count <= 0) return;
                if (listView1.FocusedItem == null) return;
                id2 = listView1.SelectedIndices[0];
                if (id2 < 0) return; 
                byte[] nhan = new byte[1024 * 5000];
                foreach (Socket clt in clientList)
                {
                    if (clt != null)
                    {
                        nhan = Giaima(imageList1.Images[id2]);
                        clt.Send(nhan);
                    }
                }

                id++;
                Image image = (Image)Gomma(nhan);
                image1.Images.Add(id + "", image);
                ListViewItem item = new ListViewItem();
                item.ImageKey = id + "";
                lsvMessage.Items.Add(item);
                lsvMessage.EnsureVisible(lsvMessage.Items.Count - 1);
                lsvMessage.Items.Add(DateTime.Now.ToString("HH:mm"));
            }
            catch
            {

            }

        }

        private void xoatnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                lsvMessage.Items.Remove(lsvMessage.SelectedItems[0]);
            }
            catch
            {
                MessageBox.Show("Chọn Tin nhắn muốn xóa!");
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }

}
