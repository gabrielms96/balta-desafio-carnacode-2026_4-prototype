using DesignPatternChallengePrototype.Interface;

namespace DesignPatternChallengePrototype.ConcretePrototype
{
    public class Section : IPrototype
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public bool IsEditable { get; set; }
        public List<string> Placeholders { get; set; }

        public Section()
        {
            Placeholders = new List<string>();
        }

        public IPrototype Clone()
        {
            return new Section
            {
                Name = this.Name,
                Content = this.Content,
                IsEditable = this.IsEditable,
                Placeholders = new List<string>(this.Placeholders)
            };
        }

    }
}
