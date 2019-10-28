using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace ComPortAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }
        private SerialPort comport = new SerialPort();
        
        
        
        public string paringdata(string data)
        {
            string[] temp = data.Split(',');
            label2.Invoke(new EventHandler(delegate { label2.Text =""; }));

            if (temp.Length == 4)
            {
                lblStatus.Invoke(new EventHandler(delegate { lblStatus.Text = temp[0].ToString(); }));
                lblType.Invoke(new EventHandler(delegate { lblType.Text = temp[1].ToString(); }));
                lblWeight.Invoke(new EventHandler(delegate { lblWeight.Text = temp[2].ToString(); }));
                lblUnit.Invoke(new EventHandler(delegate { lblUnit.Text = temp[3].ToString(); }));
            }
            
            return "";
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "DevAsp Com Port APP";
            cmbBaudRate.SelectedIndex = 0;
            cmbDataBits.SelectedIndex = 0;
            cmbParity.SelectedIndex = 0;
            cmbPortName.SelectedIndex = 0;
            cmbStopBits.SelectedIndex = 0;
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // This method will be called when there is data waiting in the port's buffer

            // Determain which mode (string or binary) the user is in
            // Read all the data waiting in the buffer
            try
            {
                string data = "";
                data = comport.ReadLine();//.ReadExisting();
                // Display the text to the user in the terminal
                paringdata(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //label2.Invoke(new EventHandler(delegate{label2.Text  = data;}));

            //Log(LogMsgType.Incoming, data);

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //comport.DiscardOutBuffer();
                //comport.DiscardInBuffer();
                //comport.Dispose();
                if (comport.IsOpen)
                {
                    comport.ReadExisting();
                    comport.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // If the port is open, close it.
            try
            {

                if (button1.Text == "Start")
                {
                    if (comport.IsOpen) comport.Close();
                    else
                    {
                        // Set the port's settings
                        comport.BaudRate = int.Parse(cmbBaudRate.Text);
                        comport.DataBits = int.Parse(cmbDataBits.Text);
                        comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text);
                        comport.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
                        comport.PortName = cmbPortName.Text;
                        comport.ReadTimeout = 100;
                        comport.Open();
                        button1.Text = "Stop";
                    }
                }
                else
                {
                    if (comport.IsOpen)
                    {
                        comport.ReadExisting();
                        comport.Close();
                    }
                    button1.Text = "Start";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}