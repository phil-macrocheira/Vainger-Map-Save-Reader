using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace Porgy_Map_Save_Reader
{
    public partial class Form1 : Form
    {
        string baseDir;
        string dataDir;
        public string itemDataPath;
        public string mapPath;
        public string outputPath;

        public Form1()
        {
            InitializeComponent();

            baseDir = AppDomain.CurrentDomain.BaseDirectory;
            dataDir = Path.Combine(baseDir, "data");
            Directory.CreateDirectory(dataDir);

            itemDataPath = Path.Combine(dataDir, "PORGY_ITEM_DATA.json");
            mapPath = Path.Combine(dataDir, "MAP.png");
            outputPath = Path.Combine(baseDir, "MISSING ITEMS MAP.png");
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
            byte fuelCount = 0;
            byte torpedoCount = 0;
            byte eggCount = 0;
            byte equipmentCount = 0;
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
                if (element.ValueKind == JsonValueKind.String)
                    double.TryParse(element.GetString(), out value);
                else if (element.ValueKind == JsonValueKind.Number)
                    element.TryGetDouble(out value);

                if (key.StartsWith("game10_itemsCollected")) {
                    string item_id = key.Substring("game10_itemsCollected".Length);
                    foreach (var item in ItemData) {
                        if (item.item_id == item_id && value == 2) {
                            item.collected = true;
                            switch (item.type) {
                                case "o10__FuelTank":
                                    fuelCount++;
                                    break;
                                case "o10__TorpBoost":
                                    torpedoCount++;
                                    break;
                                case "o10_Egg":
                                    eggCount++;
                                    break;
                                case "o10_FakeWall01":
                                case "o10_FakeWall02":
                                case "o10_FakeWall03":
                                case "o10_FakeWall04":
                                    break;
                                default:
                                    equipmentCount++;
                                    break;
                            }
                        }
                    }
                }
            }

            double sum = fuelCount + torpedoCount + eggCount + equipmentCount;
            double percentNum = Math.Floor((sum / 70) * 100);
            percent = percentNum.ToString() + "%";

            labelItemsFound.Text = "Items Found: " + percent;
            labelFuel.Text = "Fuel Tanks Found: " + fuelCount + " / 20";
            labelTorpedo.Text = "Torpedos Found: " + torpedoCount + " / 20";
            labelEgg.Text = "Eggs Found: " + eggCount + " / 20";
            labelEquipment.Text = "Equipment Found: " + equipmentCount + " / 10";

            CreateMap(ItemData);
        }

        private List<Item> GetItemData()
        {
            if (File.Exists(itemDataPath)) {
                string jsonData = File.ReadAllText(itemDataPath);
                return JsonSerializer.Deserialize<List<Item>>(jsonData);
            }
            else {
                MessageBox.Show("PORGY_ITEM_DATA.json not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return new List<Item>();
            }
        }

        private void CreateMap(List<Item> ItemData)
        {
            byte circleRadius = 40;
            byte circleThickness = 10;
            var color = Color.Yellow;
            if (!File.Exists(mapPath)) {
                MessageBox.Show("MAP.png not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            using (Bitmap originalMap = new Bitmap(mapPath))
            using (Bitmap markedMap = new Bitmap(originalMap))
            using (Graphics g = Graphics.FromImage(markedMap)) {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                foreach (var item in ItemData) {
                    if (!item.collected) {
                        int offsetX = 8;
                        int offsetY = 8;

                        switch (item.room) {
                            case "rm10_SubHunt2":
                                offsetY += 1152;
                                break;
                            case "rm10_SubHunt3":
                                offsetY += 2304;
                                break;
                        }

                        int drawX = item.x + offsetX;
                        int drawY = item.y + offsetY;

                        using (Pen pen = new Pen(color, circleThickness))
                        using (System.Drawing.Font font = new System.Drawing.Font("Roboto", 30))
                        using (Brush textBrush = new SolidBrush(color)) {
                            g.DrawEllipse(pen, drawX - circleRadius, drawY - circleRadius, circleRadius * 2, circleRadius * 2);
                            string label = "";
                            SizeF textSize = g.MeasureString(label, font);
                            float textX = drawX - textSize.Width / 2;
                            float textY = drawY - circleRadius - textSize.Height - 2;
                            g.DrawString(label, font, textBrush, textX, textY);
                        }
                    }
                }

                markedMap.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
                MessageBox.Show("Missing items marked on " + outputPath);
            }
        }
    }
}
