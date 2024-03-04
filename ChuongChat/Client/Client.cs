using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Image = System.Drawing.Image;

namespace Client
{
    public partial class Client : Form
    {
        public Client()
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
            Send();
            if (txbMessage.Text != string.Empty)
            {
                lsvMessage.Items.Add(txbMessage.Text);
                lsvMessage.Items.Add(DateTime.Now.ToString("HH:mm"));
                txbMessage.Clear();
            }
        }
        IPEndPoint IP;
        Socket client;

        
        void ketnoi()
        {
            
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2021);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            
            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }



       
        void thoat()
        {
            client.Close();
        }

        void Send()
        {
            
            if (txbMessage.Text != string.Empty)
            {
                byte[] data = new byte[1024 * 5000];
                data = Giaima(txbMessage.Text);
                client.Send(data);
            }
        }

        int id = -1;
        void Receive()
        {
            try
            {
                while (true)
                {
                    
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    object obj = Gomma(data);
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
                        lsvMessage.Items.Add(DateTime.Now.ToString("HH:mm"));
                    }
                    
                }
            }
            catch
            {
                Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image|*.bmp;*.jpg;*.gif;*.png";
            DialogResult Result = open.ShowDialog();
            //khai báo biến kết quả cho việc mở tập tin
            if (Result == DialogResult.OK) //nếu chọn Cancel
            {
                try
                {
                    if (open.FileName != "")
                    {
                        id++;
                        Image image = Image.FromFile(open.FileName);
                        client.Send(Giaima(image));
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
            if (client == null) return;
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
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedIndices.Count <= 0) return;
                if (listView1.FocusedItem == null) return;
                id2 = listView1.SelectedIndices[0];
                if (id2 < 0) return; 
                byte[] nhan = new byte[1024 * 5000];
                nhan = Giaima(imageList1.Images[id2]);
                client.Send(nhan);

                id++;
                Image image = (Image)imageList1.Images[id2];
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

        private void xóaTinNhắnToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void Client_Load(object sender, EventArgs e)
        {

        }
    }
}
