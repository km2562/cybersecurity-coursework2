using System;
using System.Collections.Generic;
using System.Text;

namespace HARAnalyser
{

    public class HelperFunctions
    {

        public string EscapeCsvField(string field)
        {
            if (string.IsNullOrEmpty(field))
            {
                return "";
            }
            else if (field.Contains(",") || field.Contains("\""))
            {
                return $"\"{field.Replace("\"", "\"\"")}\"";
            }
            else
            {
                return field;
            }
        }

    }

    public class OutputFile
    {
        public string Timestamp { get; set; }
        public string RequestUrl { get; set; }
        public string Method { get; set; }
        public int ResponseStatus { get; set; }
        public string ResponseStatusText { get; set; }

    }

    public class PaymentHar
    {

        public Log log { get; set; }


        public class Log
        {
            public string version { get; set; }
            public Creator creator { get; set; }
            public Page[] pages { get; set; }
            public Entry[] entries { get; set; }
        }

        public class Creator
        {
            public string name { get; set; }
            public string version { get; set; }
        }

        public class Page
        {
            public DateTime startedDateTime { get; set; }
            public string id { get; set; }
            public string title { get; set; }
            public Pagetimings pageTimings { get; set; }
        }

        public class Pagetimings
        {
            public float? onContentLoad { get; set; }
            public float? onLoad { get; set; }
        }

        public class Entry
        {
            public string _connectionId { get; set; }
            public _Initiator _initiator { get; set; }
            public string _priority { get; set; }
            public string _resourceType { get; set; }
            public Cache cache { get; set; }
            public string connection { get; set; }
            public string pageref { get; set; }
            public Request request { get; set; }
            public Response response { get; set; }
            public string serverIPAddress { get; set; }
            public string startedDateTime { get; set; }
            public float time { get; set; }
            public Timings timings { get; set; }
        }

        public class _Initiator
        {
            public string type { get; set; }
            public string url { get; set; }
            public int lineNumber { get; set; }
            public Stack stack { get; set; }
            public string requestId { get; set; }
        }

        public class Stack
        {
            public Callframe8[] callFrames { get; set; }
            public Parent parent { get; set; }
            public Parentid1 parentId { get; set; }
        }

        public class Parent
        {
            public string description { get; set; }
            public Callframe7[] callFrames { get; set; }
            public Parent1 parent { get; set; }
            public Parentid parentId { get; set; }
        }

        public class Parent1
        {
            public string description { get; set; }
            public Callframe6[] callFrames { get; set; }
            public Parent2 parent { get; set; }
        }

        public class Parent2
        {
            public string description { get; set; }
            public Callframe5[] callFrames { get; set; }
            public Parent3 parent { get; set; }
        }

        public class Parent3
        {
            public string description { get; set; }
            public Callframe4[] callFrames { get; set; }
            public Parent4 parent { get; set; }
        }

        public class Parent4
        {
            public string description { get; set; }
            public Callframe3[] callFrames { get; set; }
            public Parent5 parent { get; set; }
        }

        public class Parent5
        {
            public string description { get; set; }
            public Callframe2[] callFrames { get; set; }
            public Parent6 parent { get; set; }
        }

        public class Parent6
        {
            public string description { get; set; }
            public Callframe1[] callFrames { get; set; }
            public Parent7 parent { get; set; }
        }

        public class Parent7
        {
            public string description { get; set; }
            public Callframe[] callFrames { get; set; }
        }

        public class Callframe
        {
            public string functionName { get; set; }
            public string scriptId { get; set; }
            public string url { get; set; }
            public int lineNumber { get; set; }
            public int columnNumber { get; set; }
        }

        public class Callframe1
        {
            public string functionName { get; set; }
            public string scriptId { get; set; }
            public string url { get; set; }
            public int lineNumber { get; set; }
            public int columnNumber { get; set; }
        }

        public class Callframe2
        {
            public string functionName { get; set; }
            public string scriptId { get; set; }
            public string url { get; set; }
            public int lineNumber { get; set; }
            public int columnNumber { get; set; }
        }

        public class Callframe3
        {
            public string functionName { get; set; }
            public string scriptId { get; set; }
            public string url { get; set; }
            public int lineNumber { get; set; }
            public int columnNumber { get; set; }
        }

        public class Callframe4
        {
            public string functionName { get; set; }
            public string scriptId { get; set; }
            public string url { get; set; }
            public int lineNumber { get; set; }
            public int columnNumber { get; set; }
        }

        public class Callframe5
        {
            public string functionName { get; set; }
            public string scriptId { get; set; }
            public string url { get; set; }
            public int lineNumber { get; set; }
            public int columnNumber { get; set; }
        }

        public class Callframe6
        {
            public string functionName { get; set; }
            public string scriptId { get; set; }
            public string url { get; set; }
            public int lineNumber { get; set; }
            public int columnNumber { get; set; }
        }

        public class Parentid
        {
            public string id { get; set; }
            public string debuggerId { get; set; }
        }

        public class Callframe7
        {
            public string functionName { get; set; }
            public string scriptId { get; set; }
            public string url { get; set; }
            public int lineNumber { get; set; }
            public int columnNumber { get; set; }
        }

        public class Parentid1
        {
            public string id { get; set; }
            public string debuggerId { get; set; }
        }

        public class Callframe8
        {
            public string functionName { get; set; }
            public string scriptId { get; set; }
            public string url { get; set; }
            public int lineNumber { get; set; }
            public int columnNumber { get; set; }
        }

        public class Cache
        {
        }

        public class Request
        {
            public string method { get; set; }
            public string url { get; set; }
            public string httpVersion { get; set; }
            public Header[] headers { get; set; }
            public Querystring[] queryString { get; set; }
            public object[] cookies { get; set; }
            public int headersSize { get; set; }
            public int bodySize { get; set; }
            public Postdata postData { get; set; }
        }

        public class Postdata
        {
            public string mimeType { get; set; }
            public string text { get; set; }
            public Param[] _params { get; set; }
        }

        public class Param
        {
            public string name { get; set; }
            public string value { get; set; }
        }

        public class Header
        {
            public string name { get; set; }
            public string value { get; set; }
        }

        public class Querystring
        {
            public string name { get; set; }
            public string value { get; set; }
        }

        public class Response
        {
            public int status { get; set; }
            public string statusText { get; set; }
            public string httpVersion { get; set; }
            public Header1[] headers { get; set; }
            public object[] cookies { get; set; }
            public Content content { get; set; }
            public string redirectURL { get; set; }
            public int headersSize { get; set; }
            public int bodySize { get; set; }
            public int _transferSize { get; set; }
            public string _error { get; set; }
            public bool _fetchedViaServiceWorker { get; set; }
        }

        public class Content
        {
            public int size { get; set; }
            public string mimeType { get; set; }
            public int compression { get; set; }
            public string text { get; set; }
            public string encoding { get; set; }
        }

        public class Header1
        {
            public string name { get; set; }
            public string value { get; set; }
        }

        public class Timings
        {
            public float blocked { get; set; }
            public float dns { get; set; }
            public float ssl { get; set; }
            public float connect { get; set; }
            public float send { get; set; }
            public float wait { get; set; }
            public float receive { get; set; }
            public float _blocked_queueing { get; set; }
            public int _workerStart { get; set; }
            public int _workerReady { get; set; }
            public int _workerFetchStart { get; set; }
            public int _workerRespondWithSettled { get; set; }
        }


    }
}
