using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace serialPortDeneme
{
    public partial class Form1 : Form
    {
        private SerialPort myport;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
           

           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            myport = new SerialPort();
            myport.BaudRate = 9600;
            myport.PortName = "COM3";
            myport.Parity = Parity.None;
            myport.DataBits = 8;
            myport.StopBits = StopBits.One;
            myport.DataReceived += myport_DataReceived;
            try
            {
                myport.Open();
                textBox1.Text = "";
            }
            catch
            {
                MessageBox.Show("bağlanamadı");
            }
        }
        private string in_data;
        int i = 0;
        private void myport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            in_data = myport.ReadLine();
            this.Invoke(new EventHandler(displaydata_event));

            
            
        }

        private void displaydata_event(object sender, EventArgs e)
        {
            i++;
            textBox1.AppendText(in_data+"\n");
            label1.Text = i.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myport.Close();
            this.Refresh();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            myport = new SerialPort();
            myport.BaudRate = 9600;
            myport.PortName = "COM3";
            myport.Parity = Parity.None;
            myport.DataBits = 8;
            myport.StopBits = StopBits.One;
            myport.DataReceived += myport_DataReceived;
            try
            {
                myport.Open();
                textBox1.Text = "";
            }
            catch
            {
                MessageBox.Show("bağlanamadı");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                myport.Close();
                this.Refresh();

            }
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                textBox2.Text = comboBox1.SelectedItem.ToString();

            else
                textBox3.Text = comboBox1.SelectedItem.ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
