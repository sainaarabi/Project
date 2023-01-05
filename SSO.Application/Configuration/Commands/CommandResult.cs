using static SSO.Application.Enums;

namespace SSO.Application.Configuration.Commands
{
    public class CommandResult
    {
        public CommandResult(bool v)
        {

        }
        public CommandResult(CommandResultStatus status)
        {
            Status = status;
        }

        public CommandResult(CommandResultStatus status, string message)
        {
            Status = status;
            Message = message;
            Data = message;
        }
        public CommandResult(CommandResultStatus status, object data)
        {
            Status = status;
            Data = data;
            if (data is string)
                Message = data.ToString();
        }
        public CommandResult(CommandResultStatus status, object data, object data2)
        {
            Status = status;
            Data = data ;
            if (data is string)
                Message ="لاگین با موفقیت انجام شد";
        }

        public static CommandResult Ok => new CommandResult(CommandResultStatus.Success);
        public CommandResultStatus Status { get; set; }
        public int StatusCode => (int)Status;
        public string Message { get; set; }
        public object Data { get; set; }
        public bool IsSuccess => Status == CommandResultStatus.Success;
        public object ApiResult => new { Message = Message, Data = Data, Status = Status };
        public object ApiResults => new { Message = Message, Data = Data, Status = Status, IsSuccess = Status == CommandResultStatus.Success };
    }
}
