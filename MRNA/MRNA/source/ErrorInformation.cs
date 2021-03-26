// This class is responsible for containing information related with errors

using System;
using System.Collections.Generic;
using System.Text;

namespace MRNA.source
{
    public class ErrorInformation
    {
        protected int _errorPosition { set; get; }
        protected string _errorMessage { set; get; }

        protected Dictionary<TypeOfErrors.ErrorTypes, bool> _errorType;

        protected ErrorInformation()
        {
            _errorPosition = 0;
            _errorMessage = " ";
            InitializeErrorTypes();
        }

        private void InitializeErrorTypes()
        {

        }

        /*protected void SetErrorType(TypeOfErrors.ErrorTypes errorType)
        {
            _errorType = errorType;
        }

        protected TypeOfErrors.ErrorTypes GetErrorType()
        {
            return _errorType;
        }*/
    }
}
