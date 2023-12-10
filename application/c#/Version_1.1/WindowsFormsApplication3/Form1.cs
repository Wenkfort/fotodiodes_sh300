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
            time = get_time();
            EnabledButtons(true, false, false, false);
            SetVoltageUnitComboBox();
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
        private int range_text_to_code(string range_string)
        {
            range_string = range_string.Replace(" ", string.Empty);

            switch (range_string)
            {
                case "1":
                    return 2;
                case "10":
                    return 3;
                case "100":
                    return 1;
            }
            return -1;
        }

        private void start_button_click(object sender, EventArgs e) {
            try {
                string[] voltage_range = voltage_range_combo_box.SelectedItem.ToString().Split(' ');
                if (voltage_range.Length != 2)
                {
                    main_text_box.Text = "Incorrect range!";
                }
                voltage = voltage_range[1];
                code = range_text_to_code(voltage_range[0]);

                EnabledButtons(false, true, false, false);
            }
            catch {
                main_text_box.Text = "Set correct range!";
                return;
            }
            main_text_box.Clear();
            start_button.Enabled = false;
            port.DiscardInBuffer();

            int numberOfRelays = 0;
            if (relays_16_radio_button.Checked) numberOfRelays = 16;
            else if (relays_8_radio_button.Checked) numberOfRelays = 8;
            else if (relays_4_radio_button.Checked) numberOfRelays = 4;
            else
            {
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
            main_text_box.Text += voltage;

            EnabledButtons(false, true, true, true);
            port.Write("e");
        }

        private void GetAvailablePorts() {
            string[] ports = SerialPort.GetPortNames();
            com_ports_combo_box.Items.Clear();
            com_ports_combo_box.Items.AddRange(ports);
        }

        private void SetVoltageUnitComboBox() {
            voltage_range_combo_box.Items.Add("1 A");
            voltage_range_combo_box.Items.Add("100 mA");
            voltage_range_combo_box.Items.Add("10 mA");
            voltage_range_combo_box.Items.Add("1 mA");
            voltage_range_combo_box.Items.Add("100 uA");
            voltage_range_combo_box.Items.Add("10 uA");
            voltage_range_combo_box.Items.Add("1 uA");
            voltage_range_combo_box.Items.Add("100 nA");
            voltage_range_combo_box.SelectedIndex = 7;
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
                // if (port.BytesToRead == 25) {
                if (true) {
                    counter = 0;
                    limit = 1;

                    // string received_data = port.ReadExisting().ToString();
                    string received_data = "11110";
                    received_data += "0000";
                    received_data += "0001";
                    received_data += "0010";
                    received_data += "0011";
                    received_data += "0100";

                    ////Положение запятой = Шифр предела
                    // if (received_data[21] == '1') code += Convert.ToInt32(Math.Pow(2, 0));
                    // if (received_data[22] == '1') code += Convert.ToInt32(Math.Pow(2, 1));
                    // if (received_data[23] == '1') code += Convert.ToInt32(Math.Pow(2, 0));
                    // if (received_data[24] == '1') code += Convert.ToInt32(Math.Pow(2, 1));

                    ////переход от V к mV
                    if (received_data[0] == '1') counter += Convert.ToInt32(Math.Pow(2, 0));
                    if (received_data[1] == '1') counter += Convert.ToInt32(Math.Pow(2, 1));

                    //Знак - H6
                    //string temp = "~";
                    //if (a[2] == '1') temp = "+";
                    //else if (a[3] == '1') temp = "-";
                    //richTextBox1.Text += temp;

                    //1/0 - H5
                    if (received_data[4] == '1') main_text_box.Text += "1";
                    else main_text_box.Text += "0";
                    if (code == 0 || code == 2) main_text_box.Text += ".";

                    //Цифры H4 - H1
                    for (int i = 0; i < 4; i++) {
                        int result = 0;
                        for (int j = 0; j < 4; j++) {
                            if (received_data[i * 4 + j + 5] == '1') {
                                result += Convert.ToInt32(Math.Pow(2, 3 - j));
                            }
                        }
                        main_text_box.Text += result;
                        if ((i == 0 && code == 3) || (i == 1 && code == 1) || (i == 1 && code == 4))
                        {
                            main_text_box.Text += ".";
                        }
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
            time = get_time();
        }

        private int get_time()
        {
            return time_track_bar.Value * 1000;
        }
    }
}
