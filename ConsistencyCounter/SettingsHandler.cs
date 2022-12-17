using BeatSaberMarkupLanguage.Attributes;

namespace ConsistencyCounter
{
    public class SettingsHandler
    {
        [UIValue("SeparateSaber")]
        public bool SeparateSaber
        {
            get => Config.Instance.SeparateSaber;
            set
            {
                Config.Instance.SeparateSaber = value;
            }
        }

        [UIValue("DecimalPrecision")]
        public int DecimalPrecision
        {
            get => Config.Instance.DecimalPrecision;
            set
            {
                Config.Instance.DecimalPrecision = value;
            }
        }

        [UIValue("EnableLabel")]
        public bool EnableLabel
        {
            get => Config.Instance.EnableLabel;
            set
            {
                Config.Instance.EnableLabel = value;
            }
        }

        [UIValue("LabelFontSize")]
        public float LabelFontSize
        {
            get => Config.Instance.LabelFontSize;
            set
            {
                Config.Instance.LabelFontSize = value;
            }
        }

        [UIValue("FigureFontSize")]
        public float FigureFontSize
        {
            get => Config.Instance.FigureFontSize;
            set
            {
                Config.Instance.FigureFontSize = value;
            }
        }

        [UIValue("OffsetX")]
        public float OffsetX
        {
            get => Config.Instance.OffsetX;
            set
            {
                Config.Instance.OffsetX = value;
            }
        }

        [UIValue("OffsetY")]
        public float OffsetY
        {
            get => Config.Instance.OffsetY;
            set
            {
                Config.Instance.OffsetY = value;
            }
        }

        [UIValue("OffsetZ")]
        public float OffsetZ
        {
            get => Config.Instance.OffsetZ;
            set
            {
                Config.Instance.OffsetZ = value;
            }
        }

        [UIValue("IncludeSwingScore")]
        public bool IncludeSwingScore
        {
            get => Config.Instance.IncludeSwingScore;
            set
            {
                Config.Instance.IncludeSwingScore = value;
            }
        }
    }
}