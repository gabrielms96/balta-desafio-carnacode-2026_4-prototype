using DesignPatternChallengePrototype.Interface;

namespace DesignPatternChallengePrototype.ConcretePrototype
{
    public class DocumentTemplate : IPrototype
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public List<Section> Sections { get; set; }
        public DocumentStyle Style { get; set; }
        public List<string> RequiredFields { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public ApprovalWorkflow Workflow { get; set; }
        public List<string> Tags { get; set; }

        public DocumentTemplate()
        {
            Sections = new List<Section>();
            RequiredFields = new List<string>();
            Metadata = new Dictionary<string, string>();
            Tags = new List<string>();
        }

        public IPrototype Clone()
        {
            var clonedTemplate = new DocumentTemplate
            {
                Title = this.Title,
                Category = this.Category,

                Sections = this.Sections.Select(s => (Section)s.Clone()).ToList(),

                Style = this.Style != null ? (DocumentStyle)this.Style.Clone() : null,

                RequiredFields = new List<string>(this.RequiredFields),
                Tags = new List<string>(this.Tags),

                Metadata = new Dictionary<string, string>(this.Metadata),

                Workflow = this.Workflow != null ? (ApprovalWorkflow)this.Workflow.Clone() : null
            };

            return clonedTemplate;
        }
    }
}
