
using IPA.Config.Stores;
using IPA.Config.Stores.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace ConsistencyCounter
{
    internal class Config
    {
        public static Config Instance { get; set; }
        public virtual bool SeparateSaber { get; set; } = true;
        public virtual int DecimalPrecision { get; set; } = 2;
        public virtual bool EnableLabel { get; set; } = true;
        public virtual float LabelFontSize { get; set; } = 3f;
        public virtual float FigureFontSize { get; set; } = 4f;
        public virtual float OffsetX { get; set; } = 0f;
        public virtual float OffsetY { get; set; } = 0f;
        public virtual float OffsetZ { get; set; } = 0f;

    }
}