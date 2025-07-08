using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.Json;
using System.Diagnostics;
using System.Xml.Linq;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace Vainger_Map_Save_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string saveFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ufo50", "save1.ufo");
            if (!File.Exists(saveFilePath)) {
                OpenSaveFileDialog();
            }
            else {
                ReadSaveFile(saveFilePath);
            }
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            OpenSaveFileDialog();
        }
        private void OpenSaveFileDialog()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ufo50");
                openFileDialog.Filter = "UFO Save Files (*.ufo)|*.ufo|All Files (*.*)|*.*";
                openFileDialog.Title = "Select a UFO Save File";

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    string filePath = openFileDialog.FileName;
                    ReadSaveFile(filePath);
                }
            }
        }
        private void ReadSaveFile(string filePath)
        {
            int posX = 0;
            int posY = 0;
            int room = 0;
            int currentX = 0;
            byte shieldCount = 0;
            byte stabilizerCount = 0;
            byte cloneCount = 0;
            string percent = "0%";
            List<Item> ItemData = GetItemData();

            label1.Text = filePath;
            string rawSave = File.ReadAllText(filePath);
            rawSave = rawSave.TrimEnd('\0');
            byte[] bytes = Convert.FromBase64String(rawSave);
            string decodedString = Encoding.UTF8.GetString(bytes);

            var variables = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(decodedString);
            foreach (var variable in variables) {
                string key = variable.Key;
                double value = 0;
                JsonElement element = variable.Value;
                if (element.ValueKind == JsonValueKind.Number) {
                    
                    if (element.TryGetDouble(out value)) {
                        if (key.StartsWith("game7_collectListX")) {
                            currentX = (int)value;
                            //Debug.WriteLine(variable.ToString());
                        }
                        else if (key.StartsWith("game7_collectListY")) {
                            foreach (var item in ItemData) {
                                if (item.X == currentX && item.Y == (int)value) {
                                    item.Collected = true;
                                    switch (item.Type) {
                                        case "Shield":
                                            shieldCount++;
                                            break;
                                        case "Stabilizer":
                                            stabilizerCount++;
                                            break;
                                        case "Clone":
                                            cloneCount++;
                                            break;
                                        default:
                                            break;
                                    }
                                }

                                //Debug.WriteLine(variable.ToString());
                            }
                        }
                        else if (key == "game7_posX") {
                            posX = (int)value;
                            //Debug.WriteLine(variable.ToString());
                        }
                        else if (key == "game7_posY") {
                            posY = (int)value;
                            //Debug.WriteLine(variable.ToString());
                        }
                        else if (key == "game7_room") {
                            room = (int)value;
                            //Debug.WriteLine(variable.ToString());
                        }
                    }
                }
                else if (element.ValueKind == JsonValueKind.String) {
                    string stringValue = element.GetString();
                    if (key == "game0_detailValue17") {
                        percent = stringValue;
                        //Debug.WriteLine(variable.ToString());
                    }
                }
            }

            labelItemsFound.Text = "Items Found: " + percent;
            labelShield.Text = "Shields Found: " + shieldCount + " / 25";
            labelStabilizer.Text = "Stabilizers Found: " + stabilizerCount + " / 2";
            labelClone.Text = "Clones Found: " + cloneCount + " / 3";

            CreateMap(ItemData,posX,posY,room);
        }
        private List<Item> GetItemData()
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "VAINGER_ITEM_DATA.json");
            if (File.Exists(jsonPath)) {
                string jsonData = File.ReadAllText(jsonPath);
                return JsonSerializer.Deserialize<List<Item>>(jsonData);
            }
            else {
                MessageBox.Show("VAINGER_ITEM_DATA.json not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
                return new List<Item>();
            }
        }
        private void CreateMap(List<Item> ItemData,int playerX,int playerY,int playerRoom)
        {
            byte circleRadius = 64;
            byte circleThickness = 16;
            var color = Color.Yellow;
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MISSING ITEMS MAP.png");
            string mapPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "MAP.png");
            if (!File.Exists(mapPath)) {
                MessageBox.Show("MAP.png not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
                return;
            }

            using (Bitmap originalMap = new Bitmap(mapPath)) {
                using (Bitmap markedMap = new Bitmap(originalMap)) {
                    using (Graphics g = Graphics.FromImage(markedMap)) {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                        // Mark player
                        switch (playerRoom) {
                            case 2:
                                playerX += 3840;
                                break;
                            case 3:
                                playerY += 2464;
                                break;
                            case 4:
                                playerX += 4224;
                                playerY += 2464;
                                break;
                            default:
                                break;
                        }
                        using (Pen playerPen = new Pen(color, circleThickness))
                        using (System.Drawing.Font playerFont = new System.Drawing.Font("Roboto", 30))
                        using (Brush playerTextBrush = new SolidBrush(color)) {
                            g.DrawEllipse(playerPen, playerX - circleRadius, playerY - circleRadius, circleRadius * 2, circleRadius * 2);

                            string label = "PLAYER";
                            SizeF textSize = g.MeasureString(label, playerFont);
                            float textX = playerX - textSize.Width / 2;
                            float textY = playerY - circleRadius - textSize.Height - 2;
                            g.DrawString(label, playerFont, playerTextBrush, textX, textY);
                        }

                        // Mark each item
                        foreach (var item in ItemData) {
                            if (item.Collected == false) {
                                int offsetX = 8;
                                int offsetY = 8;

                                switch (item.Room) {
                                    case "rm07_GravGuns2":
                                        offsetX += 3840;
                                        break;
                                    case "rm07_GravGuns3":
                                        offsetY += 2464;
                                        break;
                                    case "rm07_GravGuns4":
                                        offsetX += 4224;
                                        offsetY += 2464;
                                        break;
                                    default:
                                        break;
                                }

                                int drawX = item.X + offsetX;
                                int drawY = item.Y + offsetY;

                                using (Pen pen = new Pen(color, circleThickness))
                                using (System.Drawing.Font font = new System.Drawing.Font("Roboto", 30))
                                using (Brush textBrush = new SolidBrush(color)) {
                                    g.DrawEllipse(pen, drawX - circleRadius, drawY - circleRadius, circleRadius * 2, circleRadius * 2);

                                    //string label = item.Type + " (" + item.X + ", " + item.Y + ")";
                                    string label = "";
                                    SizeF textSize = g.MeasureString(label, font);
                                    float textX = drawX - textSize.Width / 2;
                                    float textY = drawY - circleRadius - textSize.Height - 2;
                                    g.DrawString(label, font, textBrush, textX, textY);
                                }
                            }
                        }
                    }
                    markedMap.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Missing items marked on " + outputPath);
                }
            }
        }
    }
}