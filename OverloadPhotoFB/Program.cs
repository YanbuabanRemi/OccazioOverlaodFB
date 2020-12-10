using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;

namespace OverloadPhotoFB
{
    class Program
    {
        static void Main(string[] args)
        {
            // Charge les deux images
            using (Image<Rgba32> img1 = Image.Load<Rgba32>("C:/Users/remsk/Pictures/voiture.png"))
            using (Image<Rgba32> img2 = Image.Load<Rgba32>("C:/Users/remsk/Pictures/Bandeau_partage.png"))
            // Créer une nouvelle image aux dimensions de la largeur de l'image de voiture et de la hauteur de l'image de la voiture + 50(bandeaux)
            using (Image<Rgba32> outputImage = new Image<Rgba32>(img1.Width, img1.Height+50)) 
            {       
                // Resize le bandeau de la largeur de le photo de voiture + hauteur 50
                img2.Mutate(o => o.Resize(new Size(img1.Width, 50)));

                // Ajoute les deux images ensemble
                outputImage.Mutate(o => o
                    .DrawImage(img1, new Point(0, 0), 1f) // draw the first one top left
                    .DrawImage(img2, new Point(0, img1.Height), 1f) // draw the second next to it
                );

                outputImage.Save("ouput.png");
                Console.WriteLine("Image resizé");
            }
        }
    }
}
