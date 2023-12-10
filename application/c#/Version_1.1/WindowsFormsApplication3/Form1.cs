using System;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        int time = 1000;

        public Form1() {
            InitializeComponent();
            EnabledButtons(true, false, false, false);
            SetTextComboBox2();
            GetAvailablePorts();
        }

        private void connect_button_click(object sender, EventArgs e) {
            object selectedItem = com_ports_combo_box.SelectedItem;
            if (CreateNewConnection(selectedItem)) main_text_box.Text = "Hello";
            else {
                main_text_box.Text = "Oops!";
                return;
            }
            EnabledButtons(false, true, false, true);
        }

        private void disconnect_button_click(object sender, EventArgs e) {
            EnabledButtons(true, false, false, false);
            port.Close();
            main_text_box.Text = "Connect to device!";
        }

        private void save_button_click(object sender, EventArgs e) {
            EnabledButtons(false, true, false, true);
            File1 = new SaveFileDialog();
            if (path == "") {
                File1.OverwritePrompt = false;
                if (File1.ShowDialog() == DialogResult.OK) {
                    path = File1.FileName;
                    writeToFile();
                }
                else {
                    main_text_box.Text = "Choose path to file!";
                    return;
                }
            }
            else {
                writeToFile();
            }
        }

        private void start_button_click(object sender, EventArgs e) {
            try {
                voltage = range_combo_box.SelectedItem.ToString();
                EnabledButtons(false, true, false, false);
            }
            catch {
                main_text_box.Text = "Choose range!";
                return;
            }
            main_text_box.Clear();
            start_button.Enabled = false;
            port.DiscardInBuffer();

            int numberOfRelays = 0;
            if (relays_16_radio_button.Checked) numberOfRelays = 16;
            else if (relays_8_radio_button.Checked) numberOfRelays = 8;
            else {
                main_text_box.Text = "Choose number of channels!";
                EnabledButtons(false, true, false, true);
                return;
            }

            for (int i = 0; i < numberOfRelays; i++) {
                port.Write("n");
                Thread.Sleep(time);
                port.Write("r");
                Thread.Sleep(400);
                ReadPort();
                //richTextBox1.Text += " code: " + code;
                if (i != numberOfRelays) main_text_box.Text += ",  ";
            }
            main_text_box.Text += "" + voltage;

            EnabledButtons(false, true, true, true);
            port.Write("e");
        }

        private void GetAvailablePorts() {
            string[] ports = SerialPort.GetPortNames();
            com_ports_combo_box.Items.Clear();
            com_ports_combo_box.Items.AddRange(ports);
        }

        private void SetTextComboBox2() {
            range_combo_box.Items.Add("A");
            range_combo_box.Items.Add("mA");
            range_combo_box.Items.Add("uA");
            range_combo_box.Items.Add("nA");
        }

        private void EnabledButtons(bool connect, bool disconnect, bool writeFile, bool start) {
            connect_button.Enabled = connect;
            disconnect_button.Enabled = disconnect;
            save_button.Enabled = writeFile;
            start_button.Enabled = start;
        }

        public bool CreateNewConnection(object selectedItem) {
            try {
                port = new SerialPort(selectedItem.ToString(), 9600);
                port.ReadTimeout = 500;
                if (!port.IsOpen) {
                    port.Open();
                    port.DiscardInBuffer();
                    return true;
                }
                else return false;
            }
            catch {
                return false;
            }
        }

        private void ReadPort() {
            try {
                if (port.BytesToRead == 1) {
                    main_text_box.Text += "I am okay";
                }
                if (port.BytesToRead == 25) {
                    counter = 0;
                    code = 0;
                    limit = 1;

                    string a = port.ReadExisting().ToString();

                    ////Положение запятой = Шифр предела
                    if (a[21] == '1') code += Convert.ToInt32(Math.Pow(2, 0));
                    if (a[22] == '1') code += Convert.ToInt32(Math.Pow(2, 1));
                    if (a[23] == '1') code += Convert.ToInt32(Math.Pow(2, 0));
                    if (a[24] == '1') code += Convert.ToInt32(Math.Pow(2, 1));

                    ////переход от V к mV
                    if (a[0] == '1') counter += Convert.ToInt32(Math.Pow(2, 0));
                    if (a[1] == '1') counter += Convert.ToInt32(Math.Pow(2, 1));

                    //Знак - H6
                    //string temp = "~";
                    //if (a[2] == '1') temp = "+";
                    //else if (a[3] == '1') temp = "-";
                    //richTextBox1.Text += temp;

                    //1/0 - H5
                    if (a[4] == '1') main_text_box.Text += "1";
                    else main_text_box.Text += "0";
                    if (code == 0 || code == 2) main_text_box.Text += ".";

                    //Цифры H4 - H1
                    for (int i = 0; i < 4; i++) {
                        int result = 0;
                        for (int j = 0; j < 4; j++) {
                            if (a[i * 4 + j + 5] == '1') {
                                result += Convert.ToInt32(Math.Pow(2, 3 - j));
                            }
                        }
                        main_text_box.Text += result;
                        if ((i == 0 && code == 3) || (i == 1 && code == 1) || (i == 1 && code == 4)) main_text_box.Text += ".";
                    }
                    limit = (code == 0) ? 1000 : ((code == 1) ? 100 : ((code == 2) ? 1 : 10));
                    //if (counter == 1) limit /= 10;
                    //voltage = (counter == 2) ? "V" : "mV";
                    //richTextBox1.Invoke((MethodInvoker)(() => richTextBox1.Text += "  " + limit + voltage));

                    //Шифр
                    //richTextBox1.Invoke((MethodInvoker)(() => richTextBox1.Text += "\nзапятая: " + counter + "\nшифр: "+ code));

                }
                else if (port.BytesToRead > 25) {
                    port.DiscardInBuffer();
                    main_text_box.Text = " Incorrect incoming data. Retry!";
                    port.DiscardInBuffer();
                }
            }
            catch (TimeoutException) {
                main_text_box.Text = "Retry!\n";
                port.DiscardInBuffer();
            }
        }

        private void writeToFile() {
            // Create a file to write to.
            using (StreamWriter sw = File.AppendText(path)) {
                sw.WriteLine(main_text_box.Text);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            time = time_track_bar.Value * 200;
        }
    }
}
