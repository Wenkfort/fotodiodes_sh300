namespace WindowsFormsApplication3
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.com_ports_combo_box = new System.Windows.Forms.ComboBox();
            this.voltage_range_combo_box = new System.Windows.Forms.ComboBox();
            this.relays_16_radio_button = new System.Windows.Forms.RadioButton();
            this.relays_8_radio_button = new System.Windows.Forms.RadioButton();
            this.connect_button = new System.Windows.Forms.Button();
            this.disconnect_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.start_button = new System.Windows.Forms.Button();
            this.main_text_box = new System.Windows.Forms.RichTextBox();
            this.port = new System.IO.Ports.SerialPort(this.components);
            this.time_track_bar = new System.Windows.Forms.TrackBar();
            this.time_zero_label = new System.Windows.Forms.Label();
            this.time_2thousand_label = new System.Windows.Forms.Label();
            this.time_label = new System.Windows.Forms.Label();
            this.relays_4_radio_button = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.time_track_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // com_ports_combo_box
            // 
            this.com_ports_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_ports_combo_box.FormattingEnabled = true;
            this.com_ports_combo_box.Location = new System.Drawing.Point(921, 20);
            this.com_ports_combo_box.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.com_ports_combo_box.Name = "com_ports_combo_box";
            this.com_ports_combo_box.Size = new System.Drawing.Size(180, 28);
            this.com_ports_combo_box.TabIndex = 0;
            // 
            // voltage_range_combo_box
            // 
            this.voltage_range_combo_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.voltage_range_combo_box.FormattingEnabled = true;
            this.voltage_range_combo_box.Location = new System.Drawing.Point(921, 167);
            this.voltage_range_combo_box.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.voltage_range_combo_box.Name = "voltage_range_combo_box";
            this.voltage_range_combo_box.Size = new System.Drawing.Size(180, 28);
            this.voltage_range_combo_box.TabIndex = 1;
            // 
            // relays_16_radio_button
            // 
            this.relays_16_radio_button.AutoSize = true;
            this.relays_16_radio_button.Location = new System.Drawing.Point(921, 63);
            this.relays_16_radio_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.relays_16_radio_button.Name = "relays_16_radio_button";
            this.relays_16_radio_button.Size = new System.Drawing.Size(97, 24);
            this.relays_16_radio_button.TabIndex = 2;
            this.relays_16_radio_button.TabStop = true;
            this.relays_16_radio_button.Text = "16 relays";
            this.relays_16_radio_button.UseVisualStyleBackColor = true;
            // 
            // relays_8_radio_button
            // 
            this.relays_8_radio_button.AutoSize = true;
            this.relays_8_radio_button.Location = new System.Drawing.Point(921, 100);
            this.relays_8_radio_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.relays_8_radio_button.Name = "relays_8_radio_button";
            this.relays_8_radio_button.Size = new System.Drawing.Size(88, 24);
            this.relays_8_radio_button.TabIndex = 3;
            this.relays_8_radio_button.TabStop = true;
            this.relays_8_radio_button.Text = "8 relays";
            this.relays_8_radio_button.UseVisualStyleBackColor = true;
            // 
            // connect_button
            // 
            this.connect_button.Location = new System.Drawing.Point(20, 20);
            this.connect_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(112, 35);
            this.connect_button.TabIndex = 4;
            this.connect_button.Text = "Connect";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_click);
            // 
            // disconnect_button
            // 
            this.disconnect_button.Location = new System.Drawing.Point(20, 66);
            this.disconnect_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.disconnect_button.Name = "disconnect_button";
            this.disconnect_button.Size = new System.Drawing.Size(112, 35);
            this.disconnect_button.TabIndex = 5;
            this.disconnect_button.Text = "Disconnect";
            this.disconnect_button.UseVisualStyleBackColor = true;
            this.disconnect_button.Click += new System.EventHandler(this.disconnect_button_click);
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(991, 513);
            this.save_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(112, 35);
            this.save_button.TabIndex = 6;
            this.save_button.Text = "Write to file";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_click);
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(871, 513);
            this.start_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(112, 35);
            this.start_button.TabIndex = 7;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_click);
            // 
            // main_text_box
            // 
            this.main_text_box.Location = new System.Drawing.Point(21, 282);
            this.main_text_box.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.main_text_box.Name = "main_text_box";
            this.main_text_box.Size = new System.Drawing.Size(1082, 221);
            this.main_text_box.TabIndex = 8;
            this.main_text_box.Text = "";
            // 
            // time_track_bar
            // 
            this.time_track_bar.LargeChange = 1;
            this.time_track_bar.Location = new System.Drawing.Point(919, 203);
            this.time_track_bar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.time_track_bar.Maximum = 5;
            this.time_track_bar.Minimum = 1;
            this.time_track_bar.Name = "time_track_bar";
            this.time_track_bar.Size = new System.Drawing.Size(182, 69);
            this.time_track_bar.TabIndex = 9;
            this.time_track_bar.Value = 1;
            this.time_track_bar.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // time_zero_label
            // 
            this.time_zero_label.AutoSize = true;
            this.time_zero_label.Location = new System.Drawing.Point(917, 252);
            this.time_zero_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.time_zero_label.Name = "time_zero_label";
            this.time_zero_label.Size = new System.Drawing.Size(18, 20);
            this.time_zero_label.TabIndex = 10;
            this.time_zero_label.Text = "1";
            // 
            // time_2thousand_label
            // 
            this.time_2thousand_label.AutoSize = true;
            this.time_2thousand_label.Location = new System.Drawing.Point(1083, 252);
            this.time_2thousand_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.time_2thousand_label.Name = "time_2thousand_label";
            this.time_2thousand_label.Size = new System.Drawing.Size(18, 20);
            this.time_2thousand_label.TabIndex = 11;
            this.time_2thousand_label.Text = "5";
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(817, 203);
            this.time_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(85, 20);
            this.time_label.TabIndex = 12;
            this.time_label.Text = "время в с:";
            // 
            // relays_4_radio_button
            // 
            this.relays_4_radio_button.AutoSize = true;
            this.relays_4_radio_button.Location = new System.Drawing.Point(921, 135);
            this.relays_4_radio_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.relays_4_radio_button.Name = "relays_4_radio_button";
            this.relays_4_radio_button.Size = new System.Drawing.Size(88, 24);
            this.relays_4_radio_button.TabIndex = 15;
            this.relays_4_radio_button.TabStop = true;
            this.relays_4_radio_button.Text = "4 relays";
            this.relays_4_radio_button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 562);
            this.Controls.Add(this.relays_4_radio_button);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.time_2thousand_label);
            this.Controls.Add(this.time_zero_label);
            this.Controls.Add(this.time_track_bar);
            this.Controls.Add(this.main_text_box);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.disconnect_button);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.relays_8_radio_button);
            this.Controls.Add(this.relays_16_radio_button);
            this.Controls.Add(this.voltage_range_combo_box);
            this.Controls.Add(this.com_ports_combo_box);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "USSR multimeter";
            ((System.ComponentModel.ISupportInitialize)(this.time_track_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox com_ports_combo_box;
        private System.Windows.Forms.ComboBox voltage_range_combo_box;
        private System.Windows.Forms.RadioButton relays_16_radio_button;
        private System.Windows.Forms.RadioButton relays_8_radio_button;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.Button disconnect_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.RichTextBox main_text_box;
        private System.IO.Ports.SerialPort port;
        private static int counter = 0;
        private static int code = 0;
        private static int limit = 1;
        private static string voltage = "";
        private string path = "";
        private System.Windows.Forms.SaveFileDialog File1;
        private System.Windows.Forms.TrackBar time_track_bar;
        private System.Windows.Forms.Label time_zero_label;
        private System.Windows.Forms.Label time_2thousand_label;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.RadioButton relays_4_radio_button;
    }
}

