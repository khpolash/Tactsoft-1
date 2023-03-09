namespace Tactsoft.Core
{
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }

    public enum MaritalStatus
    {
        Single = 1,
        Married = 2,
        Divorced = 3,
        Widow = 4
    }

    public enum Status
    {
        Initial = 1,
        Pending,
        NoAssigned,
        InProgress,
        DonePayment,
        Reverted,
        Failed,
        Completed,
        Downloaded
    }

    public enum MessageType : int
    {
        All = 1,
        Sms = 2,
        Email = 3
    }
    public enum Allowance
    {

        Snacks=1,
        Lunch=2
    }
    public enum Present
    {
        Yes=1,
        No=2,
    }
    public enum Month
    {
        January=1,
        February=2,
        March=3,
        April=4,
        May=5,
        June=6,
        July=7,
        August=8,
        September=9,
        October=10,
        November=11,
        December=12

    }
}
