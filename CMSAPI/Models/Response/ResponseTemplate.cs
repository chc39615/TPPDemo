namespace CMSAPI.Models.Response
{
    public class ResponseTemplate<T>
    {

        public ResponseTemplate(string resultCode = "0000", string resultMessage = "success")
        {
            ResultCode = resultCode;
            ResultMessage = resultMessage;
        }

        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }

        /// <summary>
        /// 紀錄存在 Redis 的 UserToken
        /// </summary>
        public string UserToken { get; set; }

        public T Data { get; set; }

    }

    public class ResponseTemplate
    {
        public ResponseTemplate(string resultCode = "0000", string resultMessage = "success")
        {
            ResultCode = resultCode;
            ResultMessage = resultMessage;
        }

        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }
}
