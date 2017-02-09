using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matterspace.Models
{
    public enum OperationResultMessageType
    {
        Success,
        Warning,
        Error
    }

    public class OperationResultMessage
    {
        public OperationResultMessageType Type { get; set; }
        public string Key { get; set; }
        public string Message { get; set; }
    }

    public class OperationResult
    {
        public OperationResult()
        {
            this.Messages = new List<OperationResultMessage>();
        }

        public bool Success
        {
            get
            {
                return !this.Messages.Any(x => x.Type == OperationResultMessageType.Error);
            }
        }

        public bool Warning
        {
            get
            {
                return this.Messages.Any(x => x.Type == OperationResultMessageType.Warning);
            }
        }

        public IEnumerable<OperationResultMessage> Messages { get; private set; }

        public void AddMessage(string key, string text, OperationResultMessageType type)
        {
            var currentMessages = this.Messages.ToList();
            currentMessages.Add(new OperationResultMessage()
            {
                Key = key,
                Type = type,
                Message = text
            });
            this.Messages = currentMessages;
        }

        public void Merge(OperationResult result)
        {
            var currentMessages = this.Messages.ToList();
            currentMessages.AddRange(result.Messages);
            this.Messages = currentMessages;
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Data { get; set; }

        public void Merge(OperationResult<T> result)
        {
            base.Merge(result);

            if(this.Data == null && result.Data != null)
                this.Data = result.Data;
        }
    }
}