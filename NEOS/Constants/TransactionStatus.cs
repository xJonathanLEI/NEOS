using System.Runtime.Serialization;

namespace NEOS.Constants
{
    public enum TransactionStatus
    {
        /* succeed, no error handler executed */
        [EnumMember(Value = "executed")]
        Executed = 0,
        /* objectively failed (not executed), error handler executed */
        [EnumMember(Value = "soft_fail")]
        SoftFail = 1,
        /* objectively failed and error handler objectively failed thus no state change */
        [EnumMember(Value = "hard_fail")]
        HardFail = 2,
        /* transaction delayed/deferred/scheduled for future execution */
        [EnumMember(Value = "delayed")]
        Delayed = 3,
        /* transaction expired and storage space refuned to user */
        [EnumMember(Value = "expired")]
        Expired = 4
    }
}