using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using QuickType;

namespace flashJsontoxml
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string file = File.ReadAllText(args[0]);
            SpriteMap map = null;
            FlashFile v = null;
            if (file.StartsWith("{\"ATLAS"))
                map = JsonConvert.DeserializeObject<SpriteMap>(file);
            else
                v = JsonConvert.DeserializeObject<FlashFile>(file);
            Console.WriteLine("Converting gaming");
            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            xml += "\n<TextureAtlas imagePath=\"" + (v == null ? map.Meta.Image : v.Meta.Image) + "\">";
            xml += "\n<!-- Created with Kades Custom Converter -->";
            if (map == null)
                foreach (KeyValuePair<string, FrameValue> fv in v.Frames)
                {
                    xml +=
                        $"\n<SubTexture name=\"{fv.Key}\" x=\"{fv.Value.Frame.X}\" y=\"{fv.Value.Frame.Y}\" width=\"{fv.Value.Frame.W}\" height=\"{fv.Value.Frame.H}\" frameX=\"-{fv.Value.SpriteSourceSize.X}\" frameY=\"-{fv.Value.SpriteSourceSize.Y}\" frameWidth=\"{fv.Value.SpriteSourceSize.W}\" frameHeight=\"{fv.Value.SpriteSourceSize.H}\"/>";
                }
            else
                foreach (SpriteElement fv in map.Atlas.Sprites)
                {
                    xml +=
                        $"\n<SubTexture name=\"{fv.Sprite.Name}\" x=\"{fv.Sprite.X}\" y=\"{fv.Sprite.Y}\" width=\"{fv.Sprite.W}\" height=\"{fv.Sprite.H}\" frameX=\"-{fv.Sprite.X}\" frameY=\"-{fv.Sprite.Y}\" frameWidth=\"{fv.Sprite.W}\" frameHeight=\"{fv.Sprite.H}\"/>";
                }

            xml += "\n</TextureAtlas>";
            File.WriteAllText((map == null ? v.Meta.Image.Split('.')[0] : map.Meta.Image.Split(('.'))[0]) + ".xml", xml);
        }
    }
}