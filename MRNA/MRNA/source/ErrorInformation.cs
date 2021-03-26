// This class is responsible for containing information related with errors

using System;
using System.Collections.Generic;
using System.Text;

namespace MRNA.source
{
    using ErrorTypes = TypeOfErrors.ErrorTypes;

    public class ErrorInformation//<T1> where T1 : ErrorTypes // TODO: See how to use generic programming
    {
        protected int _errorPosition { set; get; }
        protected Dictionary<ErrorTypes, string> _errorMessage;
        protected Dictionary<ErrorTypes, bool> _errorType;

        protected ErrorInformation()
        {
            _errorPosition = 0;
            AllocateMemoryAndInitializeErrorMessages();
            AllocateMemoryAndInitializeErrorTypes();
        }

        private void AllocateMemoryAndInitializeErrorMessages()
        {
            _errorMessage = new Dictionary<ErrorTypes, string>();
            _errorMessage.Add(ErrorTypes.InvalidInput, "Error: All characters entered are invalid\n");
            _errorMessage.Add(ErrorTypes.InvalidStringLength, "Error: Invalid string length\n");
            _errorMessage.Add(ErrorTypes.NoStopCodon, "Error: No stop codon found\n");
            _errorMessage.Add(ErrorTypes.NoError, "mRNA sequence processed successfully\n");
        }

        private void AllocateMemoryAndInitializeErrorTypes()
        {
            _errorType = new Dictionary<ErrorTypes, bool>();
            _errorType.Add(ErrorTypes.InvalidInput, false);
            _errorType.Add(ErrorTypes.InvalidStringLength, false);
            _errorType.Add(ErrorTypes.NoStopCodon, false);
            _errorType.Add(ErrorTypes.NoError, true);
        }

        protected void SetErrorType(ErrorTypes errorType, bool errorValue)
        {
            if(_errorType.ContainsKey(errorType))
            {
                _errorType[errorType] = errorValue;
            }
            
        }

        protected bool GetErrorValue(ErrorTypes errorType)
        {
            bool errorValue = false;

            if (_errorType.ContainsKey(errorType))
            {
                errorValue = _errorType[errorType];
            }
            
            return errorValue;
        }
    }
}
