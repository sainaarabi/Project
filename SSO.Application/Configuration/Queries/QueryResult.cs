using static SSO.Application.Enums;

namespace SSO.Application.Configuration.Queries
{
    public class QueryResult
    {

        public QueryResult()
        {

        }
        public QueryResult(QueryResultStatus status)
        {
            Status = status;
        }
        public QueryResult(QueryResultStatus status, object data)
        {
            Status = status;
            Data = data;
            //this.data = Data;
            if (data is string)
                Message = data.ToString();
        }

        public QueryResult(object data)
        {
            if (data == null)
            {
 
                Status = QueryResultStatus.NotFound;
                Data = null;
                Message = "اطلاعاتی برای ارائه وجود ندارد";
            }
            else
            {
                Status = QueryResultStatus.Success;
                Data = data;
                Message = string.Empty;
            }
        }
        public QueryResult(bool data)
        {
            if (data == null)
            {

                Status = QueryResultStatus.NotFound;
                Data = null;
                Message = "اطلاعاتی برای ارائه وجود ندارد";
            }
            else
            {
                Status = QueryResultStatus.Success;
                Data = data;
                Message = string.Empty;
            }
        }



        public QueryResult(object data, long count)
        {
            if (count == 0)
            {
                Status = QueryResultStatus.Success;
                Data = new List<object>();
                Message = "اطلاعاتی برای ارائه وجود ندارد";
            }
            else
            {
                Status = QueryResultStatus.Success;
                Data = data;
                Message = string.Empty;
                Count = count;
            }
        }
 
        public QueryResult(QueryResultStatus status, bool isList = false)
        {
            switch (status)
            {
                case QueryResultStatus.Pending:
                    break;
                case QueryResultStatus.Success:
                    break;
                case QueryResultStatus.Fail:
                    break;
                case QueryResultStatus.NotFound:
                    if (isList)
                    {
                        Data = new List<object>();
                        Status = QueryResultStatus.Success;
                    }
                    else
                    {
                        Data = null;
                        Status = QueryResultStatus.NotFound;
                    }
                    Message = "اطلاعاتی برای ارائه وجود ندارد";
                    break;
                default:
                    break;
            }
        }
        public long Count { get; set; }
        public QueryResultStatus Status { get; set; }
        public bool IsSuccess => Status == QueryResultStatus.Success;
        public int StatusCode => (int)Status;
        public string Message { get; set; }
        public object Data { get; set; }
        public object data { get; set; }
        public object DataAndCount => new { Data = this.Data, Count = this.Count };
        public object ApiResult => new { Message = Message, Data = Data, StatusCode = Status, IsSuccess = Status == QueryResultStatus.Success };
    }
}
