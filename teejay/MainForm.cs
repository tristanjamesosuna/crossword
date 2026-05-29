using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace teejay
{
    public partial class MainForm : Form
    {
        // Art style data: each style has up to 5 artworks
        private Dictionary<string, List<ArtworkInfo>> artData = new Dictionary<string, List<ArtworkInfo>>();
        private string currentStyle = "";

        public MainForm()
        {
            InitializeComponent();
            InitializeArtData();
            SetupButtons();
        }

        private void InitializeArtData()
        {
           artData["Gothic Art"] = new List<ArtworkInfo>
		{
    		new ArtworkInfo("Lamentation (The Mourning of Christ)", "Artist: Giotto di Bondone\nInfo: Located in the Scrovegni Chapel (Arena Chapel) in Padua, Italy.", ""),
    		new ArtworkInfo("Lion", "Artist: Unknown medieval artisan\nInfo: A medieval depiction of a lion symbolizing strength and power. Such beasts in Gothic art often carried symbolic meaning, though specific intentions are not always reconstructable.", ""),
    		new ArtworkInfo("Reims Cathedral Sculptures", "Artist: Anonymous Gothic sculptors\nInfo: Reims Cathedral contains 2,303 sculptures carved in the 13th century from local limestone, celebrated for emotional expression and classical realism.", ""),
		};

			artData["Realism"] = new List<ArtworkInfo>
		{
    		new ArtworkInfo("The Wheat Sifters (Les Cribleuses de blé)", "Artist: Gustave Courbet\nInfo: Painted in 1854, it depicts women sifting wheat — highlighting rural labor and realism.", ""),
    		new ArtworkInfo("Young Ladies of the Village", "Artist: Gustave Courbet\nInfo: Painted in 1852, it shows Courbet’s sisters offering food to a peasant girl in Ornans.", ""),
    		new ArtworkInfo("The Angelus", "Artist: Jean-François Millet\nInfo: Painted between 1857–1859, it depicts two peasants pausing in a potato field to pray at dusk.", ""),
		};

			artData["Pop Art"] = new List<ArtworkInfo>
		{
    		new ArtworkInfo("Marilyn Diptych", "Artist: Andy Warhol\nInfo: Created in 1962 shortly after Marilyn Monroe’s death, using a publicity photo repeated in vivid and fading colors.", ""),
    		new ArtworkInfo("M-Maybe", "Artist: Roy Lichtenstein\nInfo: Painted in 1965, it shows a blonde woman with a thought bubble: 'M-Maybe he became ill and couldn't leave the studio.'", ""),
    		new ArtworkInfo("In the Car", "Artist: Roy Lichtenstein\nInfo: Painted in 1963, based on a comic panel, showing a tense moment between a glamorous woman and a man in a red car.", ""),
		};

			artData["Anime/Manga Style"] = new List<ArtworkInfo>
		{
    		new ArtworkInfo("Chihiro Rokuhira (Kagurabachi)", "Artist: Takeru Hokazono\nInfo: The 18-year-old protagonist of the dark fantasy manga series Kagurabachi.", ""),
    		new ArtworkInfo("Shirokura", "Artist: Grimkaru\nInfo: A digital illustration in high-contrast black-and-white, blending horror, goth, and emo aesthetics.", ""),
    		new ArtworkInfo("Dark Monochrome Horror", "Artist: Grimkaru\nInfo: Features a hand tattoo resembling an ankh and a stylized eye design on the palm.", ""),
		};

			artData["Minimalism"] = new List<ArtworkInfo>
		{
    		new ArtworkInfo("Composition with Large Red Plane, Yellow, Black, Grey and Blue", "Artist: Piet Mondrian\nInfo: Painted in 1921, Mondrian used abstraction to express universal truths underlying nature.", ""),
    		new ArtworkInfo("Architectural Butterfly Boom", "Artist: Brent Hallard\nInfo: Explores space and geometry, manipulating arrangements to challenge perception.", ""),
    		new ArtworkInfo("Die Fahne hoch!", "Artist: Frank Stella\nInfo: From his Black Paintings series (1959), bridging Abstract Expressionism and Minimalism.", ""),
		};

			artData["Renaissance Art"] = new List<ArtworkInfo>
		{
    		new ArtworkInfo("Mona Lisa", "Artist: Leonardo da Vinci\nInfo: Painted between 1503–1519, famous for its enigmatic smile.", ""),
    		new ArtworkInfo("The Creation of Adam", "Artist: Michelangelo\nInfo: A fresco on the Sistine Chapel ceiling (1512), depicting God giving life to Adam.", ""),
    		new ArtworkInfo("The School of Athens", "Artist: Raphael\nInfo: A 1511 fresco in the Vatican, showing ancient philosophers in an idealized setting.", ""),
		};

			artData["Impressionism"] = new List<ArtworkInfo>
		{
		    new ArtworkInfo("Impression, Sunrise", "Artist: Claude Monet\nInfo: Painted in 1872, it gave the Impressionist movement its name, showing a misty harbor at dawn.", ""),
		    new ArtworkInfo("A Sunday on La Grande Jatte", "Artist: Georges Seurat\nInfo: Completed in 1886 using pointillism, depicting Parisians relaxing on the Seine island.", ""),
		    new ArtworkInfo("Dance at Le Moulin de la Galette", "Artist: Pierre-Auguste Renoir\nInfo: Painted in 1876, showing a lively outdoor dance in Montmartre.", ""),
		};

			artData["Graffiti Art"] = new List<ArtworkInfo>
		{
    		new ArtworkInfo("Balloon Girl", "Artist: Banksy\nInfo: A stencil of a girl reaching for a heart-shaped balloon, one of Banksy’s most iconic works.", ""),
    		new ArtworkInfo("Save Our Bullies", "Artist: Posto and Shave\nInfo: A mural supporting the breed amid UK ban discussions.", ""),
    		new ArtworkInfo("Einstein Mural", "Artist: Eduardo Kobra\nInfo: A vibrant large-scale street mural of Albert Einstein.", ""),
		};

			artData["Surrealism"] = new List<ArtworkInfo>
		{
    		new ArtworkInfo("The Persistence of Memory", "Artist: Salvador Dalí\nInfo: Painted in 1931, featuring melting clocks in a barren landscape.", ""),
    		new ArtworkInfo("The Son of Man", "Artist: René Magritte\nInfo: A 1964 self-portrait with an apple obscuring the face, questioning identity.", ""),
    		new ArtworkInfo("The Two Fridas", "Artist: Frida Kahlo\nInfo: Painted in 1939, showing two versions of herself connected by a vein, exploring identity and heartbreak.", ""),
		};

        }

        private void SetupButtons()
        {
            // Map button names to art styles
            button1.Text = "Gothic Art";
            button2.Text = "Realism";
            button3.Text = "Pop Art";
            button4.Text = "Anime/Manga Style";
            button5.Text = "Minimalism";
            button6.Text = "Renaissance Art";
            button7.Text = "Impressionism";
            button8.Text = "Graffiti Art";
            button9.Text = "Surrealism";

            // Wire up click events
            button1.Click += (s, e) => OnArtStyleClick("Gothic Art");
            button2.Click += (s, e) => OnArtStyleClick("Realism");
            button3.Click += (s, e) => OnArtStyleClick("Pop Art");
            button4.Click += (s, e) => OnArtStyleClick("Anime/Manga Style");
            button5.Click += (s, e) => OnArtStyleClick("Minimalism");
            button6.Click += (s, e) => OnArtStyleClick("Renaissance Art");
            button7.Click += (s, e) => OnArtStyleClick("Impressionism");
            button8.Click += (s, e) => OnArtStyleClick("Graffiti Art");
            button9.Click += (s, e) => OnArtStyleClick("Surrealism");

            // Wire up listBox selection change
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            listBox1.ItemHeight = 30;
            listBox1.DrawItem += ListBox1_DrawItem;

            // Default label
            label1.Text = "Select an art style to begin.";
        }

        private void OnArtStyleClick(string styleName)
        {
            currentStyle = styleName;

            // Populate listBox with artwork titles for this style
            listBox1.Items.Clear();
            if (artData.ContainsKey(styleName))
            {
                foreach (var artwork in artData[styleName])
                    listBox1.Items.Add(artwork.Title);
            }

            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentStyle) && listBox1.SelectedIndex >= 0)
            {
                ShowArtwork(currentStyle, listBox1.SelectedIndex);
            }
        }

        private void ShowArtwork(string styleName, int index)
        {
            if (!artData.ContainsKey(styleName)) return;

            var artworks = artData[styleName];
            if (index < 0 || index >= artworks.Count) return;

            var artwork = artworks[index];

            label1.Text = "Title: " + artwork.Title + "\n\n" + artwork.Info;

            // Load image from URL
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Headers.Add("User-Agent", "Mozilla/5.0");
                    byte[] imgData = wc.DownloadData(artwork.ImageUrl);
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imgData))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
            catch
            {
                pictureBox1.Image = null;
                label1.Text += "\n\n[Image could not be loaded]";
            }
        }

        private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            string text = listBox1.Items[e.Index].ToString();
            Rectangle rect = new Rectangle(e.Bounds.X + 5, e.Bounds.Y + 5, e.Bounds.Width, e.Bounds.Height);

            using (Brush brush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(text, e.Font, brush, rect);
            }

            e.DrawFocusRectangle();
        }

        // Required by MainForm.Designer.cs — wired automatically by the designer
        private void Label3Click(object sender, EventArgs e)
        {
            // No action needed — label click is handled by the designer
        }
    }

    public class ArtworkInfo
    {
        public string Title { get; set; }
        public string Info { get; set; }
        public string ImageUrl { get; set; }

        public ArtworkInfo(string title, string info, string imageUrl)
        {
            Title = title;
            Info = info;
            ImageUrl = imageUrl;
        }
    }
}
