namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FlashFile
    {
        [JsonProperty("frames")]
        public Dictionary<string, FrameValue> Frames { get; set; }

        [JsonProperty("meta")]
        public MetaAdobe Meta { get; set; }
    }

    public partial class FrameValue
    {
        [JsonProperty("frame")]
        public SpriteSourceSizeClass Frame { get; set; }

        [JsonProperty("rotated")]
        public bool Rotated { get; set; }

        [JsonProperty("trimmed")]
        public bool Trimmed { get; set; }

        [JsonProperty("spriteSourceSize")]
        public SpriteSourceSizeClass SpriteSourceSize { get; set; }

        [JsonProperty("sourceSize")]
        public SizeAdobe SourceSize { get; set; }
    }

    public partial class SpriteSourceSizeClass
    {
        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }

        [JsonProperty("w")]
        public long W { get; set; }

        [JsonProperty("h")]
        public long H { get; set; }
    }

    public partial class SizeAdobe
    {
        [JsonProperty("w")]
        public long W { get; set; }

        [JsonProperty("h")]
        public long H { get; set; }
    }

    public partial class MetaAdobe
    {
        [JsonProperty("app")]
        public string App { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("size")]
        public SizeAdobe Size { get; set; }

        [JsonProperty("scale")]
        public long Scale { get; set; }
    }
    
    public partial class SpriteMap
    {
        [JsonProperty("ATLAS")]
        public Atlas Atlas { get; set; }

        [JsonProperty("meta")]
        public MetaSpriteMap Meta { get; set; }
    }

    public partial class Atlas
    {
        [JsonProperty("SPRITES")]
        public SpriteElement[] Sprites { get; set; }
    }

    public partial class SpriteElement
    {
        [JsonProperty("SPRITE")]
        public SpriteSprite Sprite { get; set; }
    }

    public partial class SpriteSprite
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }

        [JsonProperty("w")]
        public long W { get; set; }

        [JsonProperty("h")]
        public long H { get; set; }

        [JsonProperty("rotated")]
        public bool Rotated { get; set; }
    }

    public partial class MetaSpriteMap
    {
        [JsonProperty("app")]
        public string App { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("size")]
        public SizeSpriteMap Size { get; set; }

        [JsonProperty("resolution")]
        public long Resolution { get; set; }
    }

    public partial class SizeSpriteMap
    {
        [JsonProperty("w")]
        public long W { get; set; }

        [JsonProperty("h")]
        public long H { get; set; }
    }
}
