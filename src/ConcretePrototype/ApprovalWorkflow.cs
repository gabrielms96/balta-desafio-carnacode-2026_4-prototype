using DesignPatternChallengePrototype.Interface;

namespace DesignPatternChallengePrototype.ConcretePrototype
{
    public class ApprovalWorkflow : IPrototype
    {
        public List<string> Approvers { get; set; }
        public int RequiredApprovals { get; set; }
        public int TimeoutDays { get; set; }

        public ApprovalWorkflow()
        {
            Approvers = new List<string>();
        }

        public IPrototype Clone()
        {
            return new ApprovalWorkflow
            {
                Approvers = new List<string>(this.Approvers),
                RequiredApprovals = this.RequiredApprovals,
                TimeoutDays = this.TimeoutDays
            };
        }
    }
}
