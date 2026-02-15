using DesignPatternChallengePrototype.Interface;

namespace DesignPatternChallengePrototype.ConcretePrototype
{
    public class DocumentStyle : IPrototype
    {
        public string FontFamily { get; set; }
        public int FontSize { get; set; }
        public string HeaderColor { get; set; }
        public string LogoUrl { get; set; }
        public Margins PageMargins { get; set; }

        public IPrototype Clone()
        {
            return new DocumentStyle
            {
                FontFamily = this.FontFamily,
                FontSize = this.FontSize,
                HeaderColor = this.HeaderColor,
                LogoUrl = this.LogoUrl,
                PageMargins = this.PageMargins != null ? (Margins)this.PageMargins.Clone() : null
            };
        }
    }
}
