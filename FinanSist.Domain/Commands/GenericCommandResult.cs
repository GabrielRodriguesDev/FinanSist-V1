using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Interfaces.Commands;

namespace FinanSist.Domain.Commands
{
    public class GenericCommandResult : ICommand
    {
        #region  Property
        public bool Success { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
        #endregion

        #region  Constructor

        public GenericCommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public GenericCommandResult(bool success, string message, object? data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        #endregion
    }
}