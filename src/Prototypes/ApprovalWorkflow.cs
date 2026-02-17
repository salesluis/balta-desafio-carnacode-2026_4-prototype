using DesignPatternChallenge.Contracts;

namespace DesignPatternChallenge.Prototype;

public class ApprovalWorkflow : IPrototype<ApprovalWorkflow>
{
    public List<string> Approvers { get; set; }
    public int RequiredApprovals { get; set; }
    public int TimeoutDays { get; set; }

    public ApprovalWorkflow()
    {
        Approvers = new List<string>();
    }

    public ApprovalWorkflow ShallowCopy() => (ApprovalWorkflow)this.MemberwiseClone();

    public ApprovalWorkflow DeepCopy()=> new ApprovalWorkflow
    {
        Approvers = new List<string>(this.Approvers), 
        RequiredApprovals = this.RequiredApprovals,
        TimeoutDays = this.TimeoutDays
    };
}