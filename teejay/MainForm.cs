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
                new ArtworkInfo("13th-century Stained Glass Panel", "Artist: Anonymous medieval workshop\nInfo: The panel was created around 1243–1248 in the Île-de-France region.\nIt was commissioned by King Louis IX to be housed in the Sainte-Chapelle, a royal Gothic chapel built to protect relics of Christ's passion.\n The specific panel is now part of the collections at the Victoria and Albert Museum in London." , ""),
                new ArtworkInfo("The Milan Cathedral (also known as Duomo di Milano)", "Artist: Various architects and artisans\nInfo: Construction of this massive Gothic cathedral began in 1386 and took nearly six centuries to complete, with final details finished in 1965. It is the largest church in Italy and the third largest in the world by surface area.", ""),
                new ArtworkInfo("Lamentation (The Mourning of Christ)", "Artist: Giotto di Bondone.\nInfo: It is located in the Scrovegni Chapel (also known as the Arena Chapel) in Padua, Italy.", ""),
                new ArtworkInfo("Lion", "Artist: Unknown medieval artisan\nInfo:By portraying this lion with his muscles taut, his fur standing on end, and his gaze intense, the artist conveyed the power of this snarling big cat. Medieval beasts, whether real or imaginary, were often imbued with symbolic meaning, as they are in animal fables today. It is not always possible, however, to reconstruct their specific intention in a given monument, and such beasts could be for “aesthetic delight,” as one thirteenth-century archbishop commented. The monastery from which this fresco comes was abandoned in 1841.", ""),
                new ArtworkInfo("Reims Cathedral Sculptures", "Artist: Anonymous Gothic sculptors\nInfo: Reims Cathedral boasts the largest collection of statuary of any European religious edifice, containing exactly 2,303 individual sculptures. Carved primarily during the 13th century from soft, regional limestone, these French High Gothic masterpieces decorate the exterior walls, portals, and upper galleries. The sculptures are internationally celebrated for their deep emotional expressions, lifelike fabric drapery, and a distinct stylistic shift toward classical realism", ""),
            };
            artData["Realism"] = new List<ArtworkInfo>
            {
                new ArtworkInfo("The Stone Breakers", "Artist: Gustave Courbet\nEmotion: Empathy & Struggle\nInfo: Painted in 1849, it depicts two laborers breaking stones — a bold statement on working-class hardship.", "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7e/Gustave_Courbet_-_The_Stone_Breakers_-_1849.jpg/320px-Gustave_Courbet_-_The_Stone_Breakers_-_1849.jpg"),
                new ArtworkInfo("The Gleaners", "Artist: Jean-François Millet\nEmotion: Humility & Dignity\nInfo: Three peasant women glean leftover grain after the harvest in this 1857 masterpiece.", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1f/Jean-Fran%C3%A7ois_Millet_-_Gleaners_-_Google_Art_Project_2.jpg/320px-Jean-Fran%C3%A7ois_Millet_-_Gleaners_-_Google_Art_Project_2.jpg"),
                new ArtworkInfo("Arrangement in Grey and Black", "Artist: James McNeill Whistler\nEmotion: Calm & Nostalgia\nInfo: Known as 'Whistler's Mother' (1871), a quiet portrait that became a symbol of motherhood.", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Whistlers_Mother_high_res.jpg/253px-Whistlers_Mother_high_res.jpg"),
                new ArtworkInfo("The Gross Clinic", "Artist: Thomas Eakins\nEmotion: Tension & Admiration\nInfo: A 1875 portrait of surgeon Dr. Samuel Gross operating, praised for its unflinching realism.", "https://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Eakins_The_Gross_Clinic.jpg/222px-Eakins_The_Gross_Clinic.jpg"),
                new ArtworkInfo("Nighthawks", "Artist: Edward Hopper\nEmotion: Loneliness & Isolation\nInfo: A 1942 painting of people in a late-night diner, one of the most recognized images of American art.", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a8/Nighthawks_by_Edward_Hopper_1942.jpg/320px-Nighthawks_by_Edward_Hopper_1942.jpg")
            };

            artData["Pop Art"] = new List<ArtworkInfo>
            {
                new ArtworkInfo("Marilyn Diptych", "Artist: Andy Warhol\nEmotion: Fame & Mortality\nInfo: Created in 1962 after Marilyn Monroe's death, it explores celebrity culture through repetition and color.", "https://upload.wikimedia.org/wikipedia/en/thumb/0/0c/Marilyndiptych.jpg/320px-Marilyndiptych.jpg"),
                new ArtworkInfo("Whaam!", "Artist: Roy Lichtenstein\nEmotion: Excitement & Action\nInfo: A large 1963 diptych based on a comic strip panel, depicting a fighter jet firing a missile.", "https://upload.wikimedia.org/wikipedia/en/thumb/b/b8/Roy_Lichtenstein_Whaam.jpg/320px-Roy_Lichtenstein_Whaam.jpg"),
                new ArtworkInfo("Campbell's Soup Cans", "Artist: Andy Warhol\nEmotion: Mundanity & Commentary\nInfo: 32 canvases of soup cans exhibited in 1962, challenging the boundaries between commercial art and fine art.", "https://upload.wikimedia.org/wikipedia/en/thumb/b/b0/Campbell%27s_Soup_Cans_MOMA.jpg/180px-Campbell%27s_Soup_Cans_MOMA.jpg"),
                new ArtworkInfo("Just What Is It?", "Artist: Richard Hamilton\nEmotion: Satire & Curiosity\nInfo: A 1956 collage considered one of the first Pop Art works, commenting on consumer culture.", "https://upload.wikimedia.org/wikipedia/en/thumb/e/e8/Hamilton-appealing.jpg/213px-Hamilton-appealing.jpg"),
                new ArtworkInfo("Oh, Jeff...I Love You, Too...But...", "Artist: Roy Lichtenstein\nEmotion: Romance & Irony\nInfo: A 1964 painting in Lichtenstein's signature comic-book style, exploring melodrama and love.", "https://upload.wikimedia.org/wikipedia/en/thumb/a/a4/Roy_Lichtenstein_I_Love_You.jpg/213px-Roy_Lichtenstein_I_Love_You.jpg")
            };

            artData["Anime/Manga Style"] = new List<ArtworkInfo>
            {
                new ArtworkInfo("Akira (1988)", "Artist: Katsuhiro Otomo\nEmotion: Chaos & Power\nInfo: Groundbreaking anime film set in a dystopian Neo-Tokyo. Famous for fluid animation and detailed cityscapes.", "https://upload.wikimedia.org/wikipedia/en/thumb/4/4e/Akira_%281988_film%29.jpg/220px-Akira_%281988_film%29.jpg"),
                new ArtworkInfo("Spirited Away Poster", "Artist: Hayao Miyazaki / Studio Ghibli\nEmotion: Wonder & Adventure\nInfo: 2001 Oscar-winning film about a girl navigating a spirit world, rich in Japanese folklore.", "https://upload.wikimedia.org/wikipedia/en/thumb/d/db/Spirited_Away_Japanese_poster.png/220px-Spirited_Away_Japanese_poster.png"),
                new ArtworkInfo("Dragon Ball Super Broly", "Artist: Akira Toriyama\nEmotion: Intensity & Thrill\nInfo: The legendary Broly character redesigned in 2018, featuring explosive battle animation.", "https://upload.wikimedia.org/wikipedia/en/thumb/6/65/Dragon_Ball_Super_Broly_poster.jpg/220px-Dragon_Ball_Super_Broly_poster.jpg"),
                new ArtworkInfo("Demon Slayer: Mugen Train", "Artist: Ufotable Studio\nEmotion: Grief & Courage\nInfo: 2020 film continuation of the anime series; became Japan's highest-grossing film ever.", "https://upload.wikimedia.org/wikipedia/en/thumb/4/45/Demon_Slayer_-Kimetsu_no_Yaiba-_The_Movie_Mugen_Train_poster.jpg/220px-Demon_Slayer_-Kimetsu_no_Yaiba-_The_Movie_Mugen_Train_poster.jpg"),
                new ArtworkInfo("Your Name (Kimi no Na wa)", "Artist: Makoto Shinkai\nEmotion: Longing & Love\nInfo: A 2016 romantic fantasy anime about two teenagers who mysteriously swap bodies, renowned for breathtaking visuals.", "https://upload.wikimedia.org/wikipedia/en/thumb/0/0b/Your_Name_poster.png/220px-Your_Name_poster.png")
            };

            artData["Minimalism"] = new List<ArtworkInfo>
            {
                new ArtworkInfo("Black Square", "Artist: Kazimir Malevich\nEmotion: Emptiness & Purity\nInfo: Painted in 1915, it is considered a seminal work in abstract art — a black square on white background.", "https://upload.wikimedia.org/wikipedia/en/thumb/0/00/Kazimir_Malevich%2C_1915%2C_Black_Suprematic_Square%2C_oil_on_linen_canvas%2C_79.5_x_79.5_cm%2C_Tretyakov_Gallery%2C_Moscow.jpg/240px-Kazimir_Malevich%2C_1915%2C_Black_Suprematic_Square%2C_oil_on_linen_canvas%2C_79.5_x_79.5_cm%2C_Tretyakov_Gallery%2C_Moscow.jpg"),
                new ArtworkInfo("One: Number 31", "Artist: Jackson Pollock\nEmotion: Energy & Freedom\nInfo: A 1950 large-scale drip painting, minimalist in its repetitive action despite its chaotic appearance.", "https://upload.wikimedia.org/wikipedia/en/thumb/a/a1/Pollock_No_31.jpg/320px-Pollock_No_31.jpg"),
                new ArtworkInfo("The Clock", "Artist: Christian Marclay\nEmotion: Awareness & Time\nInfo: A 24-hour video artwork (2010) stitched from film clips showing clocks, synchronized to real time.", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a1/Blank_clock.svg/240px-Blank_clock.svg"),
                new ArtworkInfo("Untitled (Stack)", "Artist: Donald Judd\nEmotion: Order & Simplicity\nInfo: Ten identical steel boxes mounted vertically on a wall, exploring pure form without representation.", "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ec/Donald_Judd_-_Untitled_%28Stack%29_-_Google_Art_Project.jpg/240px-Donald_Judd_-_Untitled_%28Stack%29_-_Google_Art_Project.jpg"),
                new ArtworkInfo("Who's Afraid of Red, Yellow and Blue", "Artist: Barnett Newman\nEmotion: Boldness & Calm\nInfo: A series of large color field paintings (1966–70) using primary colors to evoke pure emotion.", "https://upload.wikimedia.org/wikipedia/en/thumb/3/3e/Barnett_Newman_-_Who%27s_Afraid_of_Red%2C_Yellow_and_Blue_III.jpg/320px-Barnett_Newman_-_Who%27s_Afraid_of_Red%2C_Yellow_and_Blue_III.jpg")
            };

            artData["Renaissance Art"] = new List<ArtworkInfo>
            {
                new ArtworkInfo("Mona Lisa", "Artist: Leonardo da Vinci\nEmotion: Mystery & Serenity\nInfo: Painted between 1503–1519, it is the world's most famous portrait, noted for its enigmatic smile.", "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ec/Mona_Lisa%2C_by_Leonardo_da_Vinci%2C_from_C2RMF_retouched.jpg/213px-Mona_Lisa%2C_by_Leonardo_da_Vinci%2C_from_C2RMF_retouched.jpg"),
                new ArtworkInfo("The Creation of Adam", "Artist: Michelangelo\nEmotion: Divinity & Connection\nInfo: A fresco on the Sistine Chapel ceiling (1512), depicting God breathing life into Adam.", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5b/Michelangelo_-_Creation_of_Adam_%28cropped%29.jpg/320px-Michelangelo_-_Creation_of_Adam_%28cropped%29.jpg"),
                new ArtworkInfo("The School of Athens", "Artist: Raphael\nEmotion: Wisdom & Harmony\nInfo: A 1511 fresco in the Vatican, depicting ancient Greek philosophers in an idealized architectural setting.", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/49/%22The_School_of_Athens%22_by_Raffaello_Sanzio_da_Urbino.jpg/320px-%22The_School_of_Athens%22_by_Raffaello_Sanzio_da_Urbino.jpg"),
                new ArtworkInfo("Birth of Venus", "Artist: Sandro Botticelli\nEmotion: Beauty & Grace\nInfo: Painted around 1484–1486, it shows Venus emerging from the sea as a fully grown woman.", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/26/Sandro_Botticelli_-_La_nascita_di_Venere_-_Google_Art_Project_-_edited.jpg/320px-Sandro_Botticelli_-_La_nascita_di_Venere_-_Google_Art_Project_-_edited.jpg"),
                new ArtworkInfo("The Last Supper", "Artist: Leonardo da Vinci\nEmotion: Betrayal & Devotion\nInfo: A late 15th century mural depicting the moment Jesus announces one of his apostles will betray him.", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4b/%C3%9Altima_Cena_-_Da_Vinci_5.jpg/320px-%C3%9Altima_Cena_-_Da_Vinci_5.jpg")
            };

            artData["Impressionism"] = new List<ArtworkInfo>
            {
                new ArtworkInfo("Impression, Sunrise", "Artist: Claude Monet\nEmotion: Tranquility & Hope\nInfo: Painted in 1872, this work gave the Impressionist movement its name. It captures a misty harbor at dawn.", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/59/Monet_-_Impression%2C_Sunrise.jpg/320px-Monet_-_Impression%2C_Sunrise.jpg"),
                new ArtworkInfo("A Sunday on La Grande Jatte", "Artist: Georges Seurat\nEmotion: Leisure & Stillness\nInfo: Completed in 1886 using pointillism, it depicts Parisians relaxing on an island in the Seine.", "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/A_Sunday_on_La_Grande_Jatte%2C_Georges_Seurat%2C_1884.jpg/320px-A_Sunday_on_La_Grande_Jatte%2C_Georges_Seurat%2C_1884.jpg"),
                new ArtworkInfo("Dance at Le Moulin de la Galette", "Artist: Pierre-Auguste Renoir\nEmotion: Joy & Vitality\nInfo: An 1876 painting of an outdoor dance scene in Montmartre, capturing the vibrancy of Parisian life.", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Moulin_de_la_Galette_%28Renoir%29.jpg/320px-Moulin_de_la_Galette_%28Renoir%29.jpg"),
                new ArtworkInfo("The Ballet Class", "Artist: Edgar Degas\nEmotion: Discipline & Grace\nInfo: Painted around 1874, it captures young ballet students in practice, showcasing Degas's mastery of movement.", "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f7/Edgar_Degas_-_The_Ballet_Class_-_Google_Art_Project.jpg/246px-Edgar_Degas_-_The_Ballet_Class_-_Google_Art_Project.jpg"),
                new ArtworkInfo("Water Lilies (Nymphéas)", "Artist: Claude Monet\nEmotion: Peace & Reflection\nInfo: A series of ~250 oil paintings depicting Monet's flower garden at Giverny, made in his later years.", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/aa/Claude_Monet_-_Water_Lilies_-_1906%2C_Ryerson.jpg/320px-Claude_Monet_-_Water_Lilies_-_1906%2C_Ryerson.jpg")
            };

            artData["Graffiti Art"] = new List<ArtworkInfo>
            {
                new ArtworkInfo("Balloon Girl", "Artist: Banksy\nEmotion: Innocence & Loss\nInfo: A stencil image of a girl reaching for a heart-shaped balloon — one of Banksy's most iconic street artworks.", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2b/Banksy_Girl_and_Heart_Balloon.jpg/213px-Banksy_Girl_and_Heart_Balloon.jpg"),
                new ArtworkInfo("Mear One Mural (Los Angeles)", "Artist: Mear One\nEmotion: Rebellion & Social Commentary\nInfo: A political mural by Los Angeles graffiti pioneer Mear One, known for challenging power structures.", "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Graffiti_in_Shoreditch%2C_London_-_Zabou_%288709558318%29.jpg/320px-Graffiti_in_Shoreditch%2C_London_-_Zabou_%288709558318%29.jpg"),
                new ArtworkInfo("Subway Art (New York, 1970s)", "Artist: Various NYC Writers\nEmotion: Defiance & Identity\nInfo: The birthplace of modern graffiti culture — NYC subway cars became rolling canvases for artists like Taki 183.", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/New_York_City_subway_graffiti.jpg/320px-New_York_City_subway_graffiti.jpg"),
                new ArtworkInfo("Love is in the Bin", "Artist: Banksy\nEmotion: Irony & Ephemerality\nInfo: In 2018, just after 'Girl with Balloon' sold at Sotheby's, it self-destructed through a hidden shredder.", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/Banksy_-_Girl_With_Balloon_%2847084246491%29.jpg/180px-Banksy_-_Girl_With_Balloon_%2847084246491%29.jpg"),
                new ArtworkInfo("Exit Through the Gift Shop", "Artist: Banksy\nEmotion: Satire & Chaos\nInfo: A 2010 documentary-film that blurs the line between art and commerce, featuring iconic graffiti works worldwide.", "https://upload.wikimedia.org/wikipedia/en/thumb/5/5a/Exit_Through_the_Gift_Shop.jpg/220px-Exit_Through_the_Gift_Shop.jpg")
            };

            artData["Surrealism"] = new List<ArtworkInfo>
            {
                new ArtworkInfo("The Persistence of Memory", "Artist: Salvador Dalí\nEmotion: Dreamlike Unease\nInfo: Painted in 1931, it features melting clocks in a barren landscape — a meditation on the fluidity of time.", "https://upload.wikimedia.org/wikipedia/en/d/dd/The_Persistence_of_Memory.jpg"),
                new ArtworkInfo("The Son of Man", "Artist: René Magritte\nEmotion: Mystery & Identity\nInfo: A 1964 self-portrait where an apple obscures the face, questioning identity and perception.", "https://upload.wikimedia.org/wikipedia/en/thumb/7/7d/MagritteSonOfMan.jpg/220px-MagritteSonOfMan.jpg"),
                new ArtworkInfo("The Two Fridas", "Artist: Frida Kahlo\nEmotion: Pain & Duality\nInfo: Painted in 1939, it depicts two versions of the artist connected by a shared vein — exploring identity and heartbreak.", "https://upload.wikimedia.org/wikipedia/en/thumb/2/2e/The_Two_Fridas.jpg/240px-The_Two_Fridas.jpg"),
                new ArtworkInfo("Dream Caused by a Bee", "Artist: Salvador Dalí\nEmotion: Bizarre & Subconscious\nInfo: A 1944 work depicting a woman asleep as a chain of surreal imagery (tiger, rifle, bee) erupts from her dream.", "https://upload.wikimedia.org/wikipedia/en/thumb/d/d8/DreamCausedByTheFlight.jpg/240px-DreamCausedByTheFlight.jpg"),
                new ArtworkInfo("The Treachery of Images", "Artist: René Magritte\nEmotion: Philosophical Doubt\nInfo: A 1929 painting of a pipe with the caption 'Ceci n'est pas une pipe' — this is not a pipe.", "https://upload.wikimedia.org/wikipedia/en/thumb/b/b9/MagrittePipe.jpg/320px-MagrittePipe.jpg")
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
