﻿namespace XpShop.PingAn
{
    public class HttpProvider:IHttpProvider
    {
        public HttpResponseParameter Excute(HttpRequestParameter requestParameter)
        {
            return HttpUtil.Excute(requestParameter);
        }
    }
}
